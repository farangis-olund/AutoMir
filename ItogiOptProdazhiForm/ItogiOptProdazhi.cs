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
using System.Globalization;

namespace AutoMir2022
{
    public partial class ItogiOptProdazhi : Form
    {
        private Klient klientObj = new Klient();
        private Dolg DolgObj = new Dolg();
        private bool reportCheck;

        public ItogiOptProdazhi()
        {
            InitializeComponent();
            DateTime datatoday =Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            dateBigin.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateBigin.Value = datatoday;
            dateEnd.Value = datatoday;
            reportCheck = false;
            

        }

       
        private void reportBtn_Click(object sender, EventArgs e)
        {
            reportCheck = true;
            DataTable itogProdazha= DolgObj.GetAllItogByPeriod(dateBigin.Value, dateEnd.Value);
            FullOfreport(itogProdazha);

        }

        private void ChekFrm_Load(object sender, EventArgs e)
        {
            kodKlienta.DataSource= klientObj.GetKodKlienta();
            kodKlienta.DisplayMember = "код_клиента";
            //this.reportViewer1.RefreshReport();
        }

       

        private void kodKlienta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kodKlienta.Text = kodKlienta.GetItemText(kodKlienta.SelectedItem);
            reportCheck = false;
            FullOfreport(klientObj.GetKlientInfo(kodKlienta.Text));
           
        }

        private void FullOfreport(DataTable klientInfo)
        {

            DataTable dt = new DataTable();

            if (reportCheck == false)
            {
                dt.Columns.Add("KodKlienta");
                dt.Columns.Add("Fio");
                dt.Columns.Add("Adres");
                dt.Columns.Add("Tel");
                dt.Columns.Add("Data");
                dt.Columns.Add("Ostatok");

                DataRow dr = null;

                for (int i = 0; i < klientInfo.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["KodKlienta"] = klientInfo.Rows[i][0].ToString();
                    dr["Fio"] = klientInfo.Rows[i][1].ToString();
                    dr["Adres"] = klientInfo.Rows[i][3].ToString();
                    dr["Tel"] = klientInfo.Rows[i][2].ToString();
                    dr["Data"] = DolgObj.GetPradazhaLastDate(klientInfo.Rows[i][0].ToString());
                    string text = DolgObj.GetOstatok(klientInfo.Rows[i][0].ToString()).ToString();
                    text = text.Replace(',', '.');
                    dr["Ostatok"] = text;
                    dt.Rows.Add(dr);
                    
                }
                

            } else
            {
                dt = klientInfo;
            }


            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();

            string exeFolder = Application.StartupPath;
            string reportName = "";
            if (reportCheck == true)
                reportName = "ItogiProdazhiPeriod";
            else
                reportName = "ItogiProdazhi";
            
            string reportPath = Path.Combine(exeFolder, @"Reports\"+reportName+".rdlc");

            reportViewer1.LocalReport.ReportPath = reportPath;
            
            string dataStart = dateBigin.Value.ToString("dd.MM.yyyy");
            string dataEnd = dateEnd.Value.ToString("dd.MM.yyyy");
            ReportParameter[] parms = new ReportParameter[2];

            parms[0] = new ReportParameter("dataStart", dataStart);
            parms[1] = new ReportParameter("dataEnd", dataEnd);
            reportViewer1.LocalReport.SetParameters(parms);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ItogiProdazhi", dt));

            this.reportViewer1.RefreshReport();
            reportViewer1.Visible = true;

        }

        private void vseBtn_Click(object sender, EventArgs e)
        {
            reportCheck = false;
            FullOfreport(klientObj.GetAllKlientInfo());

        }
    }
}
