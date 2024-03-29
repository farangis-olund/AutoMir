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
using Microsoft.Reporting.WinForms;
using Core.Reports.ReportPrint;
using System.Drawing.Printing;

namespace AutoMir2022
{
    public partial class ReportPrikhodRaskhod : Form  
    {
        public ReportPrikhodRaskhod()
        {
            InitializeComponent();
             
        }

        private void ReportPrikhodRaskhod_Load(object sender, EventArgs e)
        {
           
            this.reportViewer1.RefreshReport();
            
        }

        public void StartReport(string reportName, string dataset, string [,] parametrs, DataTable dt, string printYesNo)
        {
            
            ReportPrint rp = new ReportPrint();
             rp.reportVeiwerPrint(ref this.reportViewer1, reportName, parametrs, dataset, dt, printYesNo);
           
           
        }
       

        private void ReportPrikhodRaskhod_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }




    }
}
