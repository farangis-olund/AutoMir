using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Core.DB;
using Microsoft.Reporting.WinForms;
using Npgsql;
using NpgsqlTypes;


namespace Core.Reports.ReportPrint
{
    class ReportPrint
    {
        private DBNpgsql db = new DBNpgsql();

        
        public void reportVeiwerPrint(ref ReportViewer reportViewer, string reportName, string [,] parametrs, string dataset, DataTable dt)
        {
            
            reportViewer.Reset();
            reportViewer.LocalReport.DataSources.Clear();

            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\" + reportName + ".rdlc");

            reportViewer.LocalReport.ReportPath = reportPath;
            ReportParameter[] parms = new ReportParameter[parametrs.Length/2];
            for (int i=0; i<parametrs.Length/2; i++)
            {
                parms[i] = new ReportParameter(parametrs[i, 0], parametrs[i, 1]);
            }
            
            reportViewer.LocalReport.SetParameters(parms);
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataset, dt));

            reportViewer.RefreshReport();
        }

          public DataTable ConvertDataGridToDataTable(ref DataGridView dgv)
        {
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            return dt;
        }
        

        public DataTable PrikhodaRaskhodReportOshibka()
        {
            return db.GetByQuery("SELECT артикул as artikul, приход_расход as prikhod_raskhod FROM public.приход_ошибки");
            
        }

        public string ConnectionString(string FileName, string Header)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
            }

            Builder.DataSource = FileName;

            return Builder.ConnectionString;

        }

        public DataTable OpenFile(ref OpenFileDialog ofd)
        { DataTable dt = new DataTable();
            ofd.Filter = "Excel Worksheets|*.xls; *.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = ofd.FileName;
                dt = LoadData(sFileName, "Sheet1");
            }
            return dt;
        }
            public DataTable LoadData(string FileName, string SheetName)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            DataTable dt = new DataTable();

            using (OleDbConnection cn = new OleDbConnection
            { ConnectionString = ConnectionString(FileName, "YES") })
            {

                cn.Open();

                using (OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT * FROM [" + SheetName + "$] WHERE [артикул]<>null",
                    Connection = cn
                })

                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }

                return dt;
            }
        }

    }
}
