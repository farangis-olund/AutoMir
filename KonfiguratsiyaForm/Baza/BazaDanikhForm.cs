using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.DostupBD;
using Core.Controllers.Klient;
using Core.Controllers.OrgInfo;
using Core.DB;
using Npgsql;

namespace AutoMir2022
{

    public partial class BazaDanikhForm : Form
    {
        private DostupBD dostupBDObj = new DostupBD();
        private int DGVrowNum;
        public BazaDanikhForm()
        {
            InitializeComponent();

        }


        private void BazaDanikhForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void show_Click(object sender, EventArgs e)
        {
            OchistkaDGV(ref dataGridView1);
            dataGridView1.Visible = true;
            var checkedButton = panel1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            dataGridView1.DataSource = dostupBDObj.SelectDB(checkedButton.Text);

        }

       

        private bool checkDgv()
        {
            bool rowIsEmpty = true;

            if (dataGridView1.CurrentRow.Cells.Count > 0)
            {

                foreach (DataGridViewCell cell in dataGridView1.CurrentRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        rowIsEmpty = false;
                        break;
                    }
                }

            }
            return rowIsEmpty;
        }

        private void OchistkaDGV(ref DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.DataSource = null;
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OchistkaDGV(ref dataGridView1);
            var checkedButton = panel1.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked);
           DataTable dt= dostupBDObj.GetTableInfo(checkedButton.Text);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Columns.Add(dt.Rows[i][0].ToString(), dt.Rows[i][0].ToString());
            }
            
           
        }




        private void PasteClipboard(ref DataGridView dgv)
        {
            try
            {
                char[] rowSplitter = { '\r', '\n' };

                char[] columnSplitter = { '\t' };

                //get the text from clipboard

                IDataObject dataInClipboard = Clipboard.GetDataObject();

                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

                //split it into lines

                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

                //get the row and column of selected cell in grid

                int r = dgv.SelectedCells[0].RowIndex;

                int c = dgv.SelectedCells[0].ColumnIndex;

                //add rows into grid to fit clipboard lines

                if (dgv.Rows.Count < (r + rowsInClipboard.Length))

                {

                    dgv.Rows.Add(r + rowsInClipboard.Length - dgv.Rows.Count);

                }

                // loop through the lines, split them into cells and place the values in the corresponding cell.

                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)

                {

                    //split row into cell values

                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

                    //cycle through cell values

                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)

                    {

                        //assign cell value, only if it within columns of the grid

                        if (dgv.ColumnCount - 1 >= c + iCol)

                        {

                            dgv.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];

                        }

                    }

                }
            }
            catch
            {

            }
            
       
        }

        private void paste_Click(object sender, EventArgs e)
        {
           
            
            if (dataGridView1.SelectedRows.Count==0)
            {
                dataGridView1.Rows[0].Cells[0].Selected = true;
            }
            
            PasteClipboard(ref dataGridView1);
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите сохранить выбранную таблицу?", "Очистка таблиц", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    var checkedButton = panel1.Controls.OfType<RadioButton>()
                                    .FirstOrDefault(r => r.Checked);
                    dostupBDObj.InsertAllDBFromDGV(ref dataGridView1, checkedButton.Text);
                    MessageBox.Show("Таблица успешно сохранено!");
                    show.PerformClick();
                } else
                    MessageBox.Show("Таблица не выбрана!");

            }
        }

        private void cleanTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить выбранную таблицу?", "Очистка таблиц", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (dataGridView1.Rows.Count > 0)
                {

                    var checkedButton = panel1.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);
                    dostupBDObj.DeleteAll(checkedButton.Text);
                    MessageBox.Show("Удаление успешно завершено!");

                }
                else
                {   MessageBox.Show("Таблица не выбрана!");
                }
            }
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            DataObject d = dataGridView1.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }

    }
}
