using System;
using System.Data;
using System.Windows.Forms;
using Core.Controllers.VozvratKlas;
using Core.Controllers.RoznichProdazha;
using Core.Controllers.Dolg;
using Core.DB;
using Core.Controllers.ProverkaNaOshibku;
using Microsoft.Reporting.WinForms;
using Core.Controllers;

namespace AutoMir2022
{
    public partial class Vozvrat : Form
    {
        public static double dolg;
        private VozvratKlas vozvratObj = new VozvratKlas();
        private RoznichProdazha roznichProdazhaObj = new RoznichProdazha();

        public Vozvrat()
        {
            InitializeComponent();
            DateTime datatoday = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            dateStart.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateStart.Value = datatoday;
            dateEnd.Value = datatoday;
          
        }


        private void zakrit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nakladnoyNaitiCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nakladnoyNaitiCmb.Text = nakladnoyNaitiCmb.GetItemText(nakladnoyNaitiCmb.SelectedItem);
            naitiDGV.Rows.Clear();
            kodKlientaNaitiCmb.Text = "";
            artikulCmb.Text = "";

            if (nakladnoyNaitiCmb.Text != "")
            {
                DataTable dt = vozvratObj.SelectDataDGVNaiti(nakladnoyNaitiCmb.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int index = naitiDGV.Rows.Add();

                        naitiDGV.Rows[index].Cells[0].Value = dr[0];
                        naitiDGV.Rows[index].Cells[1].Value = dr[1];
                        naitiDGV.Rows[index].Cells[2].Value = dr[2];
                        naitiDGV.Rows[index].Cells[3].Value = dr[3];
                        dataTxb.Text = Convert.ToDateTime(dr[4]).ToString("dd.MM.yyyy");
                    }

                roznichProdazhaObj.SumOfColumnDataGridVeiw(ref naitiDGV, "suma", "", "", "", 0);

                }
                show_all_dataDGV.Visible = false;
                naitiDGV.Visible = true;



            }

        }

        public void show_all()
        {
            nakladnoyNaitiCmb.DataSource = vozvratObj.SelectNomerNakladnoy();
            nakladnoyNaitiCmb.DisplayMember = "накладной_текст";
            nakladnoyNaitiCmb.Text = "";

            nakladnoyVozvratCmb.DataSource = vozvratObj.SelectNomerNakladnoy();
            nakladnoyVozvratCmb.DisplayMember = "накладной_текст";
            nakladnoyVozvratCmb.Text = "";
            
            kodKlientaNaitiCmb.DataSource = vozvratObj.SelectKodKlienta();
            kodKlientaNaitiCmb.DisplayMember = "код_клиента";
            kodKlientaNaitiCmb.Text = "";

            kodKlientaProzhCmb.DataSource = vozvratObj.SelectAllKodKlienta();
            kodKlientaProzhCmb.DisplayMember = "код_клиента";
            kodKlientaProzhCmb.Text = "";

            artikulCmb.DataSource = vozvratObj.SelectArtikul();
            artikulCmb.DisplayMember = "артикул";
            artikulCmb.Text = "";

            show_all_dataDGV.Visible = false;
            naitiDGV.Visible = true;

            roznRb.Enabled = false;
            optRb.Enabled = false;
            kodKlientaProzhCmb.Enabled = false;
            prozhVozvratChek.Checked = false;
            artikulVibor.DataSource = null;

        }

        private void Vozvrat_Load(object sender, EventArgs e)
        {
            show_all();
        }

        private void kodKlientaNaitiCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kodKlientaNaitiCmb.Text = kodKlientaNaitiCmb.GetItemText(kodKlientaNaitiCmb.SelectedItem);
            if (kodKlientaNaitiCmb.Text != "")
            {
                nakladnoyNaitiCmb.DisplayMember = "накладной_текст";
                nakladnoyNaitiCmb.DataSource = vozvratObj.SelectNomerNakladnoyByKodKlienta(kodKlientaNaitiCmb.Text);
                nakladnoyNaitiCmb.Text = "";

                artikulCmb.DisplayMember = "артикул";
                artikulCmb.DataSource = vozvratObj.SelectArtikulByKodKlienta(kodKlientaNaitiCmb.Text);
                artikulCmb.Text = "";

            }


        }

        private void showAll_Click(object sender, EventArgs e)
        {
            show_all();
        }

        private void naitiBtn_Click(object sender, EventArgs e)
        {
            show_all_dataDGV.Visible = true;
            naitiDGV.Visible = false;
            if (artikulCmb.Text != "")
            {
                show_all_dataDGV.DataSource = vozvratObj.GetByParametrDate(dateStart.Value, dateEnd.Value, artikulCmb.Text);
                if (show_all_dataDGV.Rows.Count != 0)
                {
                    show_all_dataDGV.Columns[0].Width = 70;
                    show_all_dataDGV.Columns[1].Width = 150;
                }
                
            }
            else MessageBox.Show("Для поиска укажите артикул!");
        }

        private void prozhVozvratChek_CheckedChanged(object sender, EventArgs e)
        {
            if (prozhVozvratChek.Checked == true)
            {
                roznRb.Enabled = true;
                optRb.Enabled = true;
                kodKlientaProzhCmb.Enabled = true;
                vozvratDGV.Rows.Clear();
                nakladnoyVozvratCmb.Text = "";
                kodVozvrataTxb.Text = "";
                
                artikulVibor.DataSource = vozvratObj.SelectAllArtikul();
                artikulVibor.DisplayMember = "артикул";
            }
        }

        private void nakladnoyVozvratCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            
            nakladnoyVozvratCmb.Text = nakladnoyVozvratCmb.GetItemText(nakladnoyVozvratCmb.SelectedItem);
            string sumaVozvratinTable = vozvratObj.ProverkaNaNalichieVozvrata(nakladnoyVozvratCmb.Text);
            
            if ( sumaVozvratinTable!= "")
            {
                
                MessageBox.Show("На данный заказ уже оформлен возврат на сумму " +
                    sumaVozvratinTable);
            }
            vozvratDGV.Rows.Clear();

            if (nakladnoyVozvratCmb.Text != "")
            {
                restart();
                artikulVibor.DataSource= vozvratObj.SelectArtikulByNakladnoy(nakladnoyVozvratCmb.Text);
                artikulVibor.DisplayMember = "артикул";

                show_all_dataDGV.Visible = false;
                naitiDGV.Visible = true;

            }
        }

        private void vozvratDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (vozvratDGV.Columns[e.ColumnIndex].Name == "kolVozvrata")
            {
                int b = 0;

                ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref vozvratDGV, e.RowIndex, "kolVozvrata")==true)
                    goto endProcess;
                
                if (int.TryParse(vozvratDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value.ToString(), out b))
                {
                    if (b > Convert.ToInt32(vozvratDGV.Rows[e.RowIndex].Cells["kolich"].Value))
                    {
                        vozvratDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value = null;
                        MessageBox.Show("Количество возврата превышает количество оформленного заказа!");
                        
                    }
                    else
                    {
                        double a = Convert.ToDouble(vozvratDGV.Rows[e.RowIndex].Cells["tsenaVozv"].Value);
                        vozvratDGV.Rows[e.RowIndex].Cells["sumaVozv"].Value = roznichProdazhaObj.getRoundDecimal(a * b).ToString();

                        roznichProdazhaObj.SumOfColumnDataGridVeiw(ref vozvratDGV, "sumaVozv", "", "", "", 1);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    vozvratDGV.Rows[e.RowIndex].Cells["kolVozvrata"].Value = null;
                }

            }
        endProcess: { }
        }

        private void oformitBtn_Click(object sender, EventArgs e)
        {
            DBNpgsql dBNpgsqlObj = new DBNpgsql();
            Dolg dolgObj = new Dolg();
            
            if (prozhVozvratChek.Checked==true && optRb.Checked==true && kodKlientaProzhCmb.Text == "")
            {
                MessageBox.Show("Перед оформлением прошлогодного опт возврата укажите код клиента!");
                goto EndProcess;
            }

            if (prozhVozvratChek.Checked == true && optRb.Checked == true && kodKlientaProzhCmb.Text != "" && 
                vozvratObj.SelectProshlogodVozvrata()!="")
            {
                MessageBox.Show("На текущий день на данного клиента уже оформлен возврат!");
                goto EndProcess;
            }

            if (vozvratDGV.Rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали товар для возврата!");
                goto EndProcess;
            }

            for (int i = 0; i < vozvratDGV.Rows.Count - 1; i++)
            {
                if ( vozvratDGV.Rows[i].Cells["kolVozvrata"].Value == null)
                {
                    MessageBox.Show("Вы не указали количество для возврата!");
                    goto EndProcess;
                }
            }


            int kod = 0;
            if (prozhVozvratChek.Checked == true)
            {
                vozvratObj.InsertVozvrat("0", kodKlientaProzhCmb.Text);
                kod = vozvratObj.SelectNomerVozvrataProsh();
                if (optRb.Checked == true) 
                {
                    dolg=dolgObj.GetObshDolg(kodKlientaProzhCmb.Text);
                    vozvratObj.InsertVozvratProshlogod(kodKlientaProzhCmb.Text);
                }
            }
            else
            {
                vozvratObj.InsertVozvrat(nakladnoyVozvratCmb.Text, kodKlientaProzhCmb.Text);
                kod = vozvratObj.SelectNomerVozvrata(nakladnoyVozvratCmb.Text);
            }

            for (int i = 0; i < vozvratDGV.Rows.Count - 1; i++)
            {
                    //добавляем в таблицу возврат  

                    int kolVozvrata = int.Parse(vozvratDGV.Rows[i].Cells["kolVozvrata"].Value.ToString());
                    double tsena = double.Parse(vozvratDGV.Rows[i].Cells["tsenaVozv"].Value.ToString());

                     string suma =roznichProdazhaObj.getRoundDecimal(kolVozvrata * tsena);
                    vozvratObj.InsertVozvratPerechen(kod, vozvratDGV.Rows[i].Cells["artikulVozvrat"].Value.ToString(),
                    kolVozvrata, Convert.ToDouble(suma));
            }

            //сумма прописю 
            string propis = vozvratObj.SelectSummaVozvrata(kod);
            if (propis != "")
            {
                string summaPropis = roznichProdazhaObj.SummaPropis(double.Parse(propis));
                vozvratObj.UpdateVozvrat(kod, summaPropis, double.Parse(propis));
            }

            kodVozvrataTxb.Text = kod.ToString();
            
            retail retail = new retail();
            retail.dtForCHekReport = vozvratObj.printCkekQuery(kod);

            if (prozhVozvratChek.Checked==false)
            {
               retail.nameOfReport = "ChekReportVozvrat";
            }
            else if (prozhVozvratChek.Checked == true && roznRb.Checked==true)
            {
               retail.nameOfReport = "ChekReportVozvratProshRozn";
            }
            else if (prozhVozvratChek.Checked == true && optRb.Checked == true)
            {
                retail.nameOfReport = "ChekReportVozvratProshOpt";
            }

            vozvratDGV.Rows.Clear();
            artikulVibor.Text = "";

            MessageBox.Show("Возврат успешно оформлен!");
            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();
            restart();

        EndProcess: { }
        }

        private void artikulVibor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            artikulVibor.Text = artikulVibor.GetItemText(artikulVibor.SelectedItem);

            ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
            if (proverkaNaOshibkuObj.CheckReapetedValueInDVG(ref vozvratDGV, "artikulVozvrat", artikulVibor.Text) == true)
            {
                MessageBox.Show("Данный артикул уже добавлен!");
                goto endProcess;
            }
            KursValyuti kursValyutiObj = new KursValyuti();
            double kursValyuti = Convert.ToDouble(kursValyutiObj.GetKursValyuti());

            if (nakladnoyVozvratCmb.Text != "" || prozhVozvratChek.Checked==true)
            {
                int rowNum = vozvratDGV.Rows.Count;

                if (rowNum > 0)
                {
                    if (vozvratDGV.Rows[rowNum - 1].Cells[0].Value == null)
                    {
                        this.vozvratDGV.Rows.Remove(this.vozvratDGV.Rows[rowNum - 1]);
                    }
                }
                DataTable dt =null;
                
                if (nakladnoyVozvratCmb.Text=="" && prozhVozvratChek.Checked == true)
                {
                    if (roznRb.Checked == true)
                        dt = vozvratObj.SelectProshlogodRoznDataDGV(artikulVibor.Text);
                    else if (optRb.Checked == true)
                        dt = vozvratObj.SelectProshlogodOptDataDGV(artikulVibor.Text);
                    else
                    {
                        MessageBox.Show("Укажите опцию оптовый или розничный!");
                        goto endProcess;
                    }
                }
                else
                {
                    dt = vozvratObj.SelectDataDGV(nakladnoyVozvratCmb.Text, artikulVibor.Text);
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int index = vozvratDGV.Rows.Add();

                        vozvratDGV.Rows[index].Cells[0].Value = dr[0];
                        vozvratDGV.Rows[index].Cells[1].Value = dr[1];
                        if (prozhVozvratChek.Checked==true)
                            vozvratDGV.Rows[index].Cells[2].Value =
                                roznichProdazhaObj.getRoundDecimal( Convert.ToDouble(dr[2])
                                *kursValyuti);
                        else
                            vozvratDGV.Rows[index].Cells[2].Value = dr[2];
                    }

                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref vozvratDGV, "sumaVozv", "", "", "", 0);
                }
            }
            
        endProcess: { }
        }

        public void restart()
        {
            optRb.Checked = false;
            roznRb.Checked = false;
            optRb.Enabled = false;
            roznRb.Enabled = false;
            kodKlientaProzhCmb.Text = "";
            kodKlientaProzhCmb.Enabled = false;
            artikulVibor.Text = "";
            prozhVozvratChek.Checked = false;
        }

        private void ochistkaVozvratBtn_Click(object sender, EventArgs e)
        {
            vozvratDGV.Rows.Clear();
        }

        
    }
}
