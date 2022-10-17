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


        public void updateProdazha(string naklTxt, bool sklad)
        {
            db.updateDB("UPDATE public.продажа SET склад =true WHERE накладной_текст ='" + naklTxt + "'");
        }
    }
}
