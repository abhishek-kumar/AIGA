using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using MSR.LST.MDShow;
using System.Diagnostics;

namespace MSR.LST.ConferenceXP
{
    public class frmAudioFormat : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvFormats;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lvFormats = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(256, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(184, 368);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 68;
            this.btnOK.Text = "OK";
            // 
            // lvFormats
            // 
            this.lvFormats.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFormats.AutoArrange = false;
            this.lvFormats.FullRowSelect = true;
            this.lvFormats.GridLines = true;
            this.lvFormats.Location = new System.Drawing.Point(0, 0);
            this.lvFormats.MultiSelect = false;
            this.lvFormats.Name = "lvFormats";
            this.lvFormats.Size = new System.Drawing.Size(326, 361);
            this.lvFormats.TabIndex = 76;
            this.lvFormats.View = System.Windows.Forms.View.Details;
            // 
            // frmAudioFormat
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(328, 398);
            this.ControlBox = false;
            this.Controls.Add(this.lvFormats);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmAudioFormat";
            this.Text = "FAudioFormat";
            this.Load += new System.EventHandler(this.FAudioFormat_Load);
            this.ResumeLayout(false);

        }


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

        #region Members

        /// <summary>
        /// Microphone filter
        /// </summary>
        private AudioSource source = null;

        /// <summary>
        /// Media types available on the device
        /// </summary>
        _AMMediaType[] mts;

        /// <summary>
        /// Format blocks for the media types
        /// </summary>
        object[] fbs;

        /// <summary>
        /// Width percentages of the columns (in order to hi
        /// </summary>
        int[] widths = new int[] {20, 30, 30, 20};

        #endregion Members

        #region Constructor

        public frmAudioFormat(AudioSource source)
        {
            InitializeComponent();

            Debug.Assert(source != null);
            this.source = source;
        }

        
        #endregion Constructor

        /// <summary>
        /// Returns the media type and format block chosen by the user
        /// </summary>
        public void GetMediaType(out _AMMediaType mt, out object fb)
        {
            mt = mts[lvFormats.SelectedIndices[0]];
            fb = fbs[lvFormats.SelectedIndices[0]];
        }
        
        
        private void FAudioFormat_Load(object sender, System.EventArgs e)
        {
            this.Text = "Choose an audio format for - " + source.FriendlyName;

            lvFormats.View = View.Details;
            lvFormats.Columns.Add("Channels", 60, HorizontalAlignment.Right);
            lvFormats.Columns.Add("Frequency (Hz)", 90, HorizontalAlignment.Right);
            lvFormats.Columns.Add("Bits per sample", 90, HorizontalAlignment.Right);
            lvFormats.Columns.Add("Kbps", 60, HorizontalAlignment.Right);

            GetMediaTypes();
            SelectCurrent();
        }
        
        /// <summary>
        /// Populates the listview with the available media types
        /// </summary>
        private void GetMediaTypes()
        {
            source.GetMediaTypes(out mts, out fbs);

            for(int i = 0; i < mts.Length; i++)
            {
                WAVEFORMATEX wfe = (WAVEFORMATEX)fbs[i];

                lvFormats.Items.Add(wfe.Channels.ToString());
                lvFormats.Items[i].SubItems.Add(wfe.SamplesPerSec.ToString());
                lvFormats.Items[i].SubItems.Add(wfe.BitsPerSample.ToString());
                lvFormats.Items[i].SubItems.Add(((int)(wfe.AvgBytesPerSec * 8 / 1000)).ToString());
            }
        }

        /// <summary>
        /// Iterate through the available media types and mark the first one
        /// that matches our current media type
        /// </summary>
        private void SelectCurrent()
        {
            _AMMediaType mt;
            object fb;
            source.GetMediaType(out mt, out fb);
            WAVEFORMATEX cur = (WAVEFORMATEX)fb;

            for(int i = 0; i < fbs.Length; i++)
            {
                WAVEFORMATEX wfe = (WAVEFORMATEX)fbs[i];

                if(cur.Channels == wfe.Channels &&
                   cur.SamplesPerSec == wfe.SamplesPerSec &&
                   cur.BitsPerSample == wfe.BitsPerSample)
                {
                    this.Visible = true;
                    lvFormats.Focus();
                    lvFormats.Items[i].Selected = true;
                    return;
                }
            }

            Debug.Fail("We didn't find a matching media type");
        }
    }
}
