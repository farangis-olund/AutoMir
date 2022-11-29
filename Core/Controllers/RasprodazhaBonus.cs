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
            int b = 0;
            for (int i=0; i<dgv.RowCount-1; i++)
            {
                if (dgv.Rows[i].Cells[1].Value.ToString() != "")
                {
                    b = Convert.ToInt32(dgv.Rows[i].Cells[1].Value.ToString());
                }
                sub_query = sub_query + " ('" + dgv.Rows[i].Cells[0].Value.ToString() + "', '" + b + "'),";
            }
            sub_query = sub_query + sub_query.Remove(sub_query.Length-1,1);
        db.insertUpdateToDB(query+ sub_query);
            
        }

        public DataTable GetBonusByPeriodAndProdovets(DateTime startDate, DateTime endDate, int bonus)
        {
            return db.GetByParametrPeriod("SELECT p.продавец, pt.артикул, Sum(pt.количество) as количество, " +
                "Sum(pt.количество*pt.цена) as сумма, Sum(pt.количество*pt.цена)*" + bonus + "/100 as бонус " +
                "FROM public.продажа p, public.продажа_товара pt, public.распродажа t " +
                 "WHERE pt.кодпродажи=p.кодпродажи AND pt.артикул=t.артикул AND " +
                 "p.дата>=@dataStart AND p.дата<=@dataEnd" +
                 " GROUP BY p.продавец, pt.артикул", startDate, endDate);

        }

        public void InsertBonus(DateTime startDate, DateTime endDate, int bonus)
        {
            DataTable dt = GetBonusByPeriodAndProdovets(startDate, endDate, bonus);
            double summa=Convert.ToDouble(dt.Compute("Sum(сумма)", string.Empty));
            double summa_bonus = Convert.ToDouble(dt.Compute("Sum(бонус)", string.Empty));
            
            db.insertWithParametrTwoDoubleAndDate("INSERT INTO public.бонусы (дата, сумма, процент_бонуса, сумма_бонуса) " +
                "VALUES (@date, @summa, '" + bonus + "', @summa_bonus)","summa", summa, "summa_bonus", summa_bonus, "date", endDate);

        }

    }
}
