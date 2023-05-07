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
            KasaOtmena kasaOtmenaObj = new KasaOtmena();
            KasaVozvrat kasaVozvratObj = new KasaVozvrat();
            
            //продажа
            if (label3.Text == "№ Платежной")
            {
                if (pradazhaOplCkb.Checked == true && prodazhaNaklCmb.Text != "")
                {
                    kasaObj.updateProdazha(prodazhaNaklCmb.Text);
                    showAllcombo();
                    MessageBox.Show("Обновление успешно внесено!");
                }

                else if (pradazhaOplCkb.Checked == true && KassaCmb.Text != "")
                {
                    kasaObj.updatePlatezh(KassaCmb.Text);
                    showAllcombo();
                    MessageBox.Show("Обновление успешно внесено!");
                }
                else
                {
                    MessageBox.Show("Данные заданны некоректно или неправильном формате, обновление не внесен!");
                }
            }
            //возврат
            if (label3.Text == "Код возврата")
            {
                if (pradazhaOplCkb.Checked == true && prodazhaNaklCmb.Text != "" && KassaCmb.Text != "")
                {
                    kasaVozvratObj.updateVozvrat(prodazhaNaklCmb.Text, Convert.ToInt32(KassaCmb.Text));
                    showAllcombo();
                    MessageBox.Show("Обновление успешно внесено!");
                }

            }
            //отмена
            if (label3.Text == "Код отмены")
            {
                if (pradazhaOplCkb.Checked == true && prodazhaNaklCmb.Text != "" && KassaCmb.Text != "")
                {
                    kasaOtmenaObj.updateOtmena(prodazhaNaklCmb.Text, Convert.ToInt32(KassaCmb.Text));
                    showAllcombo();
                    MessageBox.Show("Обновление успешно внесено!");
                }

            }

        }


        public void showAllcombo()
        {
            prodazhaDGV.Rows.Clear();
            prodazhaNaklCmb.DataSource = null;
            KassaCmb.DataSource = null;
            prodazhaNaklCmb.DisplayMember = "Накладной_текст";

            if (label3.Text == "№ Платежной")
            {
                //продажа
                KasaProdazha kasaObj = new KasaProdazha();
                prodazhaNaklCmb.DataSource = kasaObj.SelectNakNomer();

                KassaCmb.DisplayMember = "№_платежа";
                KassaCmb.DataSource = kasaObj.SelectPlatezh();
                //--------------------------------------------------------

            }
            else if (label3.Text == "Код возврата")
            {
                //возврат
                KasaVozvrat vozvratObj = new KasaVozvrat();
                prodazhaNaklCmb.DataSource = vozvratObj.SelectNakNomer();
                 //--------------------------------------------------------

            }
            else if (label3.Text == "Код отмены")
            {
                //отмена
                KasaOtmena otmenaObj = new KasaOtmena();
                prodazhaNaklCmb.DataSource = otmenaObj.SelectNakNomer();
                   //--------------------------------------------------------

            }

            pradazhaChek.Checked = false;
            pradazhaOplCkb.Checked = false;
            updateProdazhaBtn.Enabled = false;

            prodazhaData.Text = "";
            prodazhaNaklCmb.Text = "";
            KassaCmb.Text = "";
            

        }

        private void prodazha_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor = SystemColors.Info;
            label3.Text = "№ Платежной";
            prodazhaChekBtn.Visible = true;
            pradazhaChek.Visible = true;
            showAllcombo();
        }

        
        private void vozvrat_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor= Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))); ;
            label3.Text = "Код возврата";
            prodazhaChekBtn.Visible = false;
            pradazhaChek.Visible = false;
            showAllcombo();
        }

        private void otmena_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.BackColor= Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            label3.Text = "Код отмены";
            prodazhaChekBtn.Visible = false;
            pradazhaChek.Visible = false;
            showAllcombo();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void prodazhaNaklCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KasaProdazha kasaObj = new KasaProdazha();
            KasaVozvrat kasaVozvratObj = new KasaVozvrat();
            KasaOtmena kasaOtmenaObj = new KasaOtmena();
            
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();

            string comboValue =prodazhaNaklCmb.GetItemText(prodazhaNaklCmb.SelectedItem);
            DataTable dt=null;
            prodazhaDGV.Rows.Clear();
            if (comboValue != "")
            {
                //продажа
                if (label3.Text == "№ Платежной")
                {
                    dt = kasaObj.SelectDataProdazhaKassa(comboValue);

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
                            pradazhaChek.Checked = Convert.ToBoolean(dr[5]);
                        }

                        if (prodazhaDGV.Rows.Count > 0)
                        {
                            prodazhaData.Text = Convert.ToDateTime(prodazhaDGV.Rows[0].Cells[0].Value).ToString("D");

                            roznichProdazhaObj.SumOfColumnDataGridVeiw(ref prodazhaDGV, "suma", "", "", "", "", "", 0);
                            updateProdazhaBtn.Enabled = true;
                            prodazhaChekBtn.Enabled = true;
                        }
                    }


                }
                //возврат
                if (label3.Text == "Код возврата")
                {
                    KassaCmb.DisplayMember = "код_возврата";
                    KassaCmb.DataSource = kasaVozvratObj.SelectKodVazvrata(comboValue);
                    KassaCmb.Text = "";
                }
                //отмена
                if (label3.Text == "Код отмены")
                {
                    KassaCmb.DisplayMember = "код_отмена";
                    KassaCmb.DataSource = kasaOtmenaObj.SelectKodOtmena(comboValue);
                    KassaCmb.Text = "";
                }


            }

        }

        private void KassaCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KasaProdazha kasaObj = new KasaProdazha();
            KasaVozvrat kasaVozvratObj = new KasaVozvrat();
            KasaOtmena kasaOtmenaObj = new KasaOtmena();
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();

            string comboValue = KassaCmb.GetItemText(KassaCmb.SelectedItem);
            
            prodazhaDGV.Rows.Clear();

            if (comboValue != "")
            {
                //продажа
                if (label3.Text == "№ Платежной")
                {
                    prodazhaNaklCmb.Text = "";

                    DataTable dt = kasaObj.SelectDataPlatezhKassa(comboValue);
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

                    }
                }


                //возврат
                if (label3.Text == "Код возврата")
                {
                        DataTable dt = kasaVozvratObj.SelectDataVozvratKassa(prodazhaNaklCmb.Text, comboValue);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                int index = prodazhaDGV.Rows.Add();
                                prodazhaDGV.Rows[index].Cells[0].Value = dr[0];
                                prodazhaDGV.Columns[0].Visible = false;
                                prodazhaDGV.Rows[index].Cells[1].Value = dr[1];
                                prodazhaDGV.Columns[1].HeaderText = "Артикул";
                                prodazhaDGV.Columns[2].Visible = true;
                                prodazhaDGV.Rows[index].Cells[2].Value = dr[2];
                                prodazhaDGV.Rows[index].Cells[4].Value = dr[3];
                                prodazhaDGV.Columns[3].Visible = false;

                            }

                        }
                    
                }

                //отмена

                if (label3.Text == "Код отмены")
                {
                    DataTable dt = kasaOtmenaObj.SelectDataOtmena(prodazhaNaklCmb.Text,Convert.ToInt32( comboValue));
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            int index = prodazhaDGV.Rows.Add();
                            prodazhaDGV.Rows[index].Cells[0].Value = dr[0];
                            prodazhaDGV.Columns[0].Visible = false;
                            prodazhaDGV.Rows[index].Cells[1].Value = dr[1];
                            prodazhaDGV.Columns[1].HeaderText = "Артикул";
                            prodazhaDGV.Columns[2].Visible = true;
                            prodazhaDGV.Rows[index].Cells[2].Value = dr[2];
                            prodazhaDGV.Rows[index].Cells[4].Value = dr[3];
                            prodazhaDGV.Columns[3].Visible = false;

                        }

                    }
                }


                //skladDGV.DataSource = skladObj.SelectDataSklad(NomerNakladnoyCmb.Text);
                if (prodazhaDGV.Rows.Count > 0)
                {
                    prodazhaData.Text = Convert.ToDateTime(prodazhaDGV.Rows[0].Cells[0].Value).ToString("D");

                    roznichProdazhaObj.SumOfColumnDataGridVeiw(ref prodazhaDGV, "suma", "", "", "", "", "", 0);
                    updateProdazhaBtn.Enabled = true;
                }

            }
        }

        
    }
}
