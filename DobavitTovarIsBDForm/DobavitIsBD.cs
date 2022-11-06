using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Zakazi;

namespace AutoMir2022.DobavitTovarIsBDForm
{
    public partial class DobavitIsBD : Form
    {
        private Zakazi zakaziObj = new Zakazi();
        public DobavitIsBD()
        {
            InitializeComponent();
        }

        private void DobavitIsBD_Load(object sender, EventArgs e)
        {
            dateZakaz.DataSource = zakaziObj.GetDateObnovlenieTovara();
            this.reportViewer1.RefreshReport();
        }

        private void dateZakaz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(dateZakaz.Text);
        }
    }
}
