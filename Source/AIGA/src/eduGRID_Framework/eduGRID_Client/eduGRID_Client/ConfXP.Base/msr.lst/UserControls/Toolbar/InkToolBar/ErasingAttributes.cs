using System;
using Microsoft.Ink;

namespace MSR.LST.Controls.InkToolBarControls
{
    /// <summary>
    /// Represents eraser drawing attributes.
    /// </summary>
    public class ErasingAttributes
    {
        private int m_eraserSize;
        private InkOverlayEraserMode m_eraserMode;

        /// <value>
        /// Represents the size of the eraser.
        /// </value>
        public int Size
        {
            get { return m_eraserSize; }
            set 
            { 
                if (value > 0)
                    m_eraserSize = value;
                else
                    throw new ArgumentOutOfRangeException("value", value, "Eraser size cannot be less than 1");
            }
        }

        /// <value>
        /// Represents the eraser's mode.
        /// </value>
        /// <remarks>
        /// An eraser can either eraser whole strokes or individual points.
        /// </remarks>
        public InkOverlayEraserMode Mode
        {
            get { return m_eraserMode;  }
            set { m_eraserMode = value; }
        }
    }
}
