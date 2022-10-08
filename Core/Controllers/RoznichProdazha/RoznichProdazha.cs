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
                "модель, альтернатива, количество, розн_цена__euro_, группа, место_на_складе FROM public.товар WHERE количество>0 AND ";
            
            for (int i = 0; i < (filter.Length) /2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i,1] + "'"+ " AND ";
            }
            sqlQuery=sqlQuery.Remove(sqlQuery.Length - 5, 5);
            

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



        public int getNakladnoyNomer(string nakladText)
        {
            int nakNomer = 0;
             DataTable dataTable= db.GetByQuery("SELECT кодпродажи FROM public.продажа WHERE накладной_текст LIKE '" + nakladText + "'");
            foreach (DataRow dr in dataTable.Rows)
            {
                nakNomer = Convert.ToInt32(dr[0]);
            }

           
            return nakNomer;
        }

        public string getLastNakladnoyText()
        {

            string nakNomer = "";

            DataTable dataTable = db.GetByQuery("SELECT накладной_текст FROM public.продажа ORDER BY накладной_текст DESC LIMIT 1;");
            
            foreach (DataRow dr in dataTable.Rows)
            {
                nakNomer =dr[0].ToString();
            }
            if (nakNomer == "") nakNomer = "A";

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
            //skidka скидка__%_,     + skidka + "', '"
            db.insertToDB("INSERT INTO public.продажа ( курс_валюты,  продавец, прописью, примечание, накладной_текст, chek) VALUES " +
                "('" + kurs + "', '" + prodovets + "'," +
                " '" + propis + "', '" + primech + "', '" + naklText + "', '" + chek + "')");            
            
        }



        public bool searchDataInDataGridVeiw(ref DataGridView dgv, string artikul, string columnName)
        {

            bool isExist = false;
            //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[columnName].Value == null) break;
                    if (row.Cells[columnName].Value.ToString().Equals(artikul)==true)
                    {
                        isExist = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return isExist;
        }

        public int getKolTovara(string artikul)
        {
            DataTable dt= db.GetByQuery("Select количество  FROM public.товар WHERE артикул LIKE '" + artikul + "'");
            int kolTovara = 0;
            foreach (DataRow dr in dt.Rows)
            {
                kolTovara = Convert.ToInt32(dr[0]);
            }

            return kolTovara;

        }


        public void updateTovarKol(string artikul, int kolichestvo)
        {

            int kolTovara = getKolTovara(artikul)-kolichestvo;
            


            db.updateDB("UPDATE public.товар SET количество = '" + kolTovara + "' WHERE артикул='" + artikul + "'");
        }


        public string nakTextEncrement(string lastNakl)
        {
            string firstPart = "";
            string secondPart="";
            string result = "";
            //A, B, C....AZ
            
            if (lastNakl.Length > 1)
            {
                firstPart = lastNakl.Remove(lastNakl.Length - 1, 1);
                secondPart = lastNakl.Remove(0, lastNakl.Length - 1);
                
            }
            else
            {
                firstPart = "";
                secondPart = lastNakl;
            }
            if (secondPart == "Z")
            {
                result = lastNakl + "A";
            }
            else
            {
                char c1 = Convert.ToChar(secondPart);
                c1++;
                secondPart = c1.ToString();
                result = firstPart + secondPart;
            }
            
            
            return result;


        }

        public void someFunction()
        {
            // do some action         
        }



    }

}