using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eduGRID_Client
{
    static class Program
    {
        public static eduGRID_botwrapper eduGRIDBOT = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}