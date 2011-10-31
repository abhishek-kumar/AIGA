using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MSR.LST.ConferenceXP
{
    /// <summary>
    /// Internal utility methods for ConferenceAPI
    /// </summary>
    internal class Utilities
    {
        /// <summary>
        /// Shared logic for byte[] -> Bitmap conversion using Bitmap(MemoryStream(byte[]))
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        internal static Bitmap ByteToBitmap(byte[] icon)
        {
            if (icon != null)
                return new Bitmap(new MemoryStream(icon));
            else
                return null;
        }
        /// <summary>
        /// Shared logic for Bitmap -> byte[] conversion using Bitmap -> Thumbnail -> MemoryStream.ToArray -> byte[]
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        internal static byte[] BitmapToByte(Bitmap icon)
        {
            if (icon != null)
            {
                MemoryStream ms = new MemoryStream();
                Bitmap thumbnail = GenerateThumbnail(icon);
                thumbnail.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            else
                return null;
        }
        /// <summary>
        /// Converts any bitmap down to a 96x96 square with linear x/y scaling and border whitespace if needed
        /// </summary>
        /// <param name="masterImage">Full size Bitmap of any dimension</param>
        /// <returns>96x96 Bitmap</returns>
        internal static Bitmap GenerateThumbnail(Bitmap masterImage)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            // Calculate the thumbnail size
            double newWidth = 0.0;
            double newHeight = 0.0;

            if (masterImage.Width > 96 || masterImage.Height > 96)
            {
                bool portrait = false;

                if (masterImage.Width > masterImage.Height)
                    portrait = true;

                if (portrait)
                {
                    double pct = (double)masterImage.Width / 96;
                    newWidth = (double)masterImage.Width / pct;
                    newHeight = (double)masterImage.Height / pct;
                }
                else
                {
                    double pct = (double)masterImage.Height / 96;
                    newWidth = (double)masterImage.Width / pct;
                    newHeight = (double)masterImage.Height / pct;
                }
            }
            else
            {
                newWidth = masterImage.Width;
                newHeight = masterImage.Height;
            }

            Image myThumbnail = masterImage.GetThumbnailImage((int)newWidth,(int)newHeight,myCallback,IntPtr.Zero);

            // Put the thumbnail on a square background
            Bitmap squareThumb = new Bitmap(96,96);
            Graphics g = Graphics.FromImage(squareThumb);

            int x = 0;
            int y = 0;

            x = (96 - myThumbnail.Width) / 2;
            y = (96 - myThumbnail.Height) / 2;

            g.DrawImage(myThumbnail, new Rectangle(new Point(x,y), new Size(myThumbnail.Width, myThumbnail.Height)));


            // Write out the new bitmap
            MemoryStream ms = new MemoryStream();
            squareThumb.Save(ms, ImageFormat.Png);
            return new Bitmap(ms);
        }

        /// <summary>
        /// Useless nit required by GetThumbnailImage
        /// </summary>
        /// <returns></returns>
        private static bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// Add CapabilityViewer Icons to a Participant Icon to graphically show an end user what CapabilityViewers are available for a Participant
        /// (AKA are they sending video? sending audio? sharing a whiteboard? sharing a PowerPoint?
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static Bitmap CreateDecoratedParticipantImage(Participant p)
        {

            Bitmap partBit = new Bitmap(p.Icon);
            Graphics g = Graphics.FromImage(partBit);

            // Indicate which stream's are available for the participant
            bool sendingAudio = false;
            bool sendingVideo = false;

            foreach (ICapability cv in p.Capabilities)
            {
                // Pri2: Bind this to the object type somehow -- watch interdependencies
                MSR.LST.Net.Rtp.PayloadType pt = (MSR.LST.Net.Rtp.PayloadType)cv.PayloadType;
                if (pt == MSR.LST.Net.Rtp.PayloadType.dynamicVideo)
                {
                    sendingVideo = true;
                }
                if (pt == MSR.LST.Net.Rtp.PayloadType.dynamicAudio)
                {
                    sendingAudio = true;
                }
            }

            // Draw audio, video, or audiovideo icons on bitmap
            if (sendingAudio && sendingVideo)
            {
                System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MSR.LST.ConferenceXP.AudioAndVideoDecoration.png");
                g.DrawImage(new Bitmap(stream), new Rectangle(new Point(1,1), new Size(32,24)));
            }
            else
                if (sendingAudio)
            {
                System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MSR.LST.ConferenceXP.AudioDecoration.png");
                g.DrawImage(new Bitmap(stream), new Rectangle(new Point(1,1), new Size(32,24)));
            }
            else
                if (sendingVideo)
            {
                System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MSR.LST.ConferenceXP.VideoDecoration.png");
                g.DrawImage(new Bitmap(stream), new Rectangle(new Point(1,1), new Size(32,24)));
            }

            // Write out the new bitmap
            MemoryStream ms = new MemoryStream();
            partBit.Save(ms, ImageFormat.Png);
            return new Bitmap(ms);
        }

    }
}
