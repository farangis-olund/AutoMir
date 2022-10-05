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
            DataTable dataTable = new DataTable();
            dataTable = db.GetByQuery("Select �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������  FROM public.�����");

            return dataTable;
        }

        public DataTable ByFilterTovar(string[,] filter)
        {
                        
            DataTable dataTable = new DataTable();
            string sqlQuery= "SELECT �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������ FROM public.����� WHERE ";
            
            for (int i = 0; i < (filter.Length) /2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i,1] + "'"+ " AND ";
            }
            sqlQuery=sqlQuery.Remove(sqlQuery.Length - 5, 5);
            
            dataTable = db.GetByQuery(sqlQuery);

            // other code

            return dataTable;
        }

        public double GetCursValyuti()
        {
            double CursValyuti = new double();
            DataTable dt = new DataTable();
            dt = db.GetByQuery("SELECT ����_������ FROM public.����_������ ORDER BY ���� DESC LIMIT 1;");
            CursValyuti= Convert.ToDouble(dt.Rows[0]["����_������"].ToString());
            return CursValyuti;
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
    
        public DataTable getInfoKarzina2(string artikul)
        {
            DataTable infoKarzina2 = new DataTable();
            
            
           
                        
            return infoKarzina2;
        }
        
        public void someFunction()
        {
            // do some action
        }

    }

}