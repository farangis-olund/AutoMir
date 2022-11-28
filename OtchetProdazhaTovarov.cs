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
        private ProdazhaItog prodazhaItogObj = new ProdazhaItog();
        public OtchetProdazhaTovarov()
        {
            InitializeComponent();
        }

        private void OtchetProdazhaTovarov_Load(object sender, EventArgs e)
        {
            prosentOpt.Text = prodazhaItogObj.GetProtsent().Item2.ToString();
            protsentRozn.Text = prodazhaItogObj.GetProtsent().Item1.ToString();
            this.reportViewer1.RefreshReport();
        }

        private void report_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string reportTitle = "";
            double prodazha = 0;
            double vozvrat = 0;
            double raskhodi = 0;
            double platezhi = 0;
            double ostatok = 0;
            double protsProdazhi = 0;
            double kassa = 0;

            string reportName = "";
            string reportDataSet = "";
            string dataStart = startData.Value.ToString("dd.MM.yyyy");
            string dataEnd = endData.Value.ToString("dd.MM.yyyy");
            int b = 0;
            string[,] parametr = new string[10,2];
            OrgInfo org = new OrgInfo();
            ReportPrint rp = new ReportPrint();

            if (roznOtchet.Checked == true)
            {
                dt = prodazhaItogObj.GetOtchetRoznProdazhi(Convert.ToDateTime(dataStart),Convert.ToDateTime( dataEnd)) ;
                reportTitle = "ОТЧЕТ О РОЗНЕЧНОЙ ПРОДАЖЕ";
                reportName = "ItogiRoznProdazhi";
                reportDataSet = "OtchetOstatokTovara";


                prodazha = prodazhaItogObj.GetProdazhaRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                vozvrat = prodazhaItogObj.GetVozvratRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                raskhodi = prodazhaItogObj.GetRaskhodi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                protsProdazhi = prodazhaItogObj.GetProtsenti(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
                kassa = prodazhaItogObj.GetItogiKassi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
                parametr = new string[10, 2] { {"reportTitle", reportTitle },
                { "kod_org", org.org_kod },
                { "name_org", org.org_name },
                { "prodazha", prodazha.ToString()},
                { "vozvrat", vozvrat.ToString()},
                { "raskhodi", raskhodi.ToString()},
                { "protsentProdazha", protsProdazhi.ToString()},
                { "kassa", kassa.ToString()},

                { "startDate", dataStart},
                { "endDate", dataEnd}};
            }
            else if (roznProsmotr.Checked==true)
            {
                dt = prodazhaItogObj.GetOtchetRoznProdazhiProsmotr(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                rp.reportVeiwProsmotr(ref reportViewer1, "ItogiRoznProdazhiProsmotr", "OtchetOstatokTovaraProsmotr", dt);
                goto endProcess;
            }

            else if (optProsmotr.Checked == true)
            {
                dt = prodazhaItogObj.GetOtchetOptProdazhiProsmotr(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                rp.reportVeiwProsmotr(ref reportViewer1, "ItogiOptProdazhiProsmotr", "OtchetOstatokTovaraProsmotr", dt);
                goto endProcess;
            }

            else if (prodazhaProdavtsev.Checked == true)
            {
                dt = prodazhaItogObj.GetProdovetItog(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                rp.reportVeiwProsmotr(ref reportViewer1, "ItogiProdavets", "OtchetOstatokTovaraProsmotr", dt);
                goto endProcess;
            }

            else if (optOtchet.Checked == true)
            {
                dt = prodazhaItogObj.GetOtchetOptProdazhi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                reportTitle = "ОТЧЕТ ОБ ОПТОВОЙ ПРОДАЖЕ";
                reportName = "ItogiOptProdazhi";
                reportDataSet = "OtchetOstatokTovara";

                prodazha = prodazhaItogObj.GetProdazhaOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                vozvrat = prodazhaItogObj.GetVozvratOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                platezhi = prodazhaItogObj.GetPlatezhOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                protsProdazhi = prodazhaItogObj.GetProtsenti(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item1;
                ostatok = prodazha - platezhi;
                kassa = prodazhaItogObj.GetItogiKassi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item1;

                parametr = new string[11, 2] { {"reportTitle", reportTitle },
                { "kod_org", org.org_kod },
                { "name_org", org.org_name },
                { "prodazha", prodazha.ToString()},
                { "vozvrat", vozvrat.ToString()},
                { "platezhi", platezhi.ToString()},
                { "protsentProdazha", protsProdazhi.ToString()},
                { "kassa", kassa.ToString()},
                { "ostatok", ostatok.ToString()},
                { "startDate", dataStart},
                { "endDate", dataEnd}};
            }

            else if (itogiProdazhiAll.Checked == true) {
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
                dt.Rows[0][0] = prodazhaItogObj.GetProdazhaRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][1] = prodazhaItogObj.GetProdazhaOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][2] = prodazhaItogObj.GetPlatezhRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][3] = prodazhaItogObj.GetPlatezhOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][4] = prodazhaItogObj.GetVozvratRozn(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][5] = prodazhaItogObj.GetVozvratOpt(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][6] = prodazhaItogObj.GetProtsenti(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
                dt.Rows[0][7] = prodazhaItogObj.GetProtsenti(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item1;
                dt.Rows[0][8] = prodazhaItogObj.GetItogiKassi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item2;
                dt.Rows[0][9] = prodazhaItogObj.GetItogiKassi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd)).Item1;
                dt.Rows[0][10] =prodazhaItogObj.GetRaskhodi(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));
                dt.Rows[0][11] = prodazhaItogObj.GetOstatok(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd));

                parametr = new string[4, 2] { 
                { "kod_org", org.org_kod },
                { "name_org", org.org_name },
               { "startDate", dataStart},
                { "endDate", dataEnd}};
                reportName = "TotalReportPeriod";
                reportDataSet = "ItogoviyOtchet";
               
            }

            else if (skidkaOtchet.Checked==true)

            {
                if (int.TryParse(skidka.Text,out b))
                {
                    dt = prodazhaItogObj.GetSkidkaSpetsPred(Convert.ToDateTime(dataStart), Convert.ToDateTime(dataEnd), Convert.ToInt32(skidka.Text));
                    reportTitle = "ОТЧЕТ О СКИДКАХ И СПЕЦ.ПРЕДЛОЖЕНИЯХ";
                    parametr = new string[5, 2] {
                {"reportTitle", reportTitle },
                { "kod_org", org.org_kod },
                { "name_org", org.org_name },
               { "startDate", dataStart},
                { "endDate", dataEnd}};

                    reportName = "SkidkaSpetsPredlozhenie";
                    reportDataSet = "OtchetOstatokTovaraProsmotr";

                }
                else
                {
                    skidka.Text = null;
                    MessageBox.Show("Скидка узазан не правильном формате!");
                    goto endProcess;
                }
            }


            rp.reportVeiwerPrint(ref this.reportViewer1, reportName, parametr, reportDataSet, dt, "no");
            
        endProcess: { }
        }
    }
}
