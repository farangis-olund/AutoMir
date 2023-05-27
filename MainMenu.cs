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
using Core.DesignForms;
using Core.DB;



namespace AutoMir2022
{
    public partial class MainMenu : Form
    {
        public string userGroup;
        public static string user;
        public static string password;
        public static bool userPrintFree;
        public static bool userUpdateFree;
        public static bool userExportFree;
        public static bool userOnlyChek;
        public static DataTable userKategori;
        public MainMenu()
        {
       

        InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            

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
            OptovayaProdazha myForm = new OptovayaProdazha();
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
            //Закривать все меню в Menustrip
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Enabled = false;
                foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                {
                    dropItem.Enabled = false;

                }
            }

            user = userName.Text;
            password = userPassword.Text;

            EnabledMenuStripContents(menuStrip1, true);

            

        }
        
        private void EnabledMenuStripContents(MenuStrip obj, bool enabled)
        {
            userExportFree = false;
            userPrintFree = false;
            userUpdateFree = false;
            userOnlyChek = false;
            char[] spliter = { '_' };
            DostupOgranichenie dostupOgranichenieObj = new DostupOgranichenie();
            userKategori = dostupOgranichenieObj.GetDostupUser(userName.Text, userPassword.Text);
            if (userKategori.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь или пароль задан не правильно!");
                userPassword.Text = null;
            } else
            {
                foreach (DataRow dr in userKategori.Rows)
                {
                    
                   string [] enableItems = dr[0].ToString().Split(spliter);

                    //если пользователь имеет категорию повторная печать, то переменная истина
                    if (enableItems.Contains("DobavitIsBDprint"))
                        userPrintFree = true;
            
                    //если пользователь имеет категорию повторный экспорт, то переменная истина
                    if (enableItems.Contains("DobavitIsBDexport"))
                        userExportFree = true;
                    
                    //если пользователь имеет категорию откытого обновление, то переменная истина
                    if (enableItems.Contains("DobavitIsBDupdate"))
                        userUpdateFree = true;
                    
                    //если пользователь имеет категорию только чек, то переменная истина
                    if (enableItems.Contains("OnlyChek"))
                        userOnlyChek = true;


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
            info.Text = "Данная система  позволяет вести управленческий учет" +
                " по торговому предприятию в целом. Прогамма рассчитана на управлением продажи, кассы," +
                "и различные виды отчётов. Для начало работы необходимо создать группу пользователей и их регламент!";

            
        }
        private void доступПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dostup myform = new Dostup();
            myform.Show();

        }


        private void userPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
               loginButton.PerformClick();
            }
        }

        private void info_TextChanged(object sender, EventArgs e)
        {

        }

        private void просмотрБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ProsmotrBDForm myForm = new ProsmotrBDForm();
            //myForm.Show();
        }
    }
}
