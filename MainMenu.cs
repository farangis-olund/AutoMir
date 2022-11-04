using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;


namespace AutoMir2022
{
    public partial class MainMenu : Form
    {
        public string userGroup;
        public MainMenu()
        {
       

        InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            // TestConnection();

        }

        
        private void retailButton_Click(object sender, EventArgs e)
        {
            var retail = new retail();
            retail.Show();
            
        }

        private void розничнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var retail = new retail();
            retail.Show();
            
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SkladFrm myForm = new SkladFrm();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);

            //myForm.Show();

            var SkladFrm = new SkladFrm();
            SkladFrm.Show();
        }

        private void кассаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //info.Visible = false;
            Kassa myForm = new Kassa();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);
            myForm.Show();


        }

        private void возвратToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //info.Visible = false;
            
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);
            Vozvrat myForm = new Vozvrat();
            myForm.Show();
        }

        private void очисткаБазыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //info.Visible = false;
            Konfiguratsiya.Baza.OchistkaBD myForm = new Konfiguratsiya.Baza.OchistkaBD();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);
            
            myForm.Show();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            KlientFrm myForm = new KlientFrm();
            //info.Visible = false;
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);
            myForm.Show();

        }
    public void openFrm(ref Form myForm)
        {
            
        }

        private void оптоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptProdazha myForm = new OptProdazha();
            //info.Visible = false;
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //myForm.FormBorderStyle = FormBorderStyle.None;
            //this.panelData.Controls.Add(myForm);
            myForm.Show();

        }

        private void приходТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikhodRaskhodTovara myform = new PrikhodRaskhodTovara();
            myform.Show();
        }

        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
