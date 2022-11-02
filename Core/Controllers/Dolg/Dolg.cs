using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Dolg
{
    class Dolg
    {
        private DBNpgsql db = new DBNpgsql();

        
        public double GetZadolzhnost(string kodKlienta)
        {
            DataTable dt= db.GetByQuery("Select задолжность FROM public.customers " +
                                               "WHERE код_клиента='" + kodKlienta + "'");
            double value =0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return value;
        }


        public double GetPlatezh(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_платежа) FROM public.платежи " +
                                               "WHERE код_клиента='" + kodKlienta + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            
            return value;
        }

        public double GetPlatezhTekushiy(string kodKlienta, string naklText)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_платежа) FROM public.платежи " +
                            "WHERE код_клиента='" + kodKlienta + "' AND накладной_текст='" + naklText + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);

            return value;
        }

        public double GetPradazha(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select Sum(pt.количество*pt.цена) FROM public.продажа p, public.продажа_товара pt " +
                                        "WHERE pt.кодпродажи=p.кодпродажи AND p.код_клиента='" + kodKlienta + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return value;
        }

        public double GetPradazhaTekushiy(string kodKlienta, string naklText)
        {
            DataTable dt = db.GetByQuery("Select Sum(pt.количество*pt.цена) FROM public.продажа p, public.продажа_товара pt " +
                                        "WHERE pt.кодпродажи=p.кодпродажи AND p.код_клиента='" + kodKlienta + "' AND p.накладной_текст='" + naklText + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return value;
        }

        public double GetVozvrat(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_возврата) FROM public.возврат " +
                                        "WHERE код_клиента='" + kodKlienta + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);

            return value;
        }

        public double GetObshDolg(string kodKlienta)
        { 
            return  GetPradazha(kodKlienta) - GetVozvrat(kodKlienta) 
                - GetPlatezh(kodKlienta) + GetZadolzhnost(kodKlienta);  
        }

        public double GetStariyDolg(string kodKlienta, string nakText)
        {
            return (GetPradazha(kodKlienta)-GetPradazhaTekushiy(kodKlienta, nakText)) -
                - (GetPlatezh(kodKlienta)-GetPlatezhTekushiy(kodKlienta,nakText)) + GetZadolzhnost(kodKlienta);
        }

        public DataTable GetProdazhaDgv(string kodKlienta)
        {
            return db.GetByQuery("Select p.дата, p.накладной_текст, Sum(pt.количество*pt.цена) as сумма FROM public.продажа p, public.продажа_товара pt " +
                                       "WHERE pt.кодпродажи=p.кодпродажи AND p.код_клиента='" + kodKlienta + "' GROUP BY p.дата, p.накладной_текст");
        }

    
        public DataTable GetPlatezhDgv(string kodKlienta)
        {
            return db.GetByQuery("Select дата, №_платежа, сумма_платежа FROM public.платежи " +
                                         "WHERE код_клиента='" + kodKlienta + "'");
        }

    }
}
