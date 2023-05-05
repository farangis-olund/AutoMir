using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.Controllers.RoznichProdazha;
using Core.Controllers.OtmenaProdazhi;
using Core.DB;
using Core.Controllers.ProverkaNaOshibku;
using Core.Controllers;
using Core.DesignForms;

namespace AutoMir2022
{
    public partial class retail : Form


    {
        private RoznichProdazha roznProdazhaObj = new RoznichProdazha();
        private OtmenaProdazhi otmenaProdazhiObj = new OtmenaProdazhi();

        public static DataTable dtForCHekReport;
        public static string nameOfReport;
        public retail()
        {
        
            
            InitializeComponent();
            
            showAllTovar();

            // add course valuty
            KursValyuti kursValyutiObj = new KursValyuti();
            kursValyuti.Text = kursValyutiObj.GetKursValyuti().ToString();

            //довавить продавцы в компбо
            viborProdovets.DisplayMember = "продавец";
            viborProdovets.DataSource = roznProdazhaObj.getNameSeller();
            viborProdovets.Text = null;


            // add date

            date.Text = DateTime.Now.ToString("dd/MM/yyyy");


            // datagrid column width size karzina 1

           

            //forma sklad
            SkladFrm myForm = new SkladFrm();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.closeButton = true;
            this.dataPanel.Controls.Add(myForm);
            myForm.Show();

            //forma mesto na sklade
            MestoNaSkladeFrm myFormSklad = new MestoNaSkladeFrm();
            myFormSklad.TopLevel = false;
            myFormSklad.AutoScroll = true;
            myFormSklad.FormBorderStyle = FormBorderStyle.None;
            this.mestoNaSkladePanel.Controls.Add(myFormSklad);
            myFormSklad.Show();

            //forma mesto na sklade

            ChekFrm myFormChek = new ChekFrm()
            {
                TopLevel = false,
                AutoScroll = true,
                FormBorderStyle = FormBorderStyle.None
            };

            if (this.chekPanel != null)
            {
                this.chekPanel.Controls.Add(myFormChek);
            }

            myFormChek.Show();

            //ChekFrm myFormChek = new ChekFrm();
            //myFormChek.TopLevel = false;
            //myFormChek.AutoScroll = true;
            //myFormChek.FormBorderStyle = FormBorderStyle.None;
            //this.chekPanel.Controls.Add(myFormChek);
            //myFormChek.Show();




            //add nakladnoy tab OtmenaProdazhi

            nakNomerOtmenaCmb.DisplayMember = "накладной_текст";
            nakNomerOtmenaCmb.DataSource = otmenaProdazhiObj.SelectNomerNakladnoy();
            nakNomerOtmenaCmb.Text = null;


        }

