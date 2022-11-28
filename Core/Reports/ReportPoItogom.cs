using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Reports.ReportPoItogom

{
    class ReportPoItogom

    {
        private DBNpgsql db = new DBNpgsql();
        public double prodazhaRozn { set; get; }
        public double prodazhaOpt { set; get; }
        public double platezhRozn { set; get; }
        public double platezhOpt { set; get; }
        public double vozvratRozn { set; get; }
        public double vozvratOpt { set; get; }
        public double vozvratProshRozn { set; get; }
        public double vozvratProshOpt { set; get; }
        public double protsentiRozn { set; get; }
        public double protsentiOpt { set; get; }
        public double kassaRozn { set; get; }
        public double kassaOpt { set; get; }
        public double raskhodi { set; get; }
        public double ostatok { set; get; }



        public ReportPoItogom()
        {
            prodazhaRozn=GetProdazhaRozn();
            prodazhaOpt = GetProdazhaOpt();
            platezhOpt = GetPlatezhOpt();
            platezhRozn = GetPlatezhRozn();
            vozvratOpt = GetVozvratOpt();
            vozvratRozn = GetVozvratRozn();
            vozvratProshOpt = GetVozvratProshOpt();
            vozvratProshRozn = GetVozvratProshRozn();
            protsentiOpt = GetProtsenti().Item1;
            protsentiRozn = GetProtsenti().Item2;
            kassaOpt = GetItogiKassi().Item1;
            kassaRozn = GetItogiKassi().Item2;
            raskhodi = GetRaskhodi();
            ostatok = GetOstatok();


        }
        public string ConverterToDoubleWithDot(double value)
        {
           return value.ToString().Replace(",", ".");
        }
        public double GetProdazhaOpt()
        {
            DataTable dt = db.GetByParametrDate("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                                     " WHERE d.кодпродажи=e.кодпродажи " +
                                     "AND e.оптовая_продажа=true AND e.дата=@data", "data");
            prodazhaOpt = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                prodazhaOpt = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round( prodazhaOpt,2);
        }

        public double GetProdazhaRozn()
        {
            DataTable dt = db.GetByParametrDate("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                                     " WHERE d.кодпродажи=e.кодпродажи " +
                                     "AND e.оптовая_продажа=false AND e.код_клиента IS NULL AND e.дата=@data", "data");
            prodazhaOpt = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                prodazhaOpt = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round (prodazhaOpt,2);
        }

        public double GetPlatezhRozn()
        {
            DataTable dt = db.GetByParametrDate("SELECT Sum(d.количество*d.цена) as сумма FROM public.продажа e , public.продажа_товара d" +
                      " WHERE d.кодпродажи=e.кодпродажи " +
                      "AND e.оптовая_продажа=false AND e.код_клиента IS NULL AND e.дата=@data", "data");

            platezhRozn = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                platezhRozn = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round( platezhRozn,2);

        }

        public double GetPlatezhOpt()
        {
            DataTable dt = db.GetByParametrDate("SELECT Sum(сумма_платежа) " +
                                    " FROM public.платежи" +
                                    " WHERE код_клиента IS NOT NULL " +
                                    "AND дата=@data", "data");
            platezhOpt = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                platezhOpt = Convert.ToDouble(dt.Rows[0][0]);
            return Math.Round( platezhOpt,2);

        }

        public double GetVozvratRozn()
        {
            DataTable dt = db.GetByParametrDate("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NULL AND дата=@data", "data");
            vozvratRozn = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                vozvratRozn = Convert.ToDouble(dt.Rows[0][0]);

            return Math.Round( vozvratRozn,2 );
        }

        public double GetVozvratOpt()
        {
            DataTable dt = db.GetByParametrDate("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NOT NULL AND дата=@data", "data");
            vozvratOpt = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                vozvratOpt = Convert.ToDouble(dt.Rows[0][0]);

            return Math.Round( vozvratOpt,2);
        }

        public double GetVozvratProshRozn()
        {
            DataTable dt = db.GetByParametrDate("Select Sum(сумма_возврата) FROM public.возврат " +
                                       "WHERE код_клиента IS NULL AND накладной_текст IS NULL AND дата=@data", "data");
            vozvratProshRozn = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                vozvratProshRozn = Convert.ToDouble(dt.Rows[0][0]);

            return Math.Round( vozvratProshRozn,2 );
        }

        public double GetVozvratProshOpt()
        {
            DataTable dt = db.GetByParametrDate("Select Sum(сумма_возврата) FROM public.возврат " +
                                           "WHERE код_клиента IS NOT NULL AND накладной_текст IS NULL" +
                                           " AND дата=@data", "data");
            vozvratProshOpt = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                vozvratProshOpt = Convert.ToDouble(dt.Rows[0][0]);

            return Math.Round(vozvratProshOpt, 2 );

        }

        public double GetRaskhodi()
        {
            DataTable dt= db.GetByParametrDate("Select Sum(сумма_расхода_смн) FROM public.расходы WHERE дата=@data", "data");
            raskhodi = 0;
            var b = dt.Rows[0][0].ToString();
            if (b != "")
                raskhodi =Math.Round( Convert.ToDouble(dt.Rows[0][0]),2 );

            return raskhodi;
        }

        public Tuple<double, double> GetProtsenti()
        {
            protsentiRozn = 0;
            protsentiOpt = 0;

            DataTable dt = db.GetByQuery("Select розничный_процент, оптовый_процент FROM public.процент");
            var b = dt.Rows[0][0].ToString();
            if (b != "")
            {
                protsentiOpt =Math.Round((platezhOpt - vozvratOpt) * Convert.ToInt32(dt.Rows[0][1])/100,2 );
                protsentiRozn =Math.Round( (platezhRozn - vozvratRozn) * Convert.ToInt32(dt.Rows[0][0]) / 100,2 );
            }

            return Tuple.Create(protsentiOpt, protsentiRozn);
        }

        public Tuple<double, double> GetItogiKassi()
        {
            kassaOpt = Math.Round(platezhOpt - vozvratOpt, 2);
            kassaRozn = Math.Round(platezhRozn - vozvratRozn-raskhodi, 2);
            return Tuple.Create(kassaOpt, kassaRozn);
        }

        public double GetOstatok()
        {
            return ostatok =Math.Round((prodazhaOpt + prodazhaRozn) - (platezhRozn + platezhOpt),2);
        }
        public DataTable ItogoReport()
        {
            DataTable dt =new DataTable(); ;
            dt.Columns.Add("prodazhaRozn");
            dt.Columns.Add("prodazhaOpt");
            dt.Columns.Add("platezhRozn");
            dt.Columns.Add("platezhOpt");
            dt.Columns.Add("vozvratRozn");
            dt.Columns.Add("vozvratOpt");
            dt.Columns.Add("protsentiRozn");
            dt.Columns.Add("protsentiOpt");
            dt.Columns.Add("kassaRozn");
            dt.Columns.Add("kassaOpt");
            dt.Columns.Add("raskhodi");
            dt.Columns.Add("ostatok");

            dt.Rows.Add();
            dt.Rows[0][0] =prodazhaRozn;
            dt.Rows[0][1] = prodazhaOpt;
            dt.Rows[0][2] = platezhRozn;
            dt.Rows[0][3] = platezhOpt;
            dt.Rows[0][4] = vozvratRozn;
            dt.Rows[0][5] = vozvratOpt;
            dt.Rows[0][6] = protsentiRozn;
            dt.Rows[0][7] = protsentiOpt;
            dt.Rows[0][8] = kassaRozn;
            dt.Rows[0][9] = kassaOpt;
            dt.Rows[0][10] = raskhodi;
            dt.Rows[0][11] = ostatok;
            return dt;
        }

    }
}
