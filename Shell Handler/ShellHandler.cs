using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Win32;

namespace Shell_Handler
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    public class ShellHandler : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        public static string appPath = AppDomain.CurrentDomain.BaseDirectory;

        [STAThread]
        protected override ContextMenuStrip CreateMenu()
        {


            var menu = new ContextMenuStrip();

            var archiveDirectory = new ToolStripMenuItem
            {
                Text = "Pack this Directory",
                Image = Properties.Resources.osuIconFile
            };

            var fileList = SelectedItemPaths.ToList();

            var archiveDirectoryToBeatmapFile = new ToolStripMenuItem
            {
                Text = "Pack this Directory to " + new DirectoryInfo(fileList[0]).Name + ".osz",
                Image = Properties.Resources.osuIconFile
            };

            var archiveDirectoryToSkinFile = new ToolStripMenuItem
            {
                Text = "Pack this Directory to " + new DirectoryInfo(fileList[0]).Name + ".osk",
                Image = Properties.Resources.osuIconFile
            };

            archiveDirectory.Click += (sender, args) =>
            {
                debugMessage();

                runAppWithArgs(getAppPath() + "osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\"", fileList[0], fileList[0] + ".osz"));
            };

            archiveDirectoryToBeatmapFile.Click += (sender, args) =>
            {
                debugMessage();

                runAppWithArgs(getAppPath() + "osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\" --skipMenu", fileList[0], fileList[0] + ".osz"));
            };

            archiveDirectoryToSkinFile.Click += (sender, args) =>
            {
                debugMessage();

                runAppWithArgs(getAppPath() + "osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\" --skipMenu", fileList[0], fileList[0] + ".osk"));
            };

            menu.Items.Add(archiveDirectory);
            menu.Items.Add(archiveDirectoryToBeatmapFile);
            menu.Items.Add(archiveDirectoryToSkinFile);

            return menu;
        }

        private static void runAppWithArgs(string app, string args)
        {
            ProcessStartInfo processStart = new ProcessStartInfo(app, args);
            Process.Start(processStart);
        }

        private static string getAppPath()
        {
            string path = "";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\WOW6432Node\\osu! File Archiver\\"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("Path");
                        if (o != null)
                        {
                            path = o.ToString();
                        }
                    }
                }

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\osu! File Archiver\\"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("Path");
                        if (o != null)
                        {
                            path = o.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }

            return path;
        }

        private static void debugMessage()
        {
            MessageBox.Show("asdasdasdasdasd");
            MessageBox.Show(appPath);
            MessageBox.Show(getAppPath());

        }

        public static void testFunctions()
        {
            debugMessage();
        }
    }
}