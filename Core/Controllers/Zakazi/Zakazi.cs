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
            return db.GetByQuery("Select дата FROM public.продажа p" +
                "RIGHT JOIN public.обновление_товара o ON o.дата=p.дата WHERE o.дата IS NULL ORDER BY p.дата");           
        }

        
        public DataTable GetZakazByDate(DateTime date)
        {
            return db.GetByParametrDateByUser("SELECT d.артикул as artikul, c.наименование as naimenovanie, c.группа as grup, c.бренд as brand, " +
                                        "c.марка as marka, c.модель as model, sum(d.количество) as kolichestvo FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.дата=@data GROUP BY d.артикул as artikul, c.наименование as naimenovanie, c.группа as grup, c.бренд as brand, " +
                                        "c.марка as marka, c.модель as model", date);

        }

        public DataTable GetKlientInfoByName(string fioKlienta)
        {
            return db.GetByQuery("Select * FROM public.customers " +
                                 "WHERE фио='" + fioKlienta + "' ");
        }

        public void InsertNewKlient(string kodKlienta, string fio, string tel, string addres,
            double zadolzhnost, string uroven)
        {
            db.insertWithParametrDouble ("INSERT INTO public.customers (код_клиента, фио, рабочий_телефон, " +
                "адрес, задолжность, уровень) " +
                "VALUES ('" + kodKlienta + "', '" + fio + "','" + tel + "'," +
                "'" + addres + "', @zadolg, '" + uroven + "')", "zadolg", zadolzhnost);
        }


        public void UpdateKlient(string kodKlienta, string fio, string tel, string addres,
            double zadolzhnost, string uroven)
        {

            db.insertWithParametrDouble ("UPDATE public.customers " +
                        "SET код_клиента ='" + kodKlienta + "', фио ='" + fio + "', " +
                        "рабочий_телефон = '" + tel + "', адрес = '" + addres + "', " +
                        "задолжность = @zadolg, уровень = '" + uroven + "'" +
                        "WHERE код_клиента ='" + kodKlienta + "'", "zadolg", zadolzhnost);
        }

        public void DeleteKlient(string kodKlienta)
        {
            db.insertUpdateToDB("DELETE FROM public.customers " +
                       "WHERE код_клиента ='" + kodKlienta + "'");
            

        }




    }
}
