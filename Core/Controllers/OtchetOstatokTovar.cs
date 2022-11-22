using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;

namespace Core.Controllers
{
    class OtchetOstatokTovar
    {
        DBNpgsql db = new DBNpgsql();



        public DataTable GetVozvratByArtikul(DateTime date)
        {
            return db.GetByParametrDateByUser("Select vozvrat.артикул, t.наименование, t.бренд, t.место_на_складе as место, " +
                "t.количество-vozvrat.возврат as склад, vozvrat.возврат FROM " +
                "(SELECT pv.артикул, Sum(pv.количество) as возврат FROM public.возврат v, public.перечень_возврата pv " +
                 "WHERE pv.код_возврата=v.код_возврата AND v.дата=@data GROUP BY pv.артикул) vozvrat, public.товар t " +
                 "WHERE vozvrat.артикул=t.артикул", date);
            
        }

        public DataTable GetOtmenaByArtikul(DateTime date)
        {
            return db.GetByParametrDateByUser("Select ot.артикул, t.наименование, t.бренд, t.место_на_складе as место, " +
                "t.количество-ot.количество_возврата as склад, ot.количество_возврата as возврат FROM " +
                "public.отмена_продажи ot, public.товар t " +
                 "WHERE ot.артикул=t.артикул AND ot.дата=@data ", date);

        }



        public DataTable GetVozvratDates()
        {
            return db.GetByQuery("SELECT DISTINCT дата  FROM public.возврат ORDER BY дата DESC");
        }

        public DataTable GetOtmenaDates()
        {
            return db.GetByQuery("SELECT DISTINCT дата  FROM public.отмена_продажи ORDER BY дата DESC");
        }

        public int GetVozvratRozn(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(pv.количество) as возврат FROM public.возврат v, public.перечень_возврата pv " +
                "WHERE pv.код_возврата=v.код_возврата AND v.код_клиента IS NULL AND v.дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;
        }

        public int GetVozvratOpt(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(pv.количество) as возврат FROM public.возврат v, public.перечень_возврата pv " +
                "WHERE pv.код_возврата=v.код_возврата AND v.код_клиента IS NOT NULL AND v.дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;
        }

        public int GetVozvratProshRozn(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(pv.количество) as возврат FROM public.возврат v, public.перечень_возврата pv " +
                  "WHERE pv.код_возврата=v.код_возврата AND v.код_клиента IS NULL AND v.накладной_текст IS NULL AND v.дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;

        }

        public int GetOtmenaRozn(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(количество_возврата) as возврат FROM public.отмена_продажи " +
                  "WHERE оптовый=false AND дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;

        }

        public int GetOtmenaOpt(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(количество_возврата) as возврат FROM public.отмена_продажи " +
                  "WHERE оптовый=true AND дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;

        }

        public int GetVozvratProshOpt(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT Sum(pv.количество) as возврат FROM public.возврат v, public.перечень_возврата pv " +
                  "WHERE pv.код_возврата=v.код_возврата AND v.код_клиента IS NOT NULL AND v.накладной_текст IS NULL AND v.дата=@data", date);
            int value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToInt32(dt.Rows[0][0]);

            return value;


        }




    }
}
