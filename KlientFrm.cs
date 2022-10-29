using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers.Klient;
namespace AutoMir2022
{
    public partial class KlientFrm : Form
    {
        private Klient klientObj = new Klient();
        public KlientFrm()
        {
            InitializeComponent();
            restartForm();
        }


        public void restartForm()
        {
            //klientVibor.DataSource = klientObj.GetKodKlienta();
            //klientVibor.DisplayMember = "fullName";
            //klientVibor.ValueMember = "код_клиента";

            DataTable dt = klientObj.GetKodKlienta();
            klientVibor.Items.Clear();
            klientVibor.Items.Add("Новый клиент");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    klientVibor.Items.Add(dr[0] + " | " + dr[1]);
                }

            }


            uroven.DisplayMember = "уровень";
            uroven.DataSource = klientObj.GetUrovenKlienta();
            uroven.Text = null;
            kodKlienta.Text = "";
            fio.Text = "";
            tel.Text = "";
            adres.Text = "";
            zadolzhnost.Text = "";
            

        }

        private void klientVibor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            klientVibor.Text = klientVibor.GetItemText(klientVibor.SelectedItem);

            int first = klientVibor.Text.IndexOf("|");
            klientVibor.Text = klientVibor.Text.Remove(first - 1);
            
            DataTable dt = klientObj.GetKlientInfo(klientVibor.Text);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    kodKlienta.Text = dr[0].ToString();
                    fio.Text = dr[1].ToString();
                    tel.Text = dr[2].ToString();
                    adres.Text = dr[3].ToString();
                    zadolzhnost.Text = dr[4].ToString();
                    uroven.Text = dr[5].ToString();
                }

            }
        }

       
        private void addKlient_Click(object sender, EventArgs e)
        {
            klientObj.InsertNewKlient(kodKlienta.Text, fio.Text, tel.Text,
              adres.Text, Convert.ToDouble(zadolzhnost.Text), uroven.Text);
                MessageBox.Show("Клиент добавлен!");
        }

        private void updateKlient_Click(object sender, EventArgs e)
        {
            klientObj.UpdateKlient(kodKlienta.Text, fio.Text, tel.Text,
             adres.Text, Convert.ToDouble(zadolzhnost.Text), uroven.Text);
            MessageBox.Show("Данные клиента обновлены!");
        }

        private void deleteKlient_Click(object sender, EventArgs e)
        {
            klientObj.DeleteKlient(kodKlienta.Text);
            MessageBox.Show("Клиент удален!");
            restartForm();
        }
    }
}
