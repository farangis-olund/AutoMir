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
    public partial class Rasprodazha : Form
    {
        public Rasprodazha()
        {
            InitializeComponent();
        }
        RasprodazhaBonus rasprodazhaBonusObj = new RasprodazhaBonus();
        private void Rasprodazha_Load(object sender, EventArgs e)
        {
            dateLabel.Text = Convert.ToDateTime(rasprodazhaBonusObj.GetBonusInfo().Rows[0][0]).ToString("dd.MM.yyyy");
            protsBonusa.Text= rasprodazhaBonusObj.GetBonusInfo().Rows[0][1].ToString();
            this.reportViewer1.RefreshReport();
        }

        private void uslovie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            uslovie.Text = uslovie.GetItemText(uslovie.SelectedItem);
            if (uslovie.Text == "=")
            {
                uslovieValue.Text = "0";
                uslovieValue.ReadOnly = true;
            }
            else
                uslovieValue.ReadOnly = false;
                
        }

        private void create_rashprodazha_Click(object sender, EventArgs e)
        {
            rasprodazhaBonusObj.InsertRaspradazha(uslovie.Text, Convert.ToInt32(uslovieValue.Text));
            dataGridView1.DataSource = rasprodazhaBonusObj.GetRasprodazha();
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.Columns[1].Width = 120;


        }

        private void change_rasprodazha_Click(object sender, EventArgs e)
        {
            rasprodazhaBonusObj.CreateTable(ref dataGridView1);
            MessageBox.Show("Список распродажи успешно обновлен!");
        }
    }
}
