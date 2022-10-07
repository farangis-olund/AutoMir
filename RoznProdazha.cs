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
using NickBuhro.NumToWords.Russian ;
using Core.DB;
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
            skidkaValue.Text = "0";
            // add date


            date.Text = DateTime.Now.ToString("MM/dd/yyyy");
            

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

        //add data from karizna 1 to karzina2 when user klicking to row of daagridview1
        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {

            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            DataTable alternativa = new DataTable();
            string[] arrayforKarzina2 = new List<string>().Concat(roznProdazhaObj.GetDataGridViewRowinArray(ref dataGridView1)).ToArray();

            //add array data to karzina 2... info about tovar
            string[,] arrayForfilter = new string[1, 2];

            //get alternativa from table tovar for geting all possibla alternativ goods
            bool isChecked = tolkoOdinArtikul.Checked;
            if (isChecked)
            {

                arrayForfilter[0, 0] = "артикул";
                arrayForfilter[0, 1] = arrayforKarzina2[0];

            }
            else
            {
                arrayForfilter[0, 0] = "альтернатива";
                arrayForfilter[0, 1] = arrayforKarzina2[5];

            }

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

                if (isChecked && i == 1) break;

                if (i == 4) break;

                this.dataGridView2.Rows[index].Cells[0].Value = dr[5];
                this.dataGridView2.Rows[index].Cells[1].Value = dr[1];

                // kolichestvo 2,3,4,5
                this.dataGridView2.Rows[index].Cells[2 + i].Value = dr[6];

                // tsena 19,20,21,22
                this.dataGridView2.Rows[index].Cells[19 + i].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                // summa 7,9,11,13
                this.dataGridView2.Rows[index].Cells[7 + sumaRowCounter].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                // brand 8,10,12,14
                this.dataGridView2.Rows[index].Cells[8 + sumaRowCounter].Value = dr[2];

                // artikul 15,16,17,18
                this.dataGridView2.Rows[index].Cells[15 + i].Value = dr[0];

                i = i + 1;
                sumaRowCounter = sumaRowCounter + 2;
            }
            if (i < 4 && tolkoOdinArtikul.Checked == false)
            {
                for (int k = i; k < 4; k++) {

                    // kolichestvo 2,3,4,5
                    this.dataGridView2.Rows[index].Cells[2 + k].Value = this.dataGridView2.Rows[index].Cells[(2 + k) - 1].Value;


                    // brand 8,10,12,14
                    this.dataGridView2.Rows[index].Cells[8 + sumaRowCounter].Value = this.dataGridView2.Rows[index].Cells[(8 + sumaRowCounter) - 2].Value;

                    // tsena 19,20,21,22
                    this.dataGridView2.Rows[index].Cells[19 + k].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(19 + k) - 1].Value));

                    // summa 7,9,11,13
                    this.dataGridView2.Rows[index].Cells[7 + sumaRowCounter].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(7 + sumaRowCounter) - 2].Value));

                    // artikul 15,16,17,18
                    this.dataGridView2.Rows[index].Cells[15 + k].Value = this.dataGridView2.Rows[index].Cells[(15 + k) - 1].Value;
                    sumaRowCounter = sumaRowCounter + 2;
                }


            }




        }
     

        private void search_Click(object sender, EventArgs e)
        {
            string[] combovalue = new string[5] { Brand.Text, marka.Text, gruppa.Text, artikul.Text, naimenovanie.Text };
            int result = combovalue.Count(s => s != "");

            string[,] comboColName = new string[5, 2] { { "бренд", Brand.Text.Trim() }, { "марка", marka.Text.Trim() }, { "группа", gruppa.Text.Trim() }, { "артикул", artikul.Text.Trim() }, { "наименование", naimenovanie.Text.Trim() } };

            string[,] filterQueryColumn = new string[result, 2];
            int j = 0;

            for (int i = 0; i < comboColName.Length / 2 - 1; i++)
            {
                if (comboColName[i, 1] != "")
                {
                    filterQueryColumn[j, 0] = comboColName[i, 0];
                    filterQueryColumn[j, 1] = comboColName[i, 1];
                    j = j + 1;
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
                dataGridView2.Rows[e.RowIndex].Cells[13].Value = (a * b).ToString("0.00");



            }

     

        }



        private void variantVibor_Click(object sender, EventArgs e)
        {
            double skidka = 0;
            bool isChecked = prodazhaSoSkidkoy.Checked;
            if (isChecked && skidkaValue.Text != "")
            {
                skidka = Convert.ToDouble(skidkaValue.Text);

            }
            else if (isChecked && skidkaValue.Text == "")
            {
                variant1.Checked = false;
                variant2.Checked = false;
                variant3.Checked = false;
                variant4.Checked = false;
                MessageBox.Show("Вы выбрали продажой со скидкой, укажите процент скидки!");
                goto endProsess;
            }
            string variantvibor = "";
            double kurs = Convert.ToDouble(kursValyuti.Text);
            if (variant1.Checked == true) variantvibor = "artikul1";
            else if (variant2.Checked == true) variantvibor = "artikul2";
            else if (variant3.Checked == true) variantvibor = "artikul3";
            else if (variant4.Checked == true) variantvibor = "artikul4";




            //adding data from datagrizd2 (Karzina2) to datagrid3 (karzina3)


            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            DataTable listArtikulKarzina3 = new DataTable();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                listArtikulKarzina3 = roznProdazhaObj.getviborVariant(dataGridView2.Rows[i].Cells[variantvibor].Value.ToString());
                int index = dataGridView3.Rows.Add();

                foreach (DataRow dr in listArtikulKarzina3.Rows)
                {
                    //    Select артикул, наименование, бренд, марка,
                    //    модель,  место_на_складе, розн_цена__euro_  FROM public.товар WHERE артикул

                    this.dataGridView3.Rows[index].Cells[0].Value = dr[0];
                    this.dataGridView3.Rows[index].Cells[1].Value = dr[1];
                    this.dataGridView3.Rows[index].Cells[2].Value = dr[2];
                    this.dataGridView3.Rows[index].Cells[3].Value = dr[3];
                    this.dataGridView3.Rows[index].Cells[4].Value = dr[4];
                    this.dataGridView3.Rows[index].Cells[8].Value = dr[5];

                    if (dataGridView2.Rows[i].Cells["kolZakaza"].Value.ToString() == "")
                    {
                        MessageBox.Show("Количество заказа не указан!");
                        RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                        roznichProdazhaObj.ochistkaDataGridVeiw(ref dataGridView3);

                        ochiskta();
                    }

                    //    данные из карзини 2 количество заказа, цена и сумма

                    this.dataGridView3.Rows[index].Cells[5].Value = dataGridView2.Rows[i].Cells["kolZakaza"].Value.ToString();
                    this.dataGridView3.Rows[index].Cells[6].Value = roznProdazhaObj.getRoundDecimal((Convert.ToDouble(dr[6]) * kurs));

                    if (skidka != 0) this.dataGridView3.Rows[index].Cells[7].Value = roznProdazhaObj.getRoundDecimal(
                           (Convert.ToDouble(dataGridView2.Rows[i].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs) * skidka / 100);

                    else this.dataGridView3.Rows[index].Cells[7].Value = roznProdazhaObj.getRoundDecimal(
                          (Convert.ToDouble(dataGridView2.Rows[i].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs));

                }

            }



        endProsess: { }


        }

        private void ochistkaKorzini3_Click(object sender, EventArgs e)
        {
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            roznichProdazhaObj.ochistkaDataGridVeiw(ref dataGridView3);

            ochiskta();
        }

        private void ochistkaKarzina2_Click(object sender, EventArgs e)
        {
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            roznichProdazhaObj.ochistkaDataGridVeiw(ref dataGridView2);

            ochiskta();

        }

        public void ochiskta()
        {
            variant1.Checked = false;
            variant2.Checked = false;
            variant3.Checked = false;
            variant4.Checked = false;
        }

        private void tolkoOdinArtikul_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                MessageBox.Show("При уже выбранном артикуле, не можете включить данную опцию");
                tolkoOdinArtikul.Checked = false;
            }
        }

        private void oformitZakaz_Click(object sender, EventArgs e)
        {
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();

            if (viborProdovets.Text == "")
            {
                MessageBox.Show("Перед оформлением, укажите продавца!");
                goto endProsess;

            }

            if (spetsPredlozhenie.Checked == true && spetsPredlozhenieValue.Text == "")
            {
                MessageBox.Show("Вы указали спец. предложение, но не указали кому оформляется спец.предложение!");
                goto endProsess;

            }

            if (dataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали товар в карзину 3, заказ не оформлен!");
                goto endProsess;

            }

            double summaKontrakta = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                
                //проверка остатка на складе достаточен ли для оформление заказа количество товара

                DataTable kolTovara = roznichProdazhaObj.getviborVariant(dataGridView3.Rows[i].Cells[0].Value.ToString());
                double kolTovaraDouble = 0;
                foreach (DataRow dr in kolTovara.Rows)
                {
                    kolTovaraDouble = Convert.ToDouble(dr[7]);
                }
                    
                double kolZakaz = Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value);

                if (kolTovaraDouble < kolZakaz)
                {
                    MessageBox.Show("Не достаточное количество товара на складе, остаток артикул "
                        + dataGridView3.Rows[i].Cells[0].Value.ToString() + " равняется " + kolTovaraDouble.ToString()+ " товар будет удален из карзини!");
                     dataGridView3.Rows.Clear();
                    goto endProsess;
                }
                //////////////

                summaKontrakta = summaKontrakta + Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                

            }

            /// получаем сумму с прописью
            string diram = summaKontrakta.ToString();
            diram = diram.Remove(1, diram.Length - 2) + " дирам";
            long suma = (long)summaKontrakta;
            
            string summaPropisyu = RussianConverter.Format(suma, UnitOfMeasure.Ruble) + " "+ diram;
            ///////////
            ///

            bool check = kontrolProdazhaChek.Checked;
           
            double skidkaSql = Convert.ToDouble(skidkaValue.Text);

            string nakText = "01";
            
            double kurs = Convert.ToDouble(kursValyuti.Text);

            
            DBNpgsql db = new DBNpgsql();
            db.insertProdazha(kurs, skidkaSql, viborProdovets.Text, summaPropisyu,
                    spetsPredlozhenieValue.Text, nakText, check);
            /// получаем код номер накладной

            int nakNomer =roznichProdazhaObj.getNakladnoyNomer(nakText);

            /////////// insert data to table prodazhaTovar

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                double tsenaSql = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value.ToString());
                int kolSql = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                db.insertProdazhaTovar(
                    dataGridView3.Rows[i].Cells[0].Value.ToString(),
                    kolSql, tsenaSql, nakNomer);

            }



            MessageBox.Show("Заказ укспешно оформлен!");


        endProsess: { }
        }
    }

}
