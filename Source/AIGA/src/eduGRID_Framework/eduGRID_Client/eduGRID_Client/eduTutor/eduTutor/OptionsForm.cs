using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using eduTutor.Rss;


namespace eduTutor
{
    partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            // Load the text boxes from the current settings
            try
            {
                backgroundImageFolderTextBox.Text = Properties.Settings.Default.BackgroundImagePath;
                rssFeedTextBox.Text = Properties.Settings.Default.RssFeedUri;
            }
            catch
            {
                MessageBox.Show("There was a problem reading in the settings for your screen saver.");
            }
        }

        // Update the apply button to be active only if changes 
        // have been made since apply was last pressed
        private void UpdateApply()
        {
            if (Properties.Settings.Default.BackgroundImagePath != backgroundImageFolderTextBox.Text
                  || Properties.Settings.Default.RssFeedUri != rssFeedTextBox.Text)
                applyButton.Enabled = true;
            else
                applyButton.Enabled = false;
        }

        // Apply all the changes since apply button was last pressed
        private void ApplyChanges()
        {
            Properties.Settings.Default.BackgroundImagePath = backgroundImageFolderTextBox.Text;
            Properties.Settings.Default.RssFeedUri = rssFeedTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();
            }
            catch (ConfigurationException)
            {
                MessageBox.Show("Your settings couldn't be saved.  Make sure that you have a .config file in the same directory as your screensaver.", "Failed to Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            applyButton.Enabled = false;
        }

        // Check whether the user provided URI points to a valid RSS feed
        private void validateButton_Click(object sender, EventArgs e)
        {
            try
            {
                RssFeed.FromUri(rssFeedTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Not a valid RSS feed.", "Not a valid RSS feed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Valid RSS feed.", "Valid RSS feed.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Open a file open dialog to choose an image

            DialogResult result = backgroundImageFolderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                backgroundImageFolderTextBox.Text = backgroundImageFolderBrowser.SelectedPath;
                UpdateApply();
            }
        }

        private void rssFeedTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateApply();
        }

        private void backgroundImageFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateApply();
        }
    }
}