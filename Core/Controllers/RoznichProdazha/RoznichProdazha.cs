using System;
using System.Data;
using Core.DB; 

namespace Core.Controllers.RoznProdazha
{

    class RoznichProdazha
    {

        private DBNpgsql db = new DBNpgsql();

        public DataTable Index()
        {
            DataTable dataTable = new DataTable();
            dataTable = db.GetByQuery("Select артикул, наименование, бренд, марка, модель, альтернатива, количество, Розн Цена (Euro) * FROM public.товар");

            return dataTable;
        }

        public DataTable ByFilter(string[,] filter)
        {
                        
            DataTable dataTable = new DataTable();
            string sqlQuery= "SELECT * FROM public.товар WHERE ";
            
            for (int i = 0; i < (filter.Length) /2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i,1] + "'"+ " AND ";
            }
            sqlQuery=sqlQuery.Remove(sqlQuery.Length - 5, 5);
            
            dataTable = db.GetByQuery(sqlQuery);

            // other code

            return dataTable;
        }

               
        public DataTable selectColundDistinct(DataTable mydataTable, string columnName)
        {
            DataView view = new DataView(mydataTable);
            DataTable distinctValues = view.ToTable(true, columnName);
            return distinctValues;
        }


            public void someFunction()
        {
            // do some action
        }

    }
}