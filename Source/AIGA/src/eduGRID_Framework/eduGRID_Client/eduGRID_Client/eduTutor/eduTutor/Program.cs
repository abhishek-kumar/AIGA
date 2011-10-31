using System;
using System.Windows.Forms;
using System.Globalization;

namespace eduTutor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Get the 2 character command line argument
                string arg = args[0].ToLower(CultureInfo.InvariantCulture).Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/c":
                        // Show the options dialog
                        ShowOptions();
                        break;
                    case "/p":
                        // Don't do anything for preview
                        break;
                    case "/s":
                        // Show screensaver form
                        ShowScreenSaver();
                        break;
                    default:
                        MessageBox.Show("Invalid command line argument :" + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If no arguments were passed in, show the screensaver
                ShowScreenSaver();
            }
        }


        static void ShowOptions()
        {
            OptionsForm optionsForm = new OptionsForm();
            Application.Run(optionsForm);
        }

        static void ShowScreenSaver()
        {
            ScreenSaverForm screenSaver = new ScreenSaverForm();
            Application.Run(screenSaver);
        }
    }
}