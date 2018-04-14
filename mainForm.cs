using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuFileArchiver
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        public string fileType = "";
        public static string appPath = AppDomain.CurrentDomain.BaseDirectory;

        private void Form1_Load(object sender, EventArgs e)
        {
            fileLocation.Text = variableStore.dirLocation;
            saveLocation.Text = variableStore.saveLocation;

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            folderBrowserDialog1.SelectedPath = appPath;

            saveFileDialog1.Filter = "osu! Beatmap Format (*osz)|*.osz|osu! Skin Format (*.osk)|*.osk";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = appPath;

            compressionLevel.Value = variableStore.compressionLevel;
        }

        private void fileLocation_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            fileLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void saveLocation_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveLocation.Text = saveFileDialog1.FileName;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            variableStore.dirLocation = fileLocation.Text;
            variableStore.saveLocation = saveLocation.Text;
            variableStore.compressionLevel = Convert.ToInt32(compressionLevel.Value);

            workForm workForm = new workForm();
            this.Hide();
            workForm.ShowDialog();
            this.Show();
            cancelButton.Text = "Exit";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            saveLocation.Text = Path.ChangeExtension(saveLocation.Text, ".osz");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            saveLocation.Text = Path.ChangeExtension(saveLocation.Text, ".osk");
        }

        private void fileLocation_DragEnter(object sender, DragEventArgs e)
        {
            DragDropEffects effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path))
                    effects = DragDropEffects.Copy;
            }

            e.Effect = effects;
        }

        private void fileLocation_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            fileLocation.Text = files[0];
        }

        private void fileLocation_TextChanged(object sender, EventArgs e)
        {
            saveLocation.Text = fileLocation.Text + ".osz";
        }
    }
}
