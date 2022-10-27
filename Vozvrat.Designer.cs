
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
            this.showAll = new System.Windows.Forms.Button();
            this.zakrit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.kodVozvrataTxb = new System.Windows.Forms.TextBox();
            this.pechatBtn = new System.Windows.Forms.Button();
            this.oformitBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.optRb = new System.Windows.Forms.RadioButton();
            this.roznRb = new System.Windows.Forms.RadioButton();
            this.prozhVozvratChek = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kodKlientaProzhCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nakladnoyVozvratCmb = new System.Windows.Forms.ComboBox();
            this.dataTxb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.naitiBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.artikulCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kodKlientaNaitiCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nakladnoyNaitiCmb = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.artikulVibor = new System.Windows.Forms.ComboBox();
            this.vozvratDGV = new System.Windows.Forms.DataGridView();
            this.naitiDGV = new System.Windows.Forms.DataGridView();
            this.artikul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.show_all_dataDGV = new System.Windows.Forms.DataGridView();
            this.artikulVozvrat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsenaVozv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolVozvrata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaVozv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vozvratDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.naitiDGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_all_dataDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.showAll);
            this.panel1.Controls.Add(this.zakrit);
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
            this.panel1.Size = new System.Drawing.Size(1239, 173);
            this.panel1.TabIndex = 0;
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(171, 114);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(122, 35);
            this.showAll.TabIndex = 24;
            this.showAll.Text = "Показать всё";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // zakrit
            // 
            this.zakrit.Location = new System.Drawing.Point(1120, 3);
            this.zakrit.Name = "zakrit";
            this.zakrit.Size = new System.Drawing.Size(115, 41);
            this.zakrit.TabIndex = 23;
            this.zakrit.Text = "Закрыть";
            this.zakrit.UseVisualStyleBackColor = true;
            this.zakrit.Click += new System.EventHandler(this.zakrit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(605, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Код возврата";
            // 
            // kodVozvrataTxb
            // 
            this.kodVozvrataTxb.Location = new System.Drawing.Point(608, 122);
            this.kodVozvrataTxb.Name = "kodVozvrataTxb";
            this.kodVozvrataTxb.Size = new System.Drawing.Size(110, 26);
            this.kodVozvrataTxb.TabIndex = 21;
            // 
            // pechatBtn
            // 
            this.pechatBtn.Location = new System.Drawing.Point(739, 114);
            this.pechatBtn.Name = "pechatBtn";
            this.pechatBtn.Size = new System.Drawing.Size(111, 35);
            this.pechatBtn.TabIndex = 20;
            this.pechatBtn.Text = "Печать";
            this.pechatBtn.UseVisualStyleBackColor = true;
            // 
            // oformitBtn
            // 
            this.oformitBtn.Location = new System.Drawing.Point(739, 72);
            this.oformitBtn.Name = "oformitBtn";
            this.oformitBtn.Size = new System.Drawing.Size(112, 35);
            this.oformitBtn.TabIndex = 19;
            this.oformitBtn.Text = "Оформить";
            this.oformitBtn.UseVisualStyleBackColor = true;
            this.oformitBtn.Click += new System.EventHandler(this.oformitBtn_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(863, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 93);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Прош.возврат";
            // 
            // optRb
            // 
            this.optRb.AutoSize = true;
            this.optRb.Enabled = false;
            this.optRb.Location = new System.Drawing.Point(282, 51);
            this.optRb.Name = "optRb";
            this.optRb.Size = new System.Drawing.Size(57, 24);
            this.optRb.TabIndex = 20;
            this.optRb.TabStop = true;
            this.optRb.Text = "Опт";
            this.optRb.UseVisualStyleBackColor = true;
            // 
            // roznRb
            // 
            this.roznRb.AutoSize = true;
            this.roznRb.Enabled = false;
            this.roznRb.Location = new System.Drawing.Point(282, 22);
            this.roznRb.Name = "roznRb";
            this.roznRb.Size = new System.Drawing.Size(63, 24);
            this.roznRb.TabIndex = 19;
            this.roznRb.TabStop = true;
            this.roznRb.Text = "Розн";
            this.roznRb.UseVisualStyleBackColor = true;
            // 
            // prozhVozvratChek
            // 
            this.prozhVozvratChek.AutoSize = true;
            this.prozhVozvratChek.Location = new System.Drawing.Point(60, 52);
            this.prozhVozvratChek.Name = "prozhVozvratChek";
            this.prozhVozvratChek.Size = new System.Drawing.Size(15, 14);
            this.prozhVozvratChek.TabIndex = 18;
            this.prozhVozvratChek.UseVisualStyleBackColor = true;
            this.prozhVozvratChek.CheckedChanged += new System.EventHandler(this.prozhVozvratChek_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(142, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Код клиента";
            // 
            // kodKlientaProzhCmb
            // 
            this.kodKlientaProzhCmb.DropDownHeight = 50;
            this.kodKlientaProzhCmb.Enabled = false;
            this.kodKlientaProzhCmb.FormattingEnabled = true;
            this.kodKlientaProzhCmb.IntegralHeight = false;
            this.kodKlientaProzhCmb.Location = new System.Drawing.Point(144, 45);
            this.kodKlientaProzhCmb.Name = "kodKlientaProzhCmb";
            this.kodKlientaProzhCmb.Size = new System.Drawing.Size(104, 28);
            this.kodKlientaProzhCmb.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(605, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "№ Накладной";
            // 
            // nakladnoyVozvratCmb
            // 
            this.nakladnoyVozvratCmb.DropDownHeight = 50;
            this.nakladnoyVozvratCmb.FormattingEnabled = true;
            this.nakladnoyVozvratCmb.IntegralHeight = false;
            this.nakladnoyVozvratCmb.Location = new System.Drawing.Point(608, 76);
            this.nakladnoyVozvratCmb.Name = "nakladnoyVozvratCmb";
            this.nakladnoyVozvratCmb.Size = new System.Drawing.Size(111, 28);
            this.nakladnoyVozvratCmb.TabIndex = 14;
            this.nakladnoyVozvratCmb.SelectionChangeCommitted += new System.EventHandler(this.nakladnoyVozvratCmb_SelectionChangeCommitted);
            // 
            // dataTxb
            // 
            this.dataTxb.Location = new System.Drawing.Point(8, 143);
            this.dataTxb.Name = "dataTxb";
            this.dataTxb.ReadOnly = true;
            this.dataTxb.Size = new System.Drawing.Size(139, 26);
            this.dataTxb.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(415, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(18, 29);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(121, 26);
            this.dateStart.TabIndex = 7;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(18, 61);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(121, 26);
            this.dateEnd.TabIndex = 10;
            // 
            // naitiBtn
            // 
            this.naitiBtn.Location = new System.Drawing.Point(301, 113);
            this.naitiBtn.Name = "naitiBtn";
            this.naitiBtn.Size = new System.Drawing.Size(95, 35);
            this.naitiBtn.TabIndex = 11;
            this.naitiBtn.Text = "Найти";
            this.naitiBtn.UseVisualStyleBackColor = true;
            this.naitiBtn.Click += new System.EventHandler(this.naitiBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(246, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Артикул";
            // 
            // artikulCmb
            // 
            this.artikulCmb.DropDownHeight = 50;
            this.artikulCmb.FormattingEnabled = true;
            this.artikulCmb.IntegralHeight = false;
            this.artikulCmb.Location = new System.Drawing.Point(250, 76);
            this.artikulCmb.Name = "artikulCmb";
            this.artikulCmb.Size = new System.Drawing.Size(146, 28);
            this.artikulCmb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(132, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Код клиента";
            // 
            // kodKlientaNaitiCmb
            // 
            this.kodKlientaNaitiCmb.DropDownHeight = 50;
            this.kodKlientaNaitiCmb.FormattingEnabled = true;
            this.kodKlientaNaitiCmb.IntegralHeight = false;
            this.kodKlientaNaitiCmb.Location = new System.Drawing.Point(134, 76);
            this.kodKlientaNaitiCmb.Name = "kodKlientaNaitiCmb";
            this.kodKlientaNaitiCmb.Size = new System.Drawing.Size(104, 28);
            this.kodKlientaNaitiCmb.TabIndex = 3;
            this.kodKlientaNaitiCmb.SelectionChangeCommitted += new System.EventHandler(this.kodKlientaNaitiCmb_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "№ Накладной";
            // 
            // nakladnoyNaitiCmb
            // 
            this.nakladnoyNaitiCmb.DropDownHeight = 50;
            this.nakladnoyNaitiCmb.FormattingEnabled = true;
            this.nakladnoyNaitiCmb.IntegralHeight = false;
            this.nakladnoyNaitiCmb.Location = new System.Drawing.Point(11, 76);
            this.nakladnoyNaitiCmb.Name = "nakladnoyNaitiCmb";
            this.nakladnoyNaitiCmb.Size = new System.Drawing.Size(111, 28);
            this.nakladnoyNaitiCmb.TabIndex = 1;
            this.nakladnoyNaitiCmb.SelectionChangeCommitted += new System.EventHandler(this.nakladnoyNaitiCmb_SelectionChangeCommitted);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.artikulVibor);
            this.panel2.Controls.Add(this.vozvratDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(595, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 426);
            this.panel2.TabIndex = 3;
            // 
            // artikulVibor
            // 
            this.artikulVibor.DropDownHeight = 50;
            this.artikulVibor.FormattingEnabled = true;
            this.artikulVibor.IntegralHeight = false;
            this.artikulVibor.Location = new System.Drawing.Point(6, 9);
            this.artikulVibor.Name = "artikulVibor";
            this.artikulVibor.Size = new System.Drawing.Size(236, 28);
            this.artikulVibor.TabIndex = 1;
            this.artikulVibor.SelectionChangeCommitted += new System.EventHandler(this.artikulVibor_SelectionChangeCommitted);
            // 
            // vozvratDGV
            // 
            this.vozvratDGV.AllowUserToAddRows = false;
            this.vozvratDGV.AllowUserToDeleteRows = false;
            this.vozvratDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vozvratDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artikulVozvrat,
            this.Kolich,
            this.tsenaVozv,
            this.kolVozvrata,
            this.sumaVozv});
            this.vozvratDGV.Location = new System.Drawing.Point(3, 39);
            this.vozvratDGV.Name = "vozvratDGV";
            this.vozvratDGV.Size = new System.Drawing.Size(636, 385);
            this.vozvratDGV.TabIndex = 0;
            this.vozvratDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.vozvratDGV_CellEndEdit);
            // 
            // naitiDGV
            // 
            this.naitiDGV.AllowUserToAddRows = false;
            this.naitiDGV.AllowUserToDeleteRows = false;
            this.naitiDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.naitiDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artikul,
            this.kol,
            this.tsena,
            this.suma,
            this.data});
            this.naitiDGV.Location = new System.Drawing.Point(1, 5);
            this.naitiDGV.Name = "naitiDGV";
            this.naitiDGV.ReadOnly = true;
            this.naitiDGV.Size = new System.Drawing.Size(589, 421);
            this.naitiDGV.TabIndex = 0;
            // 
            // artikul
            // 
            this.artikul.HeaderText = "Артикул";
            this.artikul.Name = "artikul";
            this.artikul.ReadOnly = true;
            this.artikul.Width = 200;
            // 
            // kol
            // 
            this.kol.HeaderText = "Количество";
            this.kol.Name = "kol";
            this.kol.ReadOnly = true;
            this.kol.Width = 120;
            // 
            // tsena
            // 
            this.tsena.HeaderText = "Цена";
            this.tsena.Name = "tsena";
            this.tsena.ReadOnly = true;
            // 
            // suma
            // 
            this.suma.HeaderText = "Сумма";
            this.suma.Name = "suma";
            this.suma.ReadOnly = true;
            // 
            // data
            // 
            this.data.HeaderText = "дата";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.show_all_dataDGV);
            this.panel3.Controls.Add(this.naitiDGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 173);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(592, 426);
            this.panel3.TabIndex = 2;
            // 
            // show_all_dataDGV
            // 
            this.show_all_dataDGV.AllowUserToAddRows = false;
            this.show_all_dataDGV.AllowUserToDeleteRows = false;
            this.show_all_dataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.show_all_dataDGV.Location = new System.Drawing.Point(4, 9);
            this.show_all_dataDGV.Name = "show_all_dataDGV";
            this.show_all_dataDGV.ReadOnly = true;
            this.show_all_dataDGV.Size = new System.Drawing.Size(585, 414);
            this.show_all_dataDGV.TabIndex = 1;
            this.show_all_dataDGV.Visible = false;
            // 
            // artikulVozvrat
            // 
            this.artikulVozvrat.HeaderText = "Артикул";
            this.artikulVozvrat.Name = "artikulVozvrat";
            this.artikulVozvrat.ReadOnly = true;
            this.artikulVozvrat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.artikulVozvrat.Width = 200;
            // 
            // Kolich
            // 
            this.Kolich.HeaderText = "Кол-во";
            this.Kolich.Name = "Kolich";
            this.Kolich.ReadOnly = true;
            // 
            // tsenaVozv
            // 
            this.tsenaVozv.HeaderText = "Цена";
            this.tsenaVozv.Name = "tsenaVozv";
            this.tsenaVozv.ReadOnly = true;
            // 
            // kolVozvrata
            // 
            this.kolVozvrata.HeaderText = "КолВозврата";
            this.kolVozvrata.Name = "kolVozvrata";
            // 
            // sumaVozv
            // 
            this.sumaVozv.HeaderText = "Сумма";
            this.sumaVozv.Name = "sumaVozv";
            this.sumaVozv.ReadOnly = true;
            // 
            // Vozvrat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Vozvrat";
            this.Text = "Возврат";
            this.Load += new System.EventHandler(this.Vozvrat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vozvratDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.naitiDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.show_all_dataDGV)).EndInit();
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
        private System.Windows.Forms.DataGridView naitiDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button zakrit;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikul;
        private System.Windows.Forms.DataGridViewTextBoxColumn kol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsena;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.DataGridView show_all_dataDGV;
        private System.Windows.Forms.ComboBox artikulVibor;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikulVozvrat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolich;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsenaVozv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolVozvrata;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumaVozv;
    }
}