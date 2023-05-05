using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.DesignForms
{
    public static class FormElementDesign
    {

        public static void SetComboBoxProperties(Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                if (ctl is ComboBox)
                {
                    // Set the Font, AutoCopeteMode and  AutoCompeteSource properties of the ComboBox
                    
                    ((ComboBox)ctl).AutoCompleteSource = AutoCompleteSource.ListItems;
                    ((ComboBox)ctl).AutoCompleteMode = AutoCompleteMode.Append;
                }
                else if (ctl.Controls.Count > 0)
                {
                    SetComboBoxProperties(ctl.Controls);
                }
            }
        }

        public static void SetAligementDataGridview(ref DataGridView dgv, string colName, string style)
        {
            if (style=="center")
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            else if (style=="right")
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            else if (style == "bold")
                dgv.Columns[colName].DefaultCellStyle.Font= new Font("Arial", 10, FontStyle.Bold);

        }
    }
}
