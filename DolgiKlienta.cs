using System;
using System.Windows.Forms;
using Core.Controllers.Klient;

namespace AutoMir2022
{
    public partial class DolgiKlienta : Form
    {
        public DolgiKlienta()
        {
            InitializeComponent();
        }
        private Klient klientObj = new Klient();
        private void DolgiKlienta_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource= klientObj.GetKodKlienta();
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 120;
        }

       
        private void update_Click(object sender, EventArgs e)
        {
            klientObj.UpdateKlientDolg(column1.Text, Convert.ToDouble(column3.Text));
            dataGridView1.DataSource = klientObj.GetKodKlienta();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            column1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            column2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            column3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }
    }
}
