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
            return db.GetByQuery("Select om.артикул, t.наименование, t.бренд, t.марка, t.количество, " +
                "om.поступление, om.пагащение, t.место_на_складе FROM public.обмен_магазинами om, public.товар t  WHERE om.артикул=t.артикул AND om.код_магазина='" + kod + "' AND om.тип='" + type + "' ");
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


        public void UpdatePriyomPostuplenie(string artikul, string kodMagazina, int kol, string type)
        {
            db.insertUpdateToDB("UPDATE public.обмен_магазинами SET поступление=поступление+'" + kol + "' WHERE артикул = '" + artikul + "' " +
                "AND тип='" + type + "' AND код_магазина='" + kodMagazina + "'");
        }

        public void DeletePriyomPostuplenie(string artikul, string kodMagazina, string type)
        {
            db.insertUpdateToDB("DELETE FROM public.обмен_магазинами WHERE артикул = '" + artikul + "' " +
                "AND тип='" + type + "' AND код_магазина='" + kodMagazina + "'");
        }

        public void InsertPriyomPostuplenie(string artikul, string kodMagazina, int kol, string type)
        {
            db.insertUpdateToDB("INSERT INTO public.обмен_магазинами (код_магазина, артикул, поступление, тип) " +
                "VALUES ('" + kodMagazina + "', '" + artikul + "', '" + kol + "', '" + type + "')");
        }

        public DataTable SelectPriyomSdachaTemp(string kodMagazina, string type)
        {
            return db.GetByQuery("SELECT артикул as artikul, наименование as naimenovanie, бренд as brand, марка as marka," +
                " количество as kolichestvo, место_на_складе as mesto FROM public.temp_обмен_магазинами WHERE код_магазина='" + kodMagazina + "' AND тип='" + type + "'");
        }

        public void InsertPriyomSdachaTemp(string artikul, string naim, string brand, string marka, string mesto, string kodMagazina, int kol, string type)
        {
            db.insertUpdateToDB("INSERT INTO public.temp_обмен_магазинами (артикул, наименование, бренд, марка, место_на_складе, количество, код_магазина, тип) " +
                "VALUES ('" + artikul + "', '" + naim + "', '" + brand + "','" + marka + "','" + mesto + "', '" + kol + "', '" + kodMagazina + "', '" + type + "')");
        }

        public void DeletePriyomSdachaTemp( string kodMagazina, string type)
        {
            db.insertUpdateToDB("DELETE FROM public.temp_обмен_магазинами WHERE код_магазина='" + kodMagazina + "' AND тип='" + type + "'");
        }

        public void DeletePriyomSdachaTempAll()
        {
            db.insertUpdateToDB("DELETE FROM public.temp_обмен_магазинами");
        }

        public void UpdatePriyomPogashenie(string artikul, string kodMagazina, int kol, string type)
        {   db.insertUpdateToDB("UPDATE public.обмен_магазинами SET поступление=поступление-'" + kol + "' WHERE артикул = '" + artikul + "' " +
                    "AND тип='" + type + "' AND код_магазина='" + kodMagazina + "'");
        }

        public int OstatokDolga(string artikul, string kodMagazina, int kol, string type)
        {
            DataTable dt= db.GetByQuery("Select * FROM public.обмен_магазинами WHERE артикул='" + artikul + "' AND код_магазина='" + kodMagazina + "' AND тип='" + type + "' ");
            return Convert.ToInt32(dt.Rows[0][2]) - kol;
        }

        

    }
}
