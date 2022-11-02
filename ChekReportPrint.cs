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
            string path = Path.GetDirectoryName(Application.StartupPath);
            string fullPath = "";

            fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\" + checkType + ".rdlc";

            //if (checkType == "ChekReportSkidka")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportSkidka.rdlc";

            //}
            //else if (checkType == "ChekReport")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\"+checkType + ".rdlc";

            //}
            //else if (checkType == "ChekReportOpt")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportOpt.rdlc";

            //}

            //else if (checkType == "ChekReportOtmenaRozn" || checkType == "ChekReportOtmenaOpt")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportOtmena.rdlc";

            //}
            //else if (checkType == "ChekReportVozvrat")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportVozvrat.rdlc";

            //}

            //else if (checkType == "ChekReportVozvratProshOpt")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportVozvratProshOpt.rdlc";

            //}

            //else if (checkType == "ChekReportVozvratProshRozn")
            //{
            //    fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportVozvratProshRozn.rdlc";

            //}


            reportViewer1.LocalReport.ReportPath = fullPath;

            if (checkType == "ChekReportVozvratProshOpt")
            {
                ReportParameter param = new ReportParameter();
                param = new ReportParameter("dolg", vozvratDolg.ToString("0.00"));
                
                reportViewer1.LocalReport.SetParameters(param);
            }

            if (checkType == "ChekReportOpt")
            {
                ReportParameter[] parms = new ReportParameter[2];

                parms[0] = new ReportParameter("dolg", optProdazhaDolg.ToString("0.00"));
                parms[1] = new ReportParameter("platezhi", optPlatezhi.ToString("0.00"));
                reportViewer1.LocalReport.SetParameters(parms);
            }

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportChek", retail.dtForCHekReport));

           
            this.reportViewer1.RefreshReport();
        }
    }
}
