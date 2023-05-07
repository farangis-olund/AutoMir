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
using Core.Controllers.ProverkaNaOshibku;
using Core.Controllers.RoznichProdazha;

namespace AutoMir2022
{
    public partial class RaskhodiFrm : Form
    {
        Raskhdi raskhdiObj = new Raskhdi();
        private int id;
        public RaskhodiFrm()
        {
            InitializeComponent();
        }

        private void RaskhodiFrm_Load(object sender, EventArgs e)
        {

            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            DataTable prodov = roznichProdazhaObj.getNameSeller();
            if (prodov.Rows.Count != 0)
            {
                prodovets.DataSource = prodov;
                prodovets.DisplayMember = "продавец";
                prodovets.Text = null;

            }

            DataTable dt = raskhdiObj.GetNaimenovanie();
            if (dt.Rows.Count != 0)
            {
                viborPoluchatel.DataSource = dt;
                viborPoluchatel.DisplayMember = "наименование_расхода";
                viborPoluchatel.Text = null;
            }
        }

        private void oformits_Click(object sender, EventArgs e)
        {
            id = raskhdiObj.GetLastRaskhodi();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                raskhdiObj.InsertRaskhodi(id, prodovets.Text, dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()
                    , Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
            }
            MessageBox.Show("Расход оформлен!");
            dataGridView1.Rows.Clear();

        }

        
        private void add_Click(object sender, EventArgs e)
        {
            int rowNum = dataGridView1.Rows.Count;

            if (rowNum > 0)
            {

                if (dataGridView1.Rows[rowNum - 1].Cells[0].Value == null)
                {
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[rowNum - 1]);

                }
            }
            int b = 0;
           
            if (int.TryParse(sumTjs.Text, out b))
            {
                int index = dataGridView1.Rows.Add();
                KursValyuti kursValyutiObj = new KursValyuti();
                dataGridView1.Rows[index].Cells["poluchatel"].Value = viborPoluchatel.Text;
                dataGridView1.Rows[index].Cells["opisanie"].Value = opis.Text;
                dataGridView1.Rows[index].Cells["sumaTJS"].Value = sumTjs.Text;
                dataGridView1.Rows[index].Cells["sumaUSD"].Value = Math.Round(b / Convert.ToDouble(kursValyutiObj.GetKursValyuti()), 2);
                RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                roznichProdazhaObj.SumOfColumnDataGridVeiw(ref dataGridView1, "sumaTJS", "sumaUSD", "", "", "", "", 0);
                Ochistka();
            }
            else
            {
                MessageBox.Show("Количество задан неправельно!");
                sumTjs.Text = null;
            }
        

        }

        private void Ochistka()
        {
            viborPoluchatel.Text = null;
            opis.Text = null;
            sumTjs.Text = null;
        }

        private void clean_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void chek_Click(object sender, EventArgs e)
        {
            DataTable dt = raskhdiObj.GetRaskhodi(id);
            OrgInfo org = new OrgInfo();
           
            string[,] parametr = {{ "kod_org", org.org_kod }};
            ReportPrikhodRaskhod reportPrikhodRaskhod = new ReportPrikhodRaskhod();
            reportPrikhodRaskhod.StartReport("ChekRaskhodi", "DtReportChek", parametr, dt,"yes");
            reportPrikhodRaskhod.Show();

        }
    }
}
