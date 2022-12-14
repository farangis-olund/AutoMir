
namespace AutoMir2022
{
    partial class Dostup
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.save = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.uslovieGruppiDgv = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_категория = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.название_категории = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.контроль = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_доступа = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.vibor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.пользователь = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фио = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пароль = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_пользователь = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.opisanie = new System.Windows.Forms.RichTextBox();
            this.id_gruppa = new System.Windows.Forms.TextBox();
            this.add_kategoria = new System.Windows.Forms.Button();
            this.kategorii = new System.Windows.Forms.ComboBox();
            this.addToList = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.ComboBox();
            this.addUser = new System.Windows.Forms.Button();
            this.newUser = new System.Windows.Forms.Button();
            this.addAll = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uslovieGruppiDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.save);
            this.panel2.Controls.Add(this.create);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1256, 57);
            this.panel2.TabIndex = 1;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(299, 7);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(111, 44);
            this.save.TabIndex = 1;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(3, 7);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(290, 44);
            this.create.TabIndex = 0;
            this.create.Text = "Создать новую группу доступа";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // uslovieGruppiDgv
            // 
            this.uslovieGruppiDgv.AllowUserToAddRows = false;
            this.uslovieGruppiDgv.AllowUserToDeleteRows = false;
            this.uslovieGruppiDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uslovieGruppiDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.add,
            this.id_категория,
            this.название_категории,
            this.контроль,
            this.id_доступа});
            this.uslovieGruppiDgv.Location = new System.Drawing.Point(15, 153);
            this.uslovieGruppiDgv.Name = "uslovieGruppiDgv";
            this.uslovieGruppiDgv.Size = new System.Drawing.Size(636, 358);
            this.uslovieGruppiDgv.TabIndex = 2;
            // 
            // add
            // 
            this.add.HeaderText = "";
            this.add.Name = "add";
            this.add.Width = 30;
            // 
            // id_категория
            // 
            this.id_категория.HeaderText = "id_категория";
            this.id_категория.Name = "id_категория";
            this.id_категория.Visible = false;
            this.id_категория.Width = 30;
            // 
            // название_категории
            // 
            this.название_категории.HeaderText = "название_категории";
            this.название_категории.Name = "название_категории";
            this.название_категории.Width = 450;
            // 
            // контроль
            // 
            this.контроль.HeaderText = "контроль";
            this.контроль.Name = "контроль";
            this.контроль.Width = 300;
            // 
            // id_доступа
            // 
            this.id_доступа.HeaderText = "id_доступа";
            this.id_доступа.Name = "id_доступа";
            this.id_доступа.Visible = false;
            this.id_доступа.Width = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Группы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Категории";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(660, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пользователи";
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vibor,
            this.пользователь,
            this.фио,
            this.пароль,
            this.id_пользователь});
            this.userDgv.Location = new System.Drawing.Point(664, 153);
            this.userDgv.Name = "userDgv";
            this.userDgv.Size = new System.Drawing.Size(592, 358);
            this.userDgv.TabIndex = 7;
            // 
            // vibor
            // 
            this.vibor.HeaderText = "";
            this.vibor.Name = "vibor";
            this.vibor.Width = 30;
            // 
            // пользователь
            // 
            this.пользователь.HeaderText = "пользователь";
            this.пользователь.Name = "пользователь";
            this.пользователь.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.пользователь.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.пользователь.Width = 200;
            // 
            // фио
            // 
            this.фио.HeaderText = "фио";
            this.фио.Name = "фио";
            this.фио.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.фио.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.фио.Width = 200;
            // 
            // пароль
            // 
            this.пароль.HeaderText = "пароль";
            this.пароль.Name = "пароль";
            this.пароль.Width = 200;
            // 
            // id_пользователь
            // 
            this.id_пользователь.HeaderText = "id_пользователь";
            this.id_пользователь.Name = "id_пользователь";
            this.id_пользователь.Visible = false;
            // 
            // name
            // 
            this.name.FormattingEnabled = true;
            this.name.Location = new System.Drawing.Point(91, 60);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(246, 28);
            this.name.TabIndex = 8;
            this.name.SelectionChangeCommitted += new System.EventHandler(this.name_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Описание";
            // 
            // opisanie
            // 
            this.opisanie.Location = new System.Drawing.Point(479, 60);
            this.opisanie.Name = "opisanie";
            this.opisanie.Size = new System.Drawing.Size(703, 52);
            this.opisanie.TabIndex = 12;
            this.opisanie.Text = "";
            // 
            // id_gruppa
            // 
            this.id_gruppa.Location = new System.Drawing.Point(394, 83);
            this.id_gruppa.Name = "id_gruppa";
            this.id_gruppa.Size = new System.Drawing.Size(79, 26);
            this.id_gruppa.TabIndex = 13;
            this.id_gruppa.Visible = false;
            // 
            // add_kategoria
            // 
            this.add_kategoria.Location = new System.Drawing.Point(575, 120);
            this.add_kategoria.Name = "add_kategoria";
            this.add_kategoria.Size = new System.Drawing.Size(76, 30);
            this.add_kategoria.TabIndex = 14;
            this.add_kategoria.Text = "Новый";
            this.add_kategoria.UseVisualStyleBackColor = true;
            this.add_kategoria.Click += new System.EventHandler(this.add_kategoria_Click);
            // 
            // kategorii
            // 
            this.kategorii.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.kategorii.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.kategorii.DropDownHeight = 200;
            this.kategorii.DropDownWidth = 450;
            this.kategorii.FormattingEnabled = true;
            this.kategorii.IntegralHeight = false;
            this.kategorii.Location = new System.Drawing.Point(110, 122);
            this.kategorii.Name = "kategorii";
            this.kategorii.Size = new System.Drawing.Size(218, 28);
            this.kategorii.TabIndex = 15;
            // 
            // addToList
            // 
            this.addToList.Location = new System.Drawing.Point(334, 120);
            this.addToList.Name = "addToList";
            this.addToList.Size = new System.Drawing.Size(95, 30);
            this.addToList.TabIndex = 16;
            this.addToList.Text = "Добавить";
            this.addToList.UseVisualStyleBackColor = true;
            this.addToList.Click += new System.EventHandler(this.addToList_Click);
            // 
            // user
            // 
            this.user.DropDownWidth = 300;
            this.user.FormattingEnabled = true;
            this.user.Location = new System.Drawing.Point(787, 122);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(156, 28);
            this.user.TabIndex = 17;
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(949, 120);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(95, 30);
            this.addUser.TabIndex = 18;
            this.addUser.Text = "Добавить";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // newUser
            // 
            this.newUser.Location = new System.Drawing.Point(1050, 120);
            this.newUser.Name = "newUser";
            this.newUser.Size = new System.Drawing.Size(89, 30);
            this.newUser.TabIndex = 19;
            this.newUser.Text = "Новый";
            this.newUser.UseVisualStyleBackColor = true;
            this.newUser.Click += new System.EventHandler(this.newUser_Click);
            // 
            // addAll
            // 
            this.addAll.Location = new System.Drawing.Point(435, 120);
            this.addAll.Name = "addAll";
            this.addAll.Size = new System.Drawing.Size(134, 30);
            this.addAll.TabIndex = 20;
            this.addAll.Text = "Добавить всё";
            this.addAll.UseVisualStyleBackColor = true;
            this.addAll.Click += new System.EventHandler(this.addAll_Click);
            // 
            // Dostup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 523);
            this.Controls.Add(this.addAll);
            this.Controls.Add(this.newUser);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.user);
            this.Controls.Add(this.addToList);
            this.Controls.Add(this.kategorii);
            this.Controls.Add(this.add_kategoria);
            this.Controls.Add(this.id_gruppa);
            this.Controls.Add(this.opisanie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.name);
            this.Controls.Add(this.userDgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uslovieGruppiDgv);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dostup";
            this.Text = "Доступ и ограничения пользователей";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dostup_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uslovieGruppiDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.DataGridView uslovieGruppiDgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView userDgv;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox opisanie;
        private System.Windows.Forms.TextBox id_gruppa;
        private System.Windows.Forms.Button add_kategoria;
        private System.Windows.Forms.ComboBox kategorii;
        private System.Windows.Forms.Button addToList;
        private System.Windows.Forms.ComboBox user;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button newUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn add;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_категория;
        private System.Windows.Forms.DataGridViewTextBoxColumn название_категории;
        private System.Windows.Forms.DataGridViewTextBoxColumn контроль;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_доступа;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vibor;
        private System.Windows.Forms.DataGridViewTextBoxColumn пользователь;
        private System.Windows.Forms.DataGridViewTextBoxColumn фио;
        private System.Windows.Forms.DataGridViewTextBoxColumn пароль;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_пользователь;
        private System.Windows.Forms.Button addAll;
    }
}