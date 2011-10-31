using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;


namespace MSR.LST.ConferenceXP.ReflectorService
{
    public class ReflectorService : System.ServiceProcess.ServiceBase
    {
        private System.ComponentModel.Container components = null;
        private AdminUI adminForm;
        private ReflectorMgr refMgr = null;

        public ReflectorService()
        {
            InitializeComponent();
            refMgr = new ReflectorMgr();
        }

        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;

            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new ReflectorService() };

            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }

        private void InitializeComponent()
        {
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        protected override void OnStart(string[] args)
        {
            refMgr.StartReflector();
            Thread form = new Thread(new ThreadStart(FormProc));
            form.IsBackground = true;
            form.Start();
        }
 
        protected override void OnStop()
        {
            refMgr.StopReflector();
            adminForm.Dispose();
            Application.Exit();
        }

        private void FormProc()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            adminForm = new AdminUI();
            Application.Run();
        }
    }
}
