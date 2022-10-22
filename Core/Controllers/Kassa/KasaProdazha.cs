using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.KasaProdazha

{
    class KasaProdazha 
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectNakNomer()
        {
            return db.GetByQuery("Select накладной_текст FROM public.продажа WHERE оплачено =False");

        }

        public DataTable SelectDataProdazhaKassa(string naklTxt)
        {
            return db.GetByQuery("SELECT e.дата, " +
                                    "d.артикул as артикул, d.количество, d.цена, d.количество*d.цена as сумма, e.chek " +
                                    "FROM public.продажа e , public.продажа_товара d" +
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
