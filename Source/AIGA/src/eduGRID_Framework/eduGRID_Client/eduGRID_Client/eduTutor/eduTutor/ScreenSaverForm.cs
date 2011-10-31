using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using eduTutor.UI;
using eduTutor.Rss;

namespace eduTutor
{
    partial class ScreenSaverForm : Form
    {
        // The RssFeed to display articles from
        private RssFeed rssFeed;

        // Objects for displaying RSS contents
        private ItemListView<RssItem> rssView;
        private ItemDescriptionView<RssItem> rssDescriptionView;

        // The images to display in the background
        private List<Image> backgroundImages;
        private int currentImageIndex;

        // Keep track of whether the screensaver has become active.
        private bool isActive = false;

        // Keep track of the location of the mouse
        private Point mouseLocation;

        private List<string> imageExtensions = new List<string>(new string[] { "*.bmp", "*.gif", "*.png", "*.jpg", "*.jpeg" });

        public ScreenSaverForm()
        {
            InitializeComponent();

            SetupScreenSaver();
            LoadBackgroundImage();
            LoadRssFeed();

            // Initialize the ItemListView to display the list of items in the 
            // RssItem.  It is placed on the left side of the screen.            
            rssView = new ItemListView<RssItem>(rssFeed.MainChannel.Title, rssFeed.MainChannel.Items);
            InitializeRssView();

            // Initialize the ItemDescriptionView to display the description of the 
            // RssItem.  It is placed on the right side of the screen.
            rssDescriptionView = new ItemDescriptionView<RssItem>();
            InitializeRssDescriptionView();
        }


        /// <summary>
        /// Set up the main form as a full screen screensaver.
        /// </summary>
        private void SetupScreenSaver()
        {
            // Use double buffering to improve drawing performance
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            // Capture the mouse
            //this.Capture = true;

            // Set the application to full screen mode and hide the mouse
            //Cursor.Hide();
            Bounds = Screen.PrimaryScreen.Bounds;
            WindowState = FormWindowState.Maximized;
            ShowInTaskbar = false;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void LoadBackgroundImage()
        {
            // Initialize the background images.
            backgroundImages = new List<Image>();
            currentImageIndex = 0;

            if (Directory.Exists(Properties.Settings.Default.BackgroundImagePath))
            {
                try
                {
                    // Try to load the images given by the users.
                    LoadImagesFromFolder();
                }
                catch
                {
                    // If this fails, load the default images.
                    LoadDefaultBackgroundImages();
                }
            }

            // If no images were loaded, load the defaults
            if (backgroundImages.Count == 0)
            {
                LoadDefaultBackgroundImages();
            }
        }

        private void LoadImagesFromFolder()
        {
            DirectoryInfo backgroundImageDir = new DirectoryInfo(Properties.Settings.Default.BackgroundImagePath);
            // For each image extension (.jpg, .bmp, etc.)
            foreach (string imageExtension in imageExtensions)
            {
                // For each file in the directory provided by the user
                foreach (FileInfo file in backgroundImageDir.GetFiles(imageExtension))
                {
                    // Try to load the image
                    try
                    {
                        Image image = Image.FromFile(file.FullName);
                        backgroundImages.Add(image);
                    }
                    catch (OutOfMemoryException)
                    {
                        // If the image can't be loaded, move on.
                        continue;
                    }
                }
            }
        }


        private void LoadDefaultBackgroundImages()
        {
            // If the background images could not be loaded for any reason
            // use the image stored in the resources 
            backgroundImages.Add(Properties.Resources.SSaverBackground);
            backgroundImages.Add(Properties.Resources.SSaverBackground2);
        }

        private void LoadRssFeed()
        {
            try
            {
                // Try to get it from the users settings
                rssFeed = RssFeed.FromUri(Properties.Settings.Default.RssFeedUri);
            }
            catch
            {
                // If there is any problem loading the RSS load an error message RSS feed
                rssFeed = RssFeed.FromText(Properties.Resources.DefaultRSSText);
            }
        }

        /// <summary>
        /// Initialize display properties of the rssView.
        /// </summary>
        private void InitializeRssView()
        {
            rssView.BackColor = Color.FromArgb(120, 240, 234, 232);
            rssView.BorderColor = Color.White;
            rssView.ForeColor = Color.FromArgb(255, 40, 40, 40);
            rssView.SelectedBackColor = Color.FromArgb(200, 105, 61, 76);
            rssView.SelectedForeColor = Color.FromArgb(255, 204, 184, 163);
            rssView.TitleBackColor = Color.Empty;
            rssView.TitleForeColor = Color.FromArgb(255, 240, 234, 232);
            rssView.MaxItemsToShow = 20;
            rssView.MinItemsToShow = 15;
            rssView.Location = new Point(Width / 10, Height / 10);
            rssView.Size = new Size(Width / 2, Height / 2);
        }

        /// <summary>
        /// Initialize display properties of the rssDescriptionView.
        /// </summary>
        private void InitializeRssDescriptionView()
        {
            rssDescriptionView.DisplayItem = rssView.SelectedItem;
            rssDescriptionView.ForeColor = Color.FromArgb(255, 240, 234, 232);
            rssDescriptionView.TitleFont = rssView.TitleFont;
            rssDescriptionView.LineColor = Color.FromArgb(120, 240, 234, 232);
            rssDescriptionView.LineWidth = 2f;
            rssDescriptionView.FadeTimer.Tick += new EventHandler(FadeTimer_Tick);
            rssDescriptionView.FadeTimer.Interval = 40;
            rssDescriptionView.Location = new Point(3 * Width / 4, Height / 3);
            rssDescriptionView.Size = new Size(Width / 4, Height / 2);
            rssDescriptionView.FadingComplete += new EventHandler(rssItemView_FadingComplete);
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Set IsActive and MouseLocation only the first time this event is called.
            if (!isActive)
            {
                mouseLocation = MousePosition;
                isActive = true;
            }
            else
            {
                // If the mouse has moved significantly since first call, close.
                if ((Math.Abs(MousePosition.X - mouseLocation.X) > 10) ||
                    (Math.Abs(MousePosition.Y - mouseLocation.Y) > 10))
                {
                    //Close();
                }
            }
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Close();

        }

        private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
        {
            //Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw the current background image stretched to fill the full screen
            e.Graphics.DrawImage(backgroundImages[currentImageIndex], 0, 0, Size.Width, Size.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            rssView.Paint(e);
            rssDescriptionView.Paint(e);
        }

        private void backgroundChangeTimerTick(object sender, EventArgs e)
        {
            // Change the background image to the next image.
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;
        }

        void FadeTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        void rssItemView_FadingComplete(object sender, EventArgs e)
        {
            rssView.NextArticle();
            rssDescriptionView.DisplayItem = rssView.SelectedItem;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
