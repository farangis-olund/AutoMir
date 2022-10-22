using System;
using System.Data;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.KasaVozvrat

{
    class KasaVozvrat
        
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable SelectNakNomer()
        {
            return db.GetByQuery("Select накладной_текст FROM public.возврат WHERE оплачено =False");

        }


        public DataTable SelectDataVozvratKassa(string naklTxt, string kodVozvrata)
        {
            return db.GetByQuery("SELECT e.дата, " +
                                    "d.артикул as артикул, d.количество, d.количество*d.цена as сумма " +
                                    "FROM public.возврат e , public.перечень_возврата d" +
                                    " WHERE d.код_возврата=e.код_возврата " +
                                    "AND e.накладной_текст= '" + naklTxt + "' AND e.код_возврата= '" + kodVozvrata + "'");
        }

        public DataTable SelectKodVazvrata(string naklTxt)
        {
            return db.GetByQuery("SELECT код_возврата" +
                                    " FROM public.возврат" +
                                    " WHERE " +
                                    "накладной_текст= '" + naklTxt + "'");
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
