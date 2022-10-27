
namespace AutoMir2022.Konfiguratsiya.Baza
{
    partial class OchistkaBD
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
            this.vozvrat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ochistka = new System.Windows.Forms.Button();
            this.zakrit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vozvrat
            // 
            this.vozvrat.AutoSize = true;
            this.vozvrat.Location = new System.Drawing.Point(17, 37);
            this.vozvrat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vozvrat.Name = "vozvrat";
            this.vozvrat.Size = new System.Drawing.Size(90, 24);
            this.vozvrat.TabIndex = 0;
            this.vozvrat.Text = "возврат";
            this.vozvrat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ochistka);
            this.groupBox1.Controls.Add(this.vozvrat);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 463);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таблицы";
            // 
            // ochistka
            // 
            this.ochistka.Location = new System.Drawing.Point(17, 407);
            this.ochistka.Name = "ochistka";
            this.ochistka.Size = new System.Drawing.Size(196, 32);
            this.ochistka.TabIndex = 2;
            this.ochistka.Text = "Очистить";
            this.ochistka.UseVisualStyleBackColor = true;
            this.ochistka.Click += new System.EventHandler(this.ochistka_Click);
            // 
            // zakrit
            // 
            this.zakrit.Location = new System.Drawing.Point(907, 12);
            this.zakrit.Name = "zakrit";
            this.zakrit.Size = new System.Drawing.Size(103, 32);
            this.zakrit.TabIndex = 3;
            this.zakrit.Text = "Закрыть";
            this.zakrit.UseVisualStyleBackColor = true;
            this.zakrit.Click += new System.EventHandler(this.zakrit_Click);
            // 
            // OchistkaBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 692);
            this.Controls.Add(this.zakrit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OchistkaBD";
            this.Text = "OchistkaBD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox vozvrat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ochistka;
        private System.Windows.Forms.Button zakrit;
    }
}