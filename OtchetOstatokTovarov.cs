using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers;
using Core.Controllers.OrgInfo;
using Core.Controllers.Tovar;
using Core.Reports.ReportPrint;

namespace AutoMir2022
{
    public partial class OtchetOstatokTovarov : Form
    {
        public OtchetOstatokTovarov()
        {
            InitializeComponent();
        }
        private Tovar tovarObj = new Tovar();
        private OtchetOstatokTovar OtchetOstatokTovarObj = new OtchetOstatokTovar();

        private void OtchetOstatokTovarov_Load(object sender, EventArgs e)
        {
            vozvrat.Checked = false;
            this.reportViewer1.RefreshReport();
        }

        private void show_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            string reportTitle = "";
            int optVozvrat = 0;
            int roznVozvrat = 0;
            string reportName = "";
            string dateString = "";
            string dataStart = startPeriod.Value.ToString("dd.MM.yyyy");
            string dataEnd = endPeriod.Value.ToString("dd.MM.yyyy");
            int b = 0;
           
            //отчет о возврате
            if (date.Text != "" && vozvrat.Checked == true)
            {
                dt = OtchetOstatokTovarObj.GetVozvratByArtikul(Convert.ToDateTime(date.Text));
                reportTitle = "ОТЧЕТ О ВОЗВРАТЕ ТОВАРОВ";
                optVozvrat = OtchetOstatokTovarObj.GetVozvratOpt(Convert.ToDateTime(date.Text)) + OtchetOstatokTovarObj.GetVozvratProshOpt(Convert.ToDateTime(date.Text));
                roznVozvrat = OtchetOstatokTovarObj.GetVozvratRozn(Convert.ToDateTime(date.Text)) + OtchetOstatokTovarObj.GetVozvratProshRozn(Convert.ToDateTime(date.Text));
                reportName = "ReportOstatokTovara";
                dateString = date.Text;
            }
            //отчет о отмены продаж
            else if (date.Text != "" && otmena.Checked == true)
            {
                dt = OtchetOstatokTovarObj.GetOtmenaByArtikul(Convert.ToDateTime(date.Text));
                reportTitle = "ОТЧЕТ О ТОВАРАХ ОТМЕНЕННЫХ ПРОДАЖ";
                optVozvrat = OtchetOstatokTovarObj.GetOtmenaOpt(Convert.ToDateTime(date.Text));
                roznVozvrat = OtchetOstatokTovarObj.GetOtmenaRozn(Convert.ToDateTime(date.Text));
                reportName = "ReportOstatokTovara";
                dateString = date.Text;
                showParam();
            }
            else if (mestoNaSklade.Checked == true)
            {
                dt = tovarObj.GetAllTovarBySectorRjad(sector.Text, rjad.Text);
                reportTitle = "ОТЧЕТ О МЕСТЕ НА СКЛАДЕ";
                reportName = "PoMestoNaSklade";
                dateString = "date";
            }

            else if (neaktivnie.Checked == true)
            {
                if (brand.Text == "" || kolTov.Text == "")
                {
                    MessageBox.Show("Фирма или количество товара не указан!");
                    goto endProcess;
                }

                
                if (int.TryParse(kolTov.Text, out b))
                {
                    dt = OtchetOstatokTovarObj.GetPradazhaByPeriod(Convert.ToDateTime(dataStart),
                    Convert.ToDateTime(dataEnd), brand.Text, Convert.ToInt32(kolTov.Text));
                }
                else
                {
                    MessageBox.Show("количество товара задан не правильном формате!");
                    goto endProcess;
                }

                reportTitle = "ОТЧЕТ О НЕАКТИВНЫХ ТОВАРОВ СКЛАДА";
                reportName = "NeaktivnieTovariSklada";
                dateString = "date";
            }
            else if (dopAlternativ.Checked == true)
            {

                if (int.TryParse(kolTov.Text, out b))
                {
                    dataGridView1.DataSource = OtchetOstatokTovarObj.GetDopAlternativ(Convert.ToInt32(kolTov.Text));
                    dataGridView1.Columns[0].Width = 180;
                    goto endProcess;
                }else
                {
                    MessageBox.Show("количество товара задан не правильном формате!");
                    goto endProcess;
                }
            } else if (spisokTovarov.Checked==true)
            {
                dt = tovarObj.GetSpisokTovarov();
                reportTitle = "СПИСОК ВСЕХ ТОВАРОВ СКЛАДА";
                reportName = "SpisokTovarov";
                dateString = "date";

            }

            OrgInfo org = new OrgInfo();
            ReportPrint rp = new ReportPrint();
           
            string[,] parametr = { {"reportTitle", reportTitle },{ "kod_org", org.org_kod }, { "name_org", org.org_name }, { "date",dateString },
            { "opt_vozvrat", optVozvrat.ToString()},
            { "rozn_vozvrat", roznVozvrat.ToString()},
            { "startDate", dataStart},
            { "endDate", dataEnd}};

            rp.reportVeiwerPrint(ref this.reportViewer1, reportName, parametr, "OtchetOstatokTovara", dt, "no");

        endProcess: { }
        }

        private void vozvrat_Click(object sender, EventArgs e)
        {
            date.Enabled = true;
            date.DisplayMember = "дата";
            date.DataSource = OtchetOstatokTovarObj.GetVozvratDates();
            date.Text = null;
            showParam();
        }

        private void otmena_Click(object sender, EventArgs e)
        {
            date.Enabled = true;
            date.DisplayMember = "дата";
            date.DataSource = OtchetOstatokTovarObj.GetOtmenaDates();
            date.Text = null;
            showParam();
        }

        private void mestoNaSklade_Click(object sender, EventArgs e)
        {
            date.Text = null;
            date.Enabled = false;
            sector.Enabled = true;
            sector.DataSource = tovarObj.GetAllSectorTovar();
            sector.DisplayMember = "сектор";
            sector.Text = null;
            rjad.Enabled = true;
            showParam();
        }

        private void sector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sector.Text = sector.GetItemText(sector.SelectedItem);
            rjad.DataSource = tovarObj.GetAllSectorRjadTovar(sector.Text);
            rjad.Text = null;
            rjad.DisplayMember = "ряд";
        }

        private void minDopusk_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.DataSource = tovarObj.GetMinDopuskKolTovara();
            neakTovariGroup.Visible = false;
            otchetParam.Visible = true;
            reportViewer1.Visible = false;
        }

        private void neaktivnie_Click(object sender, EventArgs e)
        {
            neakTovariGroup.Visible = true;
            otchetParam.Visible = false;
            reportViewer1.Visible = true;
            kolTovarLabel.Text = "кол<=";
            brand.DataSource= tovarObj.GetBrand();
            brand.DisplayMember = "фирма";
            brand.Text = null;
        }

        private void showParam()
        {
            neakTovariGroup.Visible = false;
            otchetParam.Visible = true;
            reportViewer1.Visible = true;
        }

        private void dopAlternativ_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Укажите количество артикулов в группе альтернатива, для создание отчета!");
            kolTovarLabel.Text = "кол>=";
            dataGridView1.Visible = true;
            neakTovariGroup.Visible = true;
            otchetParam.Visible = false;
            reportViewer1.Visible = false;
        }

        private void spisokTovarov_Click(object sender, EventArgs e)
        {
            reportViewer1.Visible = true;
        }
    }
}
