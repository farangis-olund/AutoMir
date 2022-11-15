using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.DostupBD;
using Core.Controllers.Klient;
using Core.Controllers.OrgInfo;
using Core.DB;
using Npgsql;

namespace AutoMir2022
{

    public partial class BazaDanikhForm : Form
    {
        private DostupBD dostupBDObj = new DostupBD();
        private int DGVrowNum;
        public BazaDanikhForm()
        {
            InitializeComponent();
           
        }


        private void BazaDanikhForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void show_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource =  dostupBDObj.SelectDB(radioButton1.Text);
                
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            dostupBDObj.UdateDBFromDGV(ref dataGridView1, DGVrowNum, radioButton1.Text);
            MessageBox.Show("Обновление успешно завершено!");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGVrowNum = e.RowIndex;
        }
    }
}
