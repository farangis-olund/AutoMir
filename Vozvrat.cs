using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.VozvratKlas;
using Core.Controllers.RoznichProdazha;
using Core.DB;

namespace AutoMir2022
{
    public partial class Vozvrat : Form
    {
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
            
            if (nakladnoyNaitiCmb.Text != "")
            {
                VozvratKlas vozvratObj = new VozvratKlas();
                DataTable dt = vozvratObj.SelectDataDGV(nakladnoyNaitiCmb.Text);
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

                    RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref naitiDGV, "suma", "", "", "", 0);

                }
                show_all_dataDGV.Visible = false;
                naitiDGV.Visible = true;



            }

        }

        public void show_all()
        {
            VozvratKlas vozvratObj = new VozvratKlas();
            nakladnoyNaitiCmb.DisplayMember = "накладной_текст";
            nakladnoyNaitiCmb.DataSource = vozvratObj.SelectNomerNakladnoy();
            nakladnoyNaitiCmb.Text = "";

            nakladnoyVozvratCmb.DisplayMember = "накладной_текст";
            nakladnoyVozvratCmb.DataSource = vozvratObj.SelectNomerNakladnoy();
            nakladnoyVozvratCmb.Text = "";


            kodKlientaNaitiCmb.DisplayMember = "код_клиента";
            
            kodKlientaNaitiCmb.DataSource = vozvratObj.SelectKodKlienta();
            kodKlientaNaitiCmb.Text = "";

            kodKlientaProzhCmb.DisplayMember = "код_клиента";

            kodKlientaProzhCmb.DataSource = vozvratObj.SelectAllKodKlienta();
            kodKlientaProzhCmb.Text = "";

            artikulCmb.DisplayMember = "артикул";
            artikulCmb.DataSource = vozvratObj.SelectArtikul();
            artikulCmb.Text = "";

            show_all_dataDGV.Visible = false;
            naitiDGV.Visible = true;

            roznRb.Enabled = false;
            optRb.Enabled = false;
            kodKlientaProzhCmb.Enabled = false;
            prozhVozvratChek.Checked = false;

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
                VozvratKlas vozvratObj = new VozvratKlas();
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
            VozvratKlas vozvratKlasObj = new VozvratKlas();
            show_all_dataDGV.Visible = true;
            naitiDGV.Visible = false;
            if (artikulCmb.Text != "")
            {
                show_all_dataDGV.DataSource = vozvratKlasObj.GetByParametrDate(dateStart.Value, dateEnd.Value, artikulCmb.Text);
                show_all_dataDGV.Columns[0].Width = 70;
                show_all_dataDGV.Columns[1].Width = 150;
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
            }
        }

        private void nakladnoyVozvratCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nakladnoyVozvratCmb.Text = nakladnoyVozvratCmb.GetItemText(nakladnoyVozvratCmb.SelectedItem);
            vozvratDGV.Rows.Clear();

            if (nakladnoyVozvratCmb.Text != "")
            {
                VozvratKlas vozvratObj = new VozvratKlas();
                DataTable dt = vozvratObj.SelectDataDGV(nakladnoyVozvratCmb.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int index = vozvratDGV.Rows.Add();

                        vozvratDGV.Rows[index].Cells[0].Value = dr[0];
                        vozvratDGV.Rows[index].Cells[1].Value = dr[1];
                        vozvratDGV.Rows[index].Cells[2].Value = dr[2];
                       
                    }

                    RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref vozvratDGV, "sumaVozv", "", "", "", 0);

                }
                show_all_dataDGV.Visible = false;
                naitiDGV.Visible = true;



            }
        }

        private void vozvratDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();

            if (vozvratDGV.Columns[e.ColumnIndex].Name == "kolVozvrata")
            {
                int b = 0;
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
        
        }

        private void oformitBtn_Click(object sender, EventArgs e)
        {
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            VozvratKlas vozvratObj = new VozvratKlas();
            DBNpgsql dBNpgsqlObj = new DBNpgsql();
            
            if (vozvratDGV.Rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали товар для возврата!");
                goto EndProcess;
            }

            int kod = vozvratObj.SelectNomerVozvrata();

            vozvratObj.InsertVozvrat(kod, nakladnoyVozvratCmb.Text,kodKlientaProzhCmb.Text);



            for (int i = 0; i < vozvratDGV.Rows.Count - 1; i++)
            {
                bool isChecked = Convert.ToBoolean(vozvratDGV.Rows[i].Cells[0].Value);
                if (isChecked == true && vozvratDGV.Rows[i].Cells["kolVozvrata"].Value == null)
                {
                    MessageBox.Show("Для выбронного артикула не указан количество возврата!");
                    
                    vozvratObj.DeleteVozvrat(nakladnoyVozvratCmb.Text, kod);

                    goto EndProcess;
                }
                else if (isChecked == true && vozvratDGV.Rows[i].Cells["kolVozvrata"].Value != null)
                {
                    //добавляем в таблицу возврат  

                    int kolVozvrata = int.Parse(vozvratDGV.Rows[i].Cells["kolVozvrata"].Value.ToString());
                    //int kolProdazha = int.Parse(vozvratDGV.Rows[i].Cells["kolich"].Value.ToString());
                    double tsena = double.Parse(vozvratDGV.Rows[i].Cells["tsenaVozv"].Value.ToString());

                     double suma = kolVozvrata * tsena;
                    vozvratObj.InsertVozvratPerechen(kod, vozvratDGV.Rows[i].Cells["artikulVozvrat"].Value.ToString(),
                    kolVozvrata, suma);

                }


            }

            //сумма прописю 
            string propis = vozvratObj.SelectSummaVozvrata(nakladnoyVozvratCmb.Text, kod);
            if (propis != null)
            {
                string summaPropis = roznichProdazhaObj.SummaPropis(double.Parse(propis));
                vozvratObj.UpdateVozvrat(nakladnoyVozvratCmb.Text, kod, summaPropis, double.Parse(propis));
            }

            
            kodVozvrataTxb.Text = kod.ToString();
            DataTable dt = vozvratObj.printCkekQuery(nakladnoyVozvratCmb.Text, kod);
            string kodKlienta = "";
            foreach (DataRow dr in dt.Rows)
            {
                kodKlienta = dr["kodKlienta"].ToString();
                break;
            }
            retail retail = new retail();

            if (kodKlienta == "")
            {
               retail.dtForCHekReport = vozvratObj.printCkekQuery(nakladnoyVozvratCmb.Text, kod);
               retail.nameOfReport = "ChekReportOtmenaRozn";

            }
            else
            {
                retail.dtForCHekReport = vozvratObj.printCkekQuery(nakladnoyVozvratCmb.Text, kod);
               retail.nameOfReport = "ChekReportOtmenaOpt";

            }

            vozvratDGV.Rows.Clear();
            MessageBox.Show("Возврат успешно оформлен!");
            ChekReportPrint reportPrintObj = new ChekReportPrint();
            reportPrintObj.Show();


        EndProcess: { }
        }
    }
}
