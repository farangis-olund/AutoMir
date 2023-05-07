using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Sklad;
using Core.Controllers.RoznichProdazha;

namespace AutoMir2022
{
    public partial class SkladFrm : Form
    {
        public bool closeButton;
        public SkladFrm()
        {
            InitializeComponent();
            RefreshFrm();
            
        }

       


        private void ViborSklad_Click(object sender, EventArgs e)
        {
            Sklad skladObj = new Sklad();
            bool oplachIsChecked = oplachenoChk.Checked;
            bool skladIsChecked = SkladChek.Checked;
            
            if (oplachIsChecked && skladIsChecked)
            {
                skladObj.updateProdazha(NomerNakladnoyCmb.Text, skladIsChecked);
                RefreshFrm();
            }
          
        }



        private void ViborNakl_Click(object sender, EventArgs e)
        {
            
            
            
        }





        public void RefreshFrm()
        {
            Sklad skladObj = new Sklad();
            NomerNakladnoyCmb.DataSource = skladObj.SelectNomerNakladnoy();
            NomerNakladnoyCmb.DisplayMember = "накладной_текст";
            NomerNakladnoyCmb.Text = null;
            skladDGV.DataSource = null;
            oplachenoChk.Checked = false;
            SkladChek.Checked = false;
            DataTxt.Text = "";
            skladDGV.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NomerNakladnoyCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NomerNakladnoyCmb.Text = NomerNakladnoyCmb.GetItemText(NomerNakladnoyCmb.SelectedItem);
            
            Sklad skladObj = new Sklad();
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            DataTable dt = skladObj.SelectDataSklad(NomerNakladnoyCmb.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int index = skladDGV.Rows.Add();
                    skladDGV.Rows[index].Cells[0].Value = dr[0];
                    skladDGV.Rows[index].Cells[1].Value = dr[1];
                    skladDGV.Rows[index].Cells[2].Value = dr[2];
                    skladDGV.Rows[index].Cells[3].Value = dr[3];
                    skladDGV.Rows[index].Cells[4].Value = dr[4];

                }

                //skladDGV.DataSource = skladObj.SelectDataSklad(NomerNakladnoyCmb.Text);
                if (skladDGV.Rows.Count > 0)
                {
                    oplachenoChk.Checked = true;
                    DataTxt.Text = Convert.ToDateTime(skladDGV.Rows[0].Cells[0].Value).ToString("D");
                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref skladDGV, "suma", "", "", "", "", "", 0);
                }
            }
        }

        private void SkladFrm_Load(object sender, EventArgs e)
        {
            if (closeButton == true) button1.Visible = false;
            else button1.Visible = true;
        }
    }
}
