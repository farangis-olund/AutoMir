
namespace AutoMir2022
{
    partial class Rasprodazha
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
            this.save_bonus = new System.Windows.Forms.Button();
            this.create_bonus = new System.Windows.Forms.Button();
            this.change_rasprodazha = new System.Windows.Forms.Button();
            this.create_rashprodazha = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.protsBonusa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uslovieValue = new System.Windows.Forms.TextBox();
            this.uslovie = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.save_bonus);
            this.panel1.Controls.Add(this.create_bonus);
            this.panel1.Controls.Add(this.change_rasprodazha);
            this.panel1.Controls.Add(this.create_rashprodazha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 51);
            this.panel1.TabIndex = 0;
            // 
            // save_bonus
            // 
            this.save_bonus.Location = new System.Drawing.Point(925, 7);
            this.save_bonus.Name = "save_bonus";
            this.save_bonus.Size = new System.Drawing.Size(252, 38);
            this.save_bonus.TabIndex = 3;
            this.save_bonus.Text = "Сохранить данные о бонусе";
            this.save_bonus.UseVisualStyleBackColor = true;
            this.save_bonus.Click += new System.EventHandler(this.save_bonus_Click);
            // 
            // create_bonus
            // 
            this.create_bonus.Location = new System.Drawing.Point(698, 7);
            this.create_bonus.Name = "create_bonus";
            this.create_bonus.Size = new System.Drawing.Size(228, 38);
            this.create_bonus.TabIndex = 2;
            this.create_bonus.Text = "Создать отчёт о бонусе";
            this.create_bonus.UseVisualStyleBackColor = true;
            this.create_bonus.Click += new System.EventHandler(this.create_bonus_Click);
            // 
            // change_rasprodazha
            // 
            this.change_rasprodazha.Location = new System.Drawing.Point(444, 7);
            this.change_rasprodazha.Name = "change_rasprodazha";
            this.change_rasprodazha.Size = new System.Drawing.Size(255, 38);
            this.change_rasprodazha.TabIndex = 1;
            this.change_rasprodazha.Text = "Изменить список распродаж";
            this.change_rasprodazha.UseVisualStyleBackColor = true;
            this.change_rasprodazha.Click += new System.EventHandler(this.change_rasprodazha_Click);
            // 
            // create_rashprodazha
            // 
            this.create_rashprodazha.Location = new System.Drawing.Point(182, 7);
            this.create_rashprodazha.Name = "create_rashprodazha";
            this.create_rashprodazha.Size = new System.Drawing.Size(263, 38);
            this.create_rashprodazha.TabIndex = 0;
            this.create_rashprodazha.Text = "Создать список распродаж";
            this.create_rashprodazha.UseVisualStyleBackColor = true;
            this.create_rashprodazha.Click += new System.EventHandler(this.create_rashprodazha_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.dateLabel);
            this.panel2.Controls.Add(this.protsBonusa);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.endDate);
            this.panel2.Controls.Add(this.startDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.uslovieValue);
            this.panel2.Controls.Add(this.uslovie);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 619);
            this.panel2.TabIndex = 1;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.dateLabel.Location = new System.Drawing.Point(6, 189);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(109, 20);
            this.dateLabel.TabIndex = 14;
            this.dateLabel.Text = "Обновлен до";
            // 
            // protsBonusa
            // 
            this.protsBonusa.Location = new System.Drawing.Point(94, 227);
            this.protsBonusa.Name = "protsBonusa";
            this.protsBonusa.Size = new System.Drawing.Size(60, 26);
            this.protsBonusa.TabIndex = 13;
            this.protsBonusa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "% Бонуса:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "по";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "с";
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(40, 341);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(119, 26);
            this.endDate.TabIndex = 9;
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(41, 304);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(119, 26);
            this.startDate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Период:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(5, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Обновлен до";
            // 
            // uslovieValue
            // 
            this.uslovieValue.Location = new System.Drawing.Point(71, 80);
            this.uslovieValue.Name = "uslovieValue";
            this.uslovieValue.Size = new System.Drawing.Size(60, 26);
            this.uslovieValue.TabIndex = 4;
            // 
            // uslovie
            // 
            this.uslovie.FormattingEnabled = true;
            this.uslovie.Items.AddRange(new object[] {
            "=",
            "<="});
            this.uslovie.Location = new System.Drawing.Point(7, 80);
            this.uslovie.Name = "uslovie";
            this.uslovie.Size = new System.Drawing.Size(57, 28);
            this.uslovie.TabIndex = 3;
            this.uslovie.SelectionChangeCommitted += new System.EventHandler(this.uslovie_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Условие:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "БОНУСЫ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "РАСПРОДАЖА";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(184, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(995, 619);
            this.reportViewer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(184, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(995, 619);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Rasprodazha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 670);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Rasprodazha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распродажа и бонусы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rasprodazha_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uslovieValue;
        private System.Windows.Forms.ComboBox uslovie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button change_rasprodazha;
        private System.Windows.Forms.Button create_rashprodazha;
        private System.Windows.Forms.Button save_bonus;
        private System.Windows.Forms.Button create_bonus;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox protsBonusa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dateLabel;
    }
}