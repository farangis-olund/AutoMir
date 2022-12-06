using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Controllers;

namespace AutoMir2022
{
    public partial class Dostup : Form
    {
        public Dostup()
        {
            InitializeComponent();
        }
        private DostupOgranichenie dostupObj = new DostupOgranichenie();
        private void Dostup_Load(object sender, EventArgs e)
        {
            //список названий групп для созданий новых груп ограничений
            name.DataSource = dostupObj.GetGruppaDostupa();
            name.DisplayMember = "название";
            name.Text = null;


            //группа ограничений
            name.DataSource= dostupObj.GetGruppaDostupa();
           name.DisplayMember = "название";
           name.Text = null;
            //категории в группе ограничений 
            kategorii.DataSource = dostupObj.GetAllKategoriaDostupa();
            kategorii.DisplayMember = "название_категории";
            kategorii.Text = null;

            
            user.DataSource = dostupObj.GetUser();
            user.DisplayMember = "фио";
            user.Text = null;



        }
        private void ochistka()
        {
            
            uslovieGruppiDgv.Rows.Clear();
            userDgv.Rows.Clear();
            kategorii.Text = null;
            user.Text = null;

        }
        private void name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ochistka();
            name.Text = name.GetItemText(name.SelectedItem);
           if (name.Text != "")
            {
                DataTable dt = dostupObj.GetGruppaDostupaByName(name.Text);
                id_gruppa.Text = dt.Rows[0][0].ToString();
                opisanie.Text = dt.Rows[0][1].ToString();
                dt = dostupObj.GetKategoriaDostupa(Convert.ToInt32(id_gruppa.Text));
                foreach (DataRow dr in dt.Rows)
                {
                    int index = uslovieGruppiDgv.Rows.Add();
                    uslovieGruppiDgv.Rows[index].Cells[0].Value = true;
                    uslovieGruppiDgv.Rows[index].Cells["id_категория"].Value = dr["id_категория"];
                    uslovieGruppiDgv.Rows[index].Cells["название_категории"].Value = dr["название_категории"];
                    uslovieGruppiDgv.Rows[index].Cells["контроль"].Value = dr["контроль"];
                }

                dt = dostupObj.GetUserByDostup(Convert.ToInt32(id_gruppa.Text));
                foreach (DataRow dr in dt.Rows)
                {
                    int index = userDgv.Rows.Add();
                    userDgv.Rows[index].Cells[0].Value = true;
                    userDgv.Rows[index].Cells["пользователь"].Value = dr["пользователь"];
                    userDgv.Rows[index].Cells["фио"].Value = dr["фио"];
                    userDgv.Rows[index].Cells["id_пользователь"].Value = dr["id_пользователь"];
                    userDgv.Rows[index].Cells["пароль"].Value = dr["пароль"];
                }

            }
            
             
        }

        private void create_Click(object sender, EventArgs e)
        {
            InputBox inputBoxObj = new InputBox();
            string value = "";
            if (inputBoxObj.GetInputBox("Создать группу доступа", "Введите название группы:", ref value) == DialogResult.OK)
            {
                if (value != "")
                {
                    dostupObj.InsertGruppaDostupa(value);
                    id_gruppa.Text= dostupObj.GetGruppaNameIDByName(value).Rows[0][0].ToString();
                    dostupObj.InsertGruppaPolzovateley(Convert.ToInt32(id_gruppa.Text));
                    name.Text = value;
                    ochistka();
                    opisanie.Text = null;
                }
                    
                else
                    MessageBox.Show("Название не может быть пустой!");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                //обновление группы
                dostupObj.UpdateGruppaDostupa(name.Text, opisanie.Text, Convert.ToInt32(id_gruppa.Text));
                //обновление категории
                for (int i=0; i<uslovieGruppiDgv.Rows.Count; i++)
                {
                        dostupObj.UpdateKategoriaDostupa(
                        uslovieGruppiDgv.Rows[i].Cells["название_категории"].Value.ToString(),
                        uslovieGruppiDgv.Rows[i].Cells["контроль"].Value.ToString(),
                        Convert.ToInt32(uslovieGruppiDgv.Rows[i].Cells["id_категория"].Value),
                        Convert.ToInt32(id_gruppa.Text),
                        Convert.ToBoolean(uslovieGruppiDgv.Rows[i].Cells[0].Value));  
                }
                //обновление пользователей
                for (int i = 0; i < userDgv.Rows.Count; i++)
                {
                    
                        dostupObj.UpdateUserByDostup( 
                    userDgv.Rows[i].Cells["пользователь"].Value.ToString(), Convert.ToInt32(id_gruppa.Text),
                    userDgv.Rows[i].Cells["фио"].Value.ToString(),
                    Convert.ToInt32(userDgv.Rows[i].Cells["id_пользователь"].Value), 
                    userDgv.Rows[i].Cells["пароль"].Value.ToString());
                    if (Convert.ToBoolean(userDgv.Rows[i].Cells[0].Value) == false)
                        dostupObj.DeleteUserFromDostup(Convert.ToInt32(userDgv.Rows[i].Cells["id_пользователь"].Value));
                }

                MessageBox.Show("Данные сохранены!");
            }
            
        }

