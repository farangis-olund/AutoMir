using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using System.Drawing;

namespace Core.Controllers.MestoNaSkalde
{
    class MestoNaSklade
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectDistinct()
        {
           

            return db.GetByQuery("Select DISTINCT артикул, наименование, группа, бренд, марка, " +
                "модель, группа, место_на_складе  FROM public.товар");
        }

        public DataTable SelectDataForDGV(string artikul)
        {
            return db.GetByQuery("Select артикул, наименование, группа, бренд, марка, " +
                "модель, место_на_складе  FROM public.товар WHERE артикул ='" + artikul + "'");
        }


        public void updateMesto(string artikul, string mesto)
        {
            db.insertUpdateToDB("UPDATE public.товар SET место_на_складе ='" + mesto + "' WHERE артикул ='" + artikul + "'");
        }


    }
}
