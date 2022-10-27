using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.VozvratKlas
{
    class VozvratKlas : DBNpgsql
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectDataDGV(string naklTxt)
        {
            return db.GetByQuery("SELECT d.артикул as артикул, d.количество, d.цена, d.количество*d.цена as suma, e.дата " +
                                    "FROM public.продажа e , public.продажа_товара d " +
                                    "WHERE d.кодпродажи=e.кодпродажи " +
                                    "AND e.накладной_текст= '" + naklTxt + "'");
        }

        public DataTable SelectNomerNakladnoy()
        {
            return db.GetByQuery("Select накладной_текст FROM public.продажа");
        }

        public DataTable SelectNomerNakladnoyByKodKlienta(string kodKlienta)
        {
            return db.GetByQuery("Select накладной_текст FROM public.продажа " +
                "WHERE код_клиента='" + kodKlienta + "'");
        }

        public DataTable SelectArtikulByKodKlienta(string kodKlienta)
        {
            return db.GetByQuery("Select d.артикул " +
                "FROM public.продажа e , public.продажа_товара d " +
                "WHERE d.кодпродажи=e.кодпродажи AND " +
                "e.код_клиента='" + kodKlienta + "'");
        }


        public DataTable SelectKodKlienta()
        {
            return db.GetByQuery("Select e.код_клиента, d.фио FROM public.продажа e , public.customers d " +
                "WHERE d.код_клиента=e.код_клиента");
        }

        public DataTable SelectAllKodKlienta()
        {
            return db.GetByQuery("Select код_клиента FROM public.customers");
        }

        public DataTable SelectArtikul()
        {
            return db.GetByQuery("Select артикул FROM public.продажа_товара");
        }

        public int SelectNomerVozvrata(string naklText)
        {
            int kod = 0;
            DataTable dt= db.GetByQuery("Select код_возврата FROM public.возврат " +
                "WHERE накладной_текст='" + naklText + "'" +
                "ORDER BY код_возврата DESC LIMIT 1");
            
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                  
                    kod = int.Parse(dr[0].ToString());
                }

            }
            
            return kod;

        }

        

        public void InsertVozvrat(string naklText, string kod_klienta)
        {
          if(kod_klienta!="")
            db.insertUpdateToDB("INSERT INTO public.возврат (накладной_текст, " +
                "код_клиента)" +
                " VALUES('" + naklText + "', '" + kod_klienta + "')");
           else
                db.insertUpdateToDB("INSERT INTO public.возврат (накладной_текст)" +
                      " VALUES('" + naklText + "')");

        }


        public void InsertVozvratPerechen(int kod, string artikul, int kol, double suma)
        {

            db.insertWithParametrDouble("INSERT INTO public.перечень_возврата(" +
                "код_возврата, артикул, количество, сумма) " +
                " VALUES ('" + kod + "','" + artikul + "', '" + kol + "', @suma)", "suma", suma);

        }


        public string SelectSummaVozvrata(int kod)
       {
                        
            DataTable dt= db.GetByQuery("Select Sum(сумма)" +
                    " FROM public.перечень_возврата " +
                    "WHERE код_возврата ='" + kod + "'");
            string suma="";
            Double sumVoz = 0;
            if (dt.Rows.Count != 0)
            {
                suma = dt.Rows[0]["sum"].ToString();

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


        public void UpdateVozvrat(string naklText, int kod, string propis, double suma)
        {
            db.insertWithParametrDouble("UPDATE public.возврат " +
            "SET прописью ='" + propis + "', сумма_возврата =@suma " +
            "WHERE накладной_текст ='" + naklText + "' AND код_возврата ='" + kod + "'","suma", suma);
        }

        public void DeleteVozvrat(string naklText, int kod)
        {
            db.insertUpdateToDB("DELETE FROM public.возврат " +
                        "WHERE накладной_текст ='" + naklText + "' AND код_возврата ='" + kod + "'");
        }


        public DataTable printCkekQuery(string naklTxt, int kod)
        {

            return db.GetByQuery("SELECT e.дата as data, e.накладной_текст as nakText, e.код_клиента as kodKlienta, e.прописью as propis, " +
                                 "d.артикул as artikul, d.сумма as suma , d.количество as kolichestvo, k.наименование as naimenovanie, k.бренд as brand, " +
                                 "k.марка as marka, k.модель as model, g.названиекомпании as komp FROM public.возврат e, public.перечень_возврата d, " +
                                 "public.товар k, public.сведения_об_организации g WHERE e.код_возврата=d.код_возврата AND d.артикул=k.артикул " +
                                 "AND e.накладной_текст= '" + naklTxt + "' AND e.код_возврата= '" + kod + "'");
            
        }


        public DataTable GetByParametrDate(DateTime dataStart, DateTime dataEnd, string artikul)
        {
            DataTable dataTable = new DataTable();
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            NpgsqlCommand sql = conn.CreateCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText = "Select e.накладной_текст as №_накл, d.артикул, d.количество, d.цена, d.количество*d.цена as сумма FROM public.продажа e , " +
                               "public.продажа_товара d WHERE e.кодпродажи=d.кодпродажи AND d.артикул='" + artikul + "'" +
                               "AND e.дата>=@dataStart AND e.дата<=@dataEnd";
            sql.Parameters.Add("dataStart", NpgsqlDbType.Date).Value = dataStart;
            sql.Parameters.Add("dataEnd", NpgsqlDbType.Date).Value = dataEnd;

            NpgsqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dataTable.Load(dr);
            }

            sql.Dispose();
            conn.Close();

            return dataTable;
        }


    }
}
