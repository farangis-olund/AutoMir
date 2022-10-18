using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using System.Drawing;
using Npgsql;

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

        public void InsertOtmenaProdazh(string artikul, string naklText)
        {
            //string artikul, int kolProdazhi, double tsena, double suma, int kolVozvrata, string kodKlienta,
            //DateTime data, string propis, string naklText, bool chek

            //db.insertToDB("INSERT INTO public.отмена_продажи (артикул, количество, цена, сумма, количествовозврата, " +
            //    "кодклиента, дата, прописью, накладной_текст, chek) VALUES " +
            //   "('" + artikul + "', '" + kolProdazhi + "', '" + tsena + "', '" + suma + "', '" + kolVozvrata + "'," +
            //   "'" + kodKlienta + "', '" + data + "', '" + propis + "', '" + naklText + "', '" + chek + "') " +
            //   "USING public.продажа p," +
            //   "public.продажа_товара pt" +
            //   "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст ='" + naklText + "' and pt.артикул ='" + artikul + "'");


            db.insertToDB("INSERT INTO public.отмена_продажи (артикул, количество, цена, " +
                "кодклиента, накладной_текст, chek) " +
                "SELECT pt.артикул, pt.количество, pt.цена, p.кодклиента, p.накладной_текст, p.chek " +
                 "FROM public.продажа p , public.продажа_товара pt " +
                 "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст= '" + naklText + "' AND pt.артикул ='" + artikul + "'");


        }

        public void UpdateOtmenaProdazh(string naklText, string artikul, int kol, double suma)
        {

            db.updateDB("UPDATE public.отмена_продажи " +
                        "SET количествовозврата ='" + kol + "', сумма ='" + suma + "' " +
                        "WHERE накладной_текст ='" + naklText + "' and pt.артикул ='" + artikul + "'");


        }

        public string SelectSummaOtmenaProdazh(string naklText)
        {
                        
            DataTable dt= db.GetByQuery("Select Sum(сумма) as сумма" +
                    " FROM отмена_продажи WHERE накладной_текст ='" + naklText + "'");
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

    }
}
