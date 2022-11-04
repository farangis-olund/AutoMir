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


        public DataTable GetAllTovar()
        {
            return db.GetByQuery("Select * FROM public.товар ORDER BY артикул ASC");
        }

        public void UpdateTovarKolichestvo(int kol, string artikul, string minusPlus)
        {
            db.insertUpdateToDB ("UPDATE public.товар SET количество=количество" + minusPlus + "" +
             "'" + kol + "' WHERE артикул='" + artikul + "'");
        }


    }
}
