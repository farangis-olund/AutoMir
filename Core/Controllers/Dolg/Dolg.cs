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


        public DataTable GetAllItogByPeriod(DateTime dataStart, DateTime dataEnd)
        {

            return db.GetByParametrPeriod("" +

            "Select p.фио as Fio, p.адрес as Adres, p.рабочий_телефон as Tel, p.код_клиента as KodKlienta, " +
                "p.itogiprodazhi, Sum(f.сумма_платежа) as ItogiPlatezha From (" +
                "Select " +
                "c.фио, c.адрес, c.рабочий_телефон, e.код_клиента, " +
                "SUM(d.количество*d.цена) as itogiprodazhi " +
             "FROM" +
                " public.customers c " +

             "INNER JOIN " +
               "public.продажа e ON " +
               "c.код_клиента=e.код_клиента " +

               "INNER JOIN public.продажа_товара d ON " +
             "e.кодпродажи=d.кодпродажи " +

             "WHERE " +
              "e.дата>=@dataStart AND e.дата<=@dataEnd GROUP BY c.фио, c.адрес, c.рабочий_телефон, e.код_клиента) as p, " +
              "public.платежи f" +
             " WHERE p.код_клиента=f.код_клиента AND f.дата>=@dataStart AND f.дата<=@dataEnd " +
             "GROUP BY p.фио, p.адрес, p.рабочий_телефон, p.код_клиента, p.itogiprodazhi ORDER BY p.фио ASC", dataStart, dataEnd);


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

        public double GetPlatezhByNomerPlatezh(string kodKlienta, int nomerPlatezh)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_платежа) FROM public.платежи " +
                            "WHERE код_клиента='" + kodKlienta + "' AND №_платежа='" + nomerPlatezh + "'");
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);

            return value;
        }



        public double GetPlatezhExceptTheLast(string kodKlienta, int nomerPlatezh)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_платежа) FROM public.платежи " +
                            "WHERE код_клиента='" + kodKlienta + "' AND №_платежа<>'" + nomerPlatezh + "'");
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

        public string GetPradazhaLastDate(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select дата FROM public.продажа  " +
                       "WHERE код_клиента='" + kodKlienta + "' ORDER BY дата DESC LIMIT 1;");
            string value = "";
            if (dt.Rows.Count != 0)
            {
                var b = dt.Rows[0][0].ToString();
                if (b != "")
                    value = Convert.ToDateTime(dt.Rows[0][0]).ToString("dd.MM.yyyy");
            }
            
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

        public double GetOstatok(string kodKlienta)
        {
            double prodazha = GetPradazha(kodKlienta);
            double zadolzhnost = GetZadolzhnost(kodKlienta);
            double platezh = GetPlatezh(kodKlienta);
            return prodazha + zadolzhnost - platezh;
        }

        public double GetObshDolg(string kodKlienta)
        { 
            return  GetPradazha(kodKlienta) - GetVozvrat(kodKlienta) 
                - GetPlatezh(kodKlienta) + GetZadolzhnost(kodKlienta);  
        }

        public double GetStariyDolg(string kodKlienta, string nakText)
        {
            double prod = GetPradazha(kodKlienta) - GetPradazhaTekushiy(kodKlienta, nakText);
            double plat = GetPlatezh(kodKlienta);
            double dolgIt=prod-plat + GetZadolzhnost(kodKlienta);
            return dolgIt;
        }

        public DataTable GetProdazhaDgv(string kodKlienta)
        {
            return db.GetByQuery("Select p.дата, p.накладной_текст, Sum(pt.количество*pt.цена) as сумма FROM public.продажа p, public.продажа_товара pt " +
                                       "WHERE pt.кодпродажи=p.кодпродажи AND p.код_клиента='" + kodKlienta + "' GROUP BY p.дата, p.накладной_текст ORDER BY p.дата DESC");
        }

    
        public DataTable GetPlatezhDgv(string kodKlienta)
        {
            return db.GetByQuery("Select дата, №_платежа, сумма_платежа FROM public.платежи " +
                                         "WHERE код_клиента='" + kodKlienta + "' ORDER BY дата DESC");
        }

    }
}
