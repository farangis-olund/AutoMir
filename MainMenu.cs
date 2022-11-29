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
using Core.Controllers;
using Core.DB;



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
           
        }

        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьИзБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DobavitTovarIsBDForm.DobavitIsBD myform = new DobavitTovarIsBDForm.DobavitIsBD();
            myform.Show();
        }

        private void обменТоварамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PriyomSdachaTovaraFrm myform = new PriyomSdachaTovaraFrm();
            myform.Show();
        }

        private void доступКТаблицамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BazaDanikhForm myform = new BazaDanikhForm();
            myform.Show();
        }

        private void курсВалютыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KursValyuti kursValyutiObj = new KursValyuti();
            kursValyutiObj.UpdateKursValyuti();
        }

        private void расходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaskhodiFrm myform = new RaskhodiFrm();
            myform.Show();

        }

        private void отчетПоМестуНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtchetOstatokTovarov myform = new OtchetOstatokTovarov();
            myform.Show();
        }

        private void приходРасходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikhodRaskhodTovara myform = new PrikhodRaskhodTovara();
            myform.Show();
        }

        private void оПродажеТовараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtchetProdazhaTovarov myform = new OtchetProdazhaTovarov();
            myform.Show();
        }

        private void долгиКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DolgiKlienta myform = new DolgiKlienta();
            myform.Show();

        }

        private void распродажаИБонусыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rasprodazha myform = new Rasprodazha();
            myform.Show();
        }

        private void назначениеПроцентаДляПродавцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdavstiProtsent myform = new ProdavstiProtsent();
            myform.Show();
        }
    }
}
