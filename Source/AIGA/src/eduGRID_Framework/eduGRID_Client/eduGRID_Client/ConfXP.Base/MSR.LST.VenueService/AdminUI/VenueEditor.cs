using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MSR.LST.ConferenceXP.VenueService
{
    /// <summary>
    /// Summary description for VenueEditor.
    /// </summary>
    internal class VenueEditor : System.Windows.Forms.Form
    {
        #region Private Winform Vars
        private System.Windows.Forms.Label ownerLbl;
        private System.Windows.Forms.TextBox ownerInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.LinkLabel multicastLink;
        private System.Windows.Forms.Button advancedBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private MSR.LST.ConferenceXP.VenueService.IconInput iconInput;
        private System.ComponentModel.Container components = null;
        #endregion

        #region Private Variables
        // TODO: get a URL to put here (Multicast IP Help)
        const string helpMulticastUrl = "http://research.microsoft.com/conferencexp/redirects/services/multicasthelp.htm";

        public static readonly Image defaultVenueIcon;
        private readonly Venue original;

        private SecurityPatterns newAccessList;
        #endregion

        #region Ctor, Dispose
        static VenueEditor()
        {
            // Load the default venue icon
            Stream resource = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MSR.LST.ConferenceXP.VenueService.GenericVenueIcon.png");
            defaultVenueIcon = Image.FromStream(resource);
        }

        public VenueEditor(Venue venueToEdit)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            iconInput.DefaultIcon = defaultVenueIcon;

            // Show the venue information in the UI
            this.nameInput.Text = venueToEdit.Name;
            this.ownerInput.Text = venueToEdit.Identifier;
            this.ipInput.Text = venueToEdit.IPAddress;
            this.portInput.Text = venueToEdit.Port.ToString();
            this.iconInput.IconAsBytes = venueToEdit.Icon;

            this.newAccessList = venueToEdit.AccessList;
            this.original = venueToEdit;
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
            this.ownerLbl = new System.Windows.Forms.Label();
            this.ownerInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.ipLbl = new System.Windows.Forms.Label();
            this.portInput = new System.Windows.Forms.TextBox();
            this.portLbl = new System.Windows.Forms.Label();
            this.multicastLink = new System.Windows.Forms.LinkLabel();
            this.iconInput = new MSR.LST.ConferenceXP.VenueService.IconInput();
            this.advancedBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ownerLbl
            // 
            this.ownerLbl.Location = new System.Drawing.Point(16, 12);
            this.ownerLbl.Name = "ownerLbl";
            this.ownerLbl.Size = new System.Drawing.Size(100, 16);
            this.ownerLbl.TabIndex = 0;
            this.ownerLbl.Text = "Owner:";
            this.ownerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ownerInput
            // 
            this.ownerInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerInput.Location = new System.Drawing.Point(16, 28);
            this.ownerInput.Name = "ownerInput";
            this.ownerInput.Size = new System.Drawing.Size(240, 20);
            this.ownerInput.TabIndex = 0;
            this.ownerInput.Text = "jay@tailspintoys.com";
            // 
            // nameInput
            // 
            this.nameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.nameInput.Location = new System.Drawing.Point(16, 72);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(240, 20);
            this.nameInput.TabIndex = 1;
            this.nameInput.Text = ".NET & Grids";
            // 
            // nameLbl
            // 
            this.nameLbl.Location = new System.Drawing.Point(16, 56);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(100, 16);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ipInput
            // 
            this.ipInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.ipInput.Location = new System.Drawing.Point(16, 116);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(176, 20);
            this.ipInput.TabIndex = 2;
            this.ipInput.Text = "192.168.41.234";
            // 
            // ipLbl
            // 
            this.ipLbl.Location = new System.Drawing.Point(16, 100);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(100, 16);
            this.ipLbl.TabIndex = 0;
            this.ipLbl.Text = "IP Address:";
            this.ipLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portInput
            // 
            this.portInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portInput.Location = new System.Drawing.Point(208, 116);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(48, 20);
            this.portInput.TabIndex = 3;
            this.portInput.Text = "5004";
            // 
            // portLbl
            // 
            this.portLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portLbl.Location = new System.Drawing.Point(208, 100);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(40, 16);
            this.portLbl.TabIndex = 0;
            this.portLbl.Text = "Port:";
            this.portLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // multicastLink
            // 
            this.multicastLink.Location = new System.Drawing.Point(16, 140);
            this.multicastLink.Name = "multicastLink";
            this.multicastLink.Size = new System.Drawing.Size(224, 16);
            this.multicastLink.TabIndex = 2;
            this.multicastLink.TabStop = true;
            this.multicastLink.Text = "How do I choose a multicast IP address?";
            this.multicastLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.multicastLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.multicastLink_LinkClicked);
            // 
            // iconInput
            // 
            this.iconInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.iconInput.DefaultIcon = null;
            this.iconInput.Icon = null;
            this.iconInput.IconAsBytes = null;
            this.iconInput.Location = new System.Drawing.Point(16, 164);
            this.iconInput.Name = "iconInput";
            this.iconInput.Size = new System.Drawing.Size(240, 104);
            this.iconInput.TabIndex = 5;
            // 
            // advancedBtn
            // 
            this.advancedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.advancedBtn.Location = new System.Drawing.Point(184, 288);
            this.advancedBtn.Name = "advancedBtn";
            this.advancedBtn.TabIndex = 4;
            this.advancedBtn.Text = "Advanced...";
            this.advancedBtn.Click += new System.EventHandler(this.advancedBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Location = new System.Drawing.Point(184, 328);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okBtn.Location = new System.Drawing.Point(96, 328);
            this.okBtn.Name = "okBtn";
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // VenueEditor
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(274, 364);
            this.ControlBox = false;
            this.Controls.Add(this.advancedBtn);
            this.Controls.Add(this.iconInput);
            this.Controls.Add(this.multicastLink);
            this.Controls.Add(this.ownerInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.ownerLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.ipLbl);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VenueEditor";
            this.ShowInTaskbar = false;
            this.Text = "VenueEditor";
            this.ResumeLayout(false);

        }
        #endregion
    
        #region Public Properties & Methods
        /// <summary>
        /// Gets the original venue this editor started with (unedited).
        /// </summary>
        public Venue OriginalVenue
        {
            get
            {
                return original;
            }
        }

        /// <summary>
        /// Compiles all of the data on the screen and returns it as a venue.
        /// </summary>
        public Venue GetVenue()
        {
            return new Venue(this.ownerInput.Text.Trim(), this.ipInput.Text.Trim(), 
                Int32.Parse(this.portInput.Text.Trim()), this.nameInput.Text.Trim(), 
                this.iconInput.IconAsBytes, this.newAccessList);
        }
        #endregion

        #region Input Validation
        private void okBtn_Click(object sender, System.EventArgs e)
        {
            bool ownerValid = ValidateOwnerInput();
            bool ipValid = ValidateIPInput();
            bool portValid = ValidatePortInput();

            if (portValid && ipValid && ownerValid)
            {
                // The input is valid.  Just return.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Just show one message for one bad input & send the user back to fix the one input
                string error = null;
                if (!ownerValid)
                    error = "\"Owner\" is not a valid e-mail address.";
                else if (!ipValid)
                    error = "\"IP Address\" is not a valid IP address. If this is an IPv6 address, the IPv6 protocol should be installed.";
                else if (!portValid)
                    error = "\"Port\" is not a valid IP port.";

                MessageBox.Show(this, error, "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateOwnerInput()
        {
            Regex reg = new Regex(SecurityPatterns.EmailValidator, RegexOptions.IgnoreCase);
            return reg.IsMatch(ownerInput.Text.Trim());
        }

        private bool ValidateIPInput()
        {
            bool valid = true;
            try
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(this.ipInput.Text.Trim());
                valid = MSR.LST.Net.Utility.IsMulticast(ip);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private bool ValidatePortInput()
        {
            bool valid = true;
            try
            {
                UInt16.Parse(portInput.Text.Trim());
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
        #endregion

        #region Other UI Events
        private void multicastLink_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(helpMulticastUrl);
        }

        private void advancedBtn_Click(object sender, System.EventArgs e)
        {
            AdvVenueSettings settings = new AdvVenueSettings(this.newAccessList);
            DialogResult dr = settings.ShowDialog();

            if (dr == DialogResult.OK)
            {
                this.newAccessList = settings.Patterns;
            }
        }
        #endregion

    }
}
