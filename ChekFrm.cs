﻿using System;
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

namespace AutoMir2022
{
    public partial class ChekFrm : Form
    {
        public ChekFrm()
        {
            InitializeComponent();
            string datatoday = DateTime.Now.ToString("dd/MM/yyyy");
            dateBigin.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;

            //dateBigin.CustomFormat = "dd.MM.yyyy";
            //dateEnd.CustomFormat = "dd.MM.yyyy";

            //Chek chekObj = new Chek();

            //string dataStart = dateBigin.Value.ToString("dd.MM.yyyy");
            //string dataEnd = dateEnd.Value.ToString("dd.MM.yyyy");


            //DataTable dt = chekObj.GetByParametrDate(DateTime.Parse(dataStart), DateTime.Parse(dataEnd));

            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtReportPeriod", dt));
            //ReportParameter[] parms = new ReportParameter[2];

            //parms[0] = new ReportParameter("dataStart", dataStart);
            //parms[1] = new ReportParameter("dataEnd", dataEnd);
            ////report.SetParameters(parms);
            //reportViewer1.LocalReport.SetParameters(parms);

            //reportViewer1.Refresh();


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
    }
}