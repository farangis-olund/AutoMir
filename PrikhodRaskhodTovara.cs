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
            ofd.Filter = "Excel Worksheets|*.xlsx";
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = ofd.FileName;
                MessageBox.Show(sFileName);           
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


        public DataTable LoadData(string FileName, string SheetName, DateTime TheDate)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            DataTable dt = new DataTable();

            using (OleDbConnection cn = new OleDbConnection
            { ConnectionString = ConnectionString(FileName, "Yes") })
            {

                cn.Open();

                using (OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT [Dates], [Office Plan] FROM [Sheet2$] WHERE [Dates] = " + TheDate.ToString(),
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
                        kolIzmeneniy.Text = null;
                    }
                    else if (raskhodRb.Checked == true)
                    {
                        tovarObj.UpdateTovarKolichestvo(b, artikul.Text, "-");
                        kolIzmeneniy.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Выберети приход или расход опцию!");
                        kolIzmeneniy.Text = null;
                    }

                    kolTovara.Text = tovarObj.GetKolTovara(artikul.Text).ToString();
                    tovarDGV.DataSource = tovarObj.GetTovarByArtikul(artikul.Text);

                }
                else
                {
                    MessageBox.Show("Количество указан неправильном формате!");
                }
            }

        }
    }
}
