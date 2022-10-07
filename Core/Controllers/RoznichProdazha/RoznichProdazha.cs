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
            //dataTable = db.GetByQuery("Select �������, ������������, �����, �����, " +
            //    "������, ������������, ����������, ����_����__euro_, ������  FROM public.�����");

            return db.GetByQuery("Select �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������,�����_��_������  FROM public.�����");
        }

        public DataTable ByFilterTovar(string[,] filter)
        {
                        
            //DataTable dataTable = new DataTable();
            string sqlQuery= "SELECT �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������, �����_��_������ FROM public.����� WHERE ";
            
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
            dt = db.GetByQuery("SELECT ����_������ FROM public.����_������ ORDER BY ���� DESC LIMIT 1;");
            //CursValyuti= Convert.ToDouble(dt.Rows[0]["����_������"].ToString());
            return Convert.ToDouble(dt.Rows[0]["����_������"].ToString()); 
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
            return db.GetByQuery("Select �������, ������������, �����, �����, " +
                "������, �����_��_������, ����_����__euro_, ����������  FROM public.����� WHERE ������� LIKE '" + artikul + "'");
        }



        public int getNakladnoyNomer(string nakladText)
        {
            int nakNomer = 0;
             DataTable dataTable= db.GetByQuery("SELECT ���������� FROM public.������� WHERE ���������_����� LIKE '" + nakladText + "'");
            foreach (DataRow dr in dataTable.Rows)
            {
                nakNomer = Convert.ToInt32(dr[0]);
            }

           
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
        public void insertProdazha(double kurs, int skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
                {
            //skidka ������__%_,     + skidka + "', '"
            db.insertToDB("INSERT INTO public.������� ( ����_������,  ��������, ��������, ����������, ���������_�����, chek) VALUES " +
                "('" + kurs + "', '" + prodovets + "'," +
                " '" + propis + "', '" + primech + "', '" + naklText + "', '" + chek + "')");            
            
        }

       



        public void someFunction()
        {
            // do some action         
        }



    }

}