        //add data from karizna 1 to karzina2 when user klicking to row of daagridview1
        
        
        private void deleteFirstRowForSumTable(ref DataGridView dgv)
        {
            //удалаем строку с итогом суммой
            //

            int rowNum = dgv.Rows.Count;

            if (rowNum > 0)
            {

                if (dgv.Rows[rowNum - 1].Cells[0].Value == null)
                {
                    dgv.Rows.Remove(dgv.Rows[rowNum - 1]);

                }
            }
        }
        
        
        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {
            //удаляем строку сумму в таблице, чтобы добавить новую строку
            deleteFirstRowForSumTable(ref dataGridView2);

            if (kursValyuti.Text.Trim() == "" || kursValyuti.Text.Trim() == "0")
            {
                MessageBox.Show("Курс валюты не указан, для выбора товара укажите курс валюты!");
                goto endProsess;

            }


            //проверка на наличие артикула в карзине 2
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


            double kurs = Convert.ToDouble(kursValyuti.Text);

            int i = 0;
            // datagrid column width size karzina 2
            // "SELECT артикул, наименование, бренд, марка, "
            // +модель, альтернатива, количество, розн_цена__euro_, группа

            // когда альтернатива больше или 4 то тогда все элементи из бази останутся такими как есть
            if (alternativa.Rows.Count == 0)
            {
                MessageBox.Show("Выбранный артикул данный момент не имеется в наличии!");
                goto endProsess;
            }



            alternativa.DefaultView.Sort = "розн_цена__euro_ DESC";
            var index = this.dataGridView2.Rows.Add();

            int sumaRowCounter = 0;
            foreach (DataRow dr in alternativa.Rows)
            {

                if (isChecked && i == 1) break; /*ischecked is tolko odin artikul*/

                if (i == 4) break;

                this.dataGridView2.Rows[index].Cells[0].Value = dr[5];
                this.dataGridView2.Rows[index].Cells[1].Value = dr[1];

                // kolichestvo 2,3,4,5
                this.dataGridView2.Rows[index].Cells[2 + i].Value = dr[6];

                // tsena 19,20,21,22
                if (dr[7].ToString() != "")
                {
                    this.dataGridView2.Rows[index].Cells[19 + i].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                }
                else
                {
                    MessageBox.Show("Цена данного артикула не указан!");
                    this.dataGridView2.Rows.Remove(this.dataGridView2.Rows[index]);

                    goto endProsess;
                }


                // summa 7,9,11,13
                this.dataGridView2.Rows[index].Cells[7 + sumaRowCounter].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                // brand 8,10,12,14
                this.dataGridView2.Rows[index].Cells[8 + sumaRowCounter].Value = dr[2];

                // artikul 15,16,17,18

                if (dataGridView2.Rows.Count > 1)
                {
                    bool artikul1IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul1");
                    bool artikul2IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul2");
                    bool artikul3IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul3");
                    bool artikul4IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul4");

                    if (artikul1IsExist == true || artikul2IsExist == true || artikul3IsExist == true || artikul4IsExist == true)
                    {
                        MessageBox.Show("Данный артикул уже добавлен в карзину!");
                        this.dataGridView2.Rows.Remove(this.dataGridView2.Rows[index]);

                        goto endProsess;
                    }
                }

                this.dataGridView2.Rows[index].Cells[15 + i].Value = dr[0];

                //// проверяем на наличие распродажи для выбранного артикула
                RasprodazhaBonus rasprodazhaBonusObj = new RasprodazhaBonus();

                rasprodazhaBonusObj.RaspradazhaArtikulColor(ref dataGridView2, index, 7 + sumaRowCounter, dr[0].ToString());

                i = i + 1;
                sumaRowCounter = sumaRowCounter + 2;
            }
            if (i < 4 && tolkoOdinArtikul.Checked == false)
            {
                for (int k = i; k < 4; k++)
                {

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

            
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.DodgerBlue;


        endProsess: { }
            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", 0);
           

        }


        private void search_Click(object sender, EventArgs e)
        {
            string[] combovalue = new string[6] { Brand.Text, marka.Text, gruppa.Text, artikul.Text, naimenovanie.Text, txtKlyuchevoeSlova.Text };
            int result = combovalue.Count(s => s != "");

            string klyuchev = "%" + txtKlyuchevoeSlova.Text.Trim() + "%";
            string[,] comboColName = new string[6, 2] { { "бренд", Brand.Text.Trim() }, { "марка", marka.Text.Trim() }, { "группа", gruppa.Text.Trim() }, { "артикул", artikul.Text.Trim() }, { "наименование", naimenovanie.Text.Trim() }, { "наименование", klyuchev } };

            string[,] filterQueryColumn = new string[result, 2];
            int j = 0;

            for (int i = 0; i < comboColName.Length / 2; i++)
            {
                if (comboColName[i, 1] != "" && comboColName[i, 1] != "%%")
                {
                    filterQueryColumn[j, 0] = comboColName[i, 0];
                    filterQueryColumn[j, 1] = comboColName[i, 1];
                    j = j + 1;
                }

            }

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
            dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.Index();
            dataGridView1.DataSource = mydataTable;

            tolkoOdinArtikul.Checked = false;

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

            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 220;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        //datagrid2 karzina2       
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView2.Columns[e.ColumnIndex].Name == "kolZakaza")
            {
                int b = 0;

                ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView2, e.RowIndex, "kolZakaza") == true)
                    goto endProcess;


                if (int.TryParse(dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value.ToString(), out b))
                {
                    double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena1"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena2"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[9].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena3"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[11].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena4"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[13].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();
                    roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", 1);
                    
                    FormElementDesign.SetAligementDataGridview(ref dataGridView2, "kolZakaza", "bold");
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value = null;
                }
              
            }
        endProcess: { }
        }

