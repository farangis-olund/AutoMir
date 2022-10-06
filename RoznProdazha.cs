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
            kursValyuti.Text = roznProdazhaObj.GetCursValyuti().ToString();
           
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
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }

        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {

            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            DataTable alternativa = new DataTable();                    
            string[] arrayforKarzina2 = new List<string>().Concat(roznProdazhaObj.GetDataGridViewRowinArray(ref dataGridView1)).ToArray();

            //add array data to karzina 2... info about tovar
            string[,] arrayForfilter = new string[1, 2];

                //get alternativa from table tovar for geting all possibla alternativ goods
                
                arrayForfilter[0,0]= "альтернатива";
                arrayForfilter[0, 1] = arrayforKarzina2[5];
                alternativa = roznProdazhaObj.ByFilterTovar(arrayForfilter);

                var index = this.dataGridView2.Rows.Add();
            double kurs = Convert.ToDouble(kursValyuti.Text);
            
                int i = 0;
            // datagrid column width size karzina 2
            // "SELECT артикул, наименование, бренд, марка, "
            // +модель, альтернатива, количество, розн_цена__euro_, группа

            // когда альтернатива больше или 4 то тогда все элементи из бази останутся такими как есть
            alternativa.DefaultView.Sort = "розн_цена__euro_ DESC";
            int sumaRowCounter = 0;
                foreach (DataRow dr in alternativa.Rows)
                {
                
                if (i == 4) break;

                this.dataGridView2.Rows[index].Cells[0].Value = dr[5];
                this.dataGridView2.Rows[index].Cells[1].Value = dr[1];

                // kolichestvo 2,3,4,5
                this.dataGridView2.Rows[index].Cells[2 + i].Value = dr[6];
                
                    // tsena 19,20,21,22
                    this.dataGridView2.Rows[index].Cells[19 + i].Value =Convert.ToDouble(dr[7])*kurs;

                    // summa 7,9,11,13
                    this.dataGridView2.Rows[index].Cells[7 + sumaRowCounter].Value = Convert.ToDouble(dr[7]) * kurs;

                // brand 8,10,12,14
                this.dataGridView2.Rows[index].Cells[8 + sumaRowCounter].Value = dr[2];

                // artikul 15,16,17,18
                this.dataGridView2.Rows[index].Cells[15 + i].Value = dr[0];

                    i = i + 1;
                sumaRowCounter = sumaRowCounter + 2;
                }
                if (i < 4)
                {
                for (int k=i; k< 4; k++) {

                    // kolichestvo 2,3,4,5
                    this.dataGridView2.Rows[index].Cells[2 + k].Value = this.dataGridView2.Rows[index].Cells[(2 +k)-1].Value;

                   
                    // brand 8,10,12,14
                    this.dataGridView2.Rows[index].Cells[8 + sumaRowCounter].Value = this.dataGridView2.Rows[index].Cells[(8 + sumaRowCounter)-2].Value;

                    // tsena 19,20,21,22
                    this.dataGridView2.Rows[index].Cells[19 + k].Value = Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(19 + k) - 1].Value)  ;

                    // summa 7,9,11,13
                    this.dataGridView2.Rows[index].Cells[7+ sumaRowCounter].Value = Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(7 +sumaRowCounter)-2].Value) ;

                    // artikul 15,16,17,18
                    this.dataGridView2.Rows[index].Cells[15 + k].Value = this.dataGridView2.Rows[index].Cells[(15 + k) - 1].Value;
                    sumaRowCounter = sumaRowCounter + 2;
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

        //datagrid2 karzina2       
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView2.Columns[e.ColumnIndex].Name == "kolZakaza")
            {
                double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena1"].Value);
                double b = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value);
                dataGridView2.Rows[e.RowIndex].Cells[7].Value = (a * b).ToString("0.00");

                 a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena2"].Value);
                 b = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value);
                dataGridView2.Rows[e.RowIndex].Cells[9].Value = (a * b).ToString("0.00");

                 a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena3"].Value);
                b = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value);
                dataGridView2.Rows[e.RowIndex].Cells[11].Value = (a * b).ToString("0.00");

                 a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena4"].Value);
                 b = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value);
                dataGridView2.Rows[e.RowIndex].Cells[13].Value = (a * b ).ToString("0.00");



            }

            if (dataGridView2.Columns[e.ColumnIndex].Name == "vibor")
            {
                //double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells[6].Value);
                //double b = Convert.ToDouble(suma.Text);
                
                //suma.Text = (a + b).ToString("0.00");

            }

        }

       

        private void addKarzina3_Click(object sender, EventArgs e)
        {
            bool isChecked = prodazhaSoSkidkoy.Checked;
            if (isChecked && skidkaValue.Text != "")
            {
                double skidka = Convert.ToDouble(skidkaValue.Text);
            
            }
            else if (isChecked && skidkaValue.Text == "")
            {
                variant1.Checked = false;
                variant2.Checked = false;
                variant3.Checked = false;
                variant4.Checked = false;
                
                goto endProcess;
            }
            string variantvibor = "";
            double kurs = Convert.ToDouble(kursValyuti.Text);
            if (variant1.Checked == true)  variantvibor = "artikul1";
             else if(variant2.Checked == true) variantvibor = "artikul2";
            else if (variant3.Checked == true) variantvibor = "artikul3";
            else if (variant4.Checked == true) variantvibor = "artikul4";




            //adding data from datagrizd2 (Karzina2) to datagrid3 (karzina3)


            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            DataTable listArtikulKarzina3 = new DataTable();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
               listArtikulKarzina3=roznProdazhaObj.getviborVariant(dataGridView2.Rows[i].Cells[variantvibor].Value.ToString());
                int index = dataGridView3.Rows.Add();

                foreach (DataRow dr in listArtikulKarzina3.Rows)
                {
                    //    Select артикул, наименование, бренд, марка,
                    //    модель,  место_на_складе, розн_цена__euro_  FROM public.товар WHERE артикул

                    this.dataGridView2.Rows[index].Cells[0].Value = dr[0];
                    this.dataGridView2.Rows[index].Cells[1].Value = dr[1];
                    this.dataGridView2.Rows[index].Cells[2].Value = dr[2];
                    this.dataGridView2.Rows[index].Cells[3].Value = dr[3];
                    this.dataGridView2.Rows[index].Cells[4].Value = dr[4];
                    this.dataGridView2.Rows[index].Cells[8].Value = dr[5];

                    //    данные из карзини 2 количество заказа, цена и сумма

                    this.dataGridView2.Rows[index].Cells[5].Value = dataGridView2.Rows[i].Cells["kolZakaza"].Value.ToString();
                    this.dataGridView2.Rows[index].Cells[6].Value = Convert.ToDouble(dr[6]) * kurs;
                    this.dataGridView2.Rows[index].Cells[7].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs;


                }

            }

            //if (this.dataGridView3.DataSource != null)
            //{
            //    this.dataGridView3.DataSource = null;
            //}
            //else
            //{
            //    this.dataGridView3.Rows.Clear();
            //}



        endProcess:
            MessageBox.Show("Вы выбрали продажой со скидкой, укажите процент скидки!");
        }

        private void variant1_CheckedChanged(object sender, EventArgs e)
        {
            
            

        }
    }

}
