using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MSR.LST.ConferenceXP.VenueService
{
    internal class VenueManager : MSR.LST.ConferenceXP.VenueService.ItemManager
    {
        #region Private Members
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The index in the image list of the default venue icon
        /// </summary>
        private int defaultIconIndex;
        #endregion

        #region Ctor, Dispose
        public VenueManager()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Like Windows Explorer, we show the icon in the first row, and accomodate it with extra space
            base.list.Columns.Add("   Name", 120+images.ImageSize.Width, HorizontalAlignment.Left);
            base.list.Columns.Add(" Identifier", 150, HorizontalAlignment.Left);
            base.list.Columns.Add(" IP Address", 96, HorizontalAlignment.Left);
            base.list.Columns.Add(" Port", 38, HorizontalAlignment.Left);

            // Store which columns we want to make fixed-width
            base.VariableWidthColumns = new int[]{0,1}; // Name & Identifier

            // And now make sure we're using up all of our column space
            base.ResizeColumns();

            // Don't allow refresh on this form
            base.refreshBtn.Visible = false;

            // Hook the button events
            base.editBtn.Click += new EventHandler(editBtn_Click);
            base.newBtn.Click += new EventHandler(newBtn_Click);
            base.deleteBtn.Click += new EventHandler(deleteBtn_Click);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region Private Methods
        override protected void RefreshList()
        {
            Venue[] venues = StorageFile.GetVenues();

            images.Images.Clear();
            list.Items.Clear();

            // Add the default venue icon at spot [0]
            defaultIconIndex = images.Images.Add(VenueEditor.defaultVenueIcon, images.TransparentColor);

            foreach(Venue venue in venues)
            {
                int imageIndex = AddVenueIcon (venue.Icon);
                list.Items.Add (CreateLvi(venue, imageIndex));
            }
        }

        private ListViewItem CreateLvi(Venue venue, int imageIndex)
        {
            string[] columns = new string[]{venue.Name, venue.Identifier, venue.IPAddress.ToString(), venue.Port.ToString()};
            ListViewItem item = new ListViewItem(columns);
            item.ImageIndex = imageIndex;
            item.Tag = venue;

            return item;
        }

        /// <summary>
        /// Takes a venue icon as a byte[], adds it to the images list, and returns its new index in the list.
        /// </summary>
        private int AddVenueIcon(byte[] venueIcon)
        {
            Image icon = IconUtilities.BytesToImage (venueIcon);
            int imageIndex;
            if( icon == null )
                imageIndex = this.defaultIconIndex;
            else
                imageIndex = images.Images.Add(icon, images.TransparentColor);

            return imageIndex;
        }
        #endregion

        #region Button Events
        private void editBtn_Click(object sender, EventArgs e)
        {
            Venue selectedVenue = (Venue)list.SelectedItems[0].Tag;
            VenueEditor editor = new VenueEditor(selectedVenue);
            editor.Text = "Edit Venue";
            editor.Closing += new CancelEventHandler(CheckForDupIP);
            editor.Closing += new CancelEventHandler(CheckForDupID);
            DialogResult dr = editor.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Venue editedVenue = editor.GetVenue();

                if (editedVenue.Identifier != selectedVenue.Identifier)
                {
                    // The venue identifier was edited, so we need to completely delete & re-add this venue
                    StorageFile.DeleteVenue(selectedVenue.Identifier);
                    StorageFile.AddVenue(editedVenue);
                }
                else
                {
                    StorageFile.UpdateVenue(editedVenue);
                }

                // Don't remove the image; it will screw up the images for all of the other venues
                // But we will check to see if the image has changed (if not, just use the old imageIndex)
                int imageIndex;
                if (editedVenue.Icon == selectedVenue.Icon)
                    imageIndex = list.SelectedItems[0].ImageIndex;
                else
                    imageIndex = AddVenueIcon(editedVenue.Icon);

                // Remove the old item
                list.Items.RemoveAt(list.SelectedIndices[0]);

                // Create and add the new item
                list.Items.Add (CreateLvi(editedVenue, imageIndex));
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            VenueEditor editor = new VenueEditor(new Venue());
            editor.Text = "New Venue";
            editor.Closing += new CancelEventHandler(CheckForDupIP);
            editor.Closing += new CancelEventHandler(CheckForDupID);
            DialogResult dr = editor.ShowDialog();

            if (dr == DialogResult.OK)
            {
                // Get the new venue
                Venue venue = editor.GetVenue();

                // Store it
                StorageFile.AddVenue(venue);

                // Create the new LVI
                int imageIndex = AddVenueIcon(venue.Icon);

                // Add it to the list
                list.Items.Add (CreateLvi(venue, imageIndex));
            }
        }

        /// <summary>
        /// When the edit form is closing, check to make sure the IP is unique.
        /// </summary>
        private void CheckForDupIP(object sender, CancelEventArgs e)
        {
            VenueEditor editor = (VenueEditor)sender;

            if (editor.DialogResult != DialogResult.OK)
                return;

            Venue ven = editor.GetVenue();
            IPAddress ip = IPAddress.Parse(ven.IPAddress.Trim());

            // First check to see if the IP changed from the selected venue
            //  If it changed, we have to check against all of the venue IPs
            Venue original = editor.OriginalVenue;
            if (original.IPAddress == null || !IPAddress.Parse(original.IPAddress.Trim()).Equals(ip))
            {
                Venue dupIPVenue = null;

                // The IP has changed, so check to make sure it's not a dup
                foreach(ListViewItem item in list.Items)
                {
                    Venue currentVen = (Venue)item.Tag;
                    if (IPAddress.Parse(currentVen.IPAddress.Trim()).Equals(ip))
                    {
                        dupIPVenue = currentVen;
                        break;
                    }
                }

                // If the IP is a duplicate, show an error and prevent the dialog from closing
                if (dupIPVenue != null)
                {
                    MessageBox.Show(this, String.Format("The venue \"{0}\" is already using the IP address \n" +
                        "you specified. Please specify another IP address.", dupIPVenue.Name),
                        "Duplicate IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// When the edit form is closing, check to make sure the IP is unique.
        /// </summary>
        private void CheckForDupID(object sender, CancelEventArgs e)
        {
            VenueEditor editor = (VenueEditor)sender;

            if (editor.DialogResult != DialogResult.OK)
                return;

            Venue ven = editor.GetVenue();
            string id = ven.Identifier.ToLower().Trim();

            // First check to see if the ID changed from the selected venue
            //  If it changed, we have to check against all of the venue IDs
            Venue original = editor.OriginalVenue;
            if (original.Identifier == null || original.Identifier.ToLower().Trim() != id)
            {
                Venue dupIDVenue = null;

                // The IP has changed, so check to make sure it's not a dup
                foreach(ListViewItem item in list.Items)
                {
                    Venue currentVen = (Venue)item.Tag;
                    if (currentVen.Identifier.ToLower().Trim() == id)
                    {
                        dupIDVenue = currentVen;
                        break;
                    }
                }

                // If the ID is a duplicate, show an error and prevent the dialog from closing
                if (dupIDVenue != null)
                {
                    MessageBox.Show(this, String.Format("The venue \"{0}\" is already using the owner \n" +
                        "you specified. Please specify another owner.", dupIDVenue.Name),
                        "Duplicate Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Venue selectedVenue = ((Venue)list.SelectedItems[0].Tag);
            string removeStr = String.Format("Are you sure you want to delete the venue \"{0}\"?",
                selectedVenue.Name);
            DialogResult dr = MessageBox.Show(this, removeStr, "Confirm Venue Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                StorageFile.DeleteVenue(selectedVenue.Identifier);
                // don't remove the image; it will screw up the images for all of the other venues
                list.Items.RemoveAt(list.SelectedIndices[0]);
            }
        }
        #endregion

    }
}

