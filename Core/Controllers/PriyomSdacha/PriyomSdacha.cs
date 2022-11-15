using System;
using System.Data;
using Core.DB;


namespace Core.Controllers.PriyomSdacha
{
    class PriyomSdacha
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectDataDGV(string artikul)
        {
            return db.GetByQuery("SELECT d.артикул as артикул, d.количество, d.цена " +
                                    "FROM public.продажа e , public.продажа_товара d " +
                                    "WHERE d.кодпродажи=e.кодпродажи " +
                                    "AND e.накладной_текст= '" + artikul + "'");
        }

        public DataTable SelectKodMagazina()
        {
            return db.GetByQuery("Select код_магазина FROM public.магазины");
        }

        public DataTable SelectObmenTovarami(string kod, string type)
        {
            return db.GetByQuery("Select * FROM public.обмен_магазинами WHERE код_магазина='" + kod + "' AND тип='" + type + "' ");
        }

        public bool IsTovarExist(string kodMagazina, string artikul, string type)
        {
            DataTable dt = db.GetByQuery("SELECT exists (SELECT 1 FROM public.обмен_магазинами WHERE артикул = '" + artikul + "' " +
                "AND тип='" + type + "' AND код_магазина='" + kodMagazina + "' LIMIT 1)");
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public bool IsObnovleniePrintExist(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.обновление_товара_статус" +
                " WHERE печать =true " +
                "AND дата=@data LIMIT 1)", date);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public bool IsObnovlenieExportExist(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.обновление_товара_статус" +
                " WHERE экспорт =true " +
                "AND дата=@data LIMIT 1)", date);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public bool IsObnovlenieExportPrintExist(DateTime date)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.обновление_товара_статус" +
                " WHERE дата=@data LIMIT 1)", date);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public void InsertObnovleniePrint(DateTime date)
        {
            db.InsertWithParametrDate("INSERT INTO public.обновление_товара_статус (дата, печать) VALUES (@data, true)", "data", date);
            
        }

        public void UpdateObnovleniePrint(DateTime date)
        {
            db.InsertWithParametrDate("UPDATE public.обновление_товара_статус SET печать=true WHERE дата=@data", "data", date);
        }

        public void InsertObnovlenieExport(DateTime date)
        {
            db.InsertWithParametrDate("INSERT INTO public.обновление_товара_статус (дата, экспорт) VALUES (@data, true)", "data", date);
        }

        public void UpdateObnovlenieExport(DateTime date)
        {
            db.InsertWithParametrDate("UPDATE public.обновление_товара_статус SET экспорт=true WHERE дата=@data", "data", date);
        }

        public void updateProdazha(string naklTxt, string artikul, int kol)
        {
            db.insertUpdateToDB("UPDATE public.продажа_товара pt " +
                        "SET количество ='" + kol + "' " +
                        "FROM  public.продажа p " +
                        "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст ='" + naklTxt + "' and pt.артикул ='" + artikul + "'");
        }


        public void DeleteProdazhaTovara(string naklTxt, string artikul)
        {
            db.insertUpdateToDB("DELETE FROM public.продажа_товара pt " +
                       "USING public.продажа p " +
                       "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст ='" + naklTxt + "' and pt.артикул ='" + artikul + "'");

        }


        public void DeleteProdazha(string naklTxt)
        {
            db.insertUpdateToDB("DELETE FROM public.продажа " +
                       "WHERE накладной_текст ='" + naklTxt + "'");

        }

        public void InsertOtmenaProdazh(string naklText, string artikul)
        {
            
            db.insertUpdateToDB("INSERT INTO public.отмена_продажи (артикул, количество, цена, " +
                "код_клиента, накладной_текст, чек) " +
                "SELECT pt.артикул, pt.количество, pt.цена, p.код_клиента, p.накладной_текст, p.chek " +
                 "FROM public.продажа p , public.продажа_товара pt " +
                 "WHERE pt.кодпродажи=p.кодпродажи AND p.накладной_текст= '" + naklText + "' AND pt.артикул ='" + artikul + "'");

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
