using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Chek;
using Core.Controllers.RoznichProdazha;
using Microsoft.Reporting.WinForms;
using Core.Controllers.Klient;
using Core.Controllers.Dolg;

namespace AutoMir2022
{
    public partial class ItogiOptProdazhi : Form
    {
        private Klient klientObj = new Klient();
        private Dolg DolgObj = new Dolg();

        public ItogiOptProdazhi()
        {
            InitializeComponent();
            DateTime datatoday =Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            dateBigin.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateBigin.Value = datatoday;
            dateEnd.Value = datatoday;
            

        }

        private void sumBtn_Click(object sender, EventArgs e)
        {
            Chek chekObj = new Chek();
            string suma=chekObj.SelectSumaProdazhiWithChek();
            if (suma == "") suma = "0";
            MessageBox.Show("Сумма проданных со знаком чек на сегодня равняется = " + suma.ToString());
        }

        

        private void reportBtn_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();

            Chek chekObj = new Chek();
            string path = Path.GetDirectoryName(Application.StartupPath);
            string fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportPeriod.rdlc";

            reportViewer1.LocalReport.ReportPath = fullPath;

            string dataStart = dateBigin.Value.ToString("dd.MM.yyyy");
            string dataEnd = dateEnd.Value.ToString("dd.MM.yyyy");
            ReportParameter[] parms = new ReportParameter[2];

            parms[0] = new ReportParameter("dataStart", dataStart);
            parms[1] = new ReportParameter("dataEnd", dataEnd);
            reportViewer1.LocalReport.SetParameters(parms);

            DataTable dt = chekObj.GetByParametrDate(DateTime.Parse(dataStart), DateTime.Parse(dataEnd));

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportPeriod", dt));
            
            //report.SetParameters(parms);
            

            this.reportViewer1.RefreshReport();
            reportViewer1.Visible = true;

        }

        private void ChekFrm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

       

        private void kodKlienta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();

            Chek chekObj = new Chek();
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\ItogiProdazhi.rdlc");

            reportViewer1.LocalReport.ReportPath = reportPath;
            DataTable klientInfo= klientObj.GetKlientInfo(kodKlienta.Text);
            
            DataTable dt = new DataTable();
            
            dt.Columns.Add("KodKlienta");
            dt.Columns.Add("Fio");
            dt.Columns.Add("Adres");
            dt.Columns.Add("Tel");
            dt.Columns.Add("Ostatok");

            DataRow dr = null;
            dr = dt.NewRow();
            dr["KodKlienta"] =klientInfo.Rows[0][0].ToString();
            dr["Fio"] = klientInfo.Rows[0][1].ToString();
            dr["Adres"] = klientInfo.Rows[0][3].ToString();
            dr["Tel"] = klientInfo.Rows[0][2].ToString();
            dr["Ostatok"] = Convert.ToDouble( DolgObj.GetOstatok(kodKlienta.Text));
            
            //for (int i = 0; i < 10; i++)
            //{
            //    dr = dt.NewRow(); // have new row on each iteration
            //    dr["ProductId"] = i.ToString();
            //    dr["ProductTotalPrice"] = (i * 1000).ToString();
            //    dt.Rows.Add(dr);
            //}


            //string dataStart = dateBigin.Value.ToString("dd.MM.yyyy");
            //string dataEnd = dateEnd.Value.ToString("dd.MM.yyyy");
            //ReportParameter[] parms = new ReportParameter[2];

            //parms[0] = new ReportParameter("dataStart", dataStart);
            //parms[1] = new ReportParameter("dataEnd", dataEnd);
            //reportViewer1.LocalReport.SetParameters(parms);

            //DataTable dt = chekObj.GetByParametrDate(DateTime.Parse(dataStart), DateTime.Parse(dataEnd));


            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ItogiProdazhi", dt));

            //report.SetParameters(parms);


            this.reportViewer1.RefreshReport();
            reportViewer1.Visible = true;

        }
    }
}
