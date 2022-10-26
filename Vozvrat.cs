using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.VozvratKlas;
using Core.Controllers.RoznichProdazha;

namespace AutoMir2022
{
    public partial class Vozvrat : Form
    {
        public Vozvrat()
        {
            InitializeComponent();
            DateTime datatoday = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            dateStart.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateStart.Value = datatoday;
            dateEnd.Value = datatoday;

            
        }


        private void zakrit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nakladnoyNaitiCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nakladnoyNaitiCmb.Text = nakladnoyNaitiCmb.GetItemText(nakladnoyNaitiCmb.SelectedItem);
            naitiDGV.Rows.Clear();
            
            VozvratKlas vozvratObj = new VozvratKlas();
            DataTable dt = vozvratObj.SelectDataDGV(nakladnoyNaitiCmb.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int index = naitiDGV.Rows.Add();

                    naitiDGV.Rows[index].Cells[0].Value = dr[0];
                    naitiDGV.Rows[index].Cells[1].Value = dr[1];
                    naitiDGV.Rows[index].Cells[2].Value = dr[2];
                    naitiDGV.Rows[index].Cells[3].Value = dr[3];
                    dataTxb.Text = Convert.ToDateTime(dr[4]).ToString("dd.MM.yyyy");
                }
                
                RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                roznichProdazhaObj.SumOfColumnDataGridVeiw(ref naitiDGV, "suma", "", "", "", 0);


            }
        }

        public void show_all()
        {
            VozvratKlas vozvratObj = new VozvratKlas();
            nakladnoyNaitiCmb.DisplayMember = "накладной_текст";
            nakladnoyNaitiCmb.DataSource = vozvratObj.SelectNomerNakladnoy();
            nakladnoyNaitiCmb.Text = "";


            kodKlientaNaitiCmb.DisplayMember = "код_клиента";
            kodKlientaNaitiCmb.DataSource = vozvratObj.SelectKodKlienta();
            kodKlientaNaitiCmb.Text = "";

            artikulCmb.DisplayMember = "артикул";
            artikulCmb.DataSource = vozvratObj.SelectArtikul();
            artikulCmb.Text = "";


        }

        private void Vozvrat_Load(object sender, EventArgs e)
        {
            show_all();
        }
    }
}
