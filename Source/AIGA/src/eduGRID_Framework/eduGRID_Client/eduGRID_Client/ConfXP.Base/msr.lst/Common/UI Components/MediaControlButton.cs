using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MSR.LST
{
    /// <summary>
    /// A generic button that displays a simple media control image, such as start or stop.
    /// </summary>
    public class MediaControlButton : System.Windows.Forms.Button
    {
        #region Component Designer generated code
        private System.ComponentModel.Container components = null;

        public MediaControlButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Set the default image
            this.ImageType = MediaControlImage.Play;
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // MediaControlButton
            // 
            this.Name = "MediaControlButton";
            this.Size = new System.Drawing.Size(24, 24);
        }
        #endregion

        private MediaControlImage controlImageType;

        public MediaControlImage ImageType
        {
            get
            {
                return this.controlImageType;
            }
            set
            {
                this.controlImageType = value;

                switch (value)
                {
                    case MediaControlImage.Pause:
                        base.Image = GetTransparentImageFromResource("MSR.LST.UI_Components.pause_enabled.bmp");
                        break;
                    case MediaControlImage.Play:
                        base.Image = GetTransparentImageFromResource("MSR.LST.UI_Components.play_enabled.bmp");
                        break;
                    case MediaControlImage.Record:
                        base.Image = GetTransparentImageFromResource("MSR.LST.UI_Components.record_enabled.bmp");
                        break;
                    case MediaControlImage.Stop:
                        base.Image = GetTransparentImageFromResource("MSR.LST.UI_Components.stop_enabled.bmp");
                        break;
                    default:
                        throw new ArgumentException("A type not handled was provided as the ControlType.");
                }
            }
        }
    
        private Image GetTransparentImageFromResource(string resourceName)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Image resImage = Image.FromStream(a.GetManifestResourceStream(resourceName));
            Bitmap bm = new Bitmap(resImage);
            bm.MakeTransparent(bm.GetPixel(0,0));
            return bm;
        }
    }

    public enum MediaControlImage {Play, Stop, Pause, Record};
}
