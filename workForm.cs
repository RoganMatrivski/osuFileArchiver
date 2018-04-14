using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;


using ICSharpCode.SharpZipLib.Zip;

namespace osuFileArchiver
{
    public partial class workForm : Form
    {
        public workForm()
        {
            InitializeComponent();
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Stopwatch timer = new Stopwatch();
         
        private void workForm_Load(object sender, EventArgs e)
        {
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.WorkerSupportsCancellation = true;
            log.InfoFormat("{0} : Running File Archiver", DateTime.Now.ToString("h:mm:ss tt"));
            
            timer.Start();
            bgWorker.RunWorkerAsync();
        }

        ManualResetEvent suspendThread = new ManualResetEvent(true);

        private void addLog(string logToAdd)
        {
            logView.TopIndex = logView.Items.Count - 1;
            logView.Items.Add(logToAdd);
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                log.FatalFormat("{0} : Archiving Failed : {1}", DateTime.Now.ToString("h:mm:ss tt"), e.Error.Message);
                MessageBox.Show(string.Format("Archiving Failed" + Environment.NewLine + e.Error.Message), "Zip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (e.Cancelled)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                log.WarnFormat("{0} : Archiving Cancelled", DateTime.Now.ToString("h:mm:ss tt"));
                MessageBox.Show("Archiving Cancelled", "Zip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                timer.Stop();

                log.InfoFormat("{0} : Archiving Success", DateTime.Now.ToString("h:mm:ss tt"));
                //MessageBox.Show("Archiving Success", "Zip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(String.Format("Archiving Success. Time Elapsed = {0}", timer.ElapsedMilliseconds), "Zip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bgWorker.ReportProgress(0, "Starting...");

                //string[] fileNames = System.IO.Directory.GetFiles(@"D:\Gim\osu!\Skins\", "*.*", SearchOption.AllDirectories);
                List<string> fileList = new List<string>();
                ulong totalBytes = 0;

                foreach (string files in GetFiles(variableStore.dirLocation))
                {
                    log.DebugFormat("{0} : Adding {1} to GetFiles Variable", DateTime.Now.ToString("h:mm:ss tt"), files);
                    fileList.Add(files);
                    totalBytes += Convert.ToUInt64(new FileInfo(files).Length);
                }

                Debug.WriteLine("Total Files : {0}", fileList.Count);

                using (ZipOutputStream zip = new ZipOutputStream(File.Create(variableStore.saveLocation)))
                {
                    zip.SetLevel(variableStore.compressionLevel);

                    byte[] buffer = new byte[4096];

                    ulong i = 0;

                    int progress;

                    log.InfoFormat("{0} : Start Archiving with Compression Level of {1}, and Buffer Size {2}.", DateTime.Now.ToString("h:mm:ss tt"), variableStore.compressionLevel, buffer.Length);

                    //Scan Files Recursively. Soruce : https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c/17667185
                    foreach (string file in fileList)
                    {
                        suspendThread.WaitOne(Timeout.Infinite);

                        if (bgWorker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            return;
                        }

                        var entry = new ZipEntry(System.IO.Path.GetFileName(file));

                        entry.DateTime = DateTime.Now;

                        log.InfoFormat("{0} : Adding {1} into Archive", DateTime.Now.ToString("h:mm:ss tt"), file);

                        i += Convert.ToUInt64(new FileInfo(file).Length);

                        Debug.WriteLine(totalBytes);

                        Debug.WriteLine(i);

                        progress = Convert.ToInt32((i) * 100 / totalBytes);

                        bgWorker.ReportProgress(progress, string.Format("Adding {0}", file));

                        zip.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                suspendThread.WaitOne(Timeout.Infinite);
                                if (bgWorker.CancellationPending == true)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                zip.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }

        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState.ToString() != "Starting...")
                progressBar.Style = ProgressBarStyle.Continuous;

            log.DebugFormat("{0} : Current Percentage : {1} | State : {2}", DateTime.Now.ToString("h:mm:ss tt"), e.ProgressPercentage.ToString(), e.UserState);
            progressBar.Value = e.ProgressPercentage;
            logLabel.Text = string.Format("{0}", e.UserState);
            addLog(string.Format("{0}", e.UserState));

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            suspendThread.Reset();

            log.DebugFormat("{0} : Cancellation Dialog Initiated", DateTime.Now.ToString("h:mm:ss tt"));
            DialogResult exitConfirmation = MessageBox.Show("Are you sure you want to abort the archiving proccess?", "Abort Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);

            if (exitConfirmation == DialogResult.Yes)
            {
                bgWorker.CancelAsync();
                suspendThread.Set();
            }
            else
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                suspendThread.Set();
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pauseButton.Text == "Pause")
            {
                pauseButton.Text = "Resume";
                suspendThread.Reset();

                Debug.WriteLine("Pausing BackgroundWorker");
            }
            else
            {
                pauseButton.Text = "Pause";
                suspendThread.Set();

                Debug.WriteLine("Resuming BackgroundWorker");
            }
        }
    }
}
