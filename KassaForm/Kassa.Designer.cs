﻿
namespace AutoMir2022
{
    partial class Kassa
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prodazhaChekBtn = new System.Windows.Forms.Button();
            this.updateProdazhaBtn = new System.Windows.Forms.Button();
            this.pradazhaChek = new System.Windows.Forms.CheckBox();
            this.pradazhaOplCkb = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prodazhaDGV = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artikul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prodazhaNaklCmb = new System.Windows.Forms.ComboBox();
            this.KassaCmb = new System.Windows.Forms.ComboBox();
            this.prodazhaData = new System.Windows.Forms.TextBox();
            this.prodazha = new System.Windows.Forms.Button();
            this.vozvrat = new System.Windows.Forms.Button();
            this.otmena = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodazhaDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.prodazhaChekBtn);
            this.groupBox2.Controls.Add(this.updateProdazhaBtn);
            this.groupBox2.Controls.Add(this.pradazhaChek);
            this.groupBox2.Controls.Add(this.pradazhaOplCkb);
            this.groupBox2.Location = new System.Drawing.Point(311, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 95);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // prodazhaChekBtn
            // 
            this.prodazhaChekBtn.Enabled = false;
            this.prodazhaChekBtn.Location = new System.Drawing.Point(116, 53);
            this.prodazhaChekBtn.Name = "prodazhaChekBtn";
            this.prodazhaChekBtn.Size = new System.Drawing.Size(66, 31);
            this.prodazhaChekBtn.TabIndex = 10;
            this.prodazhaChekBtn.Text = "ОК";
            this.prodazhaChekBtn.UseVisualStyleBackColor = true;
            this.prodazhaChekBtn.Click += new System.EventHandler(this.prodazhaChekBtn_Click);
            // 
            // updateProdazhaBtn
            // 
            this.updateProdazhaBtn.Enabled = false;
            this.updateProdazhaBtn.Location = new System.Drawing.Point(116, 18);
            this.updateProdazhaBtn.Name = "updateProdazhaBtn";
            this.updateProdazhaBtn.Size = new System.Drawing.Size(66, 31);
            this.updateProdazhaBtn.TabIndex = 4;
            this.updateProdazhaBtn.Text = "ОК";
            this.updateProdazhaBtn.UseVisualStyleBackColor = true;
            this.updateProdazhaBtn.Click += new System.EventHandler(this.updateProdazhaBtn_Click);
            // 
            // pradazhaChek
            // 
            this.pradazhaChek.AutoSize = true;
            this.pradazhaChek.Location = new System.Drawing.Point(6, 57);
            this.pradazhaChek.Name = "pradazhaChek";
            this.pradazhaChek.Size = new System.Drawing.Size(57, 24);
            this.pradazhaChek.TabIndex = 9;
            this.pradazhaChek.Text = "Чек";
            this.pradazhaChek.UseVisualStyleBackColor = true;
            // 
            // pradazhaOplCkb
            // 
            this.pradazhaOplCkb.AutoSize = true;
            this.pradazhaOplCkb.Location = new System.Drawing.Point(6, 21);
            this.pradazhaOplCkb.Name = "pradazhaOplCkb";
            this.pradazhaOplCkb.Size = new System.Drawing.Size(104, 24);
            this.pradazhaOplCkb.TabIndex = 8;
            this.pradazhaOplCkb.Text = "Оплачено";
            this.pradazhaOplCkb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Дата";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // prodazhaDGV
            // 
            this.prodazhaDGV.AllowUserToAddRows = false;
            this.prodazhaDGV.AllowUserToDeleteRows = false;
            this.prodazhaDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodazhaDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.artikul,
            this.kolich,
            this.tsena,
            this.suma});
            this.prodazhaDGV.Location = new System.Drawing.Point(11, 126);
            this.prodazhaDGV.Name = "prodazhaDGV";
            this.prodazhaDGV.ReadOnly = true;
            this.prodazhaDGV.Size = new System.Drawing.Size(672, 375);
            this.prodazhaDGV.TabIndex = 6;
            // 
            // date
            // 
            this.date.HeaderText = "дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Visible = false;
            // 
            // artikul
            // 
            this.artikul.HeaderText = "Артикул";
            this.artikul.Name = "artikul";
            this.artikul.ReadOnly = true;
            this.artikul.Width = 250;
            // 
            // kolich
            // 
            this.kolich.HeaderText = "Количество";
            this.kolich.Name = "kolich";
            this.kolich.ReadOnly = true;
            this.kolich.Width = 120;
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
            this.suma.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.prodazhaNaklCmb);
            this.groupBox1.Controls.Add(this.KassaCmb);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(11, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "№ Платежной";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "№ Накладной";
            // 
            // prodazhaNaklCmb
            // 
            this.prodazhaNaklCmb.FormattingEnabled = true;
            this.prodazhaNaklCmb.Location = new System.Drawing.Point(126, 18);
            this.prodazhaNaklCmb.Name = "prodazhaNaklCmb";
            this.prodazhaNaklCmb.Size = new System.Drawing.Size(136, 28);
            this.prodazhaNaklCmb.TabIndex = 0;
            this.prodazhaNaklCmb.SelectionChangeCommitted += new System.EventHandler(this.prodazhaNaklCmb_SelectionChangeCommitted);
            // 
            // KassaCmb
            // 
            this.KassaCmb.FormattingEnabled = true;
            this.KassaCmb.Location = new System.Drawing.Point(126, 55);
            this.KassaCmb.Name = "KassaCmb";
            this.KassaCmb.Size = new System.Drawing.Size(136, 28);
            this.KassaCmb.TabIndex = 1;
            this.KassaCmb.SelectionChangeCommitted += new System.EventHandler(this.KassaCmb_SelectionChangeCommitted);
            // 
            // prodazhaData
            // 
            this.prodazhaData.Location = new System.Drawing.Point(512, 88);
            this.prodazhaData.Name = "prodazhaData";
            this.prodazhaData.ReadOnly = true;
            this.prodazhaData.Size = new System.Drawing.Size(171, 26);
            this.prodazhaData.TabIndex = 2;
            this.prodazhaData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prodazha
            // 
            this.prodazha.BackColor = System.Drawing.SystemColors.Info;
            this.prodazha.Location = new System.Drawing.Point(13, 22);
            this.prodazha.Name = "prodazha";
            this.prodazha.Size = new System.Drawing.Size(231, 49);
            this.prodazha.TabIndex = 10;
            this.prodazha.Text = "ПРАДАЖА";
            this.prodazha.UseVisualStyleBackColor = false;
            this.prodazha.Click += new System.EventHandler(this.prodazha_Click);
            // 
            // vozvrat
            // 
            this.vozvrat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.vozvrat.Location = new System.Drawing.Point(250, 22);
            this.vozvrat.Name = "vozvrat";
            this.vozvrat.Size = new System.Drawing.Size(233, 49);
            this.vozvrat.TabIndex = 11;
            this.vozvrat.Text = "ВОЗВРАТ";
            this.vozvrat.UseVisualStyleBackColor = false;
            this.vozvrat.Click += new System.EventHandler(this.vozvrat_Click);
            // 
            // otmena
            // 
            this.otmena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.otmena.Location = new System.Drawing.Point(492, 22);
            this.otmena.Name = "otmena";
            this.otmena.Size = new System.Drawing.Size(219, 49);
            this.otmena.TabIndex = 12;
            this.otmena.Text = "ОТМЕНА";
            this.otmena.UseVisualStyleBackColor = false;
            this.otmena.Click += new System.EventHandler(this.otmena_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.prodazhaDGV);
            this.groupBox3.Controls.Add(this.prodazhaData);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 507);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // Kassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 607);
            this.Controls.Add(this.otmena);
            this.Controls.Add(this.vozvrat);
            this.Controls.Add(this.prodazha);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Kassa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Касса";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodazhaDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox prodazhaData;
        private System.Windows.Forms.ComboBox KassaCmb;
        private System.Windows.Forms.ComboBox prodazhaNaklCmb;
        private System.Windows.Forms.DataGridView prodazhaDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox pradazhaChek;
        private System.Windows.Forms.CheckBox pradazhaOplCkb;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikul;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolich;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsena;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.Button updateProdazhaBtn;
        private System.Windows.Forms.Button prodazhaChekBtn;
        private System.Windows.Forms.Button prodazha;
        private System.Windows.Forms.Button vozvrat;
        private System.Windows.Forms.Button otmena;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}