        private void add_kategoria_Click(object sender, EventArgs e)
        {
            InputBox inputBoxObj = new InputBox();
            string value = "";
            if (inputBoxObj.GetInputBox("Создать категорию для выбранной группе доступа", "Введите название категории:", ref value) == DialogResult.OK)
            {
                if (value != "")
                {
                    dostupObj.InsertKategoriaToDostupPolzovatey(value, Convert.ToInt32( id_gruppa.Text));
                    DataTable dt = dostupObj.GetKategoriaDostupaByNameKategorii(value, Convert.ToInt32(id_gruppa.Text));
                    int index = uslovieGruppiDgv.Rows.Add();
                    foreach (DataRow dr in dt.Rows)
                    {
                        uslovieGruppiDgv.Rows[index].Cells[0].Value = true;
                        uslovieGruppiDgv.Rows[index].Cells["id_категория"].Value = dr["id_категория"];
                        uslovieGruppiDgv.Rows[index].Cells["название_категории"].Value = dr["название_категории"];
                        uslovieGruppiDgv.Rows[index].Cells["контроль"].Value = dr["контроль"];
                       
                    }
                    
                }

                else
                    MessageBox.Show("Название не может быть пустой!");
            }
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            if (dostupObj.IsKategoriExist(kategorii.Text, Convert.ToInt32(id_gruppa.Text))==true)
            {
                MessageBox.Show("Категория уже имеется в данной группе ограничений!");
            }
            else
            {
                dostupObj.InsertKategoriaToDostupPolzovatey(kategorii.Text, Convert.ToInt32(id_gruppa.Text));
                DataTable dt = dostupObj.GetKategoriaDostupaByNameKategorii(kategorii.Text, Convert.ToInt32(id_gruppa.Text));
                int index = uslovieGruppiDgv.Rows.Add();
                foreach (DataRow dr in dt.Rows)
                {
                    uslovieGruppiDgv.Rows[index].Cells[0].Value = true;
                    uslovieGruppiDgv.Rows[index].Cells["id_категория"].Value = dr["id_категория"];
                    uslovieGruppiDgv.Rows[index].Cells["название_категории"].Value = dr["название_категории"];
                    uslovieGruppiDgv.Rows[index].Cells["контроль"].Value = dr["контроль"];
                    
                }
            }
            
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            dostupObj.UpdateUserAddDostup(Convert.ToInt32(id_gruppa.Text), user.Text);
            DataTable dt = dostupObj.GetUserByFio(Convert.ToInt32(id_gruppa.Text), user.Text);
            
            foreach (DataRow dr in dt.Rows)
            {
                int index = userDgv.Rows.Add();
                userDgv.Rows[index].Cells[0].Value = true;
                userDgv.Rows[index].Cells["пользователь"].Value = dr["пользователь"];
                userDgv.Rows[index].Cells["фио"].Value = dr["фио"];
                userDgv.Rows[index].Cells["id_пользователь"].Value = dr["id_пользователь"];
                userDgv.Rows[index].Cells["пароль"].Value = dr["пароль"];
            }
            
        }

        private void newUser_Click(object sender, EventArgs e)
        {
            InputBox inputBoxObj = new InputBox();
            string value = "";
            if (inputBoxObj.GetInputBox("Добавить пользователя", "Введите фио пользователя:", ref value) == DialogResult.OK)
            {
                if (value != "")
                {
                    dostupObj.InsertNewUser(Convert.ToInt32(id_gruppa.Text), value);
                    DataTable dt = dostupObj.GetUserByFio(Convert.ToInt32(id_gruppa.Text), value);
                    int index = userDgv.Rows.Add();
                    foreach (DataRow dr in dt.Rows)
                    {
                        userDgv.Rows[index].Cells[0].Value = true;
                        userDgv.Rows[index].Cells["пользователь"].Value = dr["пользователь"];
                        userDgv.Rows[index].Cells["фио"].Value = dr["фио"];
                        userDgv.Rows[index].Cells["id_пользователь"].Value = dr["id_пользователь"];
                        userDgv.Rows[index].Cells["пароль"].Value = dr["пароль"];
                    }

                }

                else
                    MessageBox.Show("Название не может быть пустой!");
            }
        }
    }
}
