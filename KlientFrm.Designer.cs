
namespace AutoMir2022
{
    partial class KlientFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeKlient = new System.Windows.Forms.Button();
            this.deleteKlient = new System.Windows.Forms.Button();
            this.updateKlient = new System.Windows.Forms.Button();
            this.addKlient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.klientVibor = new System.Windows.Forms.ComboBox();
            this.kodKlienta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.adres = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zadolzhnost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uroven = new System.Windows.Forms.ComboBox();
            this.new_klient = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.new_klient);
            this.panel1.Controls.Add(this.closeKlient);
            this.panel1.Controls.Add(this.deleteKlient);
            this.panel1.Controls.Add(this.updateKlient);
            this.panel1.Controls.Add(this.addKlient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.klientVibor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 66);
            this.panel1.TabIndex = 0;
            // 
            // closeKlient
            // 
            this.closeKlient.Location = new System.Drawing.Point(699, 12);
            this.closeKlient.Name = "closeKlient";
            this.closeKlient.Size = new System.Drawing.Size(99, 34);
            this.closeKlient.TabIndex = 3;
            this.closeKlient.Text = "Закрыть";
            this.closeKlient.UseVisualStyleBackColor = true;
            this.closeKlient.Click += new System.EventHandler(this.closeKlient_Click);
            // 
            // deleteKlient
            // 
            this.deleteKlient.ForeColor = System.Drawing.Color.DarkRed;
            this.deleteKlient.Location = new System.Drawing.Point(594, 12);
            this.deleteKlient.Name = "deleteKlient";
            this.deleteKlient.Size = new System.Drawing.Size(96, 34);
            this.deleteKlient.TabIndex = 4;
            this.deleteKlient.Text = "Удалить";
            this.deleteKlient.UseVisualStyleBackColor = true;
            this.deleteKlient.Click += new System.EventHandler(this.deleteKlient_Click);
            // 
            // updateKlient
            // 
            this.updateKlient.Location = new System.Drawing.Point(468, 13);
            this.updateKlient.Name = "updateKlient";
            this.updateKlient.Size = new System.Drawing.Size(112, 34);
            this.updateKlient.TabIndex = 3;
            this.updateKlient.Text = "Обновить";
            this.updateKlient.UseVisualStyleBackColor = true;
            this.updateKlient.Click += new System.EventHandler(this.updateKlient_Click);
            // 
            // addKlient
            // 
            this.addKlient.Enabled = false;
            this.addKlient.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addKlient.Location = new System.Drawing.Point(346, 13);
            this.addKlient.Name = "addKlient";
            this.addKlient.Size = new System.Drawing.Size(112, 34);
            this.addKlient.TabIndex = 2;
            this.addKlient.Text = "Добавить";
            this.addKlient.UseVisualStyleBackColor = true;
            this.addKlient.Click += new System.EventHandler(this.addKlient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Клиент";
            // 
            // klientVibor
            // 
            this.klientVibor.DropDownWidth = 300;
            this.klientVibor.FormattingEnabled = true;
            this.klientVibor.Location = new System.Drawing.Point(77, 15);
            this.klientVibor.Margin = new System.Windows.Forms.Padding(6);
            this.klientVibor.Name = "klientVibor";
            this.klientVibor.Size = new System.Drawing.Size(125, 32);
            this.klientVibor.Sorted = true;
            this.klientVibor.TabIndex = 0;
            this.klientVibor.SelectionChangeCommitted += new System.EventHandler(this.klientVibor_SelectionChangeCommitted);
            // 
            // kodKlienta
            // 
            this.kodKlienta.Location = new System.Drawing.Point(123, 96);
            this.kodKlienta.Name = "kodKlienta";
            this.kodKlienta.Size = new System.Drawing.Size(127, 29);
            this.kodKlienta.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(9, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Код клиента*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "ФИО";
            // 
            // fio
            // 
            this.fio.Location = new System.Drawing.Point(62, 136);
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(188, 29);
            this.fio.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(257, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Раб.телефон:";
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(378, 97);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(140, 29);
            this.tel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(257, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Адрес:";
            // 
            // adres
            // 
            this.adres.Location = new System.Drawing.Point(324, 136);
            this.adres.Name = "adres";
            this.adres.Size = new System.Drawing.Size(194, 29);
            this.adres.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(524, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Задолжность";
            // 
            // zadolzhnost
            // 
            this.zadolzhnost.Location = new System.Drawing.Point(644, 96);
            this.zadolzhnost.Name = "zadolzhnost";
            this.zadolzhnost.Size = new System.Drawing.Size(156, 29);
            this.zadolzhnost.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(524, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Уровень*";
            // 
            // uroven
            // 
            this.uroven.FormattingEnabled = true;
            this.uroven.Location = new System.Drawing.Point(611, 136);
            this.uroven.Name = "uroven";
            this.uroven.Size = new System.Drawing.Size(189, 32);
            this.uroven.TabIndex = 12;
            // 
            // new_klient
            // 
            this.new_klient.ForeColor = System.Drawing.Color.SeaGreen;
            this.new_klient.Location = new System.Drawing.Point(226, 12);
            this.new_klient.Name = "new_klient";
            this.new_klient.Size = new System.Drawing.Size(112, 34);
            this.new_klient.TabIndex = 5;
            this.new_klient.Text = "Новый";
            this.new_klient.UseVisualStyleBackColor = true;
            this.new_klient.Click += new System.EventHandler(this.new_klient_Click);
            // 
            // KlientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 222);
            this.ControlBox = false;
            this.Controls.Add(this.uroven);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zadolzhnost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.adres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kodKlienta);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "KlientFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox klientVibor;
        private System.Windows.Forms.Button closeKlient;
        private System.Windows.Forms.Button deleteKlient;
        private System.Windows.Forms.Button updateKlient;
        private System.Windows.Forms.Button addKlient;
        private System.Windows.Forms.TextBox kodKlienta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox zadolzhnost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uroven;
        private System.Windows.Forms.Button new_klient;
    }
}