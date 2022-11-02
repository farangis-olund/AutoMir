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

        public void InsertPlatezh(double suma, string propis, string naklText, string kod_klienta)
        {
            db.insertWithParametrDouble("INSERT INTO public.платежи (" +
                  "прописью, код_клиента, накладной_текст, сумма_платежа) VALUES ('" + propis + "', " +
                   "'" + kod_klienta + "', '" + naklText + "', @suma)", "suma", suma);

        }

        public string getLastNakladnoyText()
        {
            DataTable dt = db.GetByQuery("SELECT накладной_текст FROM public.продажа ORDER BY накладной_текст DESC LIMIT 1;");

            return dt.Rows[0][0].ToString();
            
        }


        public DataTable printCkekQuery(string naklTxt)
        {

            return db.GetByQuery("SELECT e.дата as date, e.накладной_текст as nakText, e.прописью as propis, c.место_на_складе as mesto, e.код_клиента as kodKlienta, " +
                                        "d.артикул as artikul, d.количество as kolichestvo, d.цена as tsena, c.бренд as brand, " +
                                        "c.марка as marka, c.модель as model,c.наименование as naimenovanie, g.названиекомпании as komp FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c, public.сведения_об_организации g WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.накладной_текст='" + naklTxt + "'");

        }


    }
}
