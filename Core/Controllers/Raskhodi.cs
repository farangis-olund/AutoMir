using System;
using System.Windows.Forms;
using System.Drawing;
using Core.DB;
using System.Data;

namespace Core.Controllers
{
    class Raskhdi
    {
        DBNpgsql db = new DBNpgsql();

        public DataTable GetNaimenovanie()
        {
            return db.GetByQuery("Select наименование_расхода FROM public.расходы GROUP BY наименование_расхода");
            
        }
        public int GetLastRaskhodi()
        {
            int idLast=0;
            DataTable dt= db.GetByParametrDate("Select idрасходной " +
                "FROM public.расходы " +
                "ORDER BY idрасходной DESC LIMIT 1", "data");
            if (dt.Rows.Count!=0)
                idLast= Convert.ToInt32(dt.Rows[0][0]);
            return idLast+1;
        }

        public DataTable GetRaskhodi(int id)
        {
            return db.GetByParametrDate ("Select idрасходной as Naktext, фио_продавца as KodKlienta, " +
                "наименование_расхода as naimenovanie, описание_расхода as fio, сумма_расхода_смн as Suma " +
                "FROM public.расходы WHERE дата=@data AND " +
                "idрасходной='" + id + "'", "data");

        }

        public void InsertRaskhodi(int id, string fio, string naimenovanie, string opisanie, double sumaSMN,
           double sumaUSD)
        {
            db.insertWithParametrTwoDouble("INSERT INTO public.расходы (idрасходной, фио_продавца, наименование_расхода, описание_расхода, сумма_расхода_смн, сумма_расхода_usd) " +
                "VALUES ('" + id + "', '" + fio + "', '" + naimenovanie + "','" + opisanie + "', @sumaSmn, @sumaUsd )", "sumaSmn", sumaSMN, "sumaUsd", sumaUSD);
        }

        
       
    }
}
