
namespace AutoMir2022
{
    partial class RaskhodiFrm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.clean = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.sumTjs = new System.Windows.Forms.TextBox();
            this.opis = new System.Windows.Forms.TextBox();
            this.viborPoluchatel = new System.Windows.Forms.ComboBox();
            this.chek = new System.Windows.Forms.Button();
            this.oformits = new System.Windows.Forms.Button();
            this.prodovets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.poluchatel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opisanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaTJS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumaUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTop.Controls.Add(this.clean);
            this.panelTop.Controls.Add(this.add);
            this.panelTop.Controls.Add(this.sumTjs);
            this.panelTop.Controls.Add(this.opis);
            this.panelTop.Controls.Add(this.viborPoluchatel);
            this.panelTop.Controls.Add(this.chek);
            this.panelTop.Controls.Add(this.oformits);
            this.panelTop.Controls.Add(this.prodovets);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(777, 99);
            this.panelTop.TabIndex = 0;
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(673, 67);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(101, 29);
            this.clean.TabIndex = 9;
            this.clean.Text = "Очистить";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(567, 67);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(95, 29);
            this.add.TabIndex = 8;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // sumTjs
            // 
            this.sumTjs.Location = new System.Drawing.Point(449, 69);
            this.sumTjs.Name = "sumTjs";
            this.sumTjs.Size = new System.Drawing.Size(112, 26);
            this.sumTjs.TabIndex = 6;
            // 
            // opis
            // 
            this.opis.Location = new System.Drawing.Point(248, 70);
            this.opis.Name = "opis";
            this.opis.Size = new System.Drawing.Size(196, 26);
            this.opis.TabIndex = 5;
            // 
            // viborPoluchatel
            // 
            this.viborPoluchatel.FormattingEnabled = true;
            this.viborPoluchatel.Location = new System.Drawing.Point(40, 69);
            this.viborPoluchatel.Name = "viborPoluchatel";
            this.viborPoluchatel.Size = new System.Drawing.Size(202, 28);
            this.viborPoluchatel.TabIndex = 4;
            // 
            // chek
            // 
            this.chek.Location = new System.Drawing.Point(561, 7);
            this.chek.Name = "chek";
            this.chek.Size = new System.Drawing.Size(95, 44);
            this.chek.TabIndex = 3;
            this.chek.Text = "Чек";
            this.chek.UseVisualStyleBackColor = true;
            this.chek.Click += new System.EventHandler(this.chek_Click);
            // 
            // oformits
            // 
            this.oformits.Location = new System.Drawing.Point(451, 8);
            this.oformits.Name = "oformits";
            this.oformits.Size = new System.Drawing.Size(104, 44);
            this.oformits.TabIndex = 2;
            this.oformits.Text = "Оформить";
            this.oformits.UseVisualStyleBackColor = true;
            this.oformits.Click += new System.EventHandler(this.oformits_Click);
            // 
            // prodovets
            // 
            this.prodovets.FormattingEnabled = true;
            this.prodovets.Location = new System.Drawing.Point(140, 17);
            this.prodovets.Name = "prodovets";
            this.prodovets.Size = new System.Drawing.Size(163, 28);
            this.prodovets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Расход на имя";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.poluchatel,
            this.opisanie,
            this.sumaTJS,
            this.sumaUSD});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 99);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(777, 325);
            this.dataGridView1.TabIndex = 1;
            // 
            // poluchatel
            // 
            this.poluchatel.HeaderText = "Получатель";
            this.poluchatel.Name = "poluchatel";
            this.poluchatel.ReadOnly = true;
            this.poluchatel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.poluchatel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.poluchatel.Width = 200;
            // 
            // opisanie
            // 
            this.opisanie.HeaderText = "Описание";
            this.opisanie.Name = "opisanie";
            this.opisanie.ReadOnly = true;
            this.opisanie.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.opisanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.opisanie.Width = 200;
            // 
            // sumaTJS
            // 
            this.sumaTJS.HeaderText = "СуммаСМН";
            this.sumaTJS.Name = "sumaTJS";
            this.sumaTJS.ReadOnly = true;
            this.sumaTJS.Width = 120;
            // 
            // sumaUSD
            // 
            this.sumaUSD.HeaderText = "Сумма$";
            this.sumaUSD.Name = "sumaUSD";
            this.sumaUSD.ReadOnly = true;
            // 
            // RaskhodiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 424);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RaskhodiFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расходы";
            this.Load += new System.EventHandler(this.RaskhodiFrm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button chek;
        private System.Windows.Forms.Button oformits;
        private System.Windows.Forms.ComboBox prodovets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn poluchatel;
        private System.Windows.Forms.DataGridViewTextBoxColumn opisanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumaTJS;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumaUSD;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox sumTjs;
        private System.Windows.Forms.TextBox opis;
        private System.Windows.Forms.ComboBox viborPoluchatel;
        private System.Windows.Forms.Button clean;
    }
}