using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Chek;
using Core.Controllers.RoznichProdazha;

namespace AutoMir2022
{
    public partial class ChekFrm : Form
    {
        public ChekFrm()
        {
            InitializeComponent();
            string datatoday = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void sumBtn_Click(object sender, EventArgs e)
        {
            Chek chekObj = new Chek();
            string suma=chekObj.SelectSumaProdazhiWithChek();
            if (suma == "") suma = "0";
            MessageBox.Show("Сумма проданных со знаком чек на сегодня равняется = " + suma.ToString());
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
           

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            Chek chekObj = new Chek();
           
            string dataStart = dateBigin.Value.ToString("dd-MM-yyyy");
            string dataEnd = dateEnd.Value.ToString("dd-MM-yyyy");

            MessageBox.Show(dataStart + "   " + dataEnd);
            
            DataTable dt= chekObj.GetByParametrDate(DateTime.Parse(dataStart), DateTime.Parse(dataEnd));
            RoznichProdazha roznichProdazhaObj = new RoznichProdazha();
            roznichProdazhaObj.printCkek(dt, "ChekReportPeriod");

        }
    }
}
