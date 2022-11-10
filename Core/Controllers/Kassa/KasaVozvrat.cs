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
            return db.GetByQuery("Select накладной_текст FROM public.возврат WHERE оплачено =False GROUP BY накладной_текст");

        }


        public DataTable SelectDataVozvratKassa(string naklTxt, string kodVozvrata)
        {
            return db.GetByQuery("SELECT e.дата, " +
                                    "d.артикул as артикул, d.количество, d.сумма " +
                                    "FROM public.возврат e , public.перечень_возврата d" +
                                    " WHERE d.код_возврата=e.код_возврата " +
                                    "AND e.накладной_текст= '" + naklTxt + "' AND e.код_возврата= '" + kodVozvrata + "'");
        }

        public DataTable SelectKodVazvrata(string naklTxt)
        {
            return db.GetByQuery("SELECT код_возврата" +
                                    " FROM public.возврат" +
                                    " WHERE " +
                                    "накладной_текст= '" + naklTxt + "' GROUP BY код_возврата");
        }


        public void updateVozvrat(string naklTxt, int kod)
        {
            db.insertUpdateToDB("UPDATE public.возврат SET оплачено =true WHERE накладной_текст ='" + naklTxt + "' AND код_возврата ='" + kod + "'");
        }

    }
}
