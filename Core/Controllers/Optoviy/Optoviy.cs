using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Optoviy
{
    class Optoviy
    {
        private DBNpgsql db = new DBNpgsql();


        public DataTable SelectAllArtikul()
        {
            return db.GetByQuery("SELECT артикул FROM public.товар WHERE количество>0 AND розн_цена__euro_ IS NOT NULL " +
                "AND розн_цена__euro_ >0 ");
        }

        public DataTable SelectTovarByArtikulDGV(string tsena, string artikul)
        {
            return db.GetByQuery("SELECT артикул, наименование, бренд, марка, модель, количество, " + tsena + " " +
                                    "FROM public.товар WHERE количество>0 AND " + tsena + " IS NOT NULL AND " + tsena + ">0 " +
                                    "AND артикул= '" + artikul + "'");
        }


        public string GetUrovenTsenKlienta(string uroven)
        {
            DataTable dt= db.GetByQuery("SELECT цена FROM public.уровень_цен " +
                                    "WHERE уровень= '" + uroven + "'");
            string value = "";

            if (dt.Rows.Count != 0)
            {
                value = dt.Rows[0]["цена"].ToString();

            }
            return value;


        }


        public string GetAlternativa(string artikul)
        {
            DataTable dt= db.GetByQuery("SELECT альтернатива FROM public.товар WHERE количество>0 AND розн_цена__euro_ IS NOT NULL " +
                "AND розн_цена__euro_ >0 AND артикул= '" + artikul + "'");

            string value = "";

            if (dt.Rows.Count != 0)
            {
                value = dt.Rows[0]["альтернатива"].ToString();

            }
            return value;

        }



        public DataTable SelectTovarByAlternativa(string[,] filter, string tsena)
        {

            //DataTable dataTable = new DataTable();
            string sqlQuery = "SELECT артикул, наименование, бренд, марка, " +
                "модель, альтернатива, количество, " + tsena + ", группа, место_на_складе FROM public.товар WHERE количество>0 AND ";

            for (int i = 0; i < (filter.Length) / 2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i, 1] + "'" + " AND ";
            }
            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 5, 5);


            return db.GetByQuery(sqlQuery); ;
        }


        public DataTable getviborVariant(string artikul, string tsena)
        {
            return db.GetByQuery("Select артикул, наименование, бренд, марка, " +
                "модель, количество, " + tsena + "  FROM public.товар WHERE артикул LIKE '" + artikul + "'");
        }


              
        public void InsertProdazha(double kurs, string prodavets, string propis, string naklText, string kod_klienta)
        {
            db.insertWithParametrDouble("INSERT INTO public.продажа (курс_валюты, продавец, " +
                  "прописью, код_клиента, накладной_текст, оптовая_продажа) VALUES (@kurs, '" + prodavets + "', '" + propis + "', " +
                   "'" + kod_klienta + "', '" + naklText + "', true)","kurs", kurs);

        }


        public void InsertVozvratPerechen(int kod, string artikul, int kol, double suma)
        {

            db.insertWithParametrDouble("INSERT INTO public.перечень_возврата(" +
                "код_возврата, артикул, количество, сумма) " +
                " VALUES ('" + kod + "','" + artikul + "', '" + kol + "', @suma)", "suma", suma);

        }
        public void InsertVozvratProshlogod(string kodKlienta)
        {
            db.insertUpdateToDB("INSERT INTO public.возврат_прошлогодный (код_клиента)" +
                     " VALUES('" + kodKlienta + "')");

        }


        public string SelectSummaVozvrata(int kod)
       {
                        
            DataTable dt= db.GetByQuery("Select Sum(сумма)" +
                    " FROM public.перечень_возврата " +
                    "WHERE код_возврата ='" + kod + "'");
            string suma="";
            
            if (dt.Rows.Count != 0)
            {
                suma = dt.Rows[0]["sum"].ToString();

            }
            return suma;

        }


        public string SelectProshlogodVozvrata()
        {

            DataTable dt = db.GetByParametrDate("Select дата" +
                    " FROM public.возврат_прошлогодный " +
                    "WHERE дата =@data", "data");
            string suma = "";

            if (dt.Rows.Count != 0)
            {
                suma = dt.Rows[0]["дата"].ToString();

            }
            return suma;

        }




        public string ProverkaNaNalichieVozvrata(string naklTxt)
        {

            DataTable dt = db.GetByQuery("Select SUM(сумма_возврата) as сумма" +
                    " FROM public.возврат " +
                    "WHERE накладной_текст ='" + naklTxt + "'");
            string suma = "";

            if (dt.Rows.Count != 0)
            {
                suma = dt.Rows[0]["сумма"].ToString();

            }
            return suma;

        }


        public void UpdateVozvrat(int kod, string propis, double suma)
        {
            db.insertWithParametrDouble("UPDATE public.возврат " +
            "SET прописью ='" + propis + "', сумма_возврата =@suma " +
            "WHERE код_возврата ='" + kod + "'","suma", suma);
        }

        public void DeleteVozvrat(string naklText, int kod)
        {
            db.insertUpdateToDB("DELETE FROM public.возврат " +
                        "WHERE накладной_текст ='" + naklText + "' AND код_возврата ='" + kod + "'");
        }


        public DataTable printCkekQuery(int kod)
        {

            return db.GetByQuery("SELECT e.дата as data, e.накладной_текст as nakText, e.код_клиента as kodKlienta, e.прописью as propis, " +
                                 "d.артикул as artikul, d.сумма as suma , d.количество as kolichestvo, k.наименование as naimenovanie, k.бренд as brand, " +
                                 "k.марка as marka, k.модель as model, g.названиекомпании as komp FROM public.возврат e, public.перечень_возврата d, " +
                                 "public.товар k, public.сведения_об_организации g WHERE e.код_возврата=d.код_возврата AND d.артикул=k.артикул " +
                                 "AND e.код_возврата= '" + kod + "'");
            
        }


    }
}
