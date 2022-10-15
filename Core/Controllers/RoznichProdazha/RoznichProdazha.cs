using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using System.Drawing;

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

        public string GetCursValyuti()
        {
            string cursValyuti="";
            DataTable dt = new DataTable();
            dt = db.GetByQuery("SELECT курс_валюты FROM public.курс_валюты ORDER BY idkurs DESC LIMIT 1;");
            if (dt.Rows.Count != 0)
            {
                cursValyuti= dt.Rows[0]["курс_валюты"].ToString();

            }
           
            return cursValyuti;
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


        public DataTable getNameSeller()
        {
            return db.GetByQuery("Select продавец FROM public.продавцы");
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

        public DataGridView OchistkaDataGridVeiw(ref DataGridView dataGridView)
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


        public DataGridView SumOfColumnDataGridVeiw(ref DataGridView dataGridView, string columnName1, string columnName2, string columnName3, string columnName4, int yesNo)
        {
            double summa1 = 0;
            double summa2 = 0;
            double summa3 = 0;
            double summa4 = 0;
            if (dataGridView.Rows.Count>0)
            {

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (columnName1 != "" && columnName2 != "" && columnName3 != "" && columnName4 != "")
                    {

                        summa1 = summa1 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName1].Value);
                        summa2 = summa2 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName2].Value);
                        summa3 = summa3 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName3].Value);
                        summa4 = summa4 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName4].Value);
                    }

                    else
                    {
                        summa1 = summa1 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName1].Value);
                    }
                }
                var index=0;
                if (yesNo==0)
                { 
                    index = dataGridView.Rows.Add();
                }
                else
                {
                    index = dataGridView.Rows.Count-1;
                    summa1 = summa1 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName1].Value);
                    summa2 = summa2 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName2].Value);
                    summa3 = summa3 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName3].Value);
                    summa4 = summa4 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName4].Value);
                }
                

                if (columnName1 != "" && columnName2 != "" && columnName3 != "" && columnName4 != "")
                {
                    dataGridView.Rows[index].Cells[columnName1].Value = summa1.ToString();
                    dataGridView.Rows[index].Cells[columnName2].Value = summa2.ToString();
                    dataGridView.Rows[index].Cells[columnName3].Value = summa3.ToString();
                    dataGridView.Rows[index].Cells[columnName4].Value = summa4.ToString();
                    
                    dataGridView.Rows[index].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                }
                else
                {
                    dataGridView.Rows[index].Cells[columnName1].Value = summa1.ToString();
                    dataGridView.Rows[index].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                }
            }


            


            return dataGridView;
        }


        public void InsertProdazha(double kurs, int skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
                {
            //skidka скидка__%_,     + skidka + "', '"
            db.insertToDB("INSERT INTO public.продажа ( курс_валюты,  продавец, прописью, примечание, накладной_текст, chek) VALUES " +
                "('" + kurs + "', '" + prodovets + "'," +
                " '" + propis + "', '" + primech + "', '" + naklText + "', '" + chek + "')");            
            
        }

        public void insertKursValyuti(double kurs)
        {
            
            db.insertToDB("INSERT INTO public.курс_валюты ( курс_валюты) VALUES " +
                "('" + kurs + "')");

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


        public DataTable printCkek(string naklTxt) {
            DataTable dt = db.GetByQuery("SELECT e.дата as date, e.накладной_текст as nakText, e.chek as chek, e.прописью as propis, e.скидка as skidka, c.место_на_складе as mesto, " +
                                        "d.артикул as artikul, d.количество as kolichestvo, d.цена as tsena, c.бренд as brand, " +
                                        "c.марка as marka, c.модель as model, g.названиекомпании as komp FROM public.продажа e , public.продажа_товара d, " +
                                        "public.товар c, public.сведения_об_организации g WHERE d.кодпродажи=e.кодпродажи and d.артикул=c.артикул " +
                                        "AND e.накладной_текст= '" + naklTxt + "'");

            return dt;
        }


        public string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }

        public void someFunction()
        {
            // do some action         
        }



    }

}