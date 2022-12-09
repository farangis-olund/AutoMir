using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AutoMir2022
{
    public partial class ChekReportPrint : Form
    {
        public ChekReportPrint()
        {
            InitializeComponent();
        
        }

        private void ChekReportPrint_Load(object sender, EventArgs e)
        {

            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            string checkType = retail.nameOfReport;
            double vozvratDolg = Vozvrat.dolg;
            double optProdazhaDolg = OptProdazha.dolgKlienta;
            double optPlatezhi = OptProdazha.platezhiKlienta;
           
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\" + checkType + ".rdlc");
            
            
            reportViewer1.LocalReport.ReportPath = reportPath;

            if (checkType == "ChekReportVozvratProshOpt")
            {
                ReportParameter param = new ReportParameter();
                param = new ReportParameter("dolg", vozvratDolg.ToString("0.00"));
                
                reportViewer1.LocalReport.SetParameters(param);
            }

            if (checkType == "ChekReportOpt" || checkType == "ChekReportOptPlatezh")
            {
                ReportParameter[] parms = new ReportParameter[2];

                parms[0] = new ReportParameter("dolg", optProdazhaDolg.ToString("0.00"));
                parms[1] = new ReportParameter("platezhi", optPlatezhi.ToString("0.00"));
                reportViewer1.LocalReport.SetParameters(parms);
               
            }

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportChek", retail.dtForCHekReport));
         
            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.PrintToPrinter();
        }
    }
}
