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
            return db.GetByQuery("Select код_клиента, фио, задолжность FROM public.customers order by код_клиента ASC");            
        }

        public DataTable GetUrovenKlienta()
        {
            return db.GetByQuery("Select уровень FROM public.уровень_цен");
        }

        public DataTable GetKlientInfo(string kodKlienta)
        {
           return db.GetByQuery("Select * FROM public.customers " +
                                               "WHERE код_клиента='" + kodKlienta + "'");
        }

        

        public DataTable GetAllKlientInfo()
        {
            return db.GetByQuery("Select * FROM public.customers ORDER BY код_клиента ASC");
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

        public void UpdateKlientDolg(string kodKlienta, double zadolzhnost)
        {
            db.insertWithParametrDouble("UPDATE public.customers " +
                        "SET задолжность = @zadolg " +
                        "WHERE код_клиента ='" + kodKlienta + "'", "zadolg", zadolzhnost);
        }



    }
}
