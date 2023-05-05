using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers;
using Core.Controllers.Chek;
using Core.Controllers.RoznichProdazha;
using Microsoft.Reporting.WinForms;

namespace AutoMir2022
{
    public partial class ChekFrm : Form
    {
        public ChekFrm()
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

        private void updateBtn_Click(object sender, EventArgs e)
        {

            Chek chekObj = new Chek();
            chekObj.updateChekProdazha(nakNomerTxb.Text);
            MessageBox.Show("Таблица продажа обновлен!");
            updateBtn.Enabled = false;
            checkBox1.Enabled = false;
            checkBox1.Checked = false;
            nakNomerTxb.Text = null;

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();



            Chek chekObj = new Chek();

            //string exeFolder = Application.StartupPath;
            //string fullPath = Path.Combine(exeFolder, @"\Reports\ChekReportPeriod.rdlc");
           
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);          
            string fullPath = path + @"\Reports\ChekReportPeriod.rdlc";

            //string path = Path.GetDirectoryName(Application.StartupPath);
            //string fullPath = Path.GetDirectoryName(Application.StartupPath).Remove(path.Length - 11) + @"\Reports\ChekReportPeriod.rdlc";

            reportViewer1.LocalReport.ReportPath = fullPath;

            string dataStart = dateBigin.Value.ToString("dd.MM.yyyy");
            string dataEnd = dateEnd.Value.ToString("dd.MM.yyyy");
            ReportParameter[] parms = new ReportParameter[2];

            parms[0] = new ReportParameter("dataStart", dataStart);
            parms[1] = new ReportParameter("dataEnd", dataEnd);
            reportViewer1.LocalReport.SetParameters(parms);

            DataTable dt = chekObj.GetByParametrDate(DateTime.Parse(dataStart), DateTime.Parse(dataEnd));

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportPeriod", dt));

           
            char[] spliter = { '_' };
            this.reportViewer1.RefreshReport();
            //получаем категории доступа для пользовательских ограничений

            //DostupOgranichenie dostupOgranichenieObj = new DostupOgranichenie();
            //DataTable userKategori = dostupOgranichenieObj.GetDostupUser(MainMenu.user, MainMenu.password);

            //    foreach (DataRow dr in userKategori.Rows)
            //    {

            //        string[] enableItems = dr[0].ToString().Split(spliter);

            DataRow[] rows = MainMenu.userKategori.Select($"{"контроль"} LIKE '%{"ChekFrm_reportView1_enable_true"}%'");

            // Check if any rows were found
            if (rows.Length > 0)
                   reportViewer1.Enabled = true;
            else
                   reportViewer1.Enabled = false;
                //}


            reportViewer1.Visible = true;
            reportViewer1.LocalReport.PrintToPrinter();
        }

        private void ChekFrm_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void proveritBtn_Click(object sender, EventArgs e)
        {
            Chek chekObj = new Chek();
            string isExist=chekObj.chekProdazhaIsExist(nakNomerTxb.Text);
            if (isExist == "False")
            {
                updateBtn.Enabled = true;
                checkBox1.Enabled = true;
            }
        }
    }
}
