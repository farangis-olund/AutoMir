using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.KasaOtmena

{
    class KasaOtmena
        
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectNakNomer()
        {
            return db.GetByQuery("Select накладной_текст FROM public.отмена_продажи WHERE оплачено =False");

        }

        public DataTable SelectDataProdazhaKassa(string naklTxt)
        {
            return db.GetByQuery("SELECT e.дата, " +
                                    "d.артикул, d.количество_возврата, d.количество_возврата*d.цена as сумма" +
                                    " FROM public.отмена_продажи e , public.продажа_товара d" +
                                    " WHERE d.кодпродажи=e.кодпродажи " +
                                    "AND e.накладной_текст= '" + naklTxt + "'");
        }

        public DataTable SelectDataPlatezhKassa(string naklTxt)
        {
            return db.GetByQuery("SELECT дата, код_клиента, сумма_платежа" +
                                    " FROM public.платежи" +
                                    " WHERE " +
                                    "№_платежа= '" + naklTxt + "'");
        }


        public void updateProdazha(string naklTxt)
        {
            db.updateDB("UPDATE public.продажа SET оплачено =true WHERE накладной_текст ='" + naklTxt + "'");
        }

        public void updatePlatezh(string naklTxt)
        {
            db.updateDB("UPDATE public.платежи SET касса =true WHERE №_платежа ='" + naklTxt + "'");
        }

        public DataTable SelectPlatezh()
        {
            return db.GetByQuery("Select №_платежа FROM public.платежи WHERE касса =false");

        }
    }
}
