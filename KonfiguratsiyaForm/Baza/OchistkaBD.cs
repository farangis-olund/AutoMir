using System;
using System.Windows.Forms;
using Core.Controllers.OchistkaBazi;

namespace AutoMir2022.Konfiguratsiya.Baza
{
    public partial class OchistkaBD : Form
    {
        public OchistkaBD()
        {
            InitializeComponent();
        }
        private OchistkaBazi ochistkaBaziObj = new OchistkaBazi();


        private void ochistka_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите очистить выбранные таблицы?", "Очистка таблиц", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (vozvrat.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTableWithCascade("возврат");
                    
                    ochistkaBaziObj.RestartIdColumn("возврат", "код_возврата");
                }
                if (prodazha.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTableWithCascade("продажа");
                    ochistkaBaziObj.RestartIdColumn("продажа", "кодпродажи");
                    
                }

                if (proshVozvrat.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("возврат_прошлогодный");
                }

                if (obmenMag.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("обмен_магазинами");
                }

                if (obnovTovara.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("обновление_товара");
                    ochistkaBaziObj.DeleteRowsInTable("обновление_товара_статус");
                }

                if (prikhodTovara.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("приход");
                    ochistkaBaziObj.DeleteRowsInTable("приход_ошибки");
                }
                if (otmenaProdazhi.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("отмена_продажи");
                    //ochistkaBaziObj.RestartIdColumn("отмена_продажи", "код_отмена");

                }
                if (bonusi.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("бонусы");
                }
                

                if (platezhi.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("платежи");
                    ochistkaBaziObj.RestartIdColumn("платежи", "№_платежа");
                }

                if (rasprodazha.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("распродажа");
                  
                }

                if (raskhodi.Checked == true)
                {
                    ochistkaBaziObj.DeleteRowsInTable("расходы");

                }

                MessageBox.Show("Данные таблицы успешно удалены!");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            

           
        }

       

        private void prodazha_Click(object sender, EventArgs e)
        {
            if (prodazha.Checked == true)
            {
                if (MainMenu.userOnlyChek==false)
                    dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTableWithCondition("продажа", "WHERE chek=true ");
                else if (MainMenu.userOnlyChek == true)
                    dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("продажа");
            }
        }

        private void vozvrat_Click(object sender, EventArgs e)
        {
            if (vozvrat.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("возврат");
            }
        }

        private void proshVozvrat_Click(object sender, EventArgs e)
        {
            if (proshVozvrat.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("возврат_прошлогодный");
            }
        }

        private void obmenMag_Click(object sender, EventArgs e)
        {
            if (obmenMag.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("обмен_магазинами");
            }
        }

        private void obnovTovara_Click(object sender, EventArgs e)
        {
            if (obnovTovara.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("обновление_товара");
            }
        }

        private void otmenaProdazhi_Click(object sender, EventArgs e)
        {
            if (otmenaProdazhi.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("отмена_продажи");
            }
        }

        private void platezhi_Click(object sender, EventArgs e)
        {
            if (platezhi.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("платежи");
            }
        }

        private void prikhodTovara_Click(object sender, EventArgs e)
        {
            if (prikhodTovara.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("приход");
            }
        }

       
        private void bonusi_Click(object sender, EventArgs e)
        {
            if (bonusi.Checked == true)
            {
               dataGridView1.DataSource= ochistkaBaziObj.ProsmotrTable("бонусы");
            }
        }

        private void raskhodi_Click(object sender, EventArgs e)
        {
            if (bonusi.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("расходы");
            }
        }
        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                prodazha.Checked = true;
                vozvrat.Checked = true;
                proshVozvrat.Checked = true;
                 obmenMag.Checked = true;
                obnovTovara.Checked = true;
                bonusi.Checked = true;
                prikhodTovara.Checked = true;
                otmenaProdazhi.Checked = true;
                platezhi.Checked = true;
                rasprodazha.Checked = true;
                raskhodi.Checked = true;

            }
            else
            {
                prodazha.Checked = false;
                vozvrat.Checked = false;
                proshVozvrat.Checked = false;
                obmenMag.Checked = false;
                obnovTovara.Checked = false;
                bonusi.Checked = false;
                prikhodTovara.Checked = false;
                otmenaProdazhi.Checked = false;
                platezhi.Checked = false;
                rasprodazha.Checked = false;
                raskhodi.Checked = false;
            }
        }

        private void rasprodazha_Click(object sender, EventArgs e)
        {
            if (rasprodazha.Checked == true)
            {
                dataGridView1.DataSource = ochistkaBaziObj.ProsmotrTable("распродажа");
            }
        }
    }
}
