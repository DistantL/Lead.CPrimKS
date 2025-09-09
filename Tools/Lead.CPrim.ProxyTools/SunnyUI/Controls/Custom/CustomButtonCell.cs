using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public class DataGridViewCustomButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewCustomButtonColumn()
        {
            CellTemplate = new CustomButtonCell();
        }
    }

    public class CustomButtonCell : DataGridViewButtonCell
    {
        public bool IsButtonEnabled
        {
            get; set;
        }

        public CustomButtonCell()
        {
            IsButtonEnabled = true;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (!IsButtonEnabled)
            {
                ButtonRenderer.DrawButton(graphics, cellBounds, value.ToString(), cellStyle.Font, false, PushButtonState.Disabled);
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
