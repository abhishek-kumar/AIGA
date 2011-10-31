using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MSR.LST.ConferenceXP
{
    /// <summary>
    /// Due to some unfortunate problems, the Conference API doesn't allow a Capability without
    /// a Form.  Thus, the OneNote capability has a form that "doesn't exist", so to speak.
    /// </summary>
    public class OptionsForm : CapabilityForm
    {
        internal bool AutoSyncSlides = true;
        internal event EventHandler SyncCurrentSlide;

        private Hashtable authorToFolderHash = null;
        private NotifyIcon sysTrayIcon = null;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.Container components = null;


        public OptionsForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                this.sysTrayIcon.Visible = false;
                this.sysTrayIcon.Dispose();

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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "If you see this form, it\'s a bug.  If you close it, the capability will die.";
            // 
            // OptionsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(186, 48);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "OneNote Importer";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// This is a hack to prevent the Capability base class from showing this form when it
        /// doesn't "want" to be shown
        /// </summary>
        private void ThisFormDoesNotExist_VisibleChanged(object sender, EventArgs e)
        {
            Hide();
        }

        private void sysTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Why hello there!");
        }

        private void SyncSlide(object sender, EventArgs e)
        {
            if( this.SyncCurrentSlide != null )
                this.SyncCurrentSlide( sender, e );
        }

        private void AutoSync(object sender, EventArgs e)
        {
            this.AutoSyncSlides = !this.AutoSyncSlides;
            
            this.sysTrayIcon.ContextMenu.MenuItems[1].Checked = this.AutoSyncSlides;

            if( this.SyncCurrentSlide != null )
                this.SyncCurrentSlide( sender, e );
        }

        /// <summary>
        /// Asks the user if he/she would like to overwrite and existing file, or keep it
        /// </summary>
        internal bool ShowOverwriteFileQuestion(string file)
        {
            // We'll use a simple MessageBox for this.  Cutomarily apps don't allow users
            // to save the "overwrite file" setting, so we won't either.
            DialogResult dr = MessageBox.Show( this,
                "The document being received has the same title as another"
                  + "document in this folder.  Would you like to overwrite: \""
                  + file + "\"?"
                  + "\n\nSelect 'Yes' to overwrite the file and 'No' to change"
                  + "the name automatically.",
                "Overwite File?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return (dr == DialogResult.Yes);
        }

        /// <summary>
        /// Gets the appropriate folder name for this author.
        /// </summary>
        /// <param name="author">The name of the author as it appears in the document.</param>
        /// <returns>The folder name, relative, with ending '\'.</returns>
        internal string GetFolderForAuthor(string author)
        {
            // Check for the author already being in the hash
            if( this.authorToFolderHash.ContainsKey(author) )
            {
                return (string) authorToFolderHash[author];
            }
            else
            {
                OptionsDialog od = new OptionsDialog();

                if( author == null )
                    author = "<Blank>";

                // Set the questionLabel, infoLabel, and options
                od.questionLabel.Text = "A document from a new author is being received."
                    + "Please select or type the name of the Section in which you would"
                    + "like the notes to be placed.";
                od.infoLabel.Text = "Author: " + author;
                od.options.Text = "";
                od.checkBox.Text = "Save this setting for this author.";
                od.checkBox.Checked = true;

                foreach( object obj in authorToFolderHash.Values )
                {
                    od.options.Items.Add( obj );
                }

                // Show the dialog
                od.ShowDialog();

                string foldername = od.options.Text.Trim();
                if( !foldername.EndsWith("\\") && foldername == "" )
                    foldername += "\\";

                // Save the setting if necessary
                if( od.checkBox.Checked )
                    authorToFolderHash.Add( author, foldername );

                // Retrieve the selection from the combo box and return it
                return foldername;
            }
        }

        /// <summary>
        /// Writes the options back to the dat file.
        /// </summary>
        private void OptionsForm_Closing(object sender, CancelEventArgs e)
        {
            string baseDir = Application.UserAppDataPath + "\\OneNote Importer\\";
            if( !Directory.Exists( baseDir ) )
                Directory.CreateDirectory( baseDir );

            string path = baseDir + "options.dat";
            FileStream fs = new FileStream( path, FileMode.Create );
            BinaryFormatter bf = new BinaryFormatter( );
            bf.Serialize( fs, authorToFolderHash );
            fs.Close( );
        }

        
        #region ICapabilityForm

        public override void AddCapability(ICapability capability)
        {
            // Load the saved options
            string path = Application.UserAppDataPath + "\\OneNote Importer\\options.dat";
            if( File.Exists(path) )
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                authorToFolderHash = (Hashtable) bf.Deserialize(fs);
                fs.Close();
            }
            else // create default options
            {
                this.authorToFolderHash = new Hashtable();
            }

            // Hook the closing event so we can write the options back to the registry
            this.Closing += new CancelEventHandler(OptionsForm_Closing);

            // Resource manager...
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resName = asm.FullName.Substring(0, asm.FullName.IndexOf(',')) + ".sysTray.ico";
            System.IO.Stream s = asm.GetManifestResourceStream(resName);

            // Create the SysTray icon
            sysTrayIcon = new NotifyIcon();
            sysTrayIcon.Icon = new Icon(s);
            sysTrayIcon.Visible = true;
            sysTrayIcon.Text = "OneNote Importer";
            sysTrayIcon.DoubleClick +=new EventHandler(sysTrayIcon_DoubleClick);

            // Create the ContextMenu for the SysTray Icon
            ContextMenu sysTrayMenu = new ContextMenu( 
                new MenuItem[]{
                                  new MenuItem( "Sync to Instructor", new EventHandler(SyncSlide) ),
                                  new MenuItem( "Stay Auto-sync'd", new EventHandler(AutoSync) ) 
                              } );
            sysTrayMenu.MenuItems[1].Checked = this.AutoSyncSlides;
            sysTrayIcon.ContextMenu = sysTrayMenu;

            // This is truly un-graceful code, but this form doesn't exist
            //  at instantiation of the Capability, so we have to hook the event
            //  in a very backwards fashion
            this.SyncCurrentSlide += new EventHandler(((PresentationToOneNoteCapability)capability).SyncToPage);

            // Through a little slight of hand, the form is never seen...
            this.VisibleChanged += new EventHandler(ThisFormDoesNotExist_VisibleChanged);
        }

        public override bool RemoveCapability(ICapability capability)
        {
            return true;
        }


        #endregion ICapabilityForm

    }


}