        private void addDataFromKarzina2ToKarzina3(bool groupVibor, int dgvRow, string dgvColName)
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
            if (variant1.Checked == true || dgvColName == "suma1") variantvibor = "artikul1";
            else if (variant2.Checked == true || dgvColName == "suma2") variantvibor = "artikul2";
            else if (variant3.Checked == true || dgvColName == "suma3") variantvibor = "artikul3";
            else if (variant4.Checked == true || dgvColName == "suma4") variantvibor = "artikul4";

            //adding data from datagrizd2 (Karzina2) to datagrid3 (karzina3)

            DataTable listArtikulKarzina3 = new DataTable();
            int rowCounter;
            if (groupVibor == true)
            {
                rowCounter = dataGridView2.Rows.Count - 1;
            }
            else
            {
                rowCounter = 1;
                //удалаем последную строку суммы, чтобы добавить новую строку для нового артикула
                
            }
            for (int i = 0; i < rowCounter; i++)
            {
                int rowDgv;
                //если вариант из radioButton выбран то будет в цикле перенесены все поля в датагрид3 
                if (groupVibor == true) rowDgv = i;
                else rowDgv = dgvRow;

                listArtikulKarzina3 = roznProdazhaObj.getviborVariant(dataGridView2.Rows[rowDgv].Cells[variantvibor].Value.ToString());

                //добавляем поле в datagrid3
                //
                deleteFirstRowForSumTable(ref dataGridView3);

                int index = dataGridView3.Rows.Add();

                foreach (DataRow dr in listArtikulKarzina3.Rows)
                {
                    //    Select артикул, наименование, бренд, марка,
                    //    модель,  место_на_складе, розн_цена__euro_  FROM public.товар WHERE артикул

                    bool artikulIsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView3, dr[0].ToString(), "artikulKarzina3");

                    if (artikulIsExist == true)
                    {
                        MessageBox.Show("Данный артикул уже добавлен в карзину!");
                        this.dataGridView3.Rows.Remove(this.dataGridView3.Rows[index]);

                        goto endProsess;
                    }

                    if (Convert.ToInt32(dr[7]) < Convert.ToInt32(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value))
                    {
                        MessageBox.Show("Количество заказа превышает количество товара в магазине!");
                        roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView3);
                        ochiskta();
                        dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value = "";
                        
                        goto endProsess;
                    }


                    this.dataGridView3.Rows[index].Cells[0].Value = dr[0];
                    this.dataGridView3.Rows[index].Cells[1].Value = dr[1];
                    this.dataGridView3.Rows[index].Cells[2].Value = dr[2];
                    this.dataGridView3.Rows[index].Cells[3].Value = dr[3];
                    this.dataGridView3.Rows[index].Cells[4].Value = dr[4];
                    this.dataGridView3.Rows[index].Cells[8].Value = dr[5];

                    if (Convert.ToString(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value) == "")
                    {
                        MessageBox.Show("Количество заказа не указан!");
                        roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView3);

