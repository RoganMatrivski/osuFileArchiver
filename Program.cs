using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommandLine;

namespace osuFileArchiver
{
    class CLI_Options
    {
        [Option("directoryLocation", Required = false, HelpText = "Directory to Archive")]
        public string directoryLocation { get; set; }

        [Option("saveLocation", Required = false, HelpText = "Archive Save Location")]
        public string saveLocation { get; set; }

        [Option("compressionLevel", Required = false, HelpText = "Compression Level. Default Value is  4 if Not Provided")]
        public string compressionLevel { get; set; }

        [Option("bufferSize", Required = false, HelpText = "Buffer Size to Use When Archiving. Default Value is 4096. USE IT IF YOU KNOW WHAT ARE YOU DOING.")]
        public string bufferSize { get; set; }

        [Option("skipMenu", Required = false, HelpText = "Skips to the Archive Process Instead of Showing The Menu First.")]
        public bool skipMenu { get; set; }
    }

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string appPath = AppDomain.CurrentDomain.BaseDirectory;
        [STAThread]
        static void Main(string[] arguments)
        {
            var result = Parser.Default.ParseArguments<CLI_Options>(arguments);
            var errors = new List<CommandLine.Error>();
            bool skipMenu = false;
            result
                .WithParsed(x =>
                {
                    if (!checkNull(x.directoryLocation))
                        variableStore.dirLocation = x.directoryLocation;
                    else
                        variableStore.dirLocation = appPath;
                    if (!checkNull(x.saveLocation))
                        variableStore.saveLocation = x.saveLocation;
                    else
                        variableStore.saveLocation = appPath + @"Test.osz";
                    if (!checkNull(x.compressionLevel))
                        variableStore.compressionLevel = Convert.ToInt32(x.compressionLevel);
                    if (!checkNull(x.bufferSize))
                        variableStore.bufferSize = Convert.ToInt32(x.bufferSize);
                    if (!checkNull(x.skipMenu))
                        skipMenu = x.skipMenu;
                }
                )
                .WithNotParsed((error) =>
                {
                MessageBox.Show(String.Format("Error While Parsing Command-Line Arguments. \n{0} \nWill start with the default settings. \nIf you think this should not happen, please contact the developer.", errorToString(error.ToList())), "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    variableStore.dirLocation = appPath;
                    variableStore.saveLocation = appPath + @"Test.osz";
                });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!skipMenu)
                Application.Run(new mainForm());
            else
                Application.Run(new workForm());
        }

        static string errorToString(List<CommandLine.Error> errors)
        {
            string errorString = "";
            if (errors.Any())
            {
                errors.ForEach (x =>
                {
                    errorString += x.ToString() + Environment.NewLine;
                }) ;
            }
            return errorString;
        }

        static bool dirCheck(string filepath)
        {
            if (filepath.Length > 0 && Directory.Exists(filepath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool checkNull(object input)
        {
            if (input == null)
                return true;
            else
                return false;
        }
    }
}
