﻿
namespace AutoMir2022
{
    partial class OtchetOstatokTovarov
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
            this.minDopusk = new System.Windows.Forms.RadioButton();
            this.neaktivnie = new System.Windows.Forms.RadioButton();
            this.mestoNaSklade = new System.Windows.Forms.RadioButton();
            this.otmena = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.vozvrat = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.ComboBox();
            this.show = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rjad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.otchetParam = new System.Windows.Forms.GroupBox();
            this.neakTovariGroup = new System.Windows.Forms.GroupBox();
            this.brandLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.brand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startPeriod = new System.Windows.Forms.DateTimePicker();
            this.endPeriod = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.kolTov = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.otchetParam.SuspendLayout();
            this.neakTovariGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.minDopusk);
            this.panel1.Controls.Add(this.neaktivnie);
            this.panel1.Controls.Add(this.mestoNaSklade);
            this.panel1.Controls.Add(this.otmena);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.vozvrat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 585);
            this.panel1.TabIndex = 0;
            // 
            // minDopusk
            // 
            this.minDopusk.AutoSize = true;
            this.minDopusk.Location = new System.Drawing.Point(12, 213);
            this.minDopusk.Name = "minDopusk";
            this.minDopusk.Size = new System.Drawing.Size(255, 24);
            this.minDopusk.TabIndex = 5;
            this.minDopusk.TabStop = true;
            this.minDopusk.Text = "по мин.допуск.кол-ве товаров";
            this.minDopusk.UseVisualStyleBackColor = true;
            this.minDopusk.Click += new System.EventHandler(this.minDopusk_Click);
            // 
            // neaktivnie
            // 
            this.neaktivnie.AutoSize = true;
            this.neaktivnie.Location = new System.Drawing.Point(12, 178);
            this.neaktivnie.Name = "neaktivnie";
            this.neaktivnie.Size = new System.Drawing.Size(196, 24);
            this.neaktivnie.TabIndex = 4;
            this.neaktivnie.TabStop = true;
            this.neaktivnie.Text = "о неактивных товаров";
            this.neaktivnie.UseVisualStyleBackColor = true;
            this.neaktivnie.Click += new System.EventHandler(this.neaktivnie_Click);
            // 
            // mestoNaSklade
            // 
            this.mestoNaSklade.AutoSize = true;
            this.mestoNaSklade.Location = new System.Drawing.Point(12, 141);
            this.mestoNaSklade.Name = "mestoNaSklade";
            this.mestoNaSklade.Size = new System.Drawing.Size(174, 24);
            this.mestoNaSklade.TabIndex = 3;
            this.mestoNaSklade.TabStop = true;
            this.mestoNaSklade.Text = "по месту на складе";
            this.mestoNaSklade.UseVisualStyleBackColor = true;
            this.mestoNaSklade.Click += new System.EventHandler(this.mestoNaSklade_Click);
            // 
            // otmena
            // 
            this.otmena.AutoSize = true;
            this.otmena.Location = new System.Drawing.Point(12, 99);
            this.otmena.Name = "otmena";
            this.otmena.Size = new System.Drawing.Size(282, 24);
            this.otmena.TabIndex = 2;
            this.otmena.TabStop = true;
            this.otmena.Text = "о кол-ве товаров отмен-х продаж";
            this.otmena.UseVisualStyleBackColor = true;
            this.otmena.Click += new System.EventHandler(this.otmena_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отчёт:";
            // 
            // vozvrat
            // 
            this.vozvrat.AutoSize = true;
            this.vozvrat.Location = new System.Drawing.Point(12, 58);
            this.vozvrat.Name = "vozvrat";
            this.vozvrat.Size = new System.Drawing.Size(218, 24);
            this.vozvrat.TabIndex = 0;
            this.vozvrat.TabStop = true;
            this.vozvrat.Text = "о возвращенных товаров";
            this.vozvrat.UseVisualStyleBackColor = true;
            this.vozvrat.Click += new System.EventHandler(this.vozvrat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.show);
            this.panel2.Controls.Add(this.neakTovariGroup);
            this.panel2.Controls.Add(this.otchetParam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(293, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 69);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата";
            // 
            // date
            // 
            this.date.FormattingEnabled = true;
            this.date.Location = new System.Drawing.Point(71, 20);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(121, 28);
            this.date.TabIndex = 3;
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(752, 8);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(174, 37);
            this.show.TabIndex = 0;
            this.show.Text = "Показать отчёт";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(297, 72);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(922, 527);
            this.reportViewer1.TabIndex = 3;
            // 
            // sector
            // 
            this.sector.Enabled = false;
            this.sector.FormattingEnabled = true;
            this.sector.Location = new System.Drawing.Point(268, 20);
            this.sector.Name = "sector";
            this.sector.Size = new System.Drawing.Size(91, 28);
            this.sector.TabIndex = 5;
            this.sector.SelectionChangeCommitted += new System.EventHandler(this.sector_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сектор";
            // 
            // rjad
            // 
            this.rjad.Enabled = false;
            this.rjad.FormattingEnabled = true;
            this.rjad.Location = new System.Drawing.Point(420, 20);
            this.rjad.Name = "rjad";
            this.rjad.Size = new System.Drawing.Size(91, 28);
            this.rjad.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ряд";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1248, 585);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // otchetParam
            // 
            this.otchetParam.Controls.Add(this.rjad);
            this.otchetParam.Controls.Add(this.label2);
            this.otchetParam.Controls.Add(this.label3);
            this.otchetParam.Controls.Add(this.date);
            this.otchetParam.Controls.Add(this.label4);
            this.otchetParam.Controls.Add(this.sector);
            this.otchetParam.Location = new System.Drawing.Point(6, 0);
            this.otchetParam.Name = "otchetParam";
            this.otchetParam.Size = new System.Drawing.Size(517, 61);
            this.otchetParam.TabIndex = 9;
            this.otchetParam.TabStop = false;
            // 
            // neakTovariGroup
            // 
            this.neakTovariGroup.Controls.Add(this.kolTov);
            this.neakTovariGroup.Controls.Add(this.label5);
            this.neakTovariGroup.Controls.Add(this.endPeriod);
            this.neakTovariGroup.Controls.Add(this.startPeriod);
            this.neakTovariGroup.Controls.Add(this.brandLabel);
            this.neakTovariGroup.Controls.Add(this.label6);
            this.neakTovariGroup.Controls.Add(this.brand);
            this.neakTovariGroup.Controls.Add(this.label7);
            this.neakTovariGroup.Location = new System.Drawing.Point(6, 0);
            this.neakTovariGroup.Name = "neakTovariGroup";
            this.neakTovariGroup.Size = new System.Drawing.Size(729, 61);
            this.neakTovariGroup.TabIndex = 10;
            this.neakTovariGroup.TabStop = false;
            this.neakTovariGroup.Visible = false;
            // 
            // brandLabel
            // 
            this.brandLabel.AutoSize = true;
            this.brandLabel.Location = new System.Drawing.Point(7, 25);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(58, 20);
            this.brandLabel.TabIndex = 4;
            this.brandLabel.Text = "Бренд";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Нач.Дата";
            // 
            // brand
            // 
            this.brand.FormattingEnabled = true;
            this.brand.Location = new System.Drawing.Point(71, 21);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(121, 28);
            this.brand.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Кон.Дата";
            // 
            // startPeriod
            // 
            this.startPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startPeriod.Location = new System.Drawing.Point(280, 23);
            this.startPeriod.Name = "startPeriod";
            this.startPeriod.Size = new System.Drawing.Size(102, 26);
            this.startPeriod.TabIndex = 9;
            // 
            // endPeriod
            // 
            this.endPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endPeriod.Location = new System.Drawing.Point(474, 22);
            this.endPeriod.Name = "endPeriod";
            this.endPeriod.Size = new System.Drawing.Size(102, 26);
            this.endPeriod.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Кол <=";
            // 
            // kolTov
            // 
            this.kolTov.Location = new System.Drawing.Point(658, 22);
            this.kolTov.Name = "kolTov";
            this.kolTov.Size = new System.Drawing.Size(59, 26);
            this.kolTov.TabIndex = 12;
            // 
            // OtchetOstatokTovarov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OtchetOstatokTovarov";
            this.Text = "Отчёт об остатках товара";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OtchetOstatokTovarov_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.otchetParam.ResumeLayout(false);
            this.otchetParam.PerformLayout();
            this.neakTovariGroup.ResumeLayout(false);
            this.neakTovariGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton neaktivnie;
        private System.Windows.Forms.RadioButton mestoNaSklade;
        private System.Windows.Forms.RadioButton otmena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton vozvrat;
        private System.Windows.Forms.RadioButton minDopusk;
        private System.Windows.Forms.Button show;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox rjad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sector;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox otchetParam;
        private System.Windows.Forms.GroupBox neakTovariGroup;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox brand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kolTov;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endPeriod;
        private System.Windows.Forms.DateTimePicker startPeriod;
    }
}