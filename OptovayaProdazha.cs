﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Core.Controllers.RoznichProdazha;
using Core.Controllers.OtmenaProdazhi;
using Core.Controllers.Klient;

using Core.DB;
using Core.Controllers.ProverkaNaOshibku;
using Core.Controllers.Optoviy;
using Core.Controllers.Dolg;
using Core.Controllers;
using Core.DesignForms;

namespace AutoMir2022
{
    public partial class OptovayaProdazha : Form
    {
        public OptovayaProdazha()
        {
            InitializeComponent();

            showAllTovar();

            // add course valuty
            KursValyuti kursValyutiObj = new KursValyuti();
            kursValyuti.Text = kursValyutiObj.GetKursValyuti().ToString();
            kurs = Convert.ToDouble(kursValyuti.Text);
            //довавить продавцы в компбо
            viborProdovets.DisplayMember = "продавец";
            viborProdovets.DataSource = roznProdazhaObj.getNameSeller();
            viborProdovets.Text = null;

        }

        private RoznichProdazha roznProdazhaObj = new RoznichProdazha();
        //private OtmenaProdazhi otmenaProdazhiObj = new OtmenaProdazhi();
        private Klient klientObj = new Klient();
        private Optoviy optoviyObj = new Optoviy();
        private Dolg dolgObj = new Dolg();
        private double kurs;
        public static double dolgKlienta;
        public static double platezhiKlienta;
        //public static DataTable dtForCHekReport;
        //public static string nameOfReport;
       

        public void showAllTovar()
        {
            //dataGridView1.AutoGenerateColumns = true;
            //DataTable mydataTable = new DataTable();
            //mydataTable = roznProdazhaObj.Index();
            ////dataGridView1.DataSource = mydataTable;

            artikul.DisplayMember = "артикул";
            artikul.DataSource = optoviyObj.SelectAllArtikul();
            artikul.SelectedItem = null;

            artikulKarz2.DisplayMember = "артикул";
            artikulKarz2.DataSource = optoviyObj.SelectAllArtikul();
            artikulKarz2.SelectedItem = null;


            //клиент информация
            kodKlienta.DataSource = klientObj.GetKodKlienta();
            kodKlienta.DisplayMember = "код_клиента";
            kodKlienta.Text = null;

            fioKlienta.DataSource = klientObj.GetKodKlienta();
            fioKlienta.DisplayMember = "фио";
            fioKlienta.Text = null;

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
                    // tsena 19,20,21,22,23,24
                    // summa 9,11,13,15,17,19  
                    double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena1"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[9].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena2"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[11].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena3"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[13].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena4"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[15].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena5"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[17].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena6"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[19].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", "suma5", "suma6", 1);

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

        private void addDataFromKarzina2ToKarzina1(bool groupVibor, int dgvRow, string dgvColName)
        {
            string variantvibor = "";

            if (variant1.Checked == true || dgvColName == "suma1") variantvibor = "artikul1";
            else if (variant2.Checked == true || dgvColName == "suma2") variantvibor = "artikul2";
            else if (variant3.Checked == true || dgvColName == "suma3") variantvibor = "artikul3";
            else if (variant4.Checked == true || dgvColName == "suma4") variantvibor = "artikul4";
            else if (variant5.Checked == true || dgvColName == "suma5") variantvibor = "artikul5";
            else if (variant6.Checked == true || dgvColName == "suma6") variantvibor = "artikul6";

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
            
            DataTable listArtikulKarzina3 = new DataTable();

            //проверка на ошибки
            for (int i = 0; i < rowCounter; i++)
            {
                int rowDgv;
                //если вариант из radioButton выбран то будет в цикле перенесены все поля в датагрид3 
                if (groupVibor == true) rowDgv = i;
                else rowDgv = dgvRow;

                listArtikulKarzina3 = optoviyObj.getviborVariant(dataGridView2.Rows[rowDgv].Cells[variantvibor].Value.ToString(), GetUrovenTsena());

                foreach (DataRow dr in listArtikulKarzina3.Rows)
                {

                    bool artikulIsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView1, dr[0].ToString(), "artikulKarz1");

                    if (artikulIsExist == true)
                    {
                        MessageBox.Show("Данный артикул уже добавлен в карзину!");
                        ochiskta();
                        goto endProsess;
                    }

                    if (Convert.ToInt32(dr[5]) < Convert.ToInt32(dataGridView2.Rows[i].Cells["kolZakaza"].Value))
                    {
                        MessageBox.Show("Количество заказа превышает количество товара в магазине!");
                        dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value = "";
                        ochiskta();
                        goto endProsess;
                    }

                    ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                    if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView2, rowDgv, "kolZakaza") == true)
                    {
                        MessageBox.Show("Количество заказа не указан!");
                        ochiskta();
                        goto endProsess;
                    }
                    int b = 0;
                    if (int.TryParse(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value.ToString(), out b))
                    {
                        if (b == 0)
                        {
                            MessageBox.Show("Количество заказа не указан или указан не правельном формате!");
                            ochiskta();
                            goto endProsess;
                        }
                    }



                }

            }

