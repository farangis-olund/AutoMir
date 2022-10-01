
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
            this.swichBarPanel = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.config = new System.Windows.Forms.Button();
            this.reports = new System.Windows.Forms.Button();
            this.Sklad = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.expendeture = new System.Windows.Forms.Button();
            this.Kassa = new System.Windows.Forms.Button();
            this.wholesale = new System.Windows.Forms.Button();
            this.retailButton = new System.Windows.Forms.Button();
            this.productSection = new System.Windows.Forms.Button();
            this.SideBar.SuspendLayout();
            this.loginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.swichBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.SideBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SideBar.Controls.Add(this.loginBox);
            this.SideBar.Controls.Add(this.TitleFormMenu);
            this.SideBar.Controls.Add(this.logo);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(277, 518);
            this.SideBar.TabIndex = 0;
            // 
            // loginBox
            // 
            this.loginBox.Controls.Add(this.loginButton);
            this.loginBox.Controls.Add(this.userLabel);
            this.loginBox.Controls.Add(this.userPasswordLabel);
            this.loginBox.Controls.Add(this.userPassword);
            this.loginBox.Controls.Add(this.userName);
            this.loginBox.Location = new System.Drawing.Point(10, 136);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(244, 210);
            this.loginBox.TabIndex = 1;
            this.loginBox.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginButton.Location = new System.Drawing.Point(135, 161);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(102, 34);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Вход";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userLabel.Location = new System.Drawing.Point(6, 28);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(122, 22);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Пользователь";
            // 
            // userPasswordLabel
            // 
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userPasswordLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userPasswordLabel.Location = new System.Drawing.Point(6, 89);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(68, 22);
            this.userPasswordLabel.TabIndex = 2;
            this.userPasswordLabel.Text = "Пароль";
            // 
            // userPassword
            // 
            this.userPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userPassword.Location = new System.Drawing.Point(9, 117);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(229, 29);
            this.userPassword.TabIndex = 2;
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userName.Location = new System.Drawing.Point(9, 54);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(229, 29);
            this.userName.TabIndex = 1;
            // 
            // TitleFormMenu
            // 
            this.TitleFormMenu.AutoSize = true;
            this.TitleFormMenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleFormMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TitleFormMenu.Location = new System.Drawing.Point(7, 104);
            this.TitleFormMenu.Name = "TitleFormMenu";
            this.TitleFormMenu.Size = new System.Drawing.Size(162, 22);
            this.TitleFormMenu.TabIndex = 0;
            this.TitleFormMenu.Text = "Добро пожаловать!";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(3, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(267, 76);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // swichBarPanel
            // 
            this.swichBarPanel.BackColor = System.Drawing.SystemColors.Info;
            this.swichBarPanel.Controls.Add(this.exit);
            this.swichBarPanel.Controls.Add(this.config);
            this.swichBarPanel.Controls.Add(this.reports);
            this.swichBarPanel.Controls.Add(this.Sklad);
            this.swichBarPanel.Controls.Add(this.returnButton);
            this.swichBarPanel.Controls.Add(this.expendeture);
            this.swichBarPanel.Controls.Add(this.Kassa);
            this.swichBarPanel.Controls.Add(this.wholesale);
            this.swichBarPanel.Controls.Add(this.retailButton);
            this.swichBarPanel.Controls.Add(this.productSection);
            this.swichBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.swichBarPanel.Location = new System.Drawing.Point(277, 0);
            this.swichBarPanel.Name = "swichBarPanel";
            this.swichBarPanel.Size = new System.Drawing.Size(396, 518);
            this.swichBarPanel.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.exit.Location = new System.Drawing.Point(41, 437);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(323, 40);
            this.exit.TabIndex = 10;
            this.exit.Text = "Выход";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.UseVisualStyleBackColor = false;
            // 
            // config
            // 
            this.config.BackColor = System.Drawing.Color.Transparent;
            this.config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.config.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.config.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.config.Location = new System.Drawing.Point(41, 391);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(323, 40);
            this.config.TabIndex = 9;
            this.config.Text = "Конфигурации БД";
            this.config.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.config.UseVisualStyleBackColor = false;
            // 
            // reports
            // 
            this.reports.BackColor = System.Drawing.Color.Transparent;
            this.reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reports.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reports.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.reports.Location = new System.Drawing.Point(41, 345);
            this.reports.Name = "reports";
            this.reports.Size = new System.Drawing.Size(323, 40);
            this.reports.TabIndex = 8;
            this.reports.Text = "Отчеты";
            this.reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reports.UseVisualStyleBackColor = false;
            // 
            // Sklad
            // 
            this.Sklad.BackColor = System.Drawing.Color.Transparent;
            this.Sklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sklad.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sklad.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Sklad.Location = new System.Drawing.Point(41, 204);
            this.Sklad.Name = "Sklad";
            this.Sklad.Size = new System.Drawing.Size(323, 40);
            this.Sklad.TabIndex = 7;
            this.Sklad.Text = "Склад";
            this.Sklad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sklad.UseVisualStyleBackColor = false;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.Transparent;
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.returnButton.Location = new System.Drawing.Point(41, 253);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(323, 40);
            this.returnButton.TabIndex = 6;
            this.returnButton.Text = "Возврат товара";
            this.returnButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.returnButton.UseVisualStyleBackColor = false;
            // 
            // expendeture
            // 
            this.expendeture.BackColor = System.Drawing.Color.Transparent;
            this.expendeture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.expendeture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expendeture.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expendeture.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.expendeture.Location = new System.Drawing.Point(41, 299);
            this.expendeture.Name = "expendeture";
            this.expendeture.Size = new System.Drawing.Size(323, 40);
            this.expendeture.TabIndex = 5;
            this.expendeture.Text = "Расходы";
            this.expendeture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.expendeture.UseVisualStyleBackColor = false;
            // 
            // Kassa
            // 
            this.Kassa.BackColor = System.Drawing.Color.Transparent;
            this.Kassa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Kassa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Kassa.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Kassa.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Kassa.Location = new System.Drawing.Point(41, 158);
            this.Kassa.Name = "Kassa";
            this.Kassa.Size = new System.Drawing.Size(323, 40);
            this.Kassa.TabIndex = 4;
            this.Kassa.Text = "Касса";
            this.Kassa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Kassa.UseVisualStyleBackColor = false;
            // 
            // wholesale
            // 
            this.wholesale.BackColor = System.Drawing.Color.Transparent;
            this.wholesale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wholesale.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wholesale.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.wholesale.Location = new System.Drawing.Point(41, 113);
            this.wholesale.Name = "wholesale";
            this.wholesale.Size = new System.Drawing.Size(323, 40);
            this.wholesale.TabIndex = 3;
            this.wholesale.Text = "Оптовая продажа";
            this.wholesale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wholesale.UseVisualStyleBackColor = false;
            // 
            // retailButton
            // 
            this.retailButton.BackColor = System.Drawing.Color.Transparent;
            this.retailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.retailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retailButton.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.retailButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.retailButton.Location = new System.Drawing.Point(41, 67);
            this.retailButton.Name = "retailButton";
            this.retailButton.Size = new System.Drawing.Size(323, 40);
            this.retailButton.TabIndex = 2;
            this.retailButton.Text = "Розничная продажа";
            this.retailButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.retailButton.UseVisualStyleBackColor = false;
            this.retailButton.Click += new System.EventHandler(this.retailButton_Click);
            // 
            // productSection
            // 
            this.productSection.BackColor = System.Drawing.Color.Transparent;
            this.productSection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.productSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productSection.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productSection.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.productSection.Location = new System.Drawing.Point(41, 20);
            this.productSection.Name = "productSection";
            this.productSection.Size = new System.Drawing.Size(323, 40);
            this.productSection.TabIndex = 0;
            this.productSection.Text = "Поступление товара";
            this.productSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productSection.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 518);
            this.Controls.Add(this.swichBarPanel);
            this.Controls.Add(this.SideBar);
            this.Name = "MainMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.SideBar.ResumeLayout(false);
            this.SideBar.PerformLayout();
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.swichBarPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel swichBarPanel;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button config;
        private System.Windows.Forms.Button reports;
        private System.Windows.Forms.Button Sklad;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button expendeture;
        private System.Windows.Forms.Button Kassa;
        private System.Windows.Forms.Button wholesale;
        private System.Windows.Forms.Button retailButton;
        private System.Windows.Forms.Button productSection;
    }

}

