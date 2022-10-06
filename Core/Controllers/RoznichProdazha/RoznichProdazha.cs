using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;

namespace Core.Controllers.RoznProdazha
{

    class RoznichProdazha
    {

        private DBNpgsql db = new DBNpgsql();

        public DataTable Index()
        {
            //DataTable dataTable = new DataTable();
            //dataTable = db.GetByQuery("Select артикул, наименование, бренд, марка, " +
            //    "модель, альтернатива, количество, розн_цена__euro_, группа  FROM public.товар");

            return db.GetByQuery("Select артикул, наименование, бренд, марка, " +
                "модель, альтернатива, количество, розн_цена__euro_, группа,место_на_складе  FROM public.товар");
        }

        public DataTable ByFilterTovar(string[,] filter)
        {
                        
            //DataTable dataTable = new DataTable();
            string sqlQuery= "SELECT артикул, наименование, бренд, марка, " +
                "модель, альтернатива, количество, розн_цена__euro_, группа, место_на_складе FROM public.товар WHERE ";
            
            for (int i = 0; i < (filter.Length) /2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i,1] + "'"+ " AND ";
            }
            sqlQuery=sqlQuery.Remove(sqlQuery.Length - 5, 5);
            
            //dataTable = db.GetByQuery(sqlQuery);

            // other code

            return db.GetByQuery(sqlQuery); ;
        }

        public double GetCursValyuti()
        {
            //double CursValyuti = new double();
            DataTable dt = new DataTable();
            dt = db.GetByQuery("SELECT курс_валюты FROM public.курс_валюты ORDER BY дата DESC LIMIT 1;");
            //CursValyuti= Convert.ToDouble(dt.Rows[0]["курс_валюты"].ToString());
            return Convert.ToDouble(dt.Rows[0]["курс_валюты"].ToString()); 
        }
               
        public DataTable selectColumnDistinct(DataTable mydataTable, string columnName)
        {
            DataView view = new DataView(mydataTable);
            DataTable distinctValues = view.ToTable(true, columnName);
            return distinctValues;
        }

        public string[] GetDataGridViewRowinArray(ref DataGridView dgv)
        {
            string[] array = new string[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    array[j] = row.Cells[j].Value.ToString();

                }
            }
            return array;
        }
    
         public DataTable getviborVariant(string artikul)
        {
            return db.GetByQuery("Select артикул, наименование, бренд, марка, " +
                "модель, место_на_складе, розн_цена__euro_, количество  FROM public.товар WHERE артикул LIKE '" + artikul + "'");
        }



        public int getNakladnoyNomer()
        {
             DataTable dataTable= db.GetByQuery("SELECT MAX(№_Накладной) FROM public.продажа;");
            
            
            int nakNomer = Convert.ToInt32(dataTable.Rows[0]);
            return nakNomer;
        }


        public double getRoundDecimal(double number)
        {
            return Math.Round(number, 2);
        }

        public DataGridView ochistkaDataGridVeiw(ref DataGridView dataGridView)
        {
            if (dataGridView.DataSource != null)
            {
                dataGridView.DataSource = null;
            }
            else
            {
                dataGridView.Rows.Clear();
            }
            return dataGridView;
        }

        public void someFunction()
        {
            // do some action
        }


    
    }

}