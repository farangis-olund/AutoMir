using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Zakazi;
using Core.Controllers.Tovar;
using Core.Reports.ReportPrint;
using Core.Controllers.OrgInfo;
using Core.Reports.ReportPoItogom;


namespace AutoMir2022.DobavitTovarIsBDForm
{
    public partial class DobavitIsBD : Form
    {
        private Zakazi zakaziObj = new Zakazi();
        private Tovar tovarObj = new Tovar();
        private ReportPrint report = new ReportPrint();
        private ReportPrikhodRaskhod reportPrikhodRaskhod = new ReportPrikhodRaskhod();
        private ReportPoItogom ReportPoItogomObj = new ReportPoItogom();
        private OrgInfo org = new OrgInfo();
        public DobavitIsBD()
        {
            InitializeComponent();
        }

        private void DobavitIsBD_Load(object sender, EventArgs e)
        {
            dateZakaz.DataSource = zakaziObj.GetDateObnovlenieTovara();
            dateZakaz.DisplayMember = "Дата";
            dateZakaz.Text = null;
            this.reportViewer1.RefreshReport();
        }

        private void dateZakaz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.DataSource = zakaziObj.GetZakazByDate(Convert.ToDateTime(dateZakaz.Text));
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[5].Width = 200;

        }

        private void update_Click(object sender, EventArgs e)
        {
                    
            int countTovar = 0;
            if (zakaziObj.IsExist(Convert.ToDateTime(dateZakaz.Text)) == false)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        countTovar = countTovar + 1;
                        tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value), dataGridView1.Rows[i].Cells[0].Value.ToString(), "+");
                    }
                    zakaziObj.InsertObnovlenieTovara(Convert.ToDateTime(dateZakaz.Text), countTovar);
                    MessageBox.Show("Обновление успешно завершено!");
                }
                else MessageBox.Show("Вы не выбрали данные для обновления");

            } else MessageBox.Show("На данную дату обновления уже оформлен!");
        }

        private void export_Click(object sender, EventArgs e)
        {
            
            DataTable dt = zakaziObj.ExportObnovlenieTovara(Convert.ToDateTime(dateZakaz.Text));
           
            string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name },
                { "date", Convert.ToDateTime(dateZakaz.Text).ToString("dd.MM.yyyy") }};
            reportPrikhodRaskhod.StartReport("ObnovlenieTovaraExport", "PrikhodRaskhod", parametr, dt);
            reportPrikhodRaskhod.Show();
        }

        private void print_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name },
                { "date", Convert.ToDateTime(dateZakaz.Text).ToString("dd.MM.yyyy") }};

            if (totalReport.Checked == true)
            {
                dt.Columns.Add("prodazhaRozn");
                dt.Columns.Add("prodazhaOpt");
                dt.Columns.Add("platezhRozn");
                dt.Columns.Add("platezhOpt");
                dt.Columns.Add("vozvratRozn");
                dt.Columns.Add("vozvratOpt");
                dt.Columns.Add("protsentiRozn");
                dt.Columns.Add("protsentiOpt");
                dt.Columns.Add("kassaRozn");
                dt.Columns.Add("kassaOpt");
                dt.Columns.Add("raskhodi");
                dt.Columns.Add("ostatok");

                dt.Rows.Add();
                dt.Rows[0][0] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.prodazhaRozn);
                dt.Rows[0][1] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.prodazhaOpt);
                dt.Rows[0][2] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.platezhRozn);
                dt.Rows[0][3] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.platezhOpt);
                dt.Rows[0][4] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.vozvratRozn);
                dt.Rows[0][5] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.vozvratOpt);
                dt.Rows[0][6] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.protsentiRozn);
                dt.Rows[0][7] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.protsentiOpt);
                dt.Rows[0][8] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.kassaRozn);
                dt.Rows[0][9] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.kassaOpt);
                dt.Rows[0][10] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.raskhodi);
                dt.Rows[0][11] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.ostatok);
                reportPrikhodRaskhod.StartReport("TotalReport", "ItogoviyOtchet", parametr, dt);

            }
            if (obnovlenieReport.Checked == true)
            {
                dt = zakaziObj.GetZakazReportByDate(Convert.ToDateTime(dateZakaz.Text));
                reportPrikhodRaskhod.StartReport("ObnovlenieTovara", "PrikhodRaskhod", parametr, dt);

            }
            reportPrikhodRaskhod.Show();
        }
    }
}
