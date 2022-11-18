using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;

namespace Core.Controllers
{
    class KursValyuti
    {
        DBNpgsql db = new DBNpgsql();
        public string UpdateKursValyuti()
        {
            InputBox inputBoxObj = new InputBox();
           

            double kurs = 0;
            string value = "0";

            if (inputBoxObj.GetInputBox("Курс валюты", "Задайте новый курс валюты:", ref value) == DialogResult.OK)
            {
                if (double.TryParse(value, out kurs))
                {
                    db.insertKurs(kurs);
                    MessageBox.Show("Курс валюты успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Курс валюты указан не правильном формате, укажите число с использованием запятой ");
                }
            }
            return kurs.ToString();
        }

        public string GetKursValyuti()
        {
            string cursValyuti = "";
            DataTable dt = new DataTable();
            dt = db.GetByQuery("SELECT курс_валюты FROM public.курс_валюты ORDER BY idkurs DESC LIMIT 1;");
            if (dt.Rows.Count != 0)
            {
                cursValyuti = dt.Rows[0]["курс_валюты"].ToString();

            }
            return cursValyuti;
        }
    }
}
