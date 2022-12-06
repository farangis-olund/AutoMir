
namespace AutoMir2022
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.SideBar = new System.Windows.Forms.Panel();
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.userLabel = new System.Windows.Forms.Label();
            this.userPasswordLabel = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.TitleFormMenu = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panelSwich = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.prodazha = new System.Windows.Forms.ToolStripMenuItem();
            this.roznichnaya = new System.Windows.Forms.ToolStripMenuItem();
            this.optovaya = new System.Windows.Forms.ToolStripMenuItem();
            this.klient = new System.Windows.Forms.ToolStripMenuItem();
            this.postuplenie = new System.Windows.Forms.ToolStripMenuItem();
            this.dobavitBd = new System.Windows.Forms.ToolStripMenuItem();
            this.prikhodRaskhod = new System.Windows.Forms.ToolStripMenuItem();
            this.obmenTovarami = new System.Windows.Forms.ToolStripMenuItem();
            this.operatsii = new System.Windows.Forms.ToolStripMenuItem();
            this.kassa = new System.Windows.Forms.ToolStripMenuItem();
            this.sklad = new System.Windows.Forms.ToolStripMenuItem();
            this.raskhodi = new System.Windows.Forms.ToolStripMenuItem();
            this.kurs = new System.Windows.Forms.ToolStripMenuItem();
            this.otcheti = new System.Windows.Forms.ToolStripMenuItem();
            this.otchetOstatok = new System.Windows.Forms.ToolStripMenuItem();
            this.otchetProdazha = new System.Windows.Forms.ToolStripMenuItem();
            this.dolgiKlienta = new System.Windows.Forms.ToolStripMenuItem();
            this.vozvrat = new System.Windows.Forms.ToolStripMenuItem();
            this.vozvratOformlenie = new System.Windows.Forms.ToolStripMenuItem();
            this.konfig = new System.Windows.Forms.ToolStripMenuItem();
            this.dostupTablitsam = new System.Windows.Forms.ToolStripMenuItem();
            this.ochistkaBazi = new System.Windows.Forms.ToolStripMenuItem();
            this.admin = new System.Windows.Forms.ToolStripMenuItem();
            this.protsenti = new System.Windows.Forms.ToolStripMenuItem();
            this.rasprodazhaBonus = new System.Windows.Forms.ToolStripMenuItem();
            this.dostupPolzovateley = new System.Windows.Forms.ToolStripMenuItem();
            this.info = new System.Windows.Forms.RichTextBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.SideBar.SuspendLayout();
            this.loginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.panelSwich.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.LightSlateGray;
            this.SideBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SideBar.Controls.Add(this.loginBox);
            this.SideBar.Controls.Add(this.TitleFormMenu);
            this.SideBar.Controls.Add(this.logo);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(238, 739);
            this.SideBar.TabIndex = 0;
            // 
            // loginBox
            // 
            this.loginBox.Controls.Add(this.loginButton);
            this.loginBox.Controls.Add(this.userLabel);
            this.loginBox.Controls.Add(this.userPasswordLabel);
            this.loginBox.Controls.Add(this.userPassword);
            this.loginBox.Controls.Add(this.userName);
            this.loginBox.Location = new System.Drawing.Point(9, 118);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(209, 192);
            this.loginBox.TabIndex = 1;
            this.loginBox.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.loginButton.Location = new System.Drawing.Point(116, 147);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(87, 29);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Вход";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.userLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userLabel.Location = new System.Drawing.Point(5, 24);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(122, 22);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Пользователь";
            // 
            // userPasswordLabel
            // 
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.userPasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userPasswordLabel.Location = new System.Drawing.Point(5, 84);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(68, 22);
            this.userPasswordLabel.TabIndex = 2;
            this.userPasswordLabel.Text = "Пароль";
            // 
            // userPassword
            // 
            this.userPassword.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPassword.Location = new System.Drawing.Point(9, 108);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(194, 33);
            this.userPassword.TabIndex = 2;
            this.userPassword.UseSystemPasswordChar = true;
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(9, 47);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(194, 33);
            this.userName.TabIndex = 1;
            // 
            // TitleFormMenu
            // 
            this.TitleFormMenu.AutoSize = true;
            this.TitleFormMenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.TitleFormMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TitleFormMenu.Location = new System.Drawing.Point(6, 90);
            this.TitleFormMenu.Name = "TitleFormMenu";
            this.TitleFormMenu.Size = new System.Drawing.Size(162, 22);
            this.TitleFormMenu.TabIndex = 0;
            this.TitleFormMenu.Text = "Добро пожаловать!";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(30, 9);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(170, 59);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // panelSwich
            // 
            this.panelSwich.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSwich.Controls.Add(this.menuStrip1);
            this.panelSwich.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSwich.Location = new System.Drawing.Point(238, 0);
            this.panelSwich.Name = "panelSwich";
            this.panelSwich.Size = new System.Drawing.Size(1069, 35);
            this.panelSwich.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MintCream;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prodazha,
            this.postuplenie,
            this.operatsii,
            this.otcheti,
            this.vozvrat,
            this.konfig,
            this.admin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1069, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // prodazha
            // 
            this.prodazha.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roznichnaya,
            this.optovaya,
            this.klient});
            this.prodazha.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prodazha.Name = "prodazha";
            this.prodazha.Size = new System.Drawing.Size(104, 29);
            this.prodazha.Text = "Продажа";
            // 
            // roznichnaya
            // 
            this.roznichnaya.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roznichnaya.Name = "roznichnaya";
            this.roznichnaya.Size = new System.Drawing.Size(414, 34);
            this.roznichnaya.Text = "Оформление розничной продажи";
            this.roznichnaya.Click += new System.EventHandler(this.розничнаяToolStripMenuItem_Click);
            // 
            // optovaya
            // 
            this.optovaya.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optovaya.Name = "optovaya";
            this.optovaya.Size = new System.Drawing.Size(414, 34);
            this.optovaya.Text = "Оформление оптовой продажи";
            this.optovaya.Click += new System.EventHandler(this.оптоваяToolStripMenuItem_Click);
            // 
            // klient
            // 
            this.klient.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.klient.Name = "klient";
            this.klient.Size = new System.Drawing.Size(414, 34);
            this.klient.Text = "Клиенты";
            this.klient.Click += new System.EventHandler(this.клиентToolStripMenuItem_Click);
            // 
            // postuplenie
            // 
            this.postuplenie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dobavitBd,
            this.prikhodRaskhod,
            this.obmenTovarami});
            this.postuplenie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postuplenie.Name = "postuplenie";
            this.postuplenie.Size = new System.Drawing.Size(138, 29);
            this.postuplenie.Text = "Поступление";
            // 
            // dobavitBd
            // 
            this.dobavitBd.Name = "dobavitBd";
            this.dobavitBd.Size = new System.Drawing.Size(232, 30);
            this.dobavitBd.Text = "Добавить из БД";
            this.dobavitBd.Click += new System.EventHandler(this.добавитьИзБДToolStripMenuItem_Click);
            // 
            // prikhodRaskhod
            // 
            this.prikhodRaskhod.Name = "prikhodRaskhod";
            this.prikhodRaskhod.Size = new System.Drawing.Size(232, 30);
            this.prikhodRaskhod.Text = "Приход/Расход";
            this.prikhodRaskhod.Click += new System.EventHandler(this.приходРасходToolStripMenuItem_Click);
            // 
            // obmenTovarami
            // 
            this.obmenTovarami.Name = "obmenTovarami";
            this.obmenTovarami.Size = new System.Drawing.Size(232, 30);
            this.obmenTovarami.Text = "Обмен товарами";
            this.obmenTovarami.Click += new System.EventHandler(this.обменТоварамиToolStripMenuItem_Click);
            // 
            // operatsii
            // 
            this.operatsii.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kassa,
            this.sklad,
            this.raskhodi,
            this.kurs});
            this.operatsii.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operatsii.Name = "operatsii";
            this.operatsii.Size = new System.Drawing.Size(113, 29);
            this.operatsii.Text = "Операции";
            // 
            // kassa
            // 
            this.kassa.Name = "kassa";
            this.kassa.Size = new System.Drawing.Size(195, 30);
            this.kassa.Text = "Касса";
            this.kassa.Click += new System.EventHandler(this.кассаToolStripMenuItem_Click);
            // 
            // sklad
            // 
            this.sklad.Name = "sklad";
            this.sklad.Size = new System.Drawing.Size(195, 30);
            this.sklad.Text = "Склад";
            this.sklad.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            // 
            // raskhodi
            // 
            this.raskhodi.Name = "raskhodi";
            this.raskhodi.Size = new System.Drawing.Size(195, 30);
            this.raskhodi.Text = "Расходы";
            this.raskhodi.Click += new System.EventHandler(this.расходыToolStripMenuItem_Click);
            // 
            // kurs
            // 
            this.kurs.Enabled = false;
            this.kurs.Name = "kurs";
            this.kurs.Size = new System.Drawing.Size(195, 30);
            this.kurs.Text = "Курс валюты";
            this.kurs.Click += new System.EventHandler(this.курсВалютыToolStripMenuItem_Click);
            // 
            // otcheti
            // 
            this.otcheti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otchetOstatok,
            this.otchetProdazha,
            this.dolgiKlienta});
            this.otcheti.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otcheti.Name = "otcheti";
            this.otcheti.Size = new System.Drawing.Size(88, 29);
            this.otcheti.Text = "Отчеты";
            // 
            // otchetOstatok
            // 
            this.otchetOstatok.Name = "otchetOstatok";
            this.otchetOstatok.Size = new System.Drawing.Size(253, 30);
            this.otchetOstatok.Text = "Об остатках товара";
            this.otchetOstatok.Click += new System.EventHandler(this.отчетПоМестуНаСкладеToolStripMenuItem_Click);
            // 
            // otchetProdazha
            // 
            this.otchetProdazha.Name = "otchetProdazha";
            this.otchetProdazha.Size = new System.Drawing.Size(253, 30);
            this.otchetProdazha.Text = "О продаже товара";
            this.otchetProdazha.Click += new System.EventHandler(this.оПродажеТовараToolStripMenuItem_Click);
            // 
            // dolgiKlienta
            // 
            this.dolgiKlienta.Name = "dolgiKlienta";
            this.dolgiKlienta.Size = new System.Drawing.Size(253, 30);
            this.dolgiKlienta.Text = "Долги клиентов";
            this.dolgiKlienta.Click += new System.EventHandler(this.долгиКлиентовToolStripMenuItem_Click);
            // 
            // vozvrat
            // 
            this.vozvrat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vozvratOformlenie});
            this.vozvrat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vozvrat.Name = "vozvrat";
            this.vozvrat.Size = new System.Drawing.Size(93, 29);
            this.vozvrat.Text = "Возврат";
            // 
            // vozvratOformlenie
            // 
            this.vozvratOformlenie.Name = "vozvratOformlenie";
            this.vozvratOformlenie.Size = new System.Drawing.Size(281, 30);
            this.vozvratOformlenie.Text = "Оформление возврата";
            this.vozvratOformlenie.Click += new System.EventHandler(this.возвратToolStripMenuItem1_Click);
            // 
            // konfig
            // 
            this.konfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dostupTablitsam,
            this.ochistkaBazi});
            this.konfig.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.konfig.Name = "konfig";
            this.konfig.Size = new System.Drawing.Size(150, 29);
            this.konfig.Text = "Конфигурация";
            // 
            // dostupTablitsam
            // 
            this.dostupTablitsam.Name = "dostupTablitsam";
            this.dostupTablitsam.Size = new System.Drawing.Size(248, 30);
            this.dostupTablitsam.Text = "Доступ к таблицам";
            this.dostupTablitsam.Click += new System.EventHandler(this.доступКТаблицамToolStripMenuItem_Click);
            // 
            // ochistkaBazi
            // 
            this.ochistkaBazi.Name = "ochistkaBazi";
            this.ochistkaBazi.Size = new System.Drawing.Size(248, 30);
            this.ochistkaBazi.Text = "Очистка базы";
            this.ochistkaBazi.Click += new System.EventHandler(this.очисткаБазыToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protsenti,
            this.rasprodazhaBonus,
            this.dostupPolzovateley});
            this.admin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(162, 29);
            this.admin.Text = "Администрация";
            // 
            // protsenti
            // 
            this.protsenti.Name = "protsenti";
            this.protsenti.Size = new System.Drawing.Size(401, 30);
            this.protsenti.Text = "Назначение процента для продавца";
            this.protsenti.Click += new System.EventHandler(this.назначениеПроцентаДляПродавцаToolStripMenuItem_Click);
            // 
            // rasprodazhaBonus
            // 
            this.rasprodazhaBonus.Name = "rasprodazhaBonus";
            this.rasprodazhaBonus.Size = new System.Drawing.Size(401, 30);
            this.rasprodazhaBonus.Text = "Распродажа и бонусы";
            this.rasprodazhaBonus.Click += new System.EventHandler(this.распродажаИБонусыToolStripMenuItem_Click);
            // 
            // dostupPolzovateley
            // 
            this.dostupPolzovateley.Name = "dostupPolzovateley";
            this.dostupPolzovateley.Size = new System.Drawing.Size(401, 30);
            this.dostupPolzovateley.Text = "Ограничение и Доступ";
            this.dostupPolzovateley.Click += new System.EventHandler(this.доступПользователейToolStripMenuItem_Click);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.SystemColors.Menu;
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.info.Location = new System.Drawing.Point(61, 100);
            this.info.Margin = new System.Windows.Forms.Padding(10);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(648, 271);
            this.info.TabIndex = 0;
            this.info.Text = "";
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.info);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(238, 35);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1069, 704);
            this.panelData.TabIndex = 3;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 739);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelSwich);
            this.Controls.Add(this.SideBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.SideBar.ResumeLayout(false);
            this.SideBar.PerformLayout();
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.panelSwich.ResumeLayout(false);
            this.panelSwich.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Label TitleFormMenu;
        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label userPasswordLabel;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel panelSwich;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem prodazha;
        private System.Windows.Forms.ToolStripMenuItem roznichnaya;
        private System.Windows.Forms.ToolStripMenuItem optovaya;
        private System.Windows.Forms.ToolStripMenuItem postuplenie;
        private System.Windows.Forms.ToolStripMenuItem operatsii;
        private System.Windows.Forms.ToolStripMenuItem kassa;
        private System.Windows.Forms.ToolStripMenuItem sklad;
        private System.Windows.Forms.ToolStripMenuItem raskhodi;
        private System.Windows.Forms.ToolStripMenuItem otcheti;
        private System.Windows.Forms.ToolStripMenuItem dobavitBd;
        private System.Windows.Forms.ToolStripMenuItem prikhodRaskhod;
        private System.Windows.Forms.ToolStripMenuItem obmenTovarami;
        private System.Windows.Forms.ToolStripMenuItem kurs;
        private System.Windows.Forms.ToolStripMenuItem otchetOstatok;
        private System.Windows.Forms.ToolStripMenuItem vozvrat;
        private System.Windows.Forms.ToolStripMenuItem vozvratOformlenie;
        private System.Windows.Forms.ToolStripMenuItem konfig;
        private System.Windows.Forms.RichTextBox info;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.ToolStripMenuItem klient;
        private System.Windows.Forms.ToolStripMenuItem admin;
        private System.Windows.Forms.ToolStripMenuItem protsenti;
        private System.Windows.Forms.ToolStripMenuItem rasprodazhaBonus;
        private System.Windows.Forms.ToolStripMenuItem dostupPolzovateley;
        private System.Windows.Forms.ToolStripMenuItem otchetProdazha;
        private System.Windows.Forms.ToolStripMenuItem dolgiKlienta;
        private System.Windows.Forms.ToolStripMenuItem dostupTablitsam;
        private System.Windows.Forms.ToolStripMenuItem ochistkaBazi;
    }

}

