
namespace AutoMir2022
{
    partial class PriyomSdachaTovaraFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kodMagazina = new System.Windows.Forms.ComboBox();
            this.sdacha = new System.Windows.Forms.RadioButton();
            this.priyom = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pogashenie = new System.Windows.Forms.RadioButton();
            this.postuplenie = new System.Windows.Forms.RadioButton();
            this.chek = new System.Windows.Forms.Button();
            this.oformit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vibor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.artikul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naimenovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolichestvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postuplenieTovara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zadavaemoeKolichestvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artikulVibor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.kodMagazina);
            this.groupBox1.Controls.Add(this.sdacha);
            this.groupBox1.Controls.Add(this.priyom);
            this.groupBox1.Location = new System.Drawing.Point(20, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(323, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "С (для) какого магазина";
            // 
            // kodMagazina
            // 
            this.kodMagazina.FormattingEnabled = true;
            this.kodMagazina.Location = new System.Drawing.Point(121, 55);
            this.kodMagazina.Name = "kodMagazina";
            this.kodMagazina.Size = new System.Drawing.Size(118, 28);
            this.kodMagazina.TabIndex = 2;
            // 
            // sdacha
            // 
            this.sdacha.AutoSize = true;
            this.sdacha.Location = new System.Drawing.Point(12, 63);
            this.sdacha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sdacha.Name = "sdacha";
            this.sdacha.Size = new System.Drawing.Size(84, 24);
            this.sdacha.TabIndex = 1;
            this.sdacha.TabStop = true;
            this.sdacha.Text = "СДАЧА";
            this.sdacha.UseVisualStyleBackColor = true;
            this.sdacha.Click += new System.EventHandler(this.sdacha_Click);
            // 
            // priyom
            // 
            this.priyom.AutoSize = true;
            this.priyom.Location = new System.Drawing.Point(12, 24);
            this.priyom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.priyom.Name = "priyom";
            this.priyom.Size = new System.Drawing.Size(84, 24);
            this.priyom.TabIndex = 0;
            this.priyom.TabStop = true;
            this.priyom.Text = "ПРИЁМ";
            this.priyom.UseVisualStyleBackColor = true;
            this.priyom.Click += new System.EventHandler(this.priyom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pogashenie);
            this.groupBox2.Controls.Add(this.postuplenie);
            this.groupBox2.Location = new System.Drawing.Point(351, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(160, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // pogashenie
            // 
            this.pogashenie.AutoSize = true;
            this.pogashenie.Location = new System.Drawing.Point(12, 63);
            this.pogashenie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pogashenie.Name = "pogashenie";
            this.pogashenie.Size = new System.Drawing.Size(113, 24);
            this.pogashenie.TabIndex = 1;
            this.pogashenie.TabStop = true;
            this.pogashenie.Text = "Погащение";
            this.pogashenie.UseVisualStyleBackColor = true;
            this.pogashenie.Click += new System.EventHandler(this.pogashenie_Click);
            // 
            // postuplenie
            // 
            this.postuplenie.AutoSize = true;
            this.postuplenie.Location = new System.Drawing.Point(12, 24);
            this.postuplenie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.postuplenie.Name = "postuplenie";
            this.postuplenie.Size = new System.Drawing.Size(127, 24);
            this.postuplenie.TabIndex = 0;
            this.postuplenie.TabStop = true;
            this.postuplenie.Text = "Поступление";
            this.postuplenie.UseVisualStyleBackColor = true;
            this.postuplenie.Click += new System.EventHandler(this.postuplenie_Click);
            // 
            // chek
            // 
            this.chek.Location = new System.Drawing.Point(534, 65);
            this.chek.Name = "chek";
            this.chek.Size = new System.Drawing.Size(116, 39);
            this.chek.TabIndex = 3;
            this.chek.Text = "Чек";
            this.chek.UseVisualStyleBackColor = true;
            this.chek.Click += new System.EventHandler(this.chek_Click);
            // 
            // oformit
            // 
            this.oformit.Location = new System.Drawing.Point(534, 21);
            this.oformit.Name = "oformit";
            this.oformit.Size = new System.Drawing.Size(116, 39);
            this.oformit.TabIndex = 2;
            this.oformit.Text = "Оформить";
            this.oformit.UseVisualStyleBackColor = true;
            this.oformit.Click += new System.EventHandler(this.oformit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vibor,
            this.artikul,
            this.naimenovanie,
            this.brand,
            this.marka,
            this.kolichestvo,
            this.postuplenieTovara,
            this.zadavaemoeKolichestvo,
            this.mesto});
            this.dataGridView1.Location = new System.Drawing.Point(20, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(963, 481);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // vibor
            // 
            this.vibor.HeaderText = "";
            this.vibor.Name = "vibor";
            this.vibor.Width = 30;
            // 
            // artikul
            // 
            this.artikul.HeaderText = "Артикул";
            this.artikul.Name = "artikul";
            this.artikul.ReadOnly = true;
            // 
            // naimenovanie
            // 
            this.naimenovanie.HeaderText = "Наименование";
            this.naimenovanie.Name = "naimenovanie";
            this.naimenovanie.ReadOnly = true;
            this.naimenovanie.Width = 160;
            // 
            // brand
            // 
            this.brand.HeaderText = "Бренд";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // marka
            // 
            this.marka.HeaderText = "Марка";
            this.marka.Name = "marka";
            this.marka.ReadOnly = true;
            // 
            // kolichestvo
            // 
            this.kolichestvo.HeaderText = "Склад";
            this.kolichestvo.Name = "kolichestvo";
            this.kolichestvo.ReadOnly = true;
            // 
            // postuplenieTovara
            // 
            this.postuplenieTovara.HeaderText = "Долг";
            this.postuplenieTovara.Name = "postuplenieTovara";
            // 
            // zadavaemoeKolichestvo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.zadavaemoeKolichestvo.DefaultCellStyle = dataGridViewCellStyle1;
            this.zadavaemoeKolichestvo.HeaderText = "Кол-во";
            this.zadavaemoeKolichestvo.Name = "zadavaemoeKolichestvo";
            // 
            // mesto
            // 
            this.mesto.HeaderText = "Место";
            this.mesto.Name = "mesto";
            this.mesto.ReadOnly = true;
            // 
            // artikulVibor
            // 
            this.artikulVibor.DropDownHeight = 85;
            this.artikulVibor.Enabled = false;
            this.artikulVibor.FormattingEnabled = true;
            this.artikulVibor.IntegralHeight = false;
            this.artikulVibor.Location = new System.Drawing.Point(54, 130);
            this.artikulVibor.Name = "artikulVibor";
            this.artikulVibor.Size = new System.Drawing.Size(177, 28);
            this.artikulVibor.TabIndex = 3;
            this.artikulVibor.SelectionChangeCommitted += new System.EventHandler(this.artikul_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ар";
            // 
            // PriyomSdachaTovaraFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 659);
            this.Controls.Add(this.chek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oformit);
            this.Controls.Add(this.artikulVibor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PriyomSdachaTovaraFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прием и сдача товаров между магазинами";
            this.Load += new System.EventHandler(this.PriyomSdachaTovaraFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox kodMagazina;
        private System.Windows.Forms.RadioButton sdacha;
        private System.Windows.Forms.RadioButton priyom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton pogashenie;
        private System.Windows.Forms.RadioButton postuplenie;
        private System.Windows.Forms.Button chek;
        private System.Windows.Forms.Button oformit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox artikulVibor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vibor;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikul;
        private System.Windows.Forms.DataGridViewTextBoxColumn naimenovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn marka;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolichestvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn postuplenieTovara;
        private System.Windows.Forms.DataGridViewTextBoxColumn zadavaemoeKolichestvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesto;
    }
}