
namespace AutoMir2022
{
    partial class OtchetProdazhaTovarov
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.startData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endData = new System.Windows.Forms.DateTimePicker();
            this.roznProsmotr = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.roznOtchet = new System.Windows.Forms.RadioButton();
            this.optProsmotr = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.optOtchet = new System.Windows.Forms.RadioButton();
            this.itogiProdazhiAll = new System.Windows.Forms.RadioButton();
            this.skidkaOtchet = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.protsentProdazhi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.skidka = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.prodazhaProdavtsev = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.prodazhaProdavtsev);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.skidkaOtchet);
            this.panel1.Controls.Add(this.itogiProdazhiAll);
            this.panel1.Controls.Add(this.optOtchet);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.optProsmotr);
            this.panel1.Controls.Add(this.roznOtchet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.roznProsmotr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 652);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.report);
            this.panel2.Controls.Add(this.skidka);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.protsentProdazhi);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.endData);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.startData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(208, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 52);
            this.panel2.TabIndex = 1;
            // 
            // startData
            // 
            this.startData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startData.Location = new System.Drawing.Point(142, 14);
            this.startData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startData.Name = "startData";
            this.startData.Size = new System.Drawing.Size(119, 26);
            this.startData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Начальная дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Конечная дата";
            // 
            // endData
            // 
            this.endData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endData.Location = new System.Drawing.Point(397, 14);
            this.endData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endData.Name = "endData";
            this.endData.Size = new System.Drawing.Size(119, 26);
            this.endData.TabIndex = 2;
            // 
            // roznProsmotr
            // 
            this.roznProsmotr.AutoSize = true;
            this.roznProsmotr.Location = new System.Drawing.Point(19, 81);
            this.roznProsmotr.Name = "roznProsmotr";
            this.roznProsmotr.Size = new System.Drawing.Size(100, 24);
            this.roznProsmotr.TabIndex = 0;
            this.roznProsmotr.TabStop = true;
            this.roznProsmotr.Text = "просмотр";
            this.roznProsmotr.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "ОТЧЁТЫ О ПРОДАЖЕ";
            // 
            // roznOtchet
            // 
            this.roznOtchet.AutoSize = true;
            this.roznOtchet.Location = new System.Drawing.Point(19, 104);
            this.roznOtchet.Name = "roznOtchet";
            this.roznOtchet.Size = new System.Drawing.Size(72, 24);
            this.roznOtchet.TabIndex = 2;
            this.roznOtchet.TabStop = true;
            this.roznOtchet.Text = "отчёт";
            this.roznOtchet.UseVisualStyleBackColor = true;
            // 
            // optProsmotr
            // 
            this.optProsmotr.AutoSize = true;
            this.optProsmotr.Location = new System.Drawing.Point(19, 172);
            this.optProsmotr.Name = "optProsmotr";
            this.optProsmotr.Size = new System.Drawing.Size(100, 24);
            this.optProsmotr.TabIndex = 3;
            this.optProsmotr.TabStop = true;
            this.optProsmotr.Text = "просмотр";
            this.optProsmotr.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Розничная";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(5, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Оптовая";
            // 
            // optOtchet
            // 
            this.optOtchet.AutoSize = true;
            this.optOtchet.Location = new System.Drawing.Point(19, 196);
            this.optOtchet.Name = "optOtchet";
            this.optOtchet.Size = new System.Drawing.Size(72, 24);
            this.optOtchet.TabIndex = 7;
            this.optOtchet.TabStop = true;
            this.optOtchet.Text = "отчёт";
            this.optOtchet.UseVisualStyleBackColor = true;
            // 
            // itogiProdazhiAll
            // 
            this.itogiProdazhiAll.AutoSize = true;
            this.itogiProdazhiAll.Location = new System.Drawing.Point(19, 318);
            this.itogiProdazhiAll.Name = "itogiProdazhiAll";
            this.itogiProdazhiAll.Size = new System.Drawing.Size(150, 24);
            this.itogiProdazhiAll.TabIndex = 8;
            this.itogiProdazhiAll.TabStop = true;
            this.itogiProdazhiAll.Text = "Итоговый отчёт";
            this.itogiProdazhiAll.UseVisualStyleBackColor = true;
            // 
            // skidkaOtchet
            // 
            this.skidkaOtchet.AutoSize = true;
            this.skidkaOtchet.Location = new System.Drawing.Point(19, 348);
            this.skidkaOtchet.Name = "skidkaOtchet";
            this.skidkaOtchet.Size = new System.Drawing.Size(185, 24);
            this.skidkaOtchet.TabIndex = 9;
            this.skidkaOtchet.TabStop = true;
            this.skidkaOtchet.Text = "Скидки и спец. пред.";
            this.skidkaOtchet.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "% от продажи";
            // 
            // protsentProdazhi
            // 
            this.protsentProdazhi.Location = new System.Drawing.Point(654, 12);
            this.protsentProdazhi.Name = "protsentProdazhi";
            this.protsentProdazhi.Size = new System.Drawing.Size(66, 26);
            this.protsentProdazhi.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(731, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "% скидки >=";
            // 
            // skidka
            // 
            this.skidka.Location = new System.Drawing.Point(829, 10);
            this.skidka.Name = "skidka";
            this.skidka.Size = new System.Drawing.Size(66, 26);
            this.skidka.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(4, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 24);
            this.label8.TabIndex = 10;
            this.label8.Text = "По продавцам ";
            // 
            // prodazhaProdavtsev
            // 
            this.prodazhaProdavtsev.AutoSize = true;
            this.prodazhaProdavtsev.Location = new System.Drawing.Point(19, 256);
            this.prodazhaProdavtsev.Name = "prodazhaProdavtsev";
            this.prodazhaProdavtsev.Size = new System.Drawing.Size(100, 24);
            this.prodazhaProdavtsev.TabIndex = 11;
            this.prodazhaProdavtsev.TabStop = true;
            this.prodazhaProdavtsev.Text = "просмотр";
            this.prodazhaProdavtsev.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(4, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "Итоги всех продаж";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(208, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1016, 600);
            this.reportViewer1.TabIndex = 2;
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(911, 8);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(89, 33);
            this.report.TabIndex = 8;
            this.report.Text = "Создать";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // OtchetProdazhaTovarov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 652);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OtchetProdazhaTovarov";
            this.Text = "Отчёт о продаже";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OtchetProdazhaTovarov_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton roznProsmotr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startData;
        private System.Windows.Forms.RadioButton roznOtchet;
        private System.Windows.Forms.RadioButton optOtchet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton optProsmotr;
        private System.Windows.Forms.RadioButton itogiProdazhiAll;
        private System.Windows.Forms.RadioButton skidkaOtchet;
        private System.Windows.Forms.TextBox protsentProdazhi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox skidka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton prodazhaProdavtsev;
        private System.Windows.Forms.Label label8;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button report;
    }
}