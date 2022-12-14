using System;
using System.Data;
using System.Windows.Forms;
using Core.Controllers;
using Core.Controllers.OrgInfo;
using Core.Reports.ReportPrint;

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
            DataTable dt = rasprodazhaBonusObj.GetBonusInfo();
            if (dt.Rows.Count > 0)
            {
                dateLabel.Text = Convert.ToDateTime(dt.Rows[0][0]).ToString("dd.MM.yyyy");
                protsBonusa.Text = dt.Rows[0][1].ToString();
                this.reportViewer1.RefreshReport();
            }
            
             
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
            if (uslovie.Text != "" && uslovieValue.Text != "")
            {
                dataGridView1.Visible = true;
                rasprodazhaBonusObj.InsertRaspradazha(uslovie.Text, Convert.ToInt32(uslovieValue.Text));

                if (dataGridView1.Rows.Count > 0)
                {

                    dataGridView1.Columns.Remove("delete");
                    dataGridView1.Columns.Remove("артикул");
                    dataGridView1.Columns.Remove("количество");


                }
                dataGridView1.DataSource = rasprodazhaBonusObj.GetRasprodazha();

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "delete";
                buttonColumn.HeaderText = "Удалить";
                int columnIndex = 2;
                dataGridView1.Columns.Insert(columnIndex, buttonColumn);


                dataGridView1.Columns[0].Width = 160;
                dataGridView1.Columns[1].Width = 120;

            }
            else
                MessageBox.Show("Укажите условие и значение для условии, затем создайте!");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex); 
            }
        }


        private void change_rasprodazha_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                rasprodazhaBonusObj.CreateTable(ref dataGridView1);
                MessageBox.Show("Список распродажи успешно обновлен!");
            } else
                MessageBox.Show("Список распродаж еще не создан!");
        }

        private void create_bonus_Click(object sender, EventArgs e)
        {
            if (protsBonusa.Text != "")
            {
                string dataStart = startDate.Value.ToString("dd.MM.yyyy");
                string dataEnd = endDate.Value.ToString("dd.MM.yyyy");
                DataTable dt = rasprodazhaBonusObj.GetBonusByPeriodAndProdovets
                 (Convert.ToDateTime(startDate.Value), Convert.ToDateTime(endDate.Value), Convert.ToInt32(protsBonusa.Text));
                OrgInfo org = new OrgInfo();
                ReportPrint rp = new ReportPrint();

                string[,] parametr = {
                {"reportTitle", "Отчёт о бонусах" },
                { "kod_org", org.org_kod },
                { "name_org", org.org_name },
               { "startDate", dataStart},
                { "endDate", dataEnd}};

                rp.reportVeiwerPrint(ref this.reportViewer1, "Bonus", parametr, "OtchetOstatokTovara", dt, "no");
                dataGridView1.Visible = false;
            }
            else
                MessageBox.Show("Укажите процент бонуса!");
            
        }

        private void save_bonus_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите сохранить последнее данные о бонусе?!", "Бонусы", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                rasprodazhaBonusObj.InsertBonus(Convert.ToDateTime(startDate.Value), Convert.ToDateTime(endDate.Value),
                Convert.ToInt32(protsBonusa.Text));
                MessageBox.Show("Данные о бонусе сохранены!");
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }
    }
}
