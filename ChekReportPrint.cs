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
            string path = Path.GetDirectoryName(Application.StartupPath);
            string fullPath = "";

            if (checkType == "ChekReportSkidka")
            {
                fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportSkidka.rdlc";

            }
            else if (checkType == "ChekReport")
            {
                fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReport.rdlc";

            }
            else if (checkType == "ChekReportOtmenaRozn" || checkType == "ChekReportOtmenaOpt")
            {
                fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 10) + @"\Reports\ChekReportOtmena.rdlc";

            }


            reportViewer1.LocalReport.ReportPath = fullPath;

           reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportChek", retail.dtForCHekReport));

           
            this.reportViewer1.RefreshReport();
        }
    }
}
