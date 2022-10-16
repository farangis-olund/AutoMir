using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using System.Drawing;

namespace Core.Controllers.Sklad
{
    class Sklad
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectDataSklad(string naklTxt)
        {
                return db.GetByQuery("SELECT e.дата as date, e.оплачено as oplacheno, " +
                                        "d.артикул as артикул, c.наименование as наименование, d.количество*d.цена as сумма " +
                                        "FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.накладной_текст= '" + naklTxt + "' AND e.оплачено=true AND e.склад=false");
        }

        public DataTable SelectNomerNakladnoy()
        {
            return db.GetByQuery("Select накладной_текст FROM public.продажа WHERE оплачено=true AND склад=false");
        }


        public void updateProdazha(string naklTxt, bool sklad)
        {
           db.updateDB("UPDATE public.продажа SET склад =true WHERE накладной_текст ='" + naklTxt + "'");
        }
    }
}
