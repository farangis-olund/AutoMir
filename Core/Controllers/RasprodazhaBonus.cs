using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;
using System.Text;

namespace Core.Controllers
{
    class RasprodazhaBonus
    {
        DBNpgsql db = new DBNpgsql();
        
        public DataTable GetBonusInfo()
        {
           return db.GetByQuery("SELECT дата, процент_бонуса FROM public.бонусы ORDER BY дата DESC LIMIT 1;");
        }

        public void InsertRaspradazha(string uslovie, int uslovieValue)
        {
            db.insertUpdateToDB("DELETE FROM public.распродажа");

            db.insertUpdateToDB("INSERT INTO public.распродажа (артикул, количество) " +
                "SELECT t.артикул, Sum(pt.количество) FROM " +
                "public.товар t " +
                "LEFT JOIN public.продажа_товара pt ON t.артикул = pt.артикул " +
                "WHERE t.количество>0 GROUP BY t.артикул " +
                "HAVING Sum(pt.количество) Is Null OR Sum(pt.количество)<='" + uslovieValue + "'");

        }

        public DataTable GetRasprodazha()
        {
            return db.GetByQuery("SELECT артикул, количество FROM public.распродажа ORDER BY артикул ASC");
        }

        public void CreateTable(ref DataGridView dgv)
        {
            db.insertUpdateToDB("DELETE FROM public.распродажа");

            string query = "INSERT INTO public.распродажа (артикул, количество) Values";
            string sub_query = "";
            for (int i=0; i<dgv.RowCount; i++)
            {
                sub_query = sub_query +" ("+ dgv.Rows[i].Cells[0].Value.ToString() + ", " + dgv.Rows[i].Cells[0].Value.ToString() + "),";
            }
            sub_query = sub_query + sub_query.Remove(sub_query.Length-1,1);
        db.insertUpdateToDB(query);
            
        }


}
}
