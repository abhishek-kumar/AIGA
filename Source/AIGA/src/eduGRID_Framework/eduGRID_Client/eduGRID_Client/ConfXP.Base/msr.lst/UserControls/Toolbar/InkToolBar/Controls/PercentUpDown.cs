using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace MSR.LST.Controls.InkToolBarControls
{
    /// <summary>
    /// Represents a <c>System.Windows.Forms.NumericUpDown</c> control that displays percentage points.
    /// </summary>
    internal class PercentUpDown : System.Windows.Forms.NumericUpDown
    {
        public PercentUpDown()
        {
        }

        protected override void UpdateEditText()
        {
            base.Text = base.Value.ToString(CultureInfo.CurrentUICulture) + "  %";
        }
    }
}
