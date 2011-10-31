using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eduGRID_ManagerApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm_connection FC = new frm_connection();
            frm_Bg FBG = new frm_Bg();
            FBG.Fconn = FC;
            Application.Run(FBG);
        }
    }
}