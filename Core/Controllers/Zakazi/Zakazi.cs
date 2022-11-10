using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Zakazi
{
    class Zakazi
    {
        private DBNpgsql db = new DBNpgsql();

        
        public DataTable GetDateObnovlenieTovara()
        {
            return db.GetByQuery("Select p.дата FROM public.продажа p " +
                "LEFT JOIN public.обновление_товара o ON o.дата=p.дата WHERE o.дата IS NULL GROUP BY p.дата ORDER BY p.дата");           
        }

        
        public DataTable GetZakazByDate(DateTime date)
        {
            return db.GetByParametrDateByUser("SELECT d.артикул, c.наименование, c.группа, c.бренд, " +
                                        "c.марка, c.модель, sum(d.количество) as количество FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.дата=@data GROUP BY d.артикул, c.наименование, c.группа, c.бренд, " +
                                        "c.марка, c.модель", date);

        }

        public DataTable GetZakazReportByDate(DateTime date)
        {
            return db.GetByParametrDateByUser("SELECT d.артикул as artikul, c.наименование as naimenovanie, c.группа as gruppa, c.бренд as brand, " +
                                        "c.марка as marka, c.модель as model, sum(d.количество) as kolichestvo, c.место_на_складе as mesto FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.дата=@data GROUP BY d.артикул, c.наименование, c.группа, c.бренд, " +
                                        "c.марка, c.модель, c.место_на_складе", date);

        }

        public DataTable ExportObnovlenieTovara(DateTime date)
        {
            return db.GetByParametrDateByUser("SELECT d.артикул as artikul, sum(d.количество) as kolichestvo FROM public.продажа e , public.продажа_товара d, " +
                                         "public.товар c WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                         "AND e.дата=@data GROUP BY d.артикул, c.наименование, c.группа, c.бренд, " +
                                         "c.марка, c.модель", date);
        }

        public void InsertObnovlenieTovara(DateTime date, int kol)
        {
            db.GetByParametrDateByUser ("INSERT INTO public.обновление_товара (дата, количество) " +
                "VALUES (@data, '" + kol + "')", date);
        }

        public bool IsExist(DateTime data)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.обновление_товара WHERE дата =@data LIMIT 1)", data);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }


    }
}
