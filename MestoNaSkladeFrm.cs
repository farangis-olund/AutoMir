using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.MestoNaSkalde;
namespace AutoMir2022
{
    public partial class MestoNaSkladeFrm : Form
    {
        public MestoNaSkladeFrm()
        {
            InitializeComponent();
            MestoNaSklade mestoNaSkladeObj = new MestoNaSklade();
            artikulCmb.DisplayMember = "артикул";
            artikulCmb.DataSource = mestoNaSkladeObj.SelectDistinct();
            artikulCmb.Text = null;
            

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            mestoNaSkladeDGV.Rows.Clear();
            MestoNaSklade mestoNaSkladeObj = new MestoNaSklade();
             DataTable dt = mestoNaSkladeObj.SelectDataForDGV(artikulCmb.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int index = mestoNaSkladeDGV.Rows.Add();
                    mestoNaSkladeDGV.Rows[index].Cells[0].Value = dr[0];
                    mestoNaSkladeDGV.Rows[index].Cells[1].Value = dr[1];
                    mestoNaSkladeDGV.Rows[index].Cells[2].Value = dr[2];
                    mestoNaSkladeDGV.Rows[index].Cells[3].Value = dr[3];
                    mestoNaSkladeDGV.Rows[index].Cells[4].Value = dr[4];
                    mestoNaSkladeDGV.Rows[index].Cells[5].Value = dr[5];
                    mestoNaSkladeDGV.Rows[index].Cells[6].Value = dr[6];

                    mestoTxb.Text = dr[6].ToString();
                }
            }

            }


            private void changeBtn_Click(object sender, EventArgs e)
            {
                MestoNaSklade mestoNaSkladeObj = new MestoNaSklade();
                mestoNaSkladeObj.updateMesto(artikulCmb.Text, mestoTxb.Text);
                showBtn.PerformClick();

            }

        
    }
}