                        ochiskta();
                        goto endProsess;
                    }

                    //    данные из карзини 2 количество заказа, цена и сумма

                    this.dataGridView3.Rows[index].Cells[5].Value = dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value.ToString();


                    if (skidka != 0)
                    {
                        this.dataGridView3.Rows[index].Cells[6].Value = roznProdazhaObj.getRoundDecimal(
                            Convert.ToDouble(dr[6]) * kurs - Convert.ToDouble(dr[6]) * kurs * skidka / 100);

                        this.dataGridView3.Rows[index].Cells[7].Value = roznProdazhaObj.getRoundDecimal(
                        (Convert.ToInt32(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value) *
                        Convert.ToDouble(dr[6]) * kurs) -
                        (Convert.ToInt32(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs) * skidka / 100);
                    }
                    else
                    {
                        this.dataGridView3.Rows[index].Cells[6].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[6]) * kurs);
                        this.dataGridView3.Rows[index].Cells[7].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToInt32(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs);
                    }
                }

            }
            dataGridView2.Rows[dgvRow].Cells[dgvColName].Style.BackColor = Color.DodgerBlue;

        endProsess: { }
            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView3, "sumaKarzina3", "", "", "", 0);

        }

        private void variantVibor_Click(object sender, EventArgs e)
        {
            addDataFromKarzina2ToKarzina3(true, 0, "");
        }

        private void ochistkaKorzini3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить карзину?", "Очистка карзины", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView3);
                roznProdazhaObj.ResetDataGridViewBackColor(ref dataGridView2);
                ochiskta();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void ochistkaKarzina2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить карзину?", "Очистка карзины", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView2);
                roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView3);
                showAllTovar();
                ochiskta();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            

        }

        public void ochiskta()
        {
            variant1.Checked = false;
            variant2.Checked = false;
            variant3.Checked = false;
            variant4.Checked = false;
            kontrolProdazhaChek.Checked = false;
            skidkaValue.Text = "";
            prodazhaSoSkidkoy.Checked = false;


        }

        private void tolkoOdinArtikul_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                MessageBox.Show("При уже выбранном артикуле, не можете включить данную опцию");
                tolkoOdinArtikul.Checked = false;
            }
        }


        private void proverkaKolTovara()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                
                //проверка остатка на складе достаточен ли для оформление заказа количество товара

                DataTable kolTovara = roznProdazhaObj.getviborVariant(dataGridView2.Rows[i].Cells[0].Value.ToString());
                double kolTovaraDouble = 0;
                foreach (DataRow dr in kolTovara.Rows)
                {
                    kolTovaraDouble = Convert.ToDouble(dr[7]);
                }

                double kolZakaz = Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value);

                if (kolTovaraDouble < kolZakaz)
                {
                    MessageBox.Show("Не достаточное количество товара на складе, остаток артикул "
                        + dataGridView3.Rows[i].Cells[0].Value.ToString() + " равняется " + kolTovaraDouble.ToString() + " товар будет удален из карзини!");
                    dataGridView3.Rows.Clear();
                    ochiskta();

                }
                //////////////


            }

        }


        private void oformitZakaz_Click(object sender, EventArgs e)
        {
           
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



            if (kursValyuti.Text.Trim() == "" || kursValyuti.Text.Trim() == "0")
            {
                MessageBox.Show("Курс валюты не указан, для выбора товара укажите курс валюты!");
                goto endProsess;

            }


            double summaKontrakta = 0;

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {

                //проверка остатка на складе достаточен ли для оформление заказа количество товара

                DataTable kolTovara = roznProdazhaObj.getviborVariant(dataGridView3.Rows[i].Cells[0].Value.ToString());
                double kolTovaraDouble = 0;
                foreach (DataRow dr in kolTovara.Rows)
                {
                    kolTovaraDouble = Convert.ToDouble(dr[7]);
                }

                double kolZakaz = Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value);

                if (kolTovaraDouble < kolZakaz)
                {
                    MessageBox.Show("Не достаточное количество товара на складе, остаток артикул "
                        + dataGridView3.Rows[i].Cells[0].Value.ToString() + " равняется " + kolTovaraDouble.ToString() + " товар будет удален из карзини!");
                    dataGridView3.Rows.Clear();
                    ochiskta();
                    goto endProsess;
                }
                //////////////

                summaKontrakta = summaKontrakta +Convert.ToDouble( roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value)));


            }

                        
            bool check = kontrolProdazhaChek.Checked;
            if (skidkaValue.Text == "") skidkaValue.Text = "0";
            int skidkaSql = Int16.Parse(skidkaValue.Text);
            double kurs = Convert.ToDouble(kursValyuti.Text);


            DBNpgsql db = new DBNpgsql();

            int nakKod = roznProdazhaObj.getLastNakladnoyText();
            string nakText = roznProdazhaObj.GetColumnName(nakKod+1);  /*roznichProdazhaObj.nakTextEncrement(nakText);*/

            db.insertProdazha(kurs, skidkaSql, viborProdovets.Text, roznProdazhaObj.SummaPropis(summaKontrakta),
                    spetsPredlozhenieValue.Text, nakText, check);

            /// получаем код номер накладной

            int nakNomer = roznProdazhaObj.getNakladnoyNomer(nakText);

            /////////// insert data to table prodazhaTovar

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                double tsenaSql =Convert.ToDouble( roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value.ToString())));
                int kolSql = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                db.insertProdazhaTovar(
                    dataGridView3.Rows[i].Cells[0].Value.ToString(),
                    kolSql, tsenaSql, nakNomer);

                /////////// update data to table Tovar

                roznProdazhaObj.updateTovarKol(dataGridView3.Rows[i].Cells[0].Value.ToString(), kolSql, "-");
            }



            MessageBox.Show("Заказ укспешно оформлен!");

            printCkekDetails(nakText);

            roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView2);
            roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView3);
            showAllTovar();
            ochiskta();
        endProsess: { }
        }

        private void btnAddKurs_Click(object sender, EventArgs e)
        {
            KursValyuti kursValyutiObj = new KursValyuti();
            kursValyuti.Text= kursValyutiObj.UpdateKursValyuti();
        }

        public void printCkekDetails(string nakTxt)
        {
            
            dtForCHekReport = roznProdazhaObj.chekProdazhaQuery(nakTxt);

            bool ischecked = prodazhaSoSkidkoy.Checked;
            if (ischecked == true)
            {
                nameOfReport = "ChekReportSkidka";
                //roznichProdazhaObj.printCkek(roznichProdazhaObj.chekProdazhaQuery(nakTxt), "ChekReportSkidka");

            }
            else
            {
                nameOfReport = "ChekReport";
                //roznichProdazhaObj.printCkek(roznichProdazhaObj.chekProdazhaQuery(nakTxt), "ChekReport");

            }

            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();
        }

        private void prodazhaSoSkidkoy_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = prodazhaSoSkidkoy.Checked;
            if (isChecked && skidkaValue.Text == "" && dataGridView3.Rows.Count > 0)
            {
                MessageBox.Show("Вы выбрали опцию продажа со скидкой после того как добавили артикули в карзину 3," +
                                " для того чтобы продажа оформилась со скидкой, сперва выберети скидку а затем добавьте товары в карзину 3!");

                dataGridView3.Rows.Clear();

                variant1.Checked = false;
                variant2.Checked = false;
                variant3.Checked = false;
                variant4.Checked = false;
            }
        }


        private void otmenaProdazhiDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double b = 0;
            if (otmenaProdazhiDGV.Columns[e.ColumnIndex].Name == "kolVozvrata")
            {

                if (Double.TryParse(otmenaProdazhiDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value.ToString(), out b))
                {
                    int kol = int.Parse(otmenaProdazhiDGV.Rows[e.RowIndex].Cells["kolOtmena"].Value.ToString());
                    if (b > kol)
                    {
                        MessageBox.Show("Количество отмены превышает количество заказа!");
                        otmenaProdazhiDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value = null;
                    }
                    else
                    {
                        double a = Convert.ToDouble(otmenaProdazhiDGV.Rows[e.RowIndex].Cells["tsenaOtmena"].Value);
                        otmenaProdazhiDGV.Rows[e.RowIndex].Cells["sumaVozvrata"].Value = (a * b).ToString("0.00");
                        roznProdazhaObj.SumOfColumnDataGridVeiw(ref otmenaProdazhiDGV, "sumaVozvrata", "", "", "", 1);
                    }

                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    otmenaProdazhiDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value = null;
                }
                
                

            }

        }

        private void otmenaProdazhiBtn_Click(object sender, EventArgs e)
        {
          
            DBNpgsql dBNpgsqlObj = new DBNpgsql();
            if (otmenaProdazhiDGV.Rows.Count == 0) {
                MessageBox.Show("Вы не выбрали товар для отмени продаж!");
                goto EndProcess; 
            }
            int kod = otmenaProdazhiObj.SelectNomerVozvrata();
            
            for (int i = 0; i < otmenaProdazhiDGV.Rows.Count - 1; i++)
            {
                bool isChecked =Convert.ToBoolean(otmenaProdazhiDGV.Rows[i].Cells[0].Value);
                if(isChecked==true && otmenaProdazhiDGV.Rows[i].Cells["kolVozvrata"].Value==null)
                {
                    MessageBox.Show("Для выбронного артикула не указан количество возврата!");
                    goto EndProcess;
                }
                else if (isChecked == true && otmenaProdazhiDGV.Rows[i].Cells["kolVozvrata"].Value != null)
                {
                    //добавляем в таблицу отмена продажа с таблицы продажа и продажа товара 

                    otmenaProdazhiObj.InsertOtmenaProdazh(nakNomerOtmenaCmb.Text, otmenaProdazhiDGV.Rows[i].Cells[1].Value.ToString());
                    
                    int kolVozvrata = int.Parse(otmenaProdazhiDGV.Rows[i].Cells["kolVozvrata"].Value.ToString());
                    int kolProdazha = int.Parse(otmenaProdazhiDGV.Rows[i].Cells["kolOtmena"].Value.ToString());
                    double tsena = double.Parse(otmenaProdazhiDGV.Rows[i].Cells["tsenaOtmena"].Value.ToString());
                    
                    
                   double suma = kolVozvrata * tsena;
                   
                    //обновляет таблицу отмена продажа с количеством возврата и суммой 
                    dBNpgsqlObj.UpdateOtmenaProdazh(nakNomerOtmenaCmb.Text, otmenaProdazhiDGV.Rows[i].Cells[1].Value.ToString(),
                        kolVozvrata, suma, kod);

                    if (kolVozvrata == kolProdazha) otmenaProdazhiObj.DeleteProdazhaTovara(nakNomerOtmenaCmb.Text,
                       otmenaProdazhiDGV.Rows[i].Cells[1].Value.ToString());

                    if (kolVozvrata < kolProdazha) otmenaProdazhiObj.updateProdazha(nakNomerOtmenaCmb.Text, 
                        otmenaProdazhiDGV.Rows[i].Cells[1].Value.ToString(),kolProdazha-kolVozvrata);

                    roznProdazhaObj.updateTovarKol(otmenaProdazhiDGV.Rows[i].Cells[1].Value.ToString(), kolVozvrata, "+");
                    
                }
            
            
            }

            //сумма прописю 
            string propis = otmenaProdazhiObj.SelectSummaOtmenaProdazh(nakNomerOtmenaCmb.Text, kod);
            if (propis != null)
            {
            
                string summaPropis = roznProdazhaObj.SummaPropis(double.Parse(propis));
                otmenaProdazhiObj.UpdatePropisOtmenaProdazh(nakNomerOtmenaCmb.Text, summaPropis);
            }

            //при отмени всех товаров удаляем вес заказ из таблицы продажа 

            if (otmenaProdazhiObj.SelectDataDGV(nakNomerOtmenaCmb.Text).Rows.Count == 0)
            {
                otmenaProdazhiObj.DeleteProdazha(nakNomerOtmenaCmb.Text);
            }
            kodVozvrataTxb.Text = kod.ToString();
            DataTable dt = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
            string kodKlienta = "";
            foreach (DataRow dr in dt.Rows)
            {
                kodKlienta = dr["kodKlienta"].ToString();
                break;
            }
            if (kodKlienta == "")
            {
                dtForCHekReport = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
                nameOfReport = "ChekReportOtmena";
                
            }
            else
            {
                dtForCHekReport = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
                nameOfReport = "ChekReportOtmenaOpt";

            }

            otmenaProdazhiDGV.Rows.Clear();
            MessageBox.Show("Заказ успешно отменен!");
            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();

            


        EndProcess: { }

        }

        private void ochistitKarzina1Btn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=null;
            showAllTovar();
        }

        private void Brand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = Brand.GetItemText(Brand.SelectedItem);
            Brand.Text = comboValue;
            search.PerformClick();
        }

        private void marka_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = marka.GetItemText(marka.SelectedItem);
            marka.Text = comboValue;
            search.PerformClick();
        }

        private void gruppa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = gruppa.GetItemText(gruppa.SelectedItem);
            gruppa.Text = comboValue;
            search.PerformClick();
        }

        private void artikul_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = artikul.GetItemText(artikul.SelectedItem);
            artikul.Text = comboValue;
            search.PerformClick();
        }

        private void naimenovanie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = naimenovanie.GetItemText(naimenovanie.SelectedItem);
            naimenovanie.Text = comboValue;
            search.PerformClick();
        }

        private void nakNomerOtmenaCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nakNomerOtmenaCmb.Text = nakNomerOtmenaCmb.GetItemText(nakNomerOtmenaCmb.SelectedItem);
            otmenaProdazhiDGV.Rows.Clear();
          
            DataTable dt = otmenaProdazhiObj.SelectDataDGV(nakNomerOtmenaCmb.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int index = otmenaProdazhiDGV.Rows.Add();

                    otmenaProdazhiDGV.Rows[index].Cells[1].Value = dr[0];
                    otmenaProdazhiDGV.Rows[index].Cells[2].Value = dr[1];
                    otmenaProdazhiDGV.Rows[index].Cells[3].Value = dr[2];

                }
                otmenaProdazhiDGV.Rows.Add();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int kod = Convert.ToInt32(kodVozvrataTxb.Text);
            DataTable dt = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
            string kodKlienta = "";
            foreach (DataRow dr in dt.Rows)
            {
                kodKlienta = dr["kodKlienta"].ToString();
                break;
            }
            if (kodKlienta == "")
            {
                dtForCHekReport = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
                nameOfReport = "ChekReportOtmenaRozn";

            }
            else
            {
                dtForCHekReport = otmenaProdazhiObj.printCkekQuery(nakNomerOtmenaCmb.Text, kod);
                nameOfReport = "ChekReportOtmenaOpt";
            }

            otmenaProdazhiDGV.Rows.Clear();
            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();

        }

        private void retail_Load(object sender, EventArgs e)
        {
           FormElementDesign.SetComboBoxProperties(this.Controls);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView2.Columns[e.ColumnIndex].Name.ToString();
            int rowNum = e.RowIndex;
            addDataFromKarzina2ToKarzina3(false, rowNum, colName);
            
        }

       
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
           
            
        }

        private void findDataInDGVColumn(ref DataGridView dgv, string columnName, string searchValue, string columnColorChange)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnName].Value != null && row.Cells[columnName].Value.ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    // The search value was found in this row's cell
                    // Do something with the row, e.g. select it
                    row.Cells[columnColorChange].Style.BackColor = SystemColors.Window; 
                    break;
                }
            }
        }

        private void findRowInDataGrid(ref DataGridView dgv, int columnNum, string searchValue)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnNum].Value != null && row.Cells[columnNum].Value.ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    // The search value was found in this row's cell
                    // Do something with the row, e.g. select it
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                    break;
                }
            }
        }
        private void dataGridView3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFirstRowForSumTable(ref dataGridView3);
                roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView3, "sumaKarzina3", "", "", "", 0);

            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dataGridView3_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            // access data of the row being deleted
            string cellValue = row.Cells["artikulKarzina3"].Value.ToString();
            //ищем артикул в карзине 2 и находя приводим выбранный цвет поумалчание 
            findDataInDGVColumn(ref dataGridView2, "artikul1", cellValue, "suma1");
            findDataInDGVColumn(ref dataGridView2, "artikul2", cellValue, "suma2");
            findDataInDGVColumn(ref dataGridView2, "artikul3", cellValue, "suma3");
            findDataInDGVColumn(ref dataGridView2, "artikul4", cellValue, "suma4");


        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFirstRowForSumTable(ref dataGridView2);
                roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", 0);

            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
            // access data of the row being deleted
            string cellValue = row.Cells["alternativa"].Value.ToString();
            //ищем артикул в карзине 2 и находя приводим выбранный цвет поумалчание 
            findRowInDataGrid(ref dataGridView1, 0, cellValue);
            
        }

       
    }
}
