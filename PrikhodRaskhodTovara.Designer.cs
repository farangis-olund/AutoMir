
namespace AutoMir2022
{
    partial class PrikhodRaskhodTovara
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.prikhodBtn = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.neoprikhodBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.spisokIzmeneniyDGV = new System.Windows.Forms.DataGridView();
            this.print = new System.Windows.Forms.Button();
            this.zadolzhnostBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.raskhodRb = new System.Windows.Forms.RadioButton();
            this.prikhodRb = new System.Windows.Forms.RadioButton();
            this.kolTovara = new System.Windows.Forms.TextBox();
            this.kolIzmeneniy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.artikul = new System.Windows.Forms.ComboBox();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.tovarDGV = new System.Windows.Forms.DataGridView();
            this.artikulIzmen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikhRaskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateVibor = new System.Windows.Forms.DateTimePicker();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spisokIzmeneniyDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tovarDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // prikhodBtn
            // 
            this.prikhodBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prikhodBtn.Location = new System.Drawing.Point(9, 141);
            this.prikhodBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prikhodBtn.Name = "prikhodBtn";
            this.prikhodBtn.Size = new System.Drawing.Size(151, 45);
            this.prikhodBtn.TabIndex = 0;
            this.prikhodBtn.Text = "Приход из Excel";
            this.prikhodBtn.UseVisualStyleBackColor = true;
            this.prikhodBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.groupBox2);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.spisokIzmeneniyDGV);
            this.topPanel.Controls.Add(this.print);
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Controls.Add(this.prikhodBtn);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1033, 206);
            this.topPanel.TabIndex = 1;
            // 
            // neoprikhodBtn
            // 
            this.neoprikhodBtn.Enabled = false;
            this.neoprikhodBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.neoprikhodBtn.Location = new System.Drawing.Point(461, 16);
            this.neoprikhodBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.neoprikhodBtn.Name = "neoprikhodBtn";
            this.neoprikhodBtn.Size = new System.Drawing.Size(190, 45);
            this.neoprikhodBtn.TabIndex = 6;
            this.neoprikhodBtn.Text = "Неоприход-е товары";
            this.neoprikhodBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Список изменений";
            // 
            // spisokIzmeneniyDGV
            // 
            this.spisokIzmeneniyDGV.AllowUserToAddRows = false;
            this.spisokIzmeneniyDGV.AllowUserToDeleteRows = false;
            this.spisokIzmeneniyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spisokIzmeneniyDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artikulIzmen,
            this.kol,
            this.prikhRaskh,
            this.itog});
            this.spisokIzmeneniyDGV.Location = new System.Drawing.Point(517, 28);
            this.spisokIzmeneniyDGV.Name = "spisokIzmeneniyDGV";
            this.spisokIzmeneniyDGV.ReadOnly = true;
            this.spisokIzmeneniyDGV.Size = new System.Drawing.Size(489, 95);
            this.spisokIzmeneniyDGV.TabIndex = 4;
            // 
            // print
            // 
            this.print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.print.Location = new System.Drawing.Point(890, 141);
            this.print.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(116, 45);
            this.print.TabIndex = 3;
            this.print.Text = "Печать";
            this.print.UseVisualStyleBackColor = true;
            // 
            // zadolzhnostBtn
            // 
            this.zadolzhnostBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zadolzhnostBtn.Location = new System.Drawing.Point(194, 16);
            this.zadolzhnostBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zadolzhnostBtn.Name = "zadolzhnostBtn";
            this.zadolzhnostBtn.Size = new System.Drawing.Size(259, 45);
            this.zadolzhnostBtn.TabIndex = 2;
            this.zadolzhnostBtn.Text = "Погашение долгов из Excel";
            this.zadolzhnostBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.raskhodRb);
            this.groupBox1.Controls.Add(this.prikhodRb);
            this.groupBox1.Controls.Add(this.kolTovara);
            this.groupBox1.Controls.Add(this.kolIzmeneniy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.artikul);
            this.groupBox1.Location = new System.Drawing.Point(9, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "приход-расход";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Кол-во в БД";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кол-во";
            // 
            // raskhodRb
            // 
            this.raskhodRb.AutoSize = true;
            this.raskhodRb.Location = new System.Drawing.Point(19, 58);
            this.raskhodRb.Name = "raskhodRb";
            this.raskhodRb.Size = new System.Drawing.Size(80, 24);
            this.raskhodRb.TabIndex = 5;
            this.raskhodRb.TabStop = true;
            this.raskhodRb.Text = "расход";
            this.raskhodRb.UseVisualStyleBackColor = true;
            // 
            // prikhodRb
            // 
            this.prikhodRb.AutoSize = true;
            this.prikhodRb.Location = new System.Drawing.Point(19, 28);
            this.prikhodRb.Name = "prikhodRb";
            this.prikhodRb.Size = new System.Drawing.Size(81, 24);
            this.prikhodRb.TabIndex = 4;
            this.prikhodRb.TabStop = true;
            this.prikhodRb.Text = "приход";
            this.prikhodRb.UseVisualStyleBackColor = true;
            // 
            // kolTovara
            // 
            this.kolTovara.Location = new System.Drawing.Point(409, 42);
            this.kolTovara.Name = "kolTovara";
            this.kolTovara.ReadOnly = true;
            this.kolTovara.Size = new System.Drawing.Size(70, 26);
            this.kolTovara.TabIndex = 3;
            // 
            // kolIzmeneniy
            // 
            this.kolIzmeneniy.Location = new System.Drawing.Point(332, 42);
            this.kolIzmeneniy.Name = "kolIzmeneniy";
            this.kolIzmeneniy.Size = new System.Drawing.Size(65, 26);
            this.kolIzmeneniy.TabIndex = 2;
            this.kolIzmeneniy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.kolIzmeneniy_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ар";
            // 
            // artikul
            // 
            this.artikul.FormattingEnabled = true;
            this.artikul.Location = new System.Drawing.Point(156, 42);
            this.artikul.Name = "artikul";
            this.artikul.Size = new System.Drawing.Size(161, 28);
            this.artikul.TabIndex = 0;
            this.artikul.SelectionChangeCommitted += new System.EventHandler(this.artikul_SelectionChangeCommitted);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.tovarDGV);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 206);
            this.dataPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(1033, 486);
            this.dataPanel.TabIndex = 2;
            // 
            // tovarDGV
            // 
            this.tovarDGV.AllowUserToAddRows = false;
            this.tovarDGV.AllowUserToDeleteRows = false;
            this.tovarDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tovarDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tovarDGV.Location = new System.Drawing.Point(0, 0);
            this.tovarDGV.Name = "tovarDGV";
            this.tovarDGV.ReadOnly = true;
            this.tovarDGV.Size = new System.Drawing.Size(1033, 486);
            this.tovarDGV.TabIndex = 1;
            // 
            // artikulIzmen
            // 
            this.artikulIzmen.HeaderText = "артикул";
            this.artikulIzmen.Name = "artikulIzmen";
            this.artikulIzmen.ReadOnly = true;
            this.artikulIzmen.Width = 130;
            // 
            // kol
            // 
            this.kol.HeaderText = "кол-во";
            this.kol.Name = "kol";
            this.kol.ReadOnly = true;
            // 
            // prikhRaskh
            // 
            this.prikhRaskh.HeaderText = "прих/расх";
            this.prikhRaskh.Name = "prikhRaskh";
            this.prikhRaskh.ReadOnly = true;
            // 
            // itog
            // 
            this.itog.HeaderText = "итого";
            this.itog.Name = "itog";
            this.itog.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateVibor);
            this.groupBox2.Controls.Add(this.neoprikhodBtn);
            this.groupBox2.Controls.Add(this.zadolzhnostBtn);
            this.groupBox2.Location = new System.Drawing.Point(177, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dateVibor
            // 
            this.dateVibor.Location = new System.Drawing.Point(26, 25);
            this.dateVibor.Name = "dateVibor";
            this.dateVibor.Size = new System.Drawing.Size(152, 26);
            this.dateVibor.TabIndex = 0;
            // 
            // PrikhodRaskhodTovara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 692);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrikhodRaskhodTovara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приход-расход товаров";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spisokIzmeneniyDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tovarDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button prikhodBtn;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton raskhodRb;
        private System.Windows.Forms.RadioButton prikhodRb;
        private System.Windows.Forms.TextBox kolTovara;
        private System.Windows.Forms.TextBox kolIzmeneniy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox artikul;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView spisokIzmeneniyDGV;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button zadolzhnostBtn;
        private System.Windows.Forms.DataGridView tovarDGV;
        private System.Windows.Forms.Button neoprikhodBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikulIzmen;
        private System.Windows.Forms.DataGridViewTextBoxColumn kol;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikhRaskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn itog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateVibor;
    }
}