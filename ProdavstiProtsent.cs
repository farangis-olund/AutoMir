using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers;

namespace AutoMir2022
{
    public partial class ProdavstiProtsent : Form
    {
        private Prodavtsi prodavtsiObj = new Prodavtsi();

        public ProdavstiProtsent()
        {
            InitializeComponent();
        }

        private void ProdavstiProtsent_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = prodavtsiObj.GetProdavtsi();
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[1].ReadOnly = true;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            column1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            column2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            
        }

        private void update_Click(object sender, EventArgs e)
        {
            int b = 0;
            if (int.TryParse(column2.Text, out b))
            {
                prodavtsiObj.UpdateProdavets(column1.Text, b);
                dataGridView1.DataSource = prodavtsiObj.GetProdavtsi();
            }
            else MessageBox.Show("Процен указан не верно!");

        }
    }
}
