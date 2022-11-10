
namespace AutoMir2022.DobavitTovarIsBDForm
{
    partial class DobavitIsBD
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
            this.export = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateZakaz = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obnovlenieReport = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalReport = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.export);
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateZakaz);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 89);
            this.panel1.TabIndex = 0;
            // 
            // export
            // 
            this.export.Font = new System.Drawing.Font("Liberation Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.export.Location = new System.Drawing.Point(589, 18);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(132, 49);
            this.export.TabIndex = 4;
            this.export.Text = "Экспорт";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // print
            // 
            this.print.Font = new System.Drawing.Font("Liberation Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.print.Location = new System.Drawing.Point(264, 15);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(132, 49);
            this.print.TabIndex = 3;
            this.print.Text = "Печать";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // update
            // 
            this.update.Font = new System.Drawing.Font("Liberation Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.update.Location = new System.Drawing.Point(743, 17);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(132, 49);
            this.update.TabIndex = 2;
            this.update.Text = "Обновить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата";
            // 
            // dateZakaz
            // 
            this.dateZakaz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateZakaz.FormattingEnabled = true;
            this.dateZakaz.Location = new System.Drawing.Point(13, 39);
            this.dateZakaz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateZakaz.Name = "dateZakaz";
            this.dateZakaz.Size = new System.Drawing.Size(134, 28);
            this.dateZakaz.TabIndex = 0;
            this.dateZakaz.SelectionChangeCommitted += new System.EventHandler(this.dateZakaz_SelectionChangeCommitted);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(878, 603);
            this.dataGridView1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(878, 692);
            this.reportViewer1.TabIndex = 2;
            // 
            // obnovlenieReport
            // 
            this.obnovlenieReport.AutoSize = true;
            this.obnovlenieReport.Checked = true;
            this.obnovlenieReport.Location = new System.Drawing.Point(5, 15);
            this.obnovlenieReport.Name = "obnovlenieReport";
            this.obnovlenieReport.Size = new System.Drawing.Size(259, 24);
            this.obnovlenieReport.TabIndex = 5;
            this.obnovlenieReport.TabStop = true;
            this.obnovlenieReport.Text = "Отчет об обновлении товаров";
            this.obnovlenieReport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalReport);
            this.groupBox1.Controls.Add(this.obnovlenieReport);
            this.groupBox1.Controls.Add(this.print);
            this.groupBox1.Location = new System.Drawing.Point(176, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // totalReport
            // 
            this.totalReport.AutoSize = true;
            this.totalReport.Location = new System.Drawing.Point(5, 39);
            this.totalReport.Name = "totalReport";
            this.totalReport.Size = new System.Drawing.Size(150, 24);
            this.totalReport.TabIndex = 6;
            this.totalReport.TabStop = true;
            this.totalReport.Text = "Итоговый отчет";
            this.totalReport.UseVisualStyleBackColor = true;
            // 
            // DobavitIsBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 692);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DobavitIsBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить из БД";
            this.Load += new System.EventHandler(this.DobavitIsBD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dateZakaz;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button update;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton totalReport;
        private System.Windows.Forms.RadioButton obnovlenieReport;
    }
}