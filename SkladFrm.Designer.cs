
namespace AutoMir2022
{
    partial class SkladFrm
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
            this.NomerNakladnoyCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.show = new System.Windows.Forms.Button();
            this.oplachenoChk = new System.Windows.Forms.CheckBox();
            this.SkladChek = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataTxt = new System.Windows.Forms.TextBox();
            this.Datapanel = new System.Windows.Forms.Panel();
            this.skladDGV = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oplacheno = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.artikul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naimenovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.Datapanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skladDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // NomerNakladnoyCmb
            // 
            this.NomerNakladnoyCmb.FormattingEnabled = true;
            this.NomerNakladnoyCmb.Location = new System.Drawing.Point(13, 64);
            this.NomerNakladnoyCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NomerNakladnoyCmb.Name = "NomerNakladnoyCmb";
            this.NomerNakladnoyCmb.Size = new System.Drawing.Size(150, 28);
            this.NomerNakladnoyCmb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Накладной №";
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.TopPanel.Controls.Add(this.button1);
            this.TopPanel.Controls.Add(this.show);
            this.TopPanel.Controls.Add(this.oplachenoChk);
            this.TopPanel.Controls.Add(this.SkladChek);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.DataTxt);
            this.TopPanel.Controls.Add(this.NomerNakladnoyCmb);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(733, 107);
            this.TopPanel.TabIndex = 2;
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(170, 62);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(92, 30);
            this.show.TabIndex = 6;
            this.show.Text = "Показать";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.ViborNakl_Click);
            // 
            // oplachenoChk
            // 
            this.oplachenoChk.AutoSize = true;
            this.oplachenoChk.Enabled = false;
            this.oplachenoChk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.oplachenoChk.Location = new System.Drawing.Point(473, 68);
            this.oplachenoChk.Name = "oplachenoChk";
            this.oplachenoChk.Size = new System.Drawing.Size(141, 24);
            this.oplachenoChk.TabIndex = 5;
            this.oplachenoChk.Text = "Заказ оплачен";
            this.oplachenoChk.UseVisualStyleBackColor = true;
            // 
            // SkladChek
            // 
            this.SkladChek.AutoSize = true;
            this.SkladChek.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SkladChek.Location = new System.Drawing.Point(634, 68);
            this.SkladChek.Name = "SkladChek";
            this.SkladChek.Size = new System.Drawing.Size(77, 24);
            this.SkladChek.TabIndex = 4;
            this.SkladChek.Text = "Склад";
            this.SkladChek.UseVisualStyleBackColor = true;
            this.SkladChek.Click += new System.EventHandler(this.ViborSklad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(315, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата заказа";
            // 
            // DataTxt
            // 
            this.DataTxt.Location = new System.Drawing.Point(319, 66);
            this.DataTxt.Name = "DataTxt";
            this.DataTxt.ReadOnly = true;
            this.DataTxt.Size = new System.Drawing.Size(134, 26);
            this.DataTxt.TabIndex = 2;
            // 
            // Datapanel
            // 
            this.Datapanel.Controls.Add(this.skladDGV);
            this.Datapanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Datapanel.Location = new System.Drawing.Point(0, 107);
            this.Datapanel.Name = "Datapanel";
            this.Datapanel.Size = new System.Drawing.Size(733, 462);
            this.Datapanel.TabIndex = 3;
            // 
            // skladDGV
            // 
            this.skladDGV.AllowUserToAddRows = false;
            this.skladDGV.AllowUserToDeleteRows = false;
            this.skladDGV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.skladDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skladDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skladDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.data,
            this.oplacheno,
            this.artikul,
            this.naimenovanie,
            this.suma});
            this.skladDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skladDGV.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.skladDGV.Location = new System.Drawing.Point(0, 0);
            this.skladDGV.Name = "skladDGV";
            this.skladDGV.ReadOnly = true;
            this.skladDGV.Size = new System.Drawing.Size(733, 462);
            this.skladDGV.TabIndex = 0;
            // 
            // data
            // 
            this.data.HeaderText = "дата";
            this.data.Name = "data";
            this.data.Visible = false;
            // 
            // oplacheno
            // 
            this.oplacheno.HeaderText = "оплачено";
            this.oplacheno.Name = "oplacheno";
            this.oplacheno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.oplacheno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.oplacheno.Visible = false;
            // 
            // artikul
            // 
            this.artikul.HeaderText = "артикул";
            this.artikul.Name = "artikul";
            this.artikul.Width = 200;
            // 
            // naimenovanie
            // 
            this.naimenovanie.HeaderText = "наименование";
            this.naimenovanie.Name = "naimenovanie";
            this.naimenovanie.Width = 350;
            // 
            // suma
            // 
            this.suma.HeaderText = "сумма";
            this.suma.Name = "suma";
            this.suma.Width = 140;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SkladFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 569);
            this.Controls.Add(this.Datapanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SkladFrm";
            this.Text = "Склад";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.Datapanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skladDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox NomerNakladnoyCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataTxt;
        private System.Windows.Forms.Panel Datapanel;
        private System.Windows.Forms.DataGridView skladDGV;
        private System.Windows.Forms.CheckBox oplachenoChk;
        private System.Windows.Forms.CheckBox SkladChek;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oplacheno;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikul;
        private System.Windows.Forms.DataGridViewTextBoxColumn naimenovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.Button button1;
    }
}