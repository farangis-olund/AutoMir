using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.KasaProdazha;
using Core.Controllers.KasaVozvrat;
using Core.Controllers.KasaOtmena;
using Core.Controllers.RoznichProdazha;
using Core.Controllers.Chek;

namespace AutoMir2022
{
    public partial class Kassa : Form
    {
        public Kassa()
        {
            
            InitializeComponent();
            showAllcombo();
        }

        private void ProdazhaBtn_Click(object sender, EventArgs e)
        {
            prodazhaDGV.Rows.Clear();
            prodazhaPlatezhCmb.Text = null; 
            KasaProdazha kasaObj = new KasaProdazha();
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            DataTable dt = kasaObj.SelectDataProdazhaKassa(prodazhaNaklCmb.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int index = prodazhaDGV.Rows.Add();
                    prodazhaDGV.Rows[index].Cells[0].Value = dr[0];
                    prodazhaDGV.Rows[index].Cells[1].Value = dr[1];
                    prodazhaDGV.Columns[1].HeaderText = "Артикул";
                    prodazhaDGV.Rows[index].Cells[2].Value = dr[2];
                    prodazhaDGV.Rows[index].Cells[3].Value = dr[3];
                    prodazhaDGV.Rows[index].Cells[4].Value = dr[4];
                    prodazhaDGV.Columns[2].Visible = true;
                    prodazhaDGV.Columns[3].Visible = true;
                    pradazhaChek.Checked =Convert.ToBoolean(dr[5]);
                }

                //skladDGV.DataSource = skladObj.SelectDataSklad(NomerNakladnoyCmb.Text);
                if (prodazhaDGV.Rows.Count > 0)
                {
                    prodazhaData.Text = Convert.ToDateTime(prodazhaDGV.Rows[0].Cells[0].Value).ToString("D");
                   
                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref prodazhaDGV, "suma", "", "", "", 0);
                    updateProdazhaBtn.Enabled = true;
                    prodazhaChekBtn.Enabled = true;
                }
            }

        }

        private void prodazhaChekBtn_Click(object sender, EventArgs e)
        {
            
            if (pradazhaChek.Checked == true && prodazhaNaklCmb.Text !="")
            {
                Chek chekObj = new Chek();
                chekObj.updateChekProdazha(prodazhaNaklCmb.Text);
                MessageBox.Show("Чек добавлен!");
                
            }


        }

        private void updateProdazhaBtn_Click(object sender, EventArgs e)
        {
            KasaProdazha kasaObj = new KasaProdazha();
            if (pradazhaOplCkb.Checked == true && prodazhaNaklCmb.Text!="")
            {
                kasaObj.updateProdazha(prodazhaNaklCmb.Text);
                showAllcombo();
                MessageBox.Show("Обновление успешно внесено!");
            }
            
            else if (pradazhaOplCkb.Checked == true && prodazhaPlatezhCmb.Text != "")
            {
                kasaObj.updatePlatezh(prodazhaPlatezhCmb.Text);
                showAllcombo();
                MessageBox.Show("Обновление успешно внесено!");
            }
            else { MessageBox.Show("Данные заданны некоректно или неправильном формате, обновление не внесен!");
            }


        }

        private void prodazhaPlatezhBtn_Click(object sender, EventArgs e)
        {
            prodazhaDGV.Rows.Clear();
            prodazhaNaklCmb.Text = null;
            if (prodazhaPlatezhCmb.Text != null)
            {
                RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
                KasaProdazha kasaObj = new KasaProdazha();

                DataTable dt = kasaObj.SelectDataPlatezhKassa( prodazhaPlatezhCmb.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int index = prodazhaDGV.Rows.Add();
                        prodazhaDGV.Rows[index].Cells[0].Value = dr[0];
                        prodazhaDGV.Rows[index].Cells[1].Value = dr[1];
                        prodazhaDGV.Columns[1].HeaderText = "Код клиента";
                        prodazhaDGV.Rows[index].Cells[4].Value = dr[2];
                        prodazhaDGV.Columns[2].Visible = false;
                        prodazhaDGV.Columns[3].Visible = false;

                    }

                    //skladDGV.DataSource = skladObj.SelectDataSklad(NomerNakladnoyCmb.Text);
                    if (prodazhaDGV.Rows.Count > 0)
                    {
                        prodazhaData.Text = Convert.ToDateTime(prodazhaDGV.Rows[0].Cells[0].Value).ToString("D");

                        roznichProdazhaObj.SumOfColumnDataGridVeiw(ref prodazhaDGV, "suma", "", "", "", 0);
                        updateProdazhaBtn.Enabled = true;
                    }
                }
            }
        }

        public void showAllcombo()
        {
            prodazhaDGV.Rows.Clear();
            prodazhaNaklCmb.DataSource = null;
            prodazhaPlatezhCmb.DataSource = null;
            prodazhaNaklCmb.DisplayMember = "Накладной_текст";

            if (label3.Text == "")
            {
                //продажа
                KasaProdazha kasaObj = new KasaProdazha();
                prodazhaNaklCmb.DataSource = kasaObj.SelectNakNomer();

                prodazhaPlatezhCmb.DisplayMember = "№_платежа";
                prodazhaPlatezhCmb.DataSource = kasaObj.SelectPlatezh();
                //--------------------------------------------------------

            }
            else if (label3.Text == "код_возврата")
            {
                //возврат
                KasaVozvrat vozvratObj = new KasaVozvrat();
                prodazhaNaklCmb.DataSource = vozvratObj.SelectNakNomer();

                prodazhaPlatezhCmb.DisplayMember = "код_возврата";
                prodazhaPlatezhCmb.DataSource = vozvratObj.SelectPlatezh();
                //--------------------------------------------------------

            }
            else if (label3.Text == "код_отмена")
            {
                //отмена
                KasaOtmena otmenaObj = new KasaOtmena();
                prodazhaNaklCmb.DataSource = otmenaObj.SelectNakNomer();

                prodazhaPlatezhCmb.DisplayMember = "код_отмена";
                prodazhaPlatezhCmb.DataSource = otmenaObj.SelectPlatezh();
                //--------------------------------------------------------

            }






            pradazhaChek.Checked = false;
            pradazhaOplCkb.Checked = false;
            updateProdazhaBtn.Enabled = false;

            prodazhaData.Text = "";
            prodazhaNaklCmb.Text = "";
            prodazhaPlatezhCmb.Text = "";
            

        }

        private void prodazha_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor = SystemColors.Info;
            label3.Text = "№ Платежной";
            prodazhaChekBtn.Visible = true;
            pradazhaChek.Visible = true;
        }

        
        private void vozvrat_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor= Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))); ;
            label3.Text = "Код возврата";
            prodazhaChekBtn.Visible = false;
            pradazhaChek.Visible = false;
        }

        private void otmena_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor= Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            label3.Text = "Код отмены";
            prodazhaChekBtn.Visible = false;
            pradazhaChek.Visible = false;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
