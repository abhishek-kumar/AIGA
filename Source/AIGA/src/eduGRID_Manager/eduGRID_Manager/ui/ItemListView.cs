using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace eduGRID_Manager.UI
{
    /// <summary>
    /// Encapsulates the rendering of a list of items.  Each item's description is shown in a list, and a single item is selected.
    /// </summary>
    /// <typeparam name="T">The type of item that this ItemListView will draw.</typeparam>
    public class ItemListView<T> : IDisposable where T : IItem
    {
        private const float percentOfArticleDisplayBoxToFillWithText = 0.5f;
        private const float percentOfFontHeightForSelectionBox = 1.5f;
        private const int padding = 20;

        // Where to draw
        private Point location;
        private Size size;

        private string title;
        private Font itemFont;
        private Font titleFont;
        private Color backColor;
        private Color borderColor;
        private Color foreColor;
        private Color titleBackColor;
        private Color titleForeColor;
        private Color selectedForeColor;
        private Color selectedBackColor;
        private float itemFontHeight;
        // An index of the currently selected item
        private int selectedIndex = 0;
        // The list of items to draw
        private IList<T> items;
        // The maximum number of articles that will be displayed
        private int maxItemsToShow;
        // The minimum number of articles that will be displayed
        // If there are less items than this in the RSS channel
        // then there will be blank space in the display
        private int minItemsToShow;

        private int NumArticles { get { return Math.Min(items.Count, maxItemsToShow); } }
        private int NumArticleRows { get { return Math.Max(NumArticles, minItemsToShow); } }

        public Point Location { get { return location; } set { location = value; } }
        public Size Size { get { return size; } set { size = value; } }

        public Color ForeColor { get { return foreColor; } set { foreColor = value; } }
        public Color BackColor { get { return backColor; } set { backColor = value; } }
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        public Color TitleForeColor { get { return titleForeColor; } set { titleForeColor = value; } }
        public Color TitleBackColor { get { return titleBackColor; } set { titleBackColor = value; } }
        public Color SelectedForeColor { get { return selectedForeColor; } set { selectedForeColor = value; } }
        public Color SelectedBackColor { get { return selectedBackColor; } set { selectedBackColor = value; } }
        public int MaxItemsToShow { get { return maxItemsToShow; } set { maxItemsToShow = value; } }
        public int MinItemsToShow { get { return minItemsToShow; } set { minItemsToShow = value; } }
        public int SelectedIndex { get { return selectedIndex; } }
        public T SelectedItem { get { return items[selectedIndex]; } }

        public int RowHeight
        {
            get
            {
                // There is one row for each item plus 2 rows for the title.
                return size.Height / (NumArticleRows + 2);
            }
        }

        public Font ItemFont
        {
            get
            {
                // Choose a font for each of the item titles that will fit all numItems 
                // of them (plus some slack for the title) in the control 
                itemFontHeight = (float)(percentOfArticleDisplayBoxToFillWithText * RowHeight);
                if (itemFont == null || itemFont.Size != itemFontHeight)
                {
                    itemFont = new Font("Microsoft Sans Serif", itemFontHeight, GraphicsUnit.Pixel);
                }
                return itemFont;
            }
        }

        public Font TitleFont
        {
            get
            {
                // Choose a font for the title text.
                // This font will be twice as big as the ItemFont
                float titleFontHeight = (float)(percentOfArticleDisplayBoxToFillWithText * 2 * RowHeight);
                if (titleFont == null || titleFont.Size != titleFontHeight)
                {
                    titleFont = new Font("Microsoft Sans Serif", titleFontHeight, GraphicsUnit.Pixel);
                }
                return titleFont;
            }
        }

        public void NextArticle()
        {
            if (selectedIndex < NumArticles - 1)
                selectedIndex++;
            else
                selectedIndex = 0;
        }

        public void PreviousArticle()
        {
            if (selectedIndex > 0)
                selectedIndex--;
            else
                selectedIndex = NumArticles - 1;
        }

        public ItemListView(string title, IList<T> items)
        {
            if (items == null)
                throw new ArgumentException("Items cannot be null", "items");

            this.items = items;
            this.title = title;
        }

        public void Paint(PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            // Settings to make the text drawing look nice
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            DrawBackground(g);

            // Draw each article's description
            for (int index = 0; index < items.Count && index < maxItemsToShow; index++)
            {
                DrawItemTitle(g, index);
            }

            // Draw the title text
            DrawTitle(g);
        }

        /// <summary>
        /// Draws a box and border ontop of which the text of the items can be drawn.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto</param>
        private void DrawBackground(Graphics g)
        {
            using (Brush backBrush = new SolidBrush(BackColor))
            using (Pen borderPen = new Pen(BorderColor, 4))
            {
                g.FillRectangle(backBrush, new Rectangle(Location.X + 4, Location.Y + 4, Size.Width - 8, Size.Height - 8));
                g.DrawRectangle(borderPen, new Rectangle(Location, Size));
            }
        }

        /// <summary>
        /// Draws the title of the item with the given index.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto</param>
        /// <param name="index">The index of the item in the list</param>
        private void DrawItemTitle(Graphics g, int index)
        {
            // Set formatting and layout
            StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            Rectangle articleRect = new Rectangle(Location.X + padding, Location.Y + (int)(index * RowHeight) + padding, Size.Width - (2 * padding), (int)(percentOfFontHeightForSelectionBox * itemFontHeight));

            // Select color and draw border if current index is selected
            Color textBrushColor = ForeColor;
            if (index == SelectedIndex)
            {
                textBrushColor = SelectedForeColor;
                using (Brush backBrush = new SolidBrush(SelectedBackColor))
                {
                    g.FillRectangle(backBrush, articleRect);
                }
            }

            // Draw the title of the item
            string textToDraw = items[index].Title;
            using (Brush textBrush = new SolidBrush(textBrushColor))
            {
                g.DrawString(textToDraw, ItemFont, textBrush, articleRect, stringFormat);
            }
        }

        /// <summary>
        /// Draws a title bar.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto</param>
        private void DrawTitle(Graphics g)
        {
            Point titleLocation = new Point(Location.X + padding, Location.Y + Size.Height - (RowHeight) - padding);
            Size titleSize = new Size(Size.Width - (2 * padding), 2 * RowHeight);
            Rectangle titleRectangle = new Rectangle(titleLocation, titleSize);

            // Draw the title box and the selected item box
            using (Brush titleBackBrush = new SolidBrush(TitleBackColor))
            {
                g.FillRectangle(titleBackBrush, titleRectangle);
            }

            // Draw the title text
            StringFormat titleFormat = new StringFormat(StringFormatFlags.LineLimit);
            titleFormat.Alignment = StringAlignment.Far;
            titleFormat.Trimming = StringTrimming.EllipsisCharacter;
            using (Brush titleBrush = new SolidBrush(TitleForeColor))
            {
                g.DrawString(title, titleFont, titleBrush, titleRectangle, titleFormat);
            }
        }

        /// <summary>
        /// Dispose all disposable fields
        /// </summary>
        public void Dispose()
        {
            if (itemFont != null)
                itemFont.Dispose();
            if (titleFont != null)
                titleFont.Dispose();
        }
    }
}
