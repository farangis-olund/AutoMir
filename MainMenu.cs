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
            //this.Close();
        }

        private void розничнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var retail = new retail();
            retail.Show();
            //this.Close();
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.Visible = false;
            SkladFrm myForm = new SkladFrm();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            this.panelData.Controls.Add(myForm);
            myForm.Show();

            ////var SkladFrm = new SkladFrm();
            ////SkladFrm.Show();
        }

        private void кассаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.Visible = false;
            Kassa myForm = new Kassa();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            this.panelData.Controls.Add(myForm);
            myForm.Show();


        }

        private void возвратToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            info.Visible = false;
            Vozvrat myForm = new Vozvrat();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            this.panelData.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
