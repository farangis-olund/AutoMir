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

namespace AutoMir2022.Core.Controllers.PrikhodRaskhodTovara
{
    public partial class ReportPrikhodRaskhod : Form  
    {
        public ReportPrikhodRaskhod()
        {
            InitializeComponent();
           

            
        }

        private void ReportPrikhodRaskhod_Load(object sender, EventArgs e)
        {
            
            
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
           
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\PrikhodRaskhod.rdlc");
                        
            reportViewer1.LocalReport.ReportPath = reportPath;
            ReportParameter[] parms = new ReportParameter[2];
            //parms[0] = new ReportParameter("kod_org", optProdazhaDolg.ToString("0.00"));
            //parms[1] = new ReportParameter("name_org", optPlatezhi.ToString("0.00"));
            //parms[2] = new ReportParameter("date", optPlatezhi.ToString("0.00"));
            reportViewer1.LocalReport.SetParameters(parms);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PrikhodRaskhod", retail.dtForCHekReport));

            this.reportViewer1.RefreshReport();
            
        }
    }
}
