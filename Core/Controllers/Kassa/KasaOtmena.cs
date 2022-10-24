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
            return db.GetByQuery("Select накладной_текст FROM public.отмена_продажи WHERE оплачено =False GROUP BY накладной_текст");

        }

        public DataTable SelectDataOtmena(string naklTxt, int kod)
        {
            return db.GetByQuery("SELECT дата, " +
                                    "артикул, количество_возврата, количество_возврата*цена as сумма" +
                                    " FROM public.отмена_продажи " +
                                    " WHERE накладной_текст= '" + naklTxt + "'" +
                                    "AND код_отмена= '" + kod + "'");
        }

        public DataTable SelectKodOtmena(string naklTxt)
        {
            return db.GetByQuery("Select код_отмена FROM public.отмена_продажи " +
                "WHERE накладной_текст= '" + naklTxt + "' GROUP BY код_отмена");
        }


        public void updateOtmena(string naklTxt, int kod)
        {
            db.updateDB("UPDATE public.отмена_продажи SET оплачено =true " +
                "WHERE накладной_текст ='" + naklTxt + "' AND код_отмена ='" + kod + "'");
        }

    }
}
