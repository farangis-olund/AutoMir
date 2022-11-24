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
using Core.Reports.ReportPrint;

namespace AutoMir2022
{
    public partial class OtchetProdazhaTovarov : Form
    {
        public OtchetProdazhaTovarov()
        {
            InitializeComponent();
        }

        private void OtchetProdazhaTovarov_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void report_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string reportTitle = "";
            double prodazha = 0;
            double vozvrat = 0;
            double raskhodi = 0;
            double protsProdazhi = 0;
            double kassa = 0;

            string reportName = "";
            string dataStart = startData.Value.ToString("dd.MM.yyyy");
            string dataEnd = endData.Value.ToString("dd.MM.yyyy");
            int b = 0;
            ProdazhaItog prodazhaItogObj = new ProdazhaItog();
            if (roznOtchet.Checked == true)
            {
                dt = prodazhaItogObj.GetOtchetRoznProdazhi(Convert.ToDateTime(dataStart),Convert.ToDateTime( dataEnd)) ;
                reportTitle = "ОТЧЕТ О РОЗНЕЧНОЙ ПРОДАЖЕ";
                reportName = "ItogiRoznProdazhi";
                prodazha = prodazhaItogObj.GetProdazhaRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                vozvrat = prodazhaItogObj.GetVozvratRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                raskhodi = prodazhaItogObj.GetRaskhodi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                protsProdazhi = prodazhaItogObj.GetProtsenti(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
                kassa = prodazhaItogObj.GetItogiKassi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
            }

            OrgInfo org = new OrgInfo();
            ReportPrint rp = new ReportPrint();

            string[,] parametr = { {"reportTitle", reportTitle },
            { "kod_org", org.org_kod }, 
            { "name_org", org.org_name },
            { "prodazha", prodazha.ToString()},
            { "vozvrat", vozvrat.ToString()},
            { "raskhodi", raskhodi.ToString()},
            { "protsentProdazha", protsProdazhi.ToString()},
            { "kassa", kassa.ToString()},

            { "startDate", dataStart},
            { "endDate", dataEnd}};

            rp.reportVeiwerPrint(ref this.reportViewer1, reportName, parametr, "OtchetOstatokTovara", dt, "no");
            
        endProcess: { }
        }
    }
}
