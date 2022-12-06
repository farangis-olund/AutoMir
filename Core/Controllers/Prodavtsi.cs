using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;

namespace Core.Controllers
{
    class Prodavtsi
    {
        DBNpgsql db = new DBNpgsql();

        public DataTable GetProdavtsi()
        {
            return db.GetByQuery("Select продавец, процент FROM public.продавцы ORDER BY продавец ASC");
            
        }

       


        public void UpdateProdavets(string fio, int protsent)
        {
            db.insertUpdateToDB("UPDATE public.продавцы SET процент='" + protsent + "' WHERE продавец='" + fio + "'");
        }

       

    }
}
