using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.Tovar
{
    class Tovar
    {
        private DBNpgsql db = new DBNpgsql();

        
        
        public DataTable GetArtikul()
        {
            return db.GetByQuery("Select артикул FROM public.товар ");            
        }

        public int GetKolTovara(string artikul)
        {
            DataTable dt=db.GetByQuery("Select количество FROM public.товар WHERE артикул='" + artikul + "'");
            int value = 0;
            if (dt.Rows.Count!=0) value =Convert.ToInt32(dt.Rows[0][0]);
            return value;
        }

        public DataTable GetTovarByArtikul(string artikul)
        {
           return db.GetByQuery("Select * FROM public.товар " +
                                               "WHERE артикул='" + artikul + "'");
        }

        public DataTable GetTovarByArtikulMoreThenNull(string artikul)
        {
            return db.GetByQuery("Select * FROM public.товар " +
                                "WHERE артикул='" + artikul + "' AND количество>0");
        }

        public DataTable GetArtikulMoreThenNull()
        {
            return db.GetByQuery("Select * FROM public.товар " +
                                "WHERE количество>0");
        }

        public DataTable GetAllTovar()
        {
            return db.GetByQuery("Select * FROM public.товар ORDER BY артикул ASC");
        }

        public bool IsTovarExist(string artikul)
        {
            DataTable dt= db.GetByQuery("SELECT exists (SELECT 1 FROM public.товар WHERE артикул = '" + artikul + "' LIMIT 1)");
            return Convert.ToBoolean(dt.Rows[0][0].ToString()); 
        }

        public bool IsPrikhodExist(DateTime data)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.приход WHERE дата =@data LIMIT 1)", data);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public bool IsRaskhodExist(DateTime data)
        {
            DataTable dt = db.GetByParametrDateByUser("SELECT exists (SELECT 1 FROM public.расход WHERE дата =@data LIMIT 1)", data);
            return Convert.ToBoolean(dt.Rows[0][0].ToString());
        }

        public void UpdateTovarKolichestvo(int kol, string artikul, string minusPlus)
        {
            db.insertUpdateToDB ("UPDATE public.товар SET количество=количество" + minusPlus + "" +
             "'" + kol + "' WHERE артикул='" + artikul + "'");
        }

        public void DeletePrikhodOshibkaTovara()
        {
            db.insertUpdateToDB("DELETE FROM public.приход_ошибки");
        }

        public void InsertPrikhodOshibkaTovara(int kol, string artikul)
        {
            db.insertUpdateToDB("INSERT INTO public.приход_ошибки (артикул, приход_расход) " +
                "VALUES ('" + artikul + "', '" + kol + "')");
        }
   
        public void InsertPrikhodTovara(int kol)
        {
            db.insertUpdateToDB("INSERT INTO public.приход (приход_товара) " +
                "VALUES ('" + kol + "')");
        }
        public void InsertRaskhodTovara(int kol)
        {
            db.insertUpdateToDB("INSERT INTO public.расход (расход_товара) " +
                "VALUES ('" + kol + "')");
        }

        public DataTable GetAllSectorTovar()
        {
            return db.GetByQuery("Select DISTINCT LEFT(место_на_складе,1) as сектор FROM public.товар WHERE место_на_складе IS NOT NULL");
        }

        public DataTable GetAllSectorRjadTovar(string sector)
        {
            return db.GetByQuery("Select DISTINCT SUBSTRING(место_на_складе,2,2) as ряд FROM public.товар WHERE LEFT(место_на_складе,1)='" +  sector + "' AND место_на_складе IS NOT NULL");
        }

        public DataTable GetAllTovarBySectorRjad(string sector, string rjad)
        {
            return db.GetByQuery("Select место_на_складе as место, артикул, наименование, бренд, марка, модель, количество FROM public.товар WHERE SUBSTRING(место_на_складе,2,2)='" + rjad + "' AND LEFT(место_на_складе,1)='" + sector + "' AND место_на_складе IS NOT NULL");
        }

        public DataTable GetMinDopuskKolTovara()
        {
            return db.GetByQuery("Select *, мин_допустимое_кол-количество as необ_кол FROM public.товар WHERE количество< мин_допустимое_кол ");
        }

        public DataTable GetBrand()
        {
            return db.GetByQuery("Select DISTINCT бренд FROM public.товар WHERE бренд IS NOT NULL");
        }

    }
}
