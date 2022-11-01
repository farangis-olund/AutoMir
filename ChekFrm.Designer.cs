
namespace AutoMir2022
{
    partial class ChekFrm
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
            this.sumBtn = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proveritBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nakNomerTxb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пероид с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
            // 
            // dateBigin
            // 
            this.dateBigin.Location = new System.Drawing.Point(110, 17);
            this.dateBigin.Name = "dateBigin";
            this.dateBigin.Size = new System.Drawing.Size(133, 26);
            this.dateBigin.TabIndex = 4;
            this.dateBigin.Value = new System.DateTime(2022, 10, 23, 0, 0, 0, 0);
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(292, 17);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(128, 26);
            this.dateEnd.TabIndex = 5;
            this.dateEnd.Value = new System.DateTime(2022, 10, 20, 0, 0, 0, 0);
            // 
            // sumBtn
            // 
            this.sumBtn.Location = new System.Drawing.Point(556, 14);
            this.sumBtn.Name = "sumBtn";
            this.sumBtn.Size = new System.Drawing.Size(98, 29);
            this.sumBtn.TabIndex = 6;
            this.sumBtn.Text = "Сумма";
            this.sumBtn.UseVisualStyleBackColor = true;
            this.sumBtn.Click += new System.EventHandler(this.sumBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(464, 14);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(86, 29);
            this.reportBtn.TabIndex = 7;
            this.reportBtn.Text = "Отчет";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proveritBtn);
            this.groupBox1.Controls.Add(this.updateBtn);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.nakNomerTxb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(27, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 76);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // proveritBtn
            // 
            this.proveritBtn.Location = new System.Drawing.Point(290, 25);
            this.proveritBtn.Name = "proveritBtn";
            this.proveritBtn.Size = new System.Drawing.Size(102, 28);
            this.proveritBtn.TabIndex = 4;
            this.proveritBtn.Text = "Проверить";
            this.proveritBtn.UseVisualStyleBackColor = true;
            this.proveritBtn.Click += new System.EventHandler(this.proveritBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Enabled = false;
            this.updateBtn.Location = new System.Drawing.Point(464, 25);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(113, 28);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Обновить";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(421, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // nakNomerTxb
            // 
            this.nakNomerTxb.Location = new System.Drawing.Point(170, 27);
            this.nakNomerTxb.Name = "nakNomerTxb";
            this.nakNomerTxb.Size = new System.Drawing.Size(114, 26);
            this.nakNomerTxb.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер накладной";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AutoMir2022.Reports.ChekReportPeriod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 179);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(782, 591);
            this.reportViewer1.TabIndex = 9;
            this.reportViewer1.Visible = false;
            // 
            // ChekFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 633);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.sumBtn);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateBigin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChekFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Контроль чека";
            this.Load += new System.EventHandler(this.ChekFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateBigin;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Button sumBtn;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox nakNomerTxb;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button proveritBtn;
    }
}