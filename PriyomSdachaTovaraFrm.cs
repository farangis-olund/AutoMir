using System;
using System.Data;
using System.Windows.Forms;
using Core.Controllers.OrgInfo;
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

            if (priyom.Checked == true && postuplenie.Checked == true)
                artikulVibor.DataSource = tovarObj.GetArtikul();
            else
                artikulVibor.DataSource = tovarObj.GetArtikulMoreThenNull();

            artikulVibor.DisplayMember = "артикул";
            artikulVibor.Text = null;
            priyomSdachaObj.DeletePriyomSdachaTempAll();

        }

        private void pokazat()
        {
            if ((priyom.Checked == true && postuplenie.Checked == true)
                || (sdacha.Checked == true && postuplenie.Checked == true) )
            {
                artikulVibor.Enabled = true;
                dataGridView1.Columns["postuplenieTovara"].Visible = false;
                dataGridView1.Columns[0].Visible = false;
            }


            else if ((priyom.Checked == true && pogashenie.Checked == true) ||
                (sdacha.Checked == true && pogashenie.Checked == true))
            {
                artikulVibor.Enabled = false;
                dataGridView1.Columns["postuplenieTovara"].Visible = true;
            }
            else MessageBox.Show("Укажите опции  'приём или сдача' и 'поступление или погащение' !");
        }

       
        private void artikul_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //если прием то артикул может быть меньше нуля если сдача то нет
            artikulVibor.Text = artikulVibor.GetItemText(artikulVibor.SelectedItem);
            ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
            if (proverkaNaOshibkuObj.CheckReapetedValueInDVG(ref dataGridView1, "artikul", artikulVibor.Text) == true)
            {
                MessageBox.Show("Данный артикул уже добавлен!");
                goto endProcess;
            }
            if (priyom.Checked==true && postuplenie.Checked==true)
                dt= tovarObj.GetTovarByArtikul(artikulVibor.Text);
            else
                dt = tovarObj.GetTovarByArtikulMoreThenNull(artikulVibor.Text);
            //////////
            ///
            

            foreach (DataRow dr in dt.Rows)
            {
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells[1].Value = dr[1];
                dataGridView1.Rows[index].Cells[2].Value = dr[2];
                dataGridView1.Rows[index].Cells[3].Value = dr[4];
                dataGridView1.Rows[index].Cells[4].Value = dr[5];
                dataGridView1.Rows[index].Cells[5].Value = dr[8];
                dataGridView1.Rows[index].Cells[8].Value = dr[12];

            }

        endProcess: { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "zadavaemoeKolichestvo")
            {
                int b = 0;
                ProverkaNaOshibku proverkaNaOshibkuObj = new ProverkaNaOshibku();
                if (proverkaNaOshibkuObj.GetEmptyCellDVG(ref dataGridView1, e.RowIndex, "zadavaemoeKolichestvo") == true)
                    goto endProcess;

                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["zadavaemoeKolichestvo"].Value.ToString(), out b))
                {
                    if (sdacha.Checked == true && postuplenie.Checked == true)
                    {
                        if (b > Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["kolichestvo"].Value))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["zadavaemoeKolichestvo"].Value = null;
                            MessageBox.Show("Количество превышает количество на складе!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Количество задан неправельно!");
                    dataGridView1.Rows[e.RowIndex].Cells["zadavaemoeKolichestvo"].Value = null;
                }

            }
        endProcess: { }
        }



        private void oformit_Click(object sender, EventArgs e)
        {
            //udalaem dannie iz tabli temp dlya cheka 
            priyomSdachaObj.DeletePriyomSdachaTemp(kodMagazina.Text, type);


            bool tovarVibran;
            if (dataGridView1.Rows.Count != 0)
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tovarVibran = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);

                    if (tovarVibran==true && priyomSdachaObj.IsTovarExist(kodMagazina.Text, dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), type) == true)
                    {
                        //sozdaem tablitu dlya cheka 
                        priyomSdachaObj.InsertPriyomSdachaTemp(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                            dataGridView1.Rows[i].Cells["naimenovanie"].Value.ToString(), dataGridView1.Rows[i].Cells["brand"].Value.ToString(),
                            dataGridView1.Rows[i].Cells["marka"].Value.ToString(), dataGridView1.Rows[i].Cells["mesto"].Value.ToString(), kodMagazina.Text, 
                            Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value.ToString()), type);
                        //
                        //
                        if (priyom.Checked == true && postuplenie.Checked == true)
                        {
                            //priem tovara v tablitsu obmen magazinami

                            priyomSdachaObj.UpdatePriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                             kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type);

                            //dobavlaem kolichestvo v tablitu tovar

                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "+");
                        }

                        else if (sdacha.Checked == true && postuplenie.Checked == true)
                        {
                            //priem tovara v tablitsu obmen magazinami

                            priyomSdachaObj.UpdatePriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                            kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type);

                            //minusuem kolichestvo dolgo is tablitis tovar

                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "-");
                        }

                        else if (priyom.Checked == true && pogashenie.Checked == true)
                        {
                            priyomSdachaObj.DeletePriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                            kodMagazina.Text, type);
                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "-");

                        }

                        else if (sdacha.Checked == true && pogashenie.Checked == true)
                        {
                            //ostatok dolga eto dolg-zadavaemoeKolichestvo
                            if (priyomSdachaObj.OstatokDolga(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                                kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type) > 0)
                            {
                                priyomSdachaObj.UpdatePriyomPogashenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                                kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type);
                            }
                            //esli ostatok 0 to udalaem danniy dolg is obmen tovarov 
                            else if (priyomSdachaObj.OstatokDolga(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                                kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type) == 0)
                            {
                                priyomSdachaObj.DeletePriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                            kodMagazina.Text, type);

                            }

                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "+");

                        }
                    }
                    else
                    {
                        //sozdaem tablitu dlya cheka 
                        priyomSdachaObj.InsertPriyomSdachaTemp(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                            dataGridView1.Rows[i].Cells["naimenovanie"].Value.ToString(), dataGridView1.Rows[i].Cells["brand"].Value.ToString(),
                            dataGridView1.Rows[i].Cells["marka"].Value.ToString(), dataGridView1.Rows[i].Cells["mesto"].Value.ToString(), kodMagazina.Text,
                            Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value.ToString()), type);
                        //
                        //


                        if (priyom.Checked == true && postuplenie.Checked == true)
                        {
                            //priem tovara v tablitsu obmen magazinami

                            priyomSdachaObj.InsertPriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                                kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type);

                            //dobavlaem kolichestvo v tablitu tovar

                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "+");
                        }

                        if (sdacha.Checked == true && postuplenie.Checked == true)
                        {
                            //priem tovara v tablitsu obmen magazinami

                            priyomSdachaObj.InsertPriyomPostuplenie(dataGridView1.Rows[i].Cells["artikul"].Value.ToString(),
                                kodMagazina.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value), type);

                            //minusuem kolichestvo dolgo is tablitis tovar

                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells["zadavaemoeKolichestvo"].Value),
                                dataGridView1.Rows[i].Cells["artikul"].Value.ToString(), "-");
                        }
                    }
                    //Ochistka();
                    //priyom.Checked = false;
                    //sdacha.Checked = false;
                
                }

                MessageBox.Show("Оформление успешно завершено!");

            }
            else
                MessageBox.Show("Вы не выбрали товар для оформление!");

            
        }
        private void priyom_Click(object sender, EventArgs e)
        {
            Ochistka();
            if (priyom.Checked == true)
            {
                type = "priyom";
            }
        }

        private void sdacha_Click(object sender, EventArgs e)
        {
            Ochistka();
            if (sdacha.Checked == true)
            {
                type = "sdacha";
                
            }
        }

        private void Ochistka()
        {
            dataGridView1.Rows.Clear();
            artikulVibor.Text = null;
            postuplenie.Checked = false;
            pogashenie.Checked = false;
            kodMagazina.Text = null;
        }

        private void postuplenie_Click(object sender, EventArgs e)
        {
           if (kodMagazina.Text == "")
            {
                MessageBox.Show("Укажите код магазина!");
                postuplenie.Checked = false;
            }
            else
            {
                pokazat();
                dataGridView1.Columns["kolichestvo"].Visible = true;
                dataGridView1.Columns["zadavaemoeKolichestvo"].ReadOnly = false;
                dataGridView1.Rows.Clear();
            }


        }

        private void pogashenie_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (kodMagazina.Text == "")
            {
                MessageBox.Show("Укажите код магазина!");
                pogashenie.Checked = false;
                goto endProcess;
            }
            DataTable dt = new DataTable();
            if (priyom.Checked == true && pogashenie.Checked == true)
            {
                
                dataGridView1.Columns["postuplenieTovara"].Visible = false;
                dataGridView1.Columns["zadavaemoeKolichestvo"].ReadOnly = true;
                dataGridView1.Columns[0].ReadOnly = true;

                dataGridView1.Columns["kolichestvo"].Visible = true;
                dt = priyomSdachaObj.SelectObmenTovarami(kodMagazina.Text, "priyom");
                foreach (DataRow dr in dt.Rows)
                {
                    int index = dataGridView1.Rows.Add();

                    dataGridView1.Rows[index].Cells[0].Value = true;
                    dataGridView1.Rows[index].Cells[1].Value = dr[0];
                    dataGridView1.Rows[index].Cells[2].Value = dr[1];
                    dataGridView1.Rows[index].Cells[3].Value = dr[2];
                    dataGridView1.Rows[index].Cells[4].Value = dr[3];
                    dataGridView1.Rows[index].Cells[5].Value = dr[4];
                    dataGridView1.Rows[index].Cells[7].Value = dr[5];
                    dataGridView1.Rows[index].Cells[8].Value = dr[7];

                }
            }
            else if (sdacha.Checked == true && pogashenie.Checked == true)
            {
                dt = priyomSdachaObj.SelectObmenTovarami(kodMagazina.Text, "sdacha");
                dataGridView1.Columns["postuplenieTovara"].Visible = true;
                dataGridView1.Columns["kolichestvo"].Visible = false;
                dataGridView1.Columns["zadavaemoeKolichestvo"].ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = false;

                foreach (DataRow dr in dt.Rows)
                {
                    int index = dataGridView1.Rows.Add();

                    dataGridView1.Rows[index].Cells[0].Value = false;
                    dataGridView1.Rows[index].Cells[1].Value = dr[0];
                    dataGridView1.Rows[index].Cells[2].Value = dr[1];
                    dataGridView1.Rows[index].Cells[3].Value = dr[2];
                    dataGridView1.Rows[index].Cells[4].Value = dr[3];

                    dataGridView1.Rows[index].Cells[6].Value = dr[5];
                    dataGridView1.Rows[index].Cells[8].Value = dr[7];

                }

            }
            if (dataGridView1.Rows.Count == 0)
                MessageBox.Show("Нет товаров для погащение!");
        endProcess: { }
        }

        private void chek_Click(object sender, EventArgs e)
        {
           DataTable dt= priyomSdachaObj.SelectPriyomSdachaTemp(kodMagazina.Text, type);
            OrgInfo org = new OrgInfo();
            string tipOctcheta="";
            if (priyom.Checked == true && postuplenie.Checked==true)
                tipOctcheta = "Приём товаров из магазина:";
            
            else if (priyom.Checked == true && pogashenie.Checked == true)
                tipOctcheta = "Возврат полученных товаров магазину:";
            
            else if (sdacha.Checked == true && postuplenie.Checked == true)
                tipOctcheta = "Сдача товаров магазину:";

            else if (sdacha.Checked == true && pogashenie.Checked == true)
                tipOctcheta = "Приход товаров из магазина:";
            
            string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name },
                { "sKakogoMagazina",kodMagazina.Text},
                { "priyomSdacha", tipOctcheta } };
            ReportPrikhodRaskhod reportPrikhodRaskhod = new ReportPrikhodRaskhod();
            reportPrikhodRaskhod.StartReport("PriyomSdachaTovara", "PrikhodRaskhod", parametr, dt);
            reportPrikhodRaskhod.Show();
            priyomSdachaObj.DeletePriyomSdachaTemp(kodMagazina.Text, type);
        }
    }
}
