using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using Npgsql;
using System.Windows.Forms;
using Core.Controllers.RoznichProdazha;
using Core.Controllers.OtmenaProdazhi;
using Core.Controllers.Klient;

using Core.DB;
using Core.Controllers.ProverkaNaOshibku;
using Core.Controllers.Optoviy;
using Core.Controllers.Dolg;

namespace AutoMir2022
{
    public partial class OptProdazha : Form


    {
        private RoznichProdazha roznProdazhaObj = new RoznichProdazha();
        private OtmenaProdazhi otmenaProdazhiObj = new OtmenaProdazhi();
        private Klient klientObj = new Klient();
        private Optoviy optoviyObj = new Optoviy();
        private Dolg dolgObj = new Dolg();
        private double kurs;
        public static double dolgKlienta;
        public static double platezhiKlienta;
        //public static DataTable dtForCHekReport;
        //public static string nameOfReport;
        public OptProdazha()
        {
        
            
            InitializeComponent();
            
            showAllTovar();
            
            // add course valuty

            kursValyuti.Text = roznProdazhaObj.GetCursValyuti().ToString();
            kurs = Convert.ToDouble(kursValyuti.Text);
            //довавить продавцы в компбо
            viborProdovets.DisplayMember = "продавец";
            viborProdovets.DataSource = roznProdazhaObj.getNameSeller();
            viborProdovets.Text = null;
               
          
            //add nakladnoy tab OtmenaProdazhi

            nakNomerOtmenaCmb.DisplayMember = "накладной_текст";
            nakNomerOtmenaCmb.DataSource = otmenaProdazhiObj.SelectNomerNakladnoy();
            nakNomerOtmenaCmb.Text = null;


        }

      
        public void showAllTovar()
        {
            //dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.Index();
            //dataGridView1.DataSource = mydataTable;

            artikul.DisplayMember = "артикул";
            artikul.DataSource = optoviyObj.SelectAllArtikul();
            artikul.SelectedItem = null;

            artikulKarz2.DisplayMember = "артикул";
            artikulKarz2.DataSource = optoviyObj.SelectAllArtikul();
            artikulKarz2.SelectedItem = null;


            //клиент информация
            kodKlienta.DataSource = klientObj.GetKodKlienta();
            kodKlienta.DisplayMember="код_клиента";
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
                    double a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena1"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena2"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[9].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena3"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[11].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();

                    a = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["tsena4"].Value);
                    dataGridView2.Rows[e.RowIndex].Cells[13].Value = roznProdazhaObj.getRoundDecimal(a * b).ToString();
                    roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", 1);
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    dataGridView2.Rows[e.RowIndex].Cells["kolZakaza"].Value = null;
                }
              
            }
        endProcess: { }
        }



        private void variantVibor_Click(object sender, EventArgs e)
        {
            
            string variantvibor = "";
            
            if (variant1.Checked == true) variantvibor = "artikul1";
            else if (variant2.Checked == true) variantvibor = "artikul2";
            else if (variant3.Checked == true) variantvibor = "artikul3";
            else if (variant4.Checked == true) variantvibor = "artikul4";



            DataTable listArtikulKarzina3 = new DataTable();

            //проверка на ошибки
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                listArtikulKarzina3 = optoviyObj.getviborVariant(dataGridView2.Rows[i].Cells[variantvibor].Value.ToString(), GetUrovenTsena());

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
                        dataGridView2.Rows[i].Cells["kolZakaza"].Value = "";
                        ochiskta();
                        goto endProsess;
                    }

                    ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                    if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView2, i, "kolZakaza") == true)
                    {
                        MessageBox.Show("Количество заказа не указан!");
                        ochiskta();
                        goto endProsess; 
                    }
                    int b=0;
                    if (int.TryParse(dataGridView2.Rows[i].Cells["kolZakaza"].Value.ToString(), out b))
                    { if (b == 0)
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

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                listArtikulKarzina3 = optoviyObj.getviborVariant(dataGridView2.Rows[i].Cells[variantvibor].Value.ToString(), GetUrovenTsena());
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
                    this.dataGridView1.Rows[index].Cells[7].Value = dataGridView2.Rows[i].Cells["kolZakaza"].Value.ToString();
                    
                    this.dataGridView1.Rows[index].Cells[8].Value = roznProdazhaObj.getRoundDecimal(
                        Convert.ToInt32(dataGridView2.Rows[i].Cells["kolZakaza"].Value) * Convert.ToDouble(dr[6]) * kurs);
                    
                }

            }

            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", 0);
            
        endProsess: {  }
        

        }


        private void ochistkaKarzina2_Click(object sender, EventArgs e)
        {
            roznProdazhaObj.OchistkaDataGridVeiw(ref dataGridView2);

            ochiskta();

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

                summaKontrakta = summaKontrakta +Convert.ToDouble( roznProdazhaObj.getRoundDecimal(Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value)));


            }

            DBNpgsql db = new DBNpgsql();

            int nakKod = roznProdazhaObj.getLastNakladnoyText();
            string nakText = roznProdazhaObj.GetColumnName(nakKod+1);  
            optoviyObj.InsertProdazha(kurs, viborProdovets.Text, roznProdazhaObj.SummaPropis(summaKontrakta), nakText, kodKlienta.Text);

            /// получаем код номер накладной

            int nakNomer = roznProdazhaObj.getNakladnoyNomer(nakText);

            /////////// insert data to table prodazhaTovar

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double tsenaSql =Convert.ToDouble( roznProdazhaObj.getRoundDecimal(Convert.ToDouble(
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
        endProsess: { }
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

        private void ochistitKarzina1Btn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=null;
            dataGridView1.Rows.Clear();
           
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
            
            DataTable dt= optoviyObj.SelectTovarByArtikulDGV(GetUrovenTsena(), artikul.Text);

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


            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", 0);

        endProsess: { }


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
                    
                    roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaKarz1", "", "", "", 1);
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

                i = i + 1;
                sumaRowCounter = sumaRowCounter + 2;
            }
            if (i < 4 )
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

            roznProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView2, "suma1", "suma2", "suma3", "suma4", 0);

            
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rozntsena_CheckedChanged(object sender, EventArgs e)
        {
            if (rozntsena.Checked == true && dataGridView1.Rows.Count>0)
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

            platezhDGV.DataSource = dolgObj.GetPlatezhDgv(kodKlienta.Text);
            zakazDGV.DataSource = dolgObj.GetProdazhaDgv(kodKlienta.Text);

        }

        private void zakazDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void zakazDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
            chekZakaz.Enabled = true;


        }

        private void chekZakaz_Click(object sender, EventArgs e)
        {
            int index = zakazDGV.CurrentCell.RowIndex;
            string nakText = zakazDGV.Rows[index].Cells[1].Value.ToString();
            dolgKlienta =dolgObj.GetStariyDolg(kodKlienta.Text, nakText);
            platezhiKlienta = dolgObj.GetPlatezh(kodKlienta.Text);
            retail.dtForCHekReport = optoviyObj.printCkekQuery(nakText);
            retail.nameOfReport = "ChekReportOpt";
             
            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();

        }

        private void oformitPlatezh_Click(object sender, EventArgs e)
        {
            string nakText=optoviyObj.getLastNakladnoyText();
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
            else { MessageBox.Show("Платеж указан не правильно!");
                sumaPlatezh.Text = "";
            }

            endProcess: { }
        }

        private void chekPlatezh_Click(object sender, EventArgs e)
        {
            int index = platezhDGV.CurrentCell.RowIndex;
            int nomerPlat =Convert.ToInt32(platezhDGV.Rows[index].Cells[1].Value);
            dolgKlienta = dolgObj.GetPradazha(kodKlienta.Text)-dolgObj.GetPlatezhExceptTheLast(kodKlienta.Text,nomerPlat);
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

        private void label10_Click(object sender, EventArgs e)
        {

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
    }
}
