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
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                   value = Convert.ToDouble(dr[0]);
                }
            }
            return value;
        }


        public double GetPlatezh(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select сумма_платежа FROM public.платежи " +
                                               "WHERE код_клиента='" + kodKlienta + "'");
            double value = 0;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    value = Convert.ToDouble(dr[0]);
                }
            }
            return value;
        }

        public double GetPradazha(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select pt.количество*pt.цена FROM public.продажа p, public.продажа_товара pt " +
                                        "WHERE pt.кодпродажи=p.кодпродажи AND p.код_клиента='" + kodKlienta + "'");
            double value = 0;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    value = Convert.ToDouble(dr[0]);
                }
            }
            return value;
        }

        public double GetVozvrat(string kodKlienta)
        {
            DataTable dt = db.GetByQuery("Select Sum(сумма_возврата) FROM public.возврат " +
                                        "WHERE код_клиента='" + kodKlienta + "'");
            double value = 0;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    value = Convert.ToDouble(dr[0]);
                }
            }
            return value;
        }

        public double GetObshDolg(string kodKlienta)
        { 
            return  GetPradazha(kodKlienta) - GetVozvrat(kodKlienta) 
                - GetPlatezh(kodKlienta) + GetZadolzhnost(kodKlienta);  
        }



    }
}
