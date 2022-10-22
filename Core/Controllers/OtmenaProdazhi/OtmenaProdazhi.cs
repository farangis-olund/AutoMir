using System.Data;
using Core.DB;


namespace Core.Controllers.OtmenaProdazhi
{
    class OtmenaProdazhi
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectDataDGV(string naklTxt)
        {
            return db.GetByQuery("SELECT d.артикул as артикул, d.количество, d.цена " +
                                    "FROM public.продажа e , public.продажа_товара d " +
                                    "WHERE d.кодпродажи=e.кодпродажи " +
                                    "AND e.накладной_текст= '" + naklTxt + "'");
        }

        public DataTable SelectNomerNakladnoy()
        {
            return db.GetByParametrDate("Select накладной_текст FROM public.продажа WHERE дата>= @data", "data");
        }

        public int SelectNomerVozvrata()
        {
            int kod = 0;
            DataTable dt= db.GetByQuery("Select код_отмена FROM public.отмена_продажи ORDER BY код_возврата DESC LIMIT 1");
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
                    " FROM отмена_продажи WHERE накладной_текст ='" + naklText + "' AND код_отмена ='" + kod + "'");
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
                                 "AND e.накладной_текст= '" + naklTxt + "' AND e.код_отмена= '" + kod + "'");
            
        }



    }
}
