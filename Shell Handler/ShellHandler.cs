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

        [STAThread]
        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();

            var archiveDirectory = new ToolStripMenuItem
            {
                Text = "Pack this Directory"
            };

            var fileList = SelectedItemPaths.ToList();

            var archiveDirectoryToBeatmapFile = new ToolStripMenuItem
            {
                Text = "Pack this Directory to " + new DirectoryInfo(fileList[0]).Name + ".osz"
            };

            var archiveDirectoryToSkinFile = new ToolStripMenuItem
            {
                Text = "Pack this Directory to " + new DirectoryInfo(fileList[0]).Name + ".osk"
            };

            archiveDirectory.Click += (sender, args) =>
            {
                runAppWithArgs("osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\"", fileList[0], fileList[0] + ".osz"));
            };

            archiveDirectoryToBeatmapFile.Click += (sender, args) =>
            {
                runAppWithArgs("osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\" --skipMenu", fileList[0], fileList[0] + ".osz"));
            };

            archiveDirectoryToSkinFile.Click += (sender, args) =>
            {
                runAppWithArgs("osuFileArchiver.exe", String.Format("--directoryLocation \"{0}\" --saveLocation \"{1}\" --skipMenu", fileList[0], fileList[0] + ".osk"));
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
    }
}