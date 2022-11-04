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

namespace AutoMir2022
{
    public partial class PrikhodRaskhodTovara : Form
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        private Tovar tovarObj = new Tovar();
        public PrikhodRaskhodTovara()
        {
            InitializeComponent();
            showTovar();
        }

        private void showTovar()
        {
            artikul.DataSource = tovarObj.GetArtikul();
            artikul.DisplayMember = "артикул";
            artikul.Text = null;
            tovarDGV.DataSource= tovarObj.GetAllTovar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Excel Worksheets|*.xls; *.xlsx";
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = ofd.FileName;
                PrikhodRAskhodTovara(LoadData(sFileName, "Sheet1"));     
            }

        }


        private void PrikhodRAskhodTovara(DataTable dt)
        {
            int countTovar = 0;
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
                    tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dr[1]), dr[0].ToString(), "+");
                    spisokIzmeneniyDGV.Rows[index].Cells[3].Value = tovarObj.GetKolTovara(dr[0].ToString()).ToString();
                }
                else
                {
                    tovarObj.InsertPrikhodOshibkaTovara(Convert.ToInt32(dr[1]), dr[0].ToString());
                }
                
            }

            if (countTovar != 0)
            {
                tovarObj.InsertPrikhodTovara(countTovar);
                MessageBox.Show("Приход товара завершен!");
            }
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
                    //CommandText = "SELECT [артикул], [количество] FROM ["Лист1"] WHERE [Dates] = " + TheDate.ToString(),

                    Connection = cn
                }
                 )

                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }

                return dt;
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
                    }

                    int index=spisokIzmeneniyDGV.Rows.Add();
                    spisokIzmeneniyDGV.Rows[index].Cells[0].Value = artikul.Text;
                    spisokIzmeneniyDGV.Rows[index].Cells[1].Value = kolTovara.Text;
                    spisokIzmeneniyDGV.Rows[index].Cells[2].Value = kolIzmeneniy.Text;

                    tovarDGV.DataSource = tovarObj.GetTovarByArtikul(artikul.Text);
                    kolTovara.Text = tovarObj.GetKolTovara(artikul.Text).ToString();
                    spisokIzmeneniyDGV.Rows[index].Cells[3].Value = kolTovara.Text;

                }
                else
                {
                    MessageBox.Show("Количество указан неправильном формате!"); 
                }
                kolIzmeneniy.Text = null;
            }

        }
    }
}
