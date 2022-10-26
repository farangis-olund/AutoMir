
namespace AutoMir2022
{
    partial class Vozvrat
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.nakladnoyNaitiCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kodKlientaNaitiCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.artikulCmb = new System.Windows.Forms.ComboBox();
            this.naitiDGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vozvratDGV = new System.Windows.Forms.DataGridView();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.naitiBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataTxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kodKlientaProzhCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nakladnoyVozvratCmb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prozhVozvratChek = new System.Windows.Forms.CheckBox();
            this.roznRb = new System.Windows.Forms.RadioButton();
            this.optRb = new System.Windows.Forms.RadioButton();
            this.oformitBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pechatBtn = new System.Windows.Forms.Button();
            this.kodVozvrataTxb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naitiDGV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vozvratDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.kodVozvrataTxb);
            this.panel1.Controls.Add(this.pechatBtn);
            this.panel1.Controls.Add(this.oformitBtn);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nakladnoyVozvratCmb);
            this.panel1.Controls.Add(this.dataTxb);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.naitiBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.artikulCmb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.kodKlientaNaitiCmb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nakladnoyNaitiCmb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 131);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.naitiDGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(648, 434);
            this.panel3.TabIndex = 2;
            // 
            // nakladnoyNaitiCmb
            // 
            this.nakladnoyNaitiCmb.FormattingEnabled = true;
            this.nakladnoyNaitiCmb.Location = new System.Drawing.Point(11, 32);
            this.nakladnoyNaitiCmb.Name = "nakladnoyNaitiCmb";
            this.nakladnoyNaitiCmb.Size = new System.Drawing.Size(116, 28);
            this.nakladnoyNaitiCmb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "№ Накладной";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(141, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Код клиента";
            // 
            // kodKlientaNaitiCmb
            // 
            this.kodKlientaNaitiCmb.FormattingEnabled = true;
            this.kodKlientaNaitiCmb.Location = new System.Drawing.Point(143, 32);
            this.kodKlientaNaitiCmb.Name = "kodKlientaNaitiCmb";
            this.kodKlientaNaitiCmb.Size = new System.Drawing.Size(104, 28);
            this.kodKlientaNaitiCmb.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(260, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Артикул";
            // 
            // artikulCmb
            // 
            this.artikulCmb.FormattingEnabled = true;
            this.artikulCmb.Location = new System.Drawing.Point(264, 32);
            this.artikulCmb.Name = "artikulCmb";
            this.artikulCmb.Size = new System.Drawing.Size(179, 28);
            this.artikulCmb.TabIndex = 5;
            // 
            // naitiDGV
            // 
            this.naitiDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.naitiDGV.Location = new System.Drawing.Point(8, 5);
            this.naitiDGV.Name = "naitiDGV";
            this.naitiDGV.Size = new System.Drawing.Size(632, 421);
            this.naitiDGV.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.vozvratDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(646, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 434);
            this.panel2.TabIndex = 3;
            // 
            // vozvratDGV
            // 
            this.vozvratDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vozvratDGV.Location = new System.Drawing.Point(9, 5);
            this.vozvratDGV.Name = "vozvratDGV";
            this.vozvratDGV.Size = new System.Drawing.Size(612, 421);
            this.vozvratDGV.TabIndex = 0;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(18, 29);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(146, 26);
            this.dateStart.TabIndex = 7;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(18, 61);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(146, 26);
            this.dateEnd.TabIndex = 10;
            // 
            // naitiBtn
            // 
            this.naitiBtn.Location = new System.Drawing.Point(348, 70);
            this.naitiBtn.Name = "naitiBtn";
            this.naitiBtn.Size = new System.Drawing.Size(95, 35);
            this.naitiBtn.TabIndex = 11;
            this.naitiBtn.Text = "Найти";
            this.naitiBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(463, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период";
            // 
            // dataTxb
            // 
            this.dataTxb.Location = new System.Drawing.Point(8, 97);
            this.dataTxb.Name = "dataTxb";
            this.dataTxb.ReadOnly = true;
            this.dataTxb.Size = new System.Drawing.Size(195, 26);
            this.dataTxb.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(131, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Код клиента";
            // 
            // kodKlientaProzhCmb
            // 
            this.kodKlientaProzhCmb.FormattingEnabled = true;
            this.kodKlientaProzhCmb.Location = new System.Drawing.Point(133, 45);
            this.kodKlientaProzhCmb.Name = "kodKlientaProzhCmb";
            this.kodKlientaProzhCmb.Size = new System.Drawing.Size(104, 28);
            this.kodKlientaProzhCmb.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(663, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "№ Накладной";
            // 
            // nakladnoyVozvratCmb
            // 
            this.nakladnoyVozvratCmb.FormattingEnabled = true;
            this.nakladnoyVozvratCmb.Location = new System.Drawing.Point(666, 32);
            this.nakladnoyVozvratCmb.Name = "nakladnoyVozvratCmb";
            this.nakladnoyVozvratCmb.Size = new System.Drawing.Size(111, 28);
            this.nakladnoyVozvratCmb.TabIndex = 14;
            this.nakladnoyVozvratCmb.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.optRb);
            this.groupBox2.Controls.Add(this.roznRb);
            this.groupBox2.Controls.Add(this.prozhVozvratChek);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.kodKlientaProzhCmb);
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(928, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 93);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // prozhVozvratChek
            // 
            this.prozhVozvratChek.AutoSize = true;
            this.prozhVozvratChek.Location = new System.Drawing.Point(65, 52);
            this.prozhVozvratChek.Name = "prozhVozvratChek";
            this.prozhVozvratChek.Size = new System.Drawing.Size(15, 14);
            this.prozhVozvratChek.TabIndex = 18;
            this.prozhVozvratChek.UseVisualStyleBackColor = true;
            // 
            // roznRb
            // 
            this.roznRb.AutoSize = true;
            this.roznRb.Location = new System.Drawing.Point(267, 27);
            this.roznRb.Name = "roznRb";
            this.roznRb.Size = new System.Drawing.Size(63, 24);
            this.roznRb.TabIndex = 19;
            this.roznRb.TabStop = true;
            this.roznRb.Text = "Розн";
            this.roznRb.UseVisualStyleBackColor = true;
            // 
            // optRb
            // 
            this.optRb.AutoSize = true;
            this.optRb.Location = new System.Drawing.Point(267, 56);
            this.optRb.Name = "optRb";
            this.optRb.Size = new System.Drawing.Size(57, 24);
            this.optRb.TabIndex = 20;
            this.optRb.TabStop = true;
            this.optRb.Text = "Опт";
            this.optRb.UseVisualStyleBackColor = true;
            // 
            // oformitBtn
            // 
            this.oformitBtn.Location = new System.Drawing.Point(797, 28);
            this.oformitBtn.Name = "oformitBtn";
            this.oformitBtn.Size = new System.Drawing.Size(112, 35);
            this.oformitBtn.TabIndex = 19;
            this.oformitBtn.Text = "Оформить";
            this.oformitBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(14, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Прош.возврат";
            // 
            // pechatBtn
            // 
            this.pechatBtn.Location = new System.Drawing.Point(797, 70);
            this.pechatBtn.Name = "pechatBtn";
            this.pechatBtn.Size = new System.Drawing.Size(111, 35);
            this.pechatBtn.TabIndex = 20;
            this.pechatBtn.Text = "Печать";
            this.pechatBtn.UseVisualStyleBackColor = true;
            // 
            // kodVozvrataTxb
            // 
            this.kodVozvrataTxb.Location = new System.Drawing.Point(666, 78);
            this.kodVozvrataTxb.Name = "kodVozvrataTxb";
            this.kodVozvrataTxb.Size = new System.Drawing.Size(110, 26);
            this.kodVozvrataTxb.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(663, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Код возврата";
            // 
            // Vozvrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Vozvrat";
            this.Text = "Возврат";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naitiDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vozvratDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox artikulCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox kodKlientaNaitiCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox nakladnoyNaitiCmb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView naitiDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView vozvratDGV;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button naitiBtn;
        private System.Windows.Forms.TextBox dataTxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox kodKlientaProzhCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox nakladnoyVozvratCmb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optRb;
        private System.Windows.Forms.RadioButton roznRb;
        private System.Windows.Forms.CheckBox prozhVozvratChek;
        private System.Windows.Forms.Button oformitBtn;
        private System.Windows.Forms.Button pechatBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kodVozvrataTxb;
    }
}