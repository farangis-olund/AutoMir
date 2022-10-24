using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Chek
{
    class Chek : DBNpgsql
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable GetByParametrDate(DateTime dataStart, DateTime dataEnd)
        {
            DataTable dataTable = new DataTable();
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            NpgsqlCommand sql = conn.CreateCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText = "Select d.артикул, c.наименование as Naimenovanie, d.цена as Tsena, SUM(d.количество) as Kolichestvo, SUM(d.количество*d.цена) as Suma FROM public.продажа e , " +
                               "public.продажа_товара d, public.товар c WHERE e.кодпродажи=d.кодпродажи AND d.артикул=c.артикул AND e.chek=true " +
                               "AND e.дата>=@dataStart AND e.дата<=@dataEnd GROUP BY d.артикул, c.наименование, d.цена";
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





        public string SelectSumaProdazhiWithChek()
        {
            
            DataTable dt= db.GetByParametrDate("Select d.количество*d.цена as suma FROM public.продажа e , " +
                                               "public.продажа_товара d WHERE d.кодпродажи=e.кодпродажи AND e.chek=true AND e.дата= @data GROUP BY suma", "data");
            double suma =0;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                   suma = suma+Convert.ToDouble(dr[0]);
                }

            }

            return suma.ToString();
        }

        public int SelectNomerVozvrata()
        {
            int kod = 0;
            DataTable dt= db.GetByQuery("Select код_возврата FROM public.отмена_продажи ORDER BY код_возврата DESC LIMIT 1");
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                  
                    kod = int.Parse(dr[0].ToString());
                }

            }
            kod = kod + 1;
            return kod;

        }



        public void updateProdazha(string naklTxt, string artikul, int kol)
        {
            db.updateDB("UPDATE public.продажа_товара pt " +
                        "SET количество ='" + kol + "' " +
                        "FROM  public.продажа p " +
                        "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст ='" + naklTxt + "' and pt.артикул ='" + artikul + "'");
        }


        public void DeleteProdazhaTovara(string naklTxt, string artikul)
        {
            db.updateDB("DELETE FROM public.продажа_товара pt " +
                       "USING public.продажа p " +
                       "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст ='" + naklTxt + "' and pt.артикул ='" + artikul + "'");

        }


        public void DeleteProdazha(string naklTxt)
        {
            db.updateDB("DELETE FROM public.продажа " +
                       "WHERE накладной_текст ='" + naklTxt + "'");

        }

        public void InsertOtmenaProdazh(string naklText, string artikul)
        {
            
            db.insertToDB("INSERT INTO public.отмена_продажи (артикул, количество, цена, " +
                "код_клиента, накладной_текст, чек) " +
                "SELECT pt.артикул, pt.количество, pt.цена, p.код_клиента, p.накладной_текст, p.chek " +
                 "FROM public.продажа p , public.продажа_товара pt " +
                 "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст= '" + naklText + "' AND pt.артикул ='" + artikul + "'");


        }

       

        public string SelectSummaOtmenaProdazh(string naklText, int kod)
        {
                        
            DataTable dt= db.GetByQuery("Select SUM(сумма) as сумма" +
                    " FROM отмена_продажи WHERE накладной_текст ='" + naklText + "' AND код_возврата ='" + kod + "'");
            string suma="";

            if (dt.Rows.Count != 0)
            {
                suma = dt.Rows[0]["сумма"].ToString();

            }
            return suma;

        }


        public void UpdatePropisOtmenaProdazh(string naklText, string propis)
        {

            db.updateDB("UPDATE public.отмена_продажи " +
                        "SET прописью ='" + propis + "'" +
                        "WHERE накладной_текст ='" + naklText + "'");


        }


        public DataTable printCkekQuery(string naklTxt, int kod)
        {

            return db.GetByQuery("SELECT e.дата as data, e.накладной_текст as nakText, e.код_клиента as kodKlienta, e.чек as chek, e.прописью as propis, c.место_на_складе as mesto, " +
                                 "e.артикул as artikul, e.количество*e.цена as suma , e.количество_возврата as kolichestvo, e.цена as tsena, c.наименование as naimenovanie, c.бренд as brand, " +
                                 "c.марка as marka, c.модель as model, g.названиекомпании as komp FROM public.отмена_продажи e, " +
                                 "public.товар c, public.сведения_об_организации g WHERE e.артикул=c.артикул " +
                                 "AND e.накладной_текст= '" + naklTxt + "' AND e.код_возврата= '" + kod + "'");
            
        }



        public void updateChekProdazha(string nakTxt)
        {
            db.updateDB("UPDATE public.продажа " +
                       "SET chek =True" +
                       " WHERE накладной_текст ='" + nakTxt + "'");
        }


        public string chekProdazhaIsExist(string naklText)
        {
            DataTable dt = db.GetByParametrDate("Select chek FROM public.продажа " +
                                              "WHERE накладной_текст= '" + naklText + "' AND дата= @data", "data");
            string isExist = "";
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    isExist = dr[0].ToString();
                }

            }

            return isExist;
        }
    
    
    }
}
