
namespace AutoMir2022
{
    partial class ItogiOptProdazhi
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateBigin = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.reportBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kodKlienta = new System.Windows.Forms.ComboBox();
            this.vseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = " с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
            // 
            // dateBigin
            // 
            this.dateBigin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBigin.Location = new System.Drawing.Point(30, 23);
            this.dateBigin.Name = "dateBigin";
            this.dateBigin.Size = new System.Drawing.Size(133, 26);
            this.dateBigin.TabIndex = 4;
            this.dateBigin.Value = new System.DateTime(2022, 10, 23, 0, 0, 0, 0);
            // 
            // dateEnd
            // 
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(218, 23);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(128, 26);
            this.dateEnd.TabIndex = 5;
            this.dateEnd.Value = new System.DateTime(2022, 10, 20, 0, 0, 0, 0);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(365, 14);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(96, 39);
            this.reportBtn.TabIndex = 7;
            this.reportBtn.Text = "Отчет";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kodKlienta);
            this.groupBox1.Controls.Add(this.vseBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 58);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клиент";
            // 
            // kodKlienta
            // 
            this.kodKlienta.FormattingEnabled = true;
            this.kodKlienta.Location = new System.Drawing.Point(59, 19);
            this.kodKlienta.Name = "kodKlienta";
            this.kodKlienta.Size = new System.Drawing.Size(106, 28);
            this.kodKlienta.Sorted = true;
            this.kodKlienta.TabIndex = 5;
            this.kodKlienta.SelectionChangeCommitted += new System.EventHandler(this.kodKlienta_SelectionChangeCommitted);
            // 
            // vseBtn
            // 
            this.vseBtn.Location = new System.Drawing.Point(189, 14);
            this.vseBtn.Name = "vseBtn";
            this.vseBtn.Size = new System.Drawing.Size(143, 37);
            this.vseBtn.TabIndex = 4;
            this.vseBtn.Text = "Все клиенты";
            this.vseBtn.UseVisualStyleBackColor = true;
            this.vseBtn.Click += new System.EventHandler(this.vseBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Код";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AutoMir2022.Reports.ChekReportPeriod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 89);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(826, 504);
            this.reportViewer1.TabIndex = 9;
            this.reportViewer1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateBigin);
            this.groupBox2.Controls.Add(this.dateEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.reportBtn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(371, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 58);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Период";
            // 
            // ItogiOptProdazhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(850, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItogiOptProdazhi";
            this.Text = "Итоги продажи";
            this.Load += new System.EventHandler(this.ChekFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateBigin;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button vseBtn;
        private System.Windows.Forms.ComboBox kodKlienta;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}