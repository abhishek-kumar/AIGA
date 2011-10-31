using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using MSR.LST;


namespace MSR.LST.ConferenceXP.ReflectorService
{
    /// <summary>
    /// Summary description for AdminUI.
    /// </summary>
    public class FormAdmin : System.Windows.Forms.Form
    {
        #region WinForm Designer Privates
        
        private System.ComponentModel.Container components = null;

        #endregion

        #region Privates
        /// <summary>
        /// The service to which we connect to start, stop, and change settings.
        /// </summary>
        private MSR.LST.Services.BasicServiceButtons basicButtons;
        private System.Windows.Forms.Label labelHelp;
        private MSR.LST.Services.ServiceControlButtons serviceControl;

        private const string helpUrlReflector = "http://research.microsoft.com/conferencexp/redirects/services/reflectorservicehelp.htm";
        #endregion
        
        #region Main, Ctor, Dispose
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.Run(new FormAdmin());
        }
        
        public FormAdmin()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.basicButtons.HelpUrl = helpUrlReflector;
            this.basicButtons.AboutClicked += new EventHandler(this.aboutBtn_Click);
            this.serviceControl.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAdmin));
            this.basicButtons = new MSR.LST.Services.BasicServiceButtons();
            this.labelHelp = new System.Windows.Forms.Label();
            this.serviceControl = new MSR.LST.Services.ServiceControlButtons();
            this.SuspendLayout();
            // 
            // basicButtons
            // 
            this.basicButtons.HelpUrl = null;
            this.basicButtons.Location = new System.Drawing.Point(16, 144);
            this.basicButtons.Name = "basicButtons";
            this.basicButtons.Size = new System.Drawing.Size(328, 24);
            this.basicButtons.TabIndex = 7;
            // 
            // labelHelp
            // 
            this.labelHelp.Location = new System.Drawing.Point(12, 92);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(340, 40);
            this.labelHelp.TabIndex = 10;
            this.labelHelp.Text = "To view Reflector participants, make sure the service is started, and then double" +
                "-click the ConferenceXP Reflector Service Monitor icon in the notification area." +
                "";
            // 
            // serviceControl
            // 
            this.serviceControl.Location = new System.Drawing.Point(16, 16);
            this.serviceControl.Name = "serviceControl";
            this.serviceControl.ServiceName = null;
            this.serviceControl.Size = new System.Drawing.Size(304, 64);
            this.serviceControl.TabIndex = 11;
            // 
            // FormAdmin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(360, 182);
            this.Controls.Add(this.serviceControl);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.basicButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(368, 216);
            this.MinimumSize = new System.Drawing.Size(368, 216);
            this.Name = "FormAdmin";
            this.Text = "ConferenceXP Reflector Service Manager";
            this.Resize += new System.EventHandler(this.AdminUI_Resize);
            this.Load += new System.EventHandler(this.AdminUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminUI_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        #region Form Events - Paint & Load
        private void AdminUI_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using(Graphics g = e.Graphics)
            {
                // Draw line across bottom of UI
                int helpBottom = labelHelp.Top + labelHelp.Height;
                int lineY = basicButtons.Top - 12;
                int lineLeft = basicButtons.Left;
                int lineRight = basicButtons.Left + basicButtons.Width;
                DrawLine(g, lineY, lineLeft, lineRight);
            }
        }

        private void DrawLine(Graphics g, int lineY, int lineLeft, int lineRight)
        {
            g.DrawLine(SystemPens.ControlDark, lineLeft, lineY, lineRight, lineY);
            lineY += 1;
            g.DrawLine(SystemPens.ControlLightLight, lineLeft, lineY, lineRight, lineY);
        }

        private void AdminUI_Resize(object sender, System.EventArgs e)
        {
            // Do a refresh to re-paint the lines on the UI
            this.Refresh();
        }

        private void AdminUI_Load(object sender, System.EventArgs e)
        {
            // Connect to service
            bool serviceFound = this.serviceControl.ConnectToService();
            
            // Report errors about both connections in one dialog
            if( !serviceFound )
            {
                MessageBox.Show(this, 
                    "The Admin Tool could not connect to the service .\n"+
                    "Please check to make sure that the ServiceName specified in the application \n"+
                    "configuration file are correct.", "Error Connecting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        
        #endregion

        #region UI Actions - About
        private void aboutBtn_Click(object sender, System.EventArgs e)
        {
            Assembly reflector = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(reflector.Location);
            string version = reflector.GetName().Name + " : " + fvi.FileVersion;

            MessageBox.Show( this, 
                "ConferenceXP Reflector Service\n" +
                "Microsoft Research\n\n" +
                version + "\n\n" +
                "For more information, see http://research.microsoft.com/conferencexp/",
                "About ConferenceXP Reflector Service" );
        }
        #endregion
    }
}
