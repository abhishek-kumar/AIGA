using System;
using System.Windows.Forms;
using System.Drawing;

namespace eduTutor.UI
{
    /// <summary>
    /// Encapsulates the rendering of the description of an item.
    /// </summary>
    /// <typeparam name="T">The type of item that this ItemDescriptionView will draw.</typeparam>
    public class ItemDescriptionView<T> : IDisposable where T : IItem
    {
        private Point location;
        private Size size;

        private static Brush textDrawingBrush = Brushes.Black;
        private Color lineColor;
        private float lineWidth;
        private Rectangle textRect;
        private Timer fadeTimer;
        private Color foreColor;
        private Font titleFont;
        private T displayItem;

        // The initial alpha value and the amount to change the value by each time
        private int textAlpha = 0;
        private int textAlphaDelta = 4;
        private int textAlphaMax = 200;

        public T DisplayItem { get { return displayItem; } set { displayItem = value; } }
        public Point Location { get { return location; } set { location = value; } }
        public Size Size { get { return size; } set { size = value; } }
        public Color ForeColor { get { return foreColor; } set { foreColor = value; } }
        public Color LineColor { get { return lineColor; } set { lineColor = value; } }
        public Font TitleFont { get { return titleFont; } set { titleFont = value; } }
        public float LineWidth { get { return lineWidth; } set { lineWidth = value; } }
        public Timer FadeTimer { get { return fadeTimer; } }

        public event EventHandler FadingComplete;

        /// <summary>
        /// Create a new ItemDescriptionView connected to <paramref name="listView"/>.
        /// </summary>
        /// <param name="listView"></param>
        public ItemDescriptionView()
        {
            fadeTimer = new Timer();
            fadeTimer.Tick += new EventHandler(scrollTimer_Tick);
            fadeTimer.Enabled = true;
            fadeTimer.Start();
        }

        public void Paint(PaintEventArgs e)
        {
            // Change the graphics settings to draw clear text
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Determine the placement of the lines that will be placed 
            // above and below the text
            float lineLeftX = Size.Width / 4;
            float lineRightX = 3 * Size.Width / 4;
            int lineVerticalBuffer = Size.Height / 50;
            float lineTopY = Location.Y + lineVerticalBuffer;
            float lineBottomY = Location.Y + Size.Height - lineVerticalBuffer;

            // Draw the two lines
            using (Pen linePen = new Pen(lineColor, lineWidth))
            {
                e.Graphics.DrawLine(linePen, Location.X + lineLeftX, lineTopY, Location.X + lineRightX, lineTopY);
                e.Graphics.DrawLine(linePen, Location.X + lineLeftX, lineBottomY, Location.X + lineRightX, lineBottomY);
            }

            // Draw the text of the article
            using (StringFormat textFormat = new StringFormat(StringFormatFlags.LineLimit))
            {
                textFormat.Alignment = StringAlignment.Near;
                textFormat.LineAlignment = StringAlignment.Near;
                textFormat.Trimming = StringTrimming.EllipsisWord;
                int textVerticalBuffer = 4 * lineVerticalBuffer;
                textRect = new Rectangle(Location.X, Location.Y + textVerticalBuffer, Size.Width, Size.Height - (2 * textVerticalBuffer));
                using (Brush textBrush = new SolidBrush(Color.FromArgb(textAlpha, ForeColor)))
                {
                    e.Graphics.DrawString(displayItem.Description, titleFont, textBrush, textRect, textFormat);
                }
            }
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            // Change the alpha value of the text being drawn
            // Moves up until it reaches textAlphaMax and then moves down
            // Moves to the next article when it gets back to zero
            textAlpha += textAlphaDelta;
            if (textAlpha >= textAlphaMax)
            {
                textAlphaDelta *= -1;
            }
            else if (textAlpha <= 0)
            {
                FadingComplete(this, new EventArgs());
                textAlpha = 0;
                textAlphaDelta *= -1;
            }
        }


        /// <summary>
        /// Dispose all disposable fields
        /// </summary>
        public void Dispose()
        {
            fadeTimer.Dispose();
        }
    }
}
