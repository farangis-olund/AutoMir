using System;
using System.Data;
using System.Windows.Forms;
using Core.Controllers.PriyomSdacha;
using Core.Controllers.ProverkaNaOshibku;
using Core.Controllers.Tovar;
namespace AutoMir2022
{
    public partial class PriyomSdachaTovaraFrm : Form
    {
        private PriyomSdacha priyomSdachaObj = new PriyomSdacha();
        private Tovar tovarObj = new Tovar();
        private string type;
        public PriyomSdachaTovaraFrm()
        {
            InitializeComponent();
        }

        private void PriyomSdachaTovaraFrm_Load(object sender, EventArgs e)
        {
            kodMagazina.DataSource = priyomSdachaObj.SelectKodMagazina();
            kodMagazina.DisplayMember = "код_магазина";
            kodMagazina.Text = null;
            artikulVibor.DataSource = tovarObj.GetArtikul();
            artikulVibor.DisplayMember = "артикул";
            artikulVibor.Text = null;
           

        }

        private void pokazat()
        {
            if ((priyom.Checked == true && postuplenie.Checked == true)
                || (sdacha.Checked == true && postuplenie.Checked == true) )
            {
                artikulVibor.Enabled = true;
            }


            else if ((priyom.Checked == true && pogashenie.Checked == true) ||
                (sdacha.Checked == true && pogashenie.Checked == true))
            {
                artikulVibor.Enabled = false;
            }
            else MessageBox.Show("Укажите опции  'приём или сдача' и 'поступление или погащение' !");
        }

        private void postuplenie_CheckedChanged(object sender, EventArgs e)
        {
            pokazat();
        }

        private void artikul_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //если прием то артикул может быть меньше нуля если сдача то нет
            artikulVibor.Text = artikulVibor.GetItemText(artikulVibor.SelectedItem);
            if (priyom.Checked==true && postuplenie.Checked==true)
                dt= tovarObj.GetTovarByArtikul(artikulVibor.Text);
            else
                dt = tovarObj.GetTovarByArtikulMoreThenNull(artikulVibor.Text);
            //////////
            ///
            ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
            if (proverkaNaOshibkuObj.CheckReapetedValueInDVG(ref dataGridView1, "artikul", artikulVibor.Text) == true)
            {
                MessageBox.Show("Данный артикул уже добавлен!");
                goto endProcess;
            }

            foreach (DataRow dr in dt.Rows)
            {
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[0].Value = dr[1];
                dataGridView1.Rows[index].Cells[1].Value = dr[2];
                dataGridView1.Rows[index].Cells[2].Value = dr[4];
                dataGridView1.Rows[index].Cells[3].Value = dr[5];
                dataGridView1.Rows[index].Cells[4].Value = dr[8];
                dataGridView1.Rows[index].Cells[6].Value = dr[12];

            }

        endProcess: { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "kolVozvrata")
            {
                int b = 0;
                ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView1, e.RowIndex, "kolichestvo") == true)
                    goto endProcess;

                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["kolichestvo"].Value.ToString(), out b))
                {
                    if (sdacha.Checked == true && postuplenie.Checked == true)
                    {
                        if (b > Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sklad"].Value))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["kolichestvo"].Value = null;
                            MessageBox.Show("Количество превышает количество на складе!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    dataGridView1.Rows[e.RowIndex].Cells["kolichestvo"].Value = null;
                }

            }
        endProcess: { }
        }

        private void pogashenie_CheckedChanged(object sender, EventArgs e)
        {
            if (priyom.Checked == true && pogashenie.Checked == true)                
            {
               dataGridView1.DataSource=priyomSdachaObj.SelectObmenTovarami(kodMagazina.Text, "priyom");
            }
            else if (sdacha.Checked == true && pogashenie.Checked == true)
            {
                dataGridView1.DataSource =priyomSdachaObj.SelectObmenTovarami(kodMagazina.Text, "sdacha");
            }
        }

        private void oformit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                for (int i=0; i<dataGridView1.Rows.Count-1; i++)
                if (priyomSdachaObj.IsTovarExist(kodMagazina.Text, dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), type) == true)
                {
                    
                }
            }
            else
                MessageBox.Show("Вы не выбрали товар для оформление!");
        }

        private void priyom_Click(object sender, EventArgs e)
        {
            if (priyom.Checked == true)
            {
                type = "priyom";
            }
        }

        private void sdacha_Click(object sender, EventArgs e)
        {
            if (sdacha.Checked == true)
            {
                type = "sdacha";
            }
        }
    }
}