            int rowNum = dataGridView1.Rows.Count;

            if (rowNum > 0)
            {
                if (dataGridView1.Rows[rowNum - 1].Cells[0].Value == null)
                {
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[rowNum - 1]);
                }
            }

            ////////////////////////
            ///
            //adding data from datagrizd2 (Karzina2) to datagrid1 (karzina1)
            

            for (int i = 0; i < rowCounter; i++)
            {
                int rowDgv;
                //если вариант из radioButton выбран то будет в цикле перенесены все поля в датагрид3 
                if (groupVibor == true) rowDgv = i;
                else rowDgv = dgvRow;

                listArtikulKarzina3 = optoviyObj.getviborVariant(dataGridView2.Rows[rowDgv].Cells[variantvibor].Value.ToString(), GetUrovenTsena());
                int index = dataGridView1.Rows.Add();

                foreach (DataRow dr in listArtikulKarzina3.Rows)
                {
                    //    Select артикул, наименование, бренд, марка,
                    //    модель,  место_на_складе, розн_цена__euro_  FROM public.товар WHERE артикул
                    this.dataGridView1.Rows[index].Cells[0].Value = dr[0];
                    this.dataGridView1.Rows[index].Cells[1].Value = dr[1];
                    this.dataGridView1.Rows[index].Cells[2].Value = dr[2];
                    this.dataGridView1.Rows[index].Cells[3].Value = dr[3];
                    this.dataGridView1.Rows[index].Cells[4].Value = dr[4];
                    this.dataGridView1.Rows[index].Cells[5].Value = dr[5];

                    //    данные из карзини 2 количество заказа, цена и сумма
                    this.dataGridView1.Rows[index].Cells[6].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[6]) * kurs);
                    this.dataGridView1.Rows[index].Cells[7].Value = dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value.ToString();

                    this.dataGridView1.Rows[index].Cells[8].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToInt32(dataGridView2.Rows[rowDgv].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs);

                }

            }
            if (groupVibor == false)
            {
                dataGridView2.Rows[dgvRow].Cells[dgvColName].Style.BackColor = Color.DodgerBlue;
            }
            
        endProsess: { }
            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", "", "", 0);

        }

        private void variantVibor_Click(object sender, EventArgs e)
        {
            addDataFromKarzina2ToKarzina1(true, 0, "");
        }


        private void ochistkaKarzina2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить карзину?", "Очистка карзины", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView2);
                ochiskta();
            }



        }

        public void ochiskta()
        {
            variant1.Checked = false;
            variant2.Checked = false;
            variant3.Checked = false;
            variant4.Checked = false;


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

                double kolZakaz = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);

                if (kolTovaraDouble < kolZakaz)
                {
                    MessageBox.Show("Не достаточное количество товара на складе, остаток артикул "
                        + dataGridView1.Rows[i].Cells[0].Value.ToString() + " равняется " + kolTovaraDouble.ToString() + " товар будет удален из карзини!");
                    dataGridView1.Rows.Clear();
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


            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали товар в карзину, заказ не оформлен!");
                goto endProsess;

            }



            if (kursValyuti.Text.Trim() == "" || kursValyuti.Text.Trim() == "0")
            {
                MessageBox.Show("Курс валюты не указан, для выбора товара укажите курс валюты!");
                goto endProsess;

            }


            double summaKontrakta = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                //проверка остатка на складе достаточен ли для оформление заказа количество товара

                DataTable kolTovara = roznProdazhaObj.getviborVariant(dataGridView1.Rows[i].Cells[0].Value.ToString());
                double kolTovaraDouble = 0;
                foreach (DataRow dr in kolTovara.Rows)
                {
                    kolTovaraDouble = Convert.ToDouble(dr[7]);
                }

                double kolZakaz = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);

                if (kolTovaraDouble < kolZakaz)
                {
                    MessageBox.Show("Не достаточное количество товара на складе, остаток артикул "
                        + dataGridView1.Rows[i].Cells[0].Value.ToString() + " равняется " + kolTovaraDouble.ToString() + " товар будет удален из карзини!");
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[i]);
                    goto endProsess;
                }
                //////////////

                summaKontrakta = summaKontrakta + Convert.ToDouble(roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value)));


            }

            DBNpgsql db = new DBNpgsql();

            int nakKod = roznProdazhaObj.getLastNakladnoyText();
            string nakText = roznProdazhaObj.GetColumnName(nakKod + 1);
            optoviyObj.InsertProdazha(kurs, viborProdovets.Text, roznProdazhaObj.SummaPropis(summaKontrakta), nakText, kodKlienta.Text);

            /// получаем код номер накладной

            int nakNomer = roznProdazhaObj.getNakladnoyNomer(nakText);

            /////////// insert data to table prodazhaTovar

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double tsenaSql = Convert.ToDouble(roznProdazhaObj.getRoundDecimal(Convert.ToDouble(
                    dataGridView1.Rows[i].Cells[6].Value.ToString())));
                int kolSql = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                db.insertProdazhaTovar(
                    dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    kolSql, tsenaSql, nakNomer);

                /////////// update data to table Tovar

                roznProdazhaObj.updateTovarKol(dataGridView1.Rows[i].Cells[0].Value.ToString(), kolSql, "-");
            }



            MessageBox.Show("Заказ укспешно оформлен!");

            roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView1);
            roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView2);
            ochiskta();
            artikul.Text = null;
            artikulKarz2.Text = null;

            //ochistkaMain();
            ////ochistkaPlatezhi();
            itogiPlatezhProdazha();
        endProsess: { }
        }
        private void ochistkaMain()
        {
            fioKlienta.Text = null;
            kodKlienta.Text = null;
            urovenKlienta.Text = null;
            rozntsena.Checked = false;
            adres.Text = null;
            kontakt.Text = null;
        }
        private void ochistkaPlatezhi()
        {
            itogoPlatezh.Text = null;
            itogoZakaz.Text = null;
            ostatok.Text = null;
            sumaPlatezh.Text = null;

            //if (platezhDGV.RowCount > 0) platezhDGV.Rows.Clear();
            //if (zakazDGV.RowCount>0) zakazDGV.Rows.Clear();
        }
        private void btnAddKurs_Click(object sender, EventArgs e)
        {
            double kurs = 0;
            DBNpgsql dBNpgsqlObj = new DBNpgsql();
            double.TryParse(kursValyuti.Text, out kurs);
            if (kurs == 0)
            {
                MessageBox.Show("Курс валюты указан не правильном формате, укажите число с использованием запятой ");
            }
            else
            {
                dBNpgsqlObj.insertKurs(kurs);
                MessageBox.Show("Курс валюты успешно добавлен!");

            }
        }


        private void ochistitKarzina1Btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить карзину?", "Очистка карзины", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }

        }


        private void artikul_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string comboValue = artikul.GetItemText(artikul.SelectedItem);
            artikul.Text = comboValue;

            if (kodKlienta.Text == "")
            {
                MessageBox.Show("Укажите код клиента!");
                goto endProsess;
            }

            if (artikul.Text == "") goto endProsess;
            int rowNum = dataGridView1.Rows.Count;

            if (rowNum > 0)
            {
                if (dataGridView1.Rows[rowNum - 1].Cells[0].Value == null)
                {
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[rowNum - 1]);
                }
            }

            DataTable dt = optoviyObj.SelectTovarByArtikulDGV(GetUrovenTsena(), artikul.Text);

            int index = dataGridView1.Rows.Add();

            foreach (DataRow dr in dt.Rows)
            {
                //    Select артикул, наименование, бренд, марка,
                //    модель,  место_на_складе, розн_цена__euro_  FROM public.товар WHERE артикул

                bool artikulIsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView1, dr[0].ToString(), "artikulKarz1");

                if (artikulIsExist == true)
                {
                    MessageBox.Show("Данный артикул уже добавлен в карзину!");
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[index]);
                    goto endProsess;
                }


                this.dataGridView1.Rows[index].Cells[0].Value = dr[0];
                this.dataGridView1.Rows[index].Cells[1].Value = dr[1];
                this.dataGridView1.Rows[index].Cells[2].Value = dr[2];
                this.dataGridView1.Rows[index].Cells[3].Value = dr[3];
                this.dataGridView1.Rows[index].Cells[4].Value = dr[4];
                this.dataGridView1.Rows[index].Cells[5].Value = dr[5];
                this.dataGridView1.Rows[index].Cells[6].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToDouble(dr[6]) * kurs);

            }


            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", "", "", 0);

        endProsess: { }


        }


        private void kodKlienta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kodKlienta.Text = kodKlienta.GetItemText(kodKlienta.SelectedItem);
            if (kodKlienta.Text != "")
            {
                DataTable dt = klientObj.GetKlientInfo(kodKlienta.Text);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        kodKlienta.Text = dr[0].ToString();
                        fioKlienta.Text = dr[1].ToString();
                        kontakt.Text = dr[2].ToString();
                        adres.Text = dr[3].ToString();
                        urovenKlienta.Text = dr[5].ToString();
                    }
                    itogiPlatezhProdazha();
                }

            }

        }

        private void newKlient_Click(object sender, EventArgs e)
        {
            KlientFrm klientFrm = new KlientFrm();
            klientFrm.Show();
        }


        private void fioKlienta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fioKlienta.Text = fioKlienta.GetItemText(fioKlienta.SelectedItem);
            if (fioKlienta.Text != "")
            {
                DataTable dt = klientObj.GetKlientInfoByName(fioKlienta.Text);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        kodKlienta.Text = dr[0].ToString();
                        fioKlienta.Text = dr[1].ToString();
                        kontakt.Text = dr[2].ToString();
                        adres.Text = dr[3].ToString();
                        urovenKlienta.Text = dr[5].ToString();
                    }
                    itogiPlatezhProdazha();
                }


            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "kolZakazaKarz1")

            {
                int b = 0;

                ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView1, e.RowIndex, "kolZakazaKarz1") == true)
                    goto endProcess;


                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["kolZakazaKarz1"].Value.ToString(), out b))

                {
                    double a = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["tsena"].Value);
                    dataGridView1.Rows[e.RowIndex].Cells["sumaKarz1"].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", "", "", 1);
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    dataGridView1.Rows[e.RowIndex].Cells["kolZakazaKarz1"].Value = null;
                }

            }
        endProcess: { }
        }

        private void artikulKarz2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            artikulKarz2.Text = artikulKarz2.GetItemText(artikulKarz2.SelectedItem);

            if (kodKlienta.Text == "")
            {
                MessageBox.Show("Укажите код клиента!");
                goto endProsess;
            }

            int rowNum = dataGridView2.Rows.Count;

            if (rowNum > 0)
            {

                if (dataGridView2.Rows[rowNum - 1].Cells[0].Value == null)
                {
                    this.dataGridView2.Rows.Remove(this.dataGridView2.Rows[rowNum - 1]);

                }
            }

            if (kursValyuti.Text.Trim() == "" || kursValyuti.Text.Trim() == "0")
            {
                MessageBox.Show("Курс валюты не указан, для выбора товара укажите курс валюты!");
                goto endProsess;

            }


            //проверка на наличие артикула в карзине 2
            DataTable alternativa = new DataTable();

            //add array data to karzina 2... info about tovar
            string[,] arrayForfilter = new string[1, 2];

            //get alternativa from table tovar for geting all possibla alternativ goods

            arrayForfilter[0, 0] = "альтернатива";
            arrayForfilter[0, 1] = optoviyObj.GetAlternativa(artikulKarz2.Text);


            alternativa = optoviyObj.SelectTovarByAlternativa(arrayForfilter, GetUrovenTsena());

            int i = 0;

            // когда альтернатива больше или 4 то тогда все элементи из бази останутся такими как есть
            if (alternativa.Rows.Count == 0)
            {
                MessageBox.Show("Выбранный артикул данный момент не имеется в наличии!");
                goto endProsess;
            }

            alternativa.DefaultView.Sort = GetUrovenTsena() + " DESC";
            var index = this.dataGridView2.Rows.Add();

            int sumaRowCounter = 0;
            foreach (DataRow dr in alternativa.Rows)
            {

                if (i == 6) break;

                this.dataGridView2.Rows[index].Cells[0].Value = dr[5];
                this.dataGridView2.Rows[index].Cells[1].Value = dr[1];

                // kolichestvo 2,3,4,5,6,7
                this.dataGridView2.Rows[index].Cells[2 + i].Value = dr[6];

                // tsena 27,28,29,30,31,32
                if (dr[7].ToString() != "")
                {
                    this.dataGridView2.Rows[index].Cells[27 + i].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                }
                else
                {
                    MessageBox.Show("Цена данного артикула не указан!");
                    this.dataGridView2.Rows.Remove(this.dataGridView2.Rows[index]);

                    goto endProsess;
                }


                // summa 9,11,13,15,17,19  
                this.dataGridView2.Rows[index].Cells[9 + sumaRowCounter].Value = roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dr[7]) * kurs);

                // brand 10,12,14,16,18,20
                this.dataGridView2.Rows[index].Cells[10 + sumaRowCounter].Value = dr[2];

                // artikul 21,22,23,24,25,26


                if (dataGridView2.Rows.Count > 1)
                {
                    bool artikul1IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul1");
                    bool artikul2IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul2");
                    bool artikul3IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul3");
                    bool artikul4IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul4");
                    bool artikul5IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul5");
                    bool artikul6IsExist = roznProdazhaObj.searchDataInDataGridVeiw(ref dataGridView2, dr[0].ToString(), "artikul6");

                    if (artikul1IsExist == true || artikul2IsExist == true ||
                        artikul3IsExist == true || artikul4IsExist == true ||
                        artikul5IsExist == true || artikul6IsExist == true)
                    {
                        MessageBox.Show("Данный артикул уже добавлен в карзину!");
                        this.dataGridView2.Rows.Remove(this.dataGridView2.Rows[index]);

                        goto endProsess;
                    }
                }
                // artikul 21,22,23,24,25,26
                this.dataGridView2.Rows[index].Cells[21 + i].Value = dr[0];
                //// проверяем на наличие распродажи для выбранного артикула
                RasprodazhaBonus rasprodazhaBonusObj = new RasprodazhaBonus();

                rasprodazhaBonusObj.RaspradazhaArtikulColor(ref dataGridView2, index, 9 + sumaRowCounter, dr[0].ToString());

                i = i + 1;
                sumaRowCounter = sumaRowCounter + 2;
            }
            if (i < 6)
            {
                for (int k = i; k < 6; k++)
                {

                    // kolichestvo 2,3,4,5,6,7
                    this.dataGridView2.Rows[index].Cells[2 + k].Value = this.dataGridView2.Rows[index].Cells[(2 + k) - 1].Value;


                    // brand 10,12,14,16,18,20
                    this.dataGridView2.Rows[index].Cells[10 + sumaRowCounter].Value = this.dataGridView2.Rows[index].Cells[(10 + sumaRowCounter) - 2].Value;

                    // tsena 27,28,29,30,31,32
                    this.dataGridView2.Rows[index].Cells[27 + k].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(27 + k) - 1].Value));

                    // summa 9,11,13,15,17,19
                    this.dataGridView2.Rows[index].Cells[9 + sumaRowCounter].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToDouble(this.dataGridView2.Rows[index].Cells[(9 + sumaRowCounter) - 2].Value));

                    // artikul 21,22,23,24,25,26
                    this.dataGridView2.Rows[index].Cells[21 + k].Value = this.dataGridView2.Rows[index].Cells[(21 + k) - 1].Value;
                    sumaRowCounter = sumaRowCounter + 2;
                }


            }

            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", "suma5", "suma6", 0);
            

        endProsess: { }

        }

        private string GetUrovenTsena()
        {
            string urovenTsena;
            if (rozntsena.Checked == true)
                urovenTsena = "розн_цена__euro_";
            else urovenTsena = optoviyObj.GetUrovenTsenKlienta(urovenKlienta.Text);
            return urovenTsena;
        }

        private void rozntsena_CheckedChanged(object sender, EventArgs e)
        {
            if (rozntsena.Checked == true && dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Опцию розн.цена укажите перед добавлением товара в карзину!");
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                ochiskta();
            }
        }

        private void itogiPlatezhProdazha()
        {

            double prodazha = dolgObj.GetPradazha(kodKlienta.Text);
            double platezh = dolgObj.GetPlatezh(kodKlienta.Text);
            double zadolzhnost = dolgObj.GetZadolzhnost(kodKlienta.Text);

            itogoZakaz.Text = prodazha.ToString("0.00");
            itogoPlatezh.Text = platezh.ToString("0.00");
            ostatok.Text = (prodazha + zadolzhnost - platezh).ToString("0.00");

            //если категория указывает отчет только для текущего то в датагриде показываем за текущей день 

            DataRow[] rows = MainMenu.userKategori.Select($"{"контроль"} LIKE '%{"OptProdazha_platezhi_zakazDGV_platezhiDGV_currentDate"}%'");

            // Check if any rows were found
            if (rows.Length > 0)
            {
                platezhDGV.DataSource = dolgObj.GetPlatezhDgvCurrentDate(kodKlienta.Text);
                zakazDGV.DataSource = dolgObj.GetProdazhaDgvCurrentDate(kodKlienta.Text);
            }
            else
            {
                platezhDGV.DataSource = dolgObj.GetPlatezhDgv(kodKlienta.Text);
                zakazDGV.DataSource = dolgObj.GetProdazhaDgv(kodKlienta.Text);

            }


        }
        private void zakazDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chekZakaz.Enabled = true;
        }

        private void chekZakaz_Click(object sender, EventArgs e)
        {
            int index = zakazDGV.CurrentCell.RowIndex;
            string nakText = zakazDGV.Rows[index].Cells[1].Value.ToString();

            dolgKlienta = dolgObj.GetStariyDolg(kodKlienta.Text, nakText);

            platezhiKlienta = dolgObj.GetPlatezhTekushiy(kodKlienta.Text, nakText);
            retail.dtForCHekReport = optoviyObj.printCkekQuery(nakText);
            retail.nameOfReport = "ChekReportOpt";

            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();

        }

        private void oformitPlatezh_Click(object sender, EventArgs e)
        {
            string nakText = optoviyObj.getLastNakladnoyText();
            double b = 0;
            if (nakText == "")
            {
                MessageBox.Show("Выбранному клиенту заказ еще не оформлен!");
                goto endProcess;
            }

            else if (double.TryParse(sumaPlatezh.Text, out b))
            {
                optoviyObj.InsertPlatezh(Convert.ToDouble(sumaPlatezh.Text), roznProdazhaObj.SummaPropis(Convert.ToDouble(sumaPlatezh.Text)),
                nakText, kodKlienta.Text);
                MessageBox.Show("Платеж успешно оформлен!");
                sumaPlatezh.Text = "";
                itogiPlatezhProdazha();
                chekPlatezh.Enabled = true;



            }
            else
            {
                MessageBox.Show("Платеж указан не правильно!");
                sumaPlatezh.Text = "";
            }

        endProcess: { }
        }

        private void chekPlatezh_Click(object sender, EventArgs e)
        {
            int index = platezhDGV.CurrentCell.RowIndex;
            int nomerPlat = Convert.ToInt32(platezhDGV.Rows[index].Cells[1].Value);
            dolgKlienta = dolgObj.GetPradazha(kodKlienta.Text) - dolgObj.GetPlatezhExceptTheLast(kodKlienta.Text, nomerPlat)
                + dolgObj.GetZadolzhnost(kodKlienta.Text);

            platezhiKlienta = dolgObj.GetPlatezhByNomerPlatezh(kodKlienta.Text, nomerPlat);
            retail.dtForCHekReport = optoviyObj.printCkekQueryPlatezh(nomerPlat);
            retail.nameOfReport = "ChekReportOptPlatezh";

            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();

        }

        private void platezhDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chekPlatezh.Enabled = true;
        }

        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void OptProdazha_Load(object sender, EventArgs e)
        {
            ItogiOptProdazhi myForm = new ItogiOptProdazhi();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;

            this.itogiPanel.Controls.Add(myForm);
            myForm.Show();

            FormElementDesign.SetComboBoxProperties(this.Controls);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", "", "", 1);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView2.Columns[e.ColumnIndex].Name.ToString();
            int rowNum = e.RowIndex;
            addDataFromKarzina2ToKarzina1(false, rowNum, colName);
        }

      

        private void artikulKarz2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                artikulKarz2_SelectionChangeCommitted(sender, EventArgs.Empty);
                e.Handled = true; // prevent the default behavior of the Enter key
            }
        }

        private void artikul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                artikul_SelectionChangeCommitted(sender, EventArgs.Empty);
                e.Handled = true; // prevent the default behavior of the Enter key
            }
        }

        private void fioKlienta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fioKlienta_SelectionChangeCommitted(sender, EventArgs.Empty);
                e.Handled = true; // prevent the default behavior of the Enter key
            }
        }

        private void kodKlienta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kodKlienta_SelectionChangeCommitted(sender, EventArgs.Empty);
                e.Handled = true; // prevent the default behavior of the Enter key
            }
            
        }

        private void zakazDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)

        {

            decimal decValue;

            if (e.Value == null)

                return;

            if (decimal.TryParse(e.Value.ToString(), out decValue) == false)

                return;

            e.Value = Math.Round(decValue, 2);

        }


    }
}
