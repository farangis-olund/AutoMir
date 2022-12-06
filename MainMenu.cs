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
            var SkladFrm = new SkladFrm();
            SkladFrm.Show();
        }

        private void кассаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kassa myForm = new Kassa();
            myForm.Show();
        }

        private void возвратToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vozvrat myForm = new Vozvrat();
            myForm.Show();
        }

        private void очисткаБазыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Konfiguratsiya.Baza.OchistkaBD myForm = new Konfiguratsiya.Baza.OchistkaBD();
            myForm.Show();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            KlientFrm myForm = new KlientFrm();
            myForm.Show();

        }
   

        private void оптоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptProdazha myForm = new OptProdazha();
            myForm.Show();

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

        private void loginButton_Click(object sender, EventArgs e)
        {

            EnabledMenuStripContents(menuStrip1, true);

            

        }

        private void EnabledMenuStripContents(MenuStrip obj, bool enabled)
        {
            char[] spliter = { '_' };
            DostupOgranichenie dostupOgranichenieObj = new DostupOgranichenie();
            DataTable dt = dostupOgranichenieObj.GetDostupUser(userName.Text, userPassword.Text);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь или пароль задан не правильно!");
                userPassword.Text = null;
            } else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string[] enableItems = dr[0].ToString().Split(spliter);

                    foreach (ToolStripMenuItem item in obj.Items)
                    {
                        if (enableItems.Contains(item.Name))
                        {
                            item.Enabled = enabled;
                        }

                        foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                        {
                            if (enableItems.Contains(dropItem.Name))
                            {
                                dropItem.Enabled = enabled;
                            }
                        }
                    
                    }
                    
                }
            }
            

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //Закривать все меню в Menustrip
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            { 
                item.Enabled = false;
                foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                {   
                    dropItem.Enabled = false;
                    
                }
            }
            info.Text = "Добро пожаловать в систему управление учёта! Для начало работы входите в систему!";
            
            
        }
        private void доступПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dostup myform = new Dostup();
            myform.Show();

        }

        private void bd_Click(object sender, EventArgs e)
        {

        }
    }
}
