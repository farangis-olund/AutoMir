using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers

{
    class ProdazhaItog

    {
        private DBNpgsql db = new DBNpgsql();
        
        public DataTable GetOtchetRoznProdazhiProsmotr(DateTime startData, DateTime endData)
        {
           return db.GetByParametrPeriod("SELECT e.дата, e.накладной_текст, Sum(d.количество*d.цена) as сумма, " +
               "d.артикул, t.наименование, t.группа, t.бренд, t.марка, t.модель, " +
               "e.курс_валюты, e.скидка, e.продавец, e.оплачено, e.склад," +
               "Sum(d.количество) as количество " +
               "FROM public.продажа e, public.продажа_товара d, public.товар t" +
             " WHERE d.кодпродажи=e.кодпродажи AND d.артикул=t.артикул " +
              "AND e.оптовая_продажа=false AND e.дата>=@dataStart AND e.дата<=@dataEnd " +
              "GROUP BY d.артикул, t.наименование, t.группа, t.бренд, t.марка, t.модель, e.дата, e.накладной_текст, " +
              "e.курс_валюты, e.скидка, e.продавец, e.склад, e.оплачено", startData, endData);
        }


        public DataTable GetOtchetOptProdazhiProsmotr(DateTime startData, DateTime endData)
        {
            return db.GetByParametrPeriod("SELECT e.дата, e.накладной_текст, Sum(d.количество*d.цена) as сумма, " +
                "d.артикул, t.наименование, t.группа, t.бренд, t.марка, t.модель, " +
                "c.код_клиента, c.фио, c.рабочий_телефон, c.адрес " +
                "FROM public.продажа e, public.продажа_товара d, public.товар t, public.customers c" +
              " WHERE d.кодпродажи=e.кодпродажи AND e.код_клиента=c.код_клиента AND d.артикул=t.артикул " +
               "AND e.оптовая_продажа=true AND e.дата>=@dataStart AND e.дата<=@dataEnd " +
               "GROUP BY d.артикул, t.наименование, t.группа, t.бренд, t.марка, t.модель, e.дата, e.накладной_текст, " +
               "c.код_клиента, c.фио, c.рабочий_телефон, c.адрес", startData, endData);
        }


        public DataTable GetOtchetRoznProdazhi(DateTime startData, DateTime endData)
        {
            return db.GetByParametrPeriod("SELECT d.артикул, t.наименование, t.бренд, t.марка, t.модель, " +
                "Sum(d.количество) as количество, d.цена, Sum(d.количество*d.цена) as сумма FROM public.продажа e , " +
                "public.продажа_товара d, public.товар t" +
              " WHERE d.кодпродажи=e.кодпродажи AND d.артикул=t.артикул " +
               "AND e.оптовая_продажа=false AND e.дата>=@dataStart AND e.дата<=@dataEnd " +
               "GROUP BY d.артикул, t.наименование, t.бренд, t.марка, t.модель, d.цена", startData, endData);
        }

        public DataTable GetOtchetOptProdazhi(DateTime startData, DateTime endData)
        {
            return db.GetByParametrPeriod("SELECT d.артикул, t.наименование, t.бренд, t.марка, t.модель, " +
                "Sum(d.количество) as количество, d.цена, Sum(d.количество*d.цена) as сумма FROM public.продажа e , " +
                "public.продажа_товара d, public.товар t" +
              " WHERE d.кодпродажи=e.кодпродажи AND d.артикул=t.артикул " +
               "AND e.оптовая_продажа=true AND e.дата>=@dataStart AND e.дата<=@dataEnd " +
               "GROUP BY d.артикул, t.наименование, t.бренд, t.марка, t.модель, d.цена", startData, endData);
        }

        public double GetProdazhaOpt(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                                     " WHERE d.кодпродажи=e.кодпродажи " +
                                     "AND e.оптовая_продажа=true AND e.дата>=@dataStart AND e.дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round( value,2);
        }

        public double GetProdazhaRozn(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                                     " WHERE d.кодпродажи=e.кодпродажи " +
                                     "AND e.оптовая_продажа=false AND e.код_клиента IS NULL AND e.дата>=@dataStart AND e.дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round (value,2);
        }

        public double GetPlatezhRozn(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                          " WHERE d.кодпродажи=e.кодпродажи " +
                        "AND e.оптовая_продажа=false AND e.код_клиента IS NULL AND e.дата>=@dataStart AND e.дата<=@dataEnd", startData, endData);

            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);

        }

        public double GetPlatezhOpt(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("SELECT Sum(сумма_платежа) " +
                                    " FROM public.платежи" +
                                    " WHERE код_клиента IS NOT NULL " +
                                    "AND дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);

        }

        public double GetVozvratRozn(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NULL AND дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);
        }

        public double GetVozvratOpt(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NOT NULL AND дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);
        }

        public double GetVozvratProshRozn(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NULL AND накладной_текст IS NULL AND дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);
        }

        public double GetVozvratProshOpt(DateTime startData, DateTime endData)
        {
            DataTable dt = db.GetByParametrPeriod("Select Sum(сумма_возврата) FROM public.возврат " +
                                           "WHERE код_клиента IS NOT NULL AND накладной_текст IS NULL" +
                                           " AND дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);

        }

        public double GetRaskhodi(DateTime startData, DateTime endData)
        {
            DataTable dt= db.GetByParametrPeriod("Select Sum(сумма_расхода_смн) FROM public.расходы WHERE дата>=@dataStart AND дата<=@dataEnd", startData, endData);
            double value = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                value = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round(value, 2);
        }

        public Tuple<double, double> GetProtsenti(DateTime startData, DateTime endData)
        {
            double protsentiRozn = 0;
            double protsentiOpt = 0;

            DataTable dt = db.GetByQuery("Select розничный_процент, оптовый_процент FROM public.процент");
            var b = dt.Rows[0][0].ToString();
            if (b != "")
            {
                protsentiOpt =Math.Round((GetPlatezhOpt(startData, endData) - GetVozvratOpt(startData, endData)) * Convert.ToInt32(dt.Rows[0][1])/100,2 );
                protsentiRozn =Math.Round( (GetPlatezhRozn(startData, endData) - GetVozvratRozn(startData, endData)) * Convert.ToInt32(dt.Rows[0][0]) / 100,2 );
            }

            return Tuple.Create(protsentiOpt, protsentiRozn);
        }

        public Tuple<double, double> GetItogiKassi(DateTime startData, DateTime endData)
        {
            double kassaOpt = Math.Round(GetPlatezhOpt(startData, endData) - GetVozvratOpt(startData, endData), 2);
            double kassaRozn = Math.Round(GetPlatezhRozn(startData, endData) - GetVozvratRozn(startData, endData) -GetRaskhodi(startData, endData), 2);
            return Tuple.Create(kassaOpt, kassaRozn);
        }

        public double GetOstatok(DateTime startData, DateTime endData)
        {
            return Math.Round((GetProdazhaOpt(startData, endData) + GetProdazhaRozn(startData, endData)) - 
                (GetPlatezhRozn(startData, endData) + GetPlatezhOpt(startData, endData)),2);
        }
        
        public Tuple<int, int> GetProtsent()
        {
            DataTable dt = db.GetByQuery("Select розничный_процент, оптовый_процент FROM public.процент");
            int rozn = Convert.ToInt32(dt.Rows[0][0].ToString());
            int opt = Convert.ToInt32(dt.Rows[0][1].ToString());
            return Tuple.Create(rozn, opt);
        }

        public DataTable GetProdovetItog(DateTime startData, DateTime endData)
        {
            return db.GetByParametrPeriod("SELECT p.продавец, prodazha.продажа, " +
               "raskhodi.расходы, vozvrat.возврат, prodazha.продажа-(raskhodi.расходы + vozvrat.возврат) as итоги, " +
               "p.процент, (prodazha.продажа-(raskhodi.расходы+vozvrat.возврат))*p.процент/100 as процент_за_реализацию FROM public.продавцы p " +
               "LEFT JOIN " +

               "(SELECT e.продавец, Sum(d.количество*d.цена) as продажа FROM public.продажа e , public.продажа_товара d" +
                " WHERE d.кодпродажи=e.кодпродажи " +
                "AND e.оптовая_продажа=false AND e.дата>=@dataStart AND e.дата<=@dataEnd GROUP BY e.продавец) prodazha " +
                "ON p.продавец=prodazha.продавец " +

                "LEFT JOIN " +
                "(SELECT фио_продавца as продавец, Sum(сумма_расхода_смн) as расходы FROM public.расходы WHERE дата>=@dataStart AND дата<=@dataEnd GROUP BY фио_продавца) raskhodi " +
                "ON p.продавец=raskhodi.продавец " +
                 
                "LEFT JOIN " +
                "(Select e.продавец, Sum(v.сумма_возврата) as возврат FROM public.возврат v, public.продажа e " +
                 "WHERE v.накладной_текст=e.накладной_текст AND v.код_клиента IS NULL AND v.дата>=@dataStart AND v.дата<=@dataEnd GROUP BY e.продавец) vozvrat " +
                 "ON p.продавец=vozvrat.продавец", startData, endData);

        }


        public DataTable GetSkidkaSpetsPred(DateTime startData, DateTime endData, int skidka)
        {
           return db.GetByParametrPeriod("SELECT e.накладной_текст, e.дата, Sum(d.количество*d.цена) as сумма, e.скидка, e.примечание  FROM public.продажа e , public.продажа_товара d" +
             " WHERE d.кодпродажи=e.кодпродажи AND e.скидка>='"+ skidka +"'" +
             "AND e.дата>=@dataStart AND e.дата<=@dataEnd GROUP BY e.накладной_текст, e.дата, e.скидка, e.примечание", startData, endData);

        }
    }
}
