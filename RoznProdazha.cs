using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using Npgsql;
using System.Windows.Forms;
using Core.Controllers.RoznProdazha;
namespace AutoMir2022
{
    public partial class retail : Form

    {
        public retail()
        {
            InitializeComponent();

            showAllTovar();
            RoznichProdazha roznProdazhaObj = new RoznichProdazha();

            // add course valuty
            kursValyuti.Text = "Курс валюты= "+ roznProdazhaObj.GetCursValyuti().ToString()+ "ТJS";
           
            // add date
            DateTime today = DateTime.Today;
            date.Text = today.ToString();
           
            // datagrid column width size karzina 1

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 260;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 240;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 60;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }

        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {

            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            DataTable alternativa = new DataTable();                    
            string[] arrayforKarzina2 = new List<string>().Concat(roznProdazhaObj.GetDataGridViewRowinArray(ref dataGridView1)).ToArray();

            //add array data to karzina 2... info about tovar
            string[,] arrayForfilter = new string[1, 2];

            for (int i = 0; i < 1; i++)
            {

                //get alternativa from table tovar for geting all possibla alternativ goods
                
                arrayForfilter[0,0]= "альтернатива";
                arrayForfilter[0, 1] = arrayforKarzina2[5];
                alternativa = roznProdazhaObj.ByFilterTovar(arrayForfilter);


                foreach (DataRow dr in alternativa.Rows)
                {
                    // datagrid column width size karzina 2
                    // "SELECT артикул, наименование, бренд, марка, "
                    // +модель, альтернатива, количество, розн_цена__euro_, группа

                    dataGridView2.Rows.Add(dr[5], dr[0], dr[1], dr[2], dr[6], dr[7]);
                    
                }

            }

        }
        private void retail_Load(object sender, EventArgs e)
        {

        }

              

        private void search_Click(object sender, EventArgs e)
        {
            string[] combovalue = new string[5] { Brand.Text, marka.Text, gruppa.Text, artikul.Text, naimenovanie.Text };
            int result = combovalue.Count(s => s != "");

            string[,] comboColName= new string [5,2] { { "бренд", Brand.Text.Trim() } , {"марка", marka.Text.Trim() }, {"группа", gruppa.Text.Trim() }, {"артикул", artikul.Text.Trim() }, { "наименование", naimenovanie.Text.Trim() } };
            
            string[,] filterQueryColumn= new string[result, 2];
            int j = 0;
            
            for (int i = 0;i< comboColName.Length/2-1; i++)
            {
                if (comboColName[i, 1] != "")
                {
                    filterQueryColumn[j, 0] = comboColName[i, 0];
                    filterQueryColumn[j, 1] = comboColName[i, 1];
                    j = j+1;
                }

            }

            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.ByFilterTovar(filterQueryColumn);
            dataGridView1.DataSource = mydataTable;

            
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            showAllTovar();
        }

        public void showAllTovar()
        {
            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.Index();
            dataGridView1.DataSource = mydataTable;

            Brand.DisplayMember = "бренд";
            Brand.DataSource = roznProdazhaObj.selectColumnDistinct(mydataTable, "бренд");

            marka.DisplayMember = "марка";
            marka.DataSource = roznProdazhaObj.selectColumnDistinct(mydataTable, "марка");

            gruppa.DisplayMember = "группа";
            gruppa.DataSource = roznProdazhaObj.selectColumnDistinct(mydataTable, "группа");

            artikul.DisplayMember = "артикул";
            artikul.DataSource = roznProdazhaObj.selectColumnDistinct(mydataTable, "артикул");

            naimenovanie.DisplayMember = "наименование";
            naimenovanie.DataSource = roznProdazhaObj.selectColumnDistinct(mydataTable, "наименование");

            Brand.SelectedItem = null;
            marka.SelectedItem = null;
            gruppa.SelectedItem = null;
            artikul.SelectedItem = null;
            naimenovanie.SelectedItem = null;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
       
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Columns[e.ColumnIndex].Name == "kolZakaza")
            {
                double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena"].Value);
                double b = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value);
                dataGridView2.Rows[e.RowIndex].Cells[6].Value = (a * b).ToString("0.00");

            }

            if (dataGridView2.Columns[e.ColumnIndex].Name == "vibor")
            {
                //double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells[6].Value);
                //double b = Convert.ToDouble(suma.Text);
                
                //suma.Text = (a + b).ToString("0.00");

            }

        }



    }

}
