using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.OchistkaBazi;

namespace AutoMir2022.Konfiguratsiya.Baza
{
    public partial class OchistkaBD : Form
    {
        public OchistkaBD()
        {
            InitializeComponent();
        }

        private void ochistka_Click(object sender, EventArgs e)
        {
            OchistkaBazi ochistkaBaziObj = new OchistkaBazi();
            if (vozvrat.Checked == true)
            {
                ochistkaBaziObj.DeleteRowsInTable(vozvrat.Text);
                ochistkaBaziObj.RestartIdColumn(vozvrat.Text, "код_возврата");

            }

             MessageBox.Show("Данные таблицы успешно удалены!");
        }

        private void zakrit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
