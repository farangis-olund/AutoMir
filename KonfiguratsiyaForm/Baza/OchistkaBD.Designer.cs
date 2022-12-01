
namespace AutoMir2022.Konfiguratsiya.Baza
{
    partial class OchistkaBD
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
            this.vozvrat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rasprodazha = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.prikhodTovara = new System.Windows.Forms.CheckBox();
            this.platezhi = new System.Windows.Forms.CheckBox();
            this.otmenaProdazhi = new System.Windows.Forms.CheckBox();
            this.bonusi = new System.Windows.Forms.CheckBox();
            this.obnovTovara = new System.Windows.Forms.CheckBox();
            this.obmenMag = new System.Windows.Forms.CheckBox();
            this.proshVozvrat = new System.Windows.Forms.CheckBox();
            this.prodazha = new System.Windows.Forms.CheckBox();
            this.ochistka = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // vozvrat
            // 
            this.vozvrat.AutoSize = true;
            this.vozvrat.Location = new System.Drawing.Point(17, 109);
            this.vozvrat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vozvrat.Name = "vozvrat";
            this.vozvrat.Size = new System.Drawing.Size(92, 24);
            this.vozvrat.TabIndex = 0;
            this.vozvrat.Text = "Возврат";
            this.vozvrat.UseVisualStyleBackColor = true;
            this.vozvrat.Click += new System.EventHandler(this.vozvrat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rasprodazha);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.prikhodTovara);
            this.groupBox1.Controls.Add(this.platezhi);
            this.groupBox1.Controls.Add(this.otmenaProdazhi);
            this.groupBox1.Controls.Add(this.bonusi);
            this.groupBox1.Controls.Add(this.obnovTovara);
            this.groupBox1.Controls.Add(this.obmenMag);
            this.groupBox1.Controls.Add(this.proshVozvrat);
            this.groupBox1.Controls.Add(this.prodazha);
            this.groupBox1.Controls.Add(this.ochistka);
            this.groupBox1.Controls.Add(this.vozvrat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 592);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таблицы";
            // 
            // rasprodazha
            // 
            this.rasprodazha.AutoSize = true;
            this.rasprodazha.Location = new System.Drawing.Point(17, 379);
            this.rasprodazha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rasprodazha.Name = "rasprodazha";
            this.rasprodazha.Size = new System.Drawing.Size(122, 24);
            this.rasprodazha.TabIndex = 15;
            this.rasprodazha.Text = "Распродажа";
            this.rasprodazha.UseVisualStyleBackColor = true;
            this.rasprodazha.Click += new System.EventHandler(this.rasprodazha_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(17, 27);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(56, 24);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "Всё";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Click += new System.EventHandler(this.checkBox4_Click);
            // 
            // prikhodTovara
            // 
            this.prikhodTovara.AutoSize = true;
            this.prikhodTovara.Location = new System.Drawing.Point(17, 311);
            this.prikhodTovara.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prikhodTovara.Name = "prikhodTovara";
            this.prikhodTovara.Size = new System.Drawing.Size(143, 24);
            this.prikhodTovara.TabIndex = 11;
            this.prikhodTovara.Text = "Приход товара";
            this.prikhodTovara.UseVisualStyleBackColor = true;
            this.prikhodTovara.Click += new System.EventHandler(this.prikhodTovara_Click);
            // 
            // platezhi
            // 
            this.platezhi.AutoSize = true;
            this.platezhi.Location = new System.Drawing.Point(17, 277);
            this.platezhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.platezhi.Name = "platezhi";
            this.platezhi.Size = new System.Drawing.Size(97, 24);
            this.platezhi.TabIndex = 10;
            this.platezhi.Text = "Платежи";
            this.platezhi.UseVisualStyleBackColor = true;
            this.platezhi.Click += new System.EventHandler(this.platezhi_Click);
            // 
            // otmenaProdazhi
            // 
            this.otmenaProdazhi.AutoSize = true;
            this.otmenaProdazhi.Location = new System.Drawing.Point(17, 243);
            this.otmenaProdazhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.otmenaProdazhi.Name = "otmenaProdazhi";
            this.otmenaProdazhi.Size = new System.Drawing.Size(158, 24);
            this.otmenaProdazhi.TabIndex = 9;
            this.otmenaProdazhi.Text = "Отмена продажи";
            this.otmenaProdazhi.UseVisualStyleBackColor = true;
            this.otmenaProdazhi.Click += new System.EventHandler(this.otmenaProdazhi_Click);
            // 
            // bonusi
            // 
            this.bonusi.AutoSize = true;
            this.bonusi.Location = new System.Drawing.Point(17, 345);
            this.bonusi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bonusi.Name = "bonusi";
            this.bonusi.Size = new System.Drawing.Size(83, 24);
            this.bonusi.TabIndex = 8;
            this.bonusi.Text = "Бонусы";
            this.bonusi.UseVisualStyleBackColor = true;
            this.bonusi.Click += new System.EventHandler(this.bonusi_Click);
            // 
            // obnovTovara
            // 
            this.obnovTovara.AutoSize = true;
            this.obnovTovara.Location = new System.Drawing.Point(17, 209);
            this.obnovTovara.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.obnovTovara.Name = "obnovTovara";
            this.obnovTovara.Size = new System.Drawing.Size(148, 24);
            this.obnovTovara.TabIndex = 7;
            this.obnovTovara.Text = "Обнов-е товара";
            this.obnovTovara.UseVisualStyleBackColor = true;
            this.obnovTovara.Click += new System.EventHandler(this.obnovTovara_Click);
            // 
            // obmenMag
            // 
            this.obmenMag.AutoSize = true;
            this.obmenMag.Location = new System.Drawing.Point(17, 177);
            this.obmenMag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.obmenMag.Name = "obmenMag";
            this.obmenMag.Size = new System.Drawing.Size(173, 24);
            this.obmenMag.TabIndex = 5;
            this.obmenMag.Text = "Обмен магазинами";
            this.obmenMag.UseVisualStyleBackColor = true;
            this.obmenMag.Click += new System.EventHandler(this.obmenMag_Click);
            // 
            // proshVozvrat
            // 
            this.proshVozvrat.AutoSize = true;
            this.proshVozvrat.Location = new System.Drawing.Point(17, 143);
            this.proshVozvrat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.proshVozvrat.Name = "proshVozvrat";
            this.proshVozvrat.Size = new System.Drawing.Size(210, 24);
            this.proshVozvrat.TabIndex = 4;
            this.proshVozvrat.Text = "Прошлогодний возврат";
            this.proshVozvrat.UseVisualStyleBackColor = true;
            this.proshVozvrat.Click += new System.EventHandler(this.proshVozvrat_Click);
            // 
            // prodazha
            // 
            this.prodazha.AutoSize = true;
            this.prodazha.Location = new System.Drawing.Point(17, 75);
            this.prodazha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prodazha.Name = "prodazha";
            this.prodazha.Size = new System.Drawing.Size(98, 24);
            this.prodazha.TabIndex = 3;
            this.prodazha.Text = "Продажа";
            this.prodazha.UseVisualStyleBackColor = true;
            this.prodazha.Click += new System.EventHandler(this.prodazha_Click);
            // 
            // ochistka
            // 
            this.ochistka.Location = new System.Drawing.Point(106, 16);
            this.ochistka.Name = "ochistka";
            this.ochistka.Size = new System.Drawing.Size(121, 38);
            this.ochistka.TabIndex = 2;
            this.ochistka.Text = "Очистить";
            this.ochistka.UseVisualStyleBackColor = true;
            this.ochistka.Click += new System.EventHandler(this.ochistka_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(237, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(785, 592);
            this.dataGridView1.TabIndex = 3;
            // 
            // OchistkaBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 592);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OchistkaBD";
            this.Text = "Очистка базы данных";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox vozvrat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ochistka;
        private System.Windows.Forms.CheckBox bonusi;
        private System.Windows.Forms.CheckBox obnovTovara;
        private System.Windows.Forms.CheckBox obmenMag;
        private System.Windows.Forms.CheckBox proshVozvrat;
        private System.Windows.Forms.CheckBox prodazha;
        private System.Windows.Forms.CheckBox prikhodTovara;
        private System.Windows.Forms.CheckBox platezhi;
        private System.Windows.Forms.CheckBox otmenaProdazhi;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox rasprodazha;
    }
}