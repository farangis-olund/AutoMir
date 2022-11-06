using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Tovar;
using Core.Controllers.OrgInfo;
using Core.Reports.ReportPrint;


namespace AutoMir2022
{
    public partial class PrikhodRaskhodTovara : Form
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        private Tovar tovarObj = new Tovar();
        private ReportPrint report = new ReportPrint();
        private OrgInfo org = new OrgInfo();
        private ReportPrikhodRaskhod reportPrikhodRaskhod = new ReportPrikhodRaskhod();

        public string typeReport;

        public PrikhodRaskhodTovara()
        {
            InitializeComponent();
            
            dateVibor.Format = DateTimePickerFormat.Custom;
            dateVibor.Value = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yy"));
            
            showTovar();
        }

        private void showTovar()
        {
            artikul.DataSource = tovarObj.GetArtikul();
            artikul.DisplayMember = "артикул";
            artikul.Text = null;
            tovarDGV.DataSource= tovarObj.GetAllTovar();
        }

       

        private void PrikhodRaskhodUpdate(string prikhodRaskhod)
        {
            DataTable dt= report.OpenFile(ref ofd);
            int countTovar = 0;
            if (dt.Rows.Count!=0)
            {
                tovarObj.DeletePrikhodOshibkaTovara();
                spisokIzmeneniyDGV.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {

                    if (tovarObj.IsTovarExist(dr[0].ToString()) == true)
                    {

                        countTovar = countTovar + 1;
                        int index = spisokIzmeneniyDGV.Rows.Add();
                        spisokIzmeneniyDGV.Rows[index].Cells[0].Value = dr[0].ToString();
                        spisokIzmeneniyDGV.Rows[index].Cells[1].Value = tovarObj.GetKolTovara(dr[0].ToString()).ToString();
                        spisokIzmeneniyDGV.Rows[index].Cells[2].Value = dr[1].ToString();
                        if (prikhodRaskhod == "prikhod")
                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dr[1]), dr[0].ToString(), "+");
                        else
                            tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dr[1]), dr[0].ToString(), "-");
                        spisokIzmeneniyDGV.Rows[index].Cells[3].Value = tovarObj.GetKolTovara(dr[0].ToString()).ToString();
                        DataTable datatable = tovarObj.GetTovarByArtikul(dr[0].ToString());
                        spisokIzmeneniyDGV.Rows[index].Cells[4].Value = datatable.Rows[0][2];
                        spisokIzmeneniyDGV.Rows[index].Cells[5].Value = datatable.Rows[0][4];
                        spisokIzmeneniyDGV.Rows[index].Cells[6].Value = datatable.Rows[0][12];


                    }
                    else
                    {
                        tovarObj.InsertPrikhodOshibkaTovara(Convert.ToInt32(dr[1]), dr[0].ToString());
                        neoprikhodBtn.Enabled = true;
                    }

                }

            }

            if (countTovar != 0 && prikhodRaskhod=="prikhod")
            {
                tovarObj.InsertPrikhodTovara(countTovar);
                MessageBox.Show("Приход товара завершен!");
            }
            else
            {
                tovarObj.InsertPrikhodTovara(countTovar);
                MessageBox.Show("Погащение долга завершен!");
            }
        }

        private void artikul_SelectionChangeCommitted(object sender, EventArgs e)
        {
            artikul.Text = artikul.GetItemText(artikul.SelectedItem);
            kolTovara.Text = tovarObj.GetKolTovara(artikul.Text).ToString();
            tovarDGV.DataSource= tovarObj.GetTovarByArtikul(artikul.Text);
        }


        private void kolIzmeneniy_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int b;
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(kolIzmeneniy.Text, out b))
                {
                    if (prikhodRb.Checked == true)
                    {
                        tovarObj.UpdateTovarKolichestvo(b, artikul.Text, "+");
                    }
                    else if (raskhodRb.Checked == true)
                    {
                        tovarObj.UpdateTovarKolichestvo(b, artikul.Text, "-");
                    }
                    else
                    {
                        MessageBox.Show("Выберети приход или расход опцию!");
                        goto endProcess;
                    }

                    DataTable datatable = tovarObj.GetTovarByArtikul(artikul.Text);
                    int index=spisokIzmeneniyDGV.Rows.Add();
                    spisokIzmeneniyDGV.Rows[index].Cells[0].Value = artikul.Text;
                    spisokIzmeneniyDGV.Rows[index].Cells[1].Value = kolTovara.Text;
                    spisokIzmeneniyDGV.Rows[index].Cells[2].Value = kolIzmeneniy.Text;

                    tovarDGV.DataSource = tovarObj.GetTovarByArtikul(artikul.Text);
                    kolTovara.Text = tovarObj.GetKolTovara(artikul.Text).ToString();
                    spisokIzmeneniyDGV.Rows[index].Cells[3].Value = kolTovara.Text;
                    
                    spisokIzmeneniyDGV.Rows[index].Cells[4].Value = datatable.Rows[0][2];
                    spisokIzmeneniyDGV.Rows[index].Cells[5].Value = datatable.Rows[0][4];
                    spisokIzmeneniyDGV.Rows[index].Cells[6].Value = datatable.Rows[0][12];

                }
                else
                {
                    MessageBox.Show("Количество указан неправильном формате!"); 
                }
            
            }
        endProcess: { }
            kolIzmeneniy.Text = null;
        }

        private void prikhod_Click(object sender, EventArgs e)
        {
            if (tovarObj.IsPrikhodExist(dateVibor.Value) == false)
            {
                PrikhodRaskhodUpdate("prikhod");
            }
            else MessageBox.Show("На эту дату приход товара оформлен!");
        }

        private void zadolzhnostBtn_Click(object sender, EventArgs e)
        {
            if (tovarObj.IsRaskhodExist(dateVibor.Value) == false)
            {
                PrikhodRaskhodUpdate("raskhod");
            }
            else MessageBox.Show("На эту дату погащение долга оформлен!");
        }

       
        private void print_Click(object sender, EventArgs e)
        {
            DataTable dt = report.ConvertDataGridToDataTable(ref spisokIzmeneniyDGV);
            dt.Columns["ArtikulIzmen"].ColumnName = "artikul";

            string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name }, 
                { "date", Convert.ToDateTime(dateVibor.Value).ToString("dd.MM.yyyy") }};
            reportPrikhodRaskhod.StartReport("PrikhodRaskhod", "PrikhodRaskhod",parametr, dt);
            reportPrikhodRaskhod.Show();
        }

        
        private void cleanBtn_Click(object sender, EventArgs e)
        {
            spisokIzmeneniyDGV.Rows.Clear();
        }

        private void neoprikhodBtn_Click(object sender, EventArgs e)
        {
            string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name },
                { "date", Convert.ToDateTime(dateVibor.Value).ToString("dd.MM.yyyy") }};
            reportPrikhodRaskhod.StartReport("PrikhodRaskhodOshibka", "PrikhodRaskhod", parametr, report.PrikhodaRaskhodReportOshibka());
            reportPrikhodRaskhod.Show();

        }
    }
}
