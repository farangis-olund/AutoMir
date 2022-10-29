using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Klient
{
    class Klient
    {
        private DBNpgsql db = new DBNpgsql();

        
        public DataTable GetKodKlienta()
        {
            return db.GetByQuery("Select код_клиента, фио FROM public.customers ");            
        }

        public DataTable GetUrovenKlienta()
        {
            return db.GetByQuery("Select уровень FROM public.customers WHERE уровень IS NOT NULL GROUP BY уровень ");
        }

        public DataTable GetKlientInfo(string kodKlienta)
        {
           return db.GetByQuery("Select * FROM public.customers " +
                                               "WHERE код_клиента='" + kodKlienta + "'");
        }

        public void InsertNewKlient(string kodKlienta, string fio, string tel, string addres,
            double zadolzhnost, string uroven)
        {
            db.insertWithParametrDouble ("INSERT INTO public.customers (код_клиента, фио, рабочий_телефон, " +
                "адрес, задолжность, уровень) " +
                "VALUE('" + kodKlienta + "', '" + fio + "','" + tel + "'," +
                "'" + addres + "', @zadolg, '" + uroven + "',", "zadolg", zadolzhnost);
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
