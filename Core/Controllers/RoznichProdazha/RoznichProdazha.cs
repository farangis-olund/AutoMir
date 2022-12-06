using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using NickBuhro.NumToWords.Russian;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;


namespace Core.Controllers.RoznichProdazha
{

    class RoznichProdazha
    {

        private DBNpgsql db = new DBNpgsql();

        public DataTable Index()
        {

            return db.GetByQuery("Select �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������,�����_��_������  FROM public.�����");
        }

        public DataTable ByFilterTovar(string[,] filter)
        {
                        
            //DataTable dataTable = new DataTable();
            string sqlQuery= "SELECT �������, ������������, �����, �����, " +
                "������, ������������, ����������, ����_����__euro_, ������, �����_��_������ FROM public.����� WHERE ����������>0 AND ";
            
            for (int i = 0; i < (filter.Length) /2; i++)
            {
                sqlQuery = sqlQuery + filter[i, 0] + " LIKE '" + filter[i,1] + "'"+ " AND ";
            }
            sqlQuery=sqlQuery.Remove(sqlQuery.Length - 5, 5);
            

            return db.GetByQuery(sqlQuery); ;
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


        public DataTable getNameSeller()
        {
            return db.GetByQuery("Select �������� FROM public.��������");
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

        public int getLastNakladnoyText()
        {

            int nakNomer = 0;

            DataTable dataTable = db.GetByQuery("SELECT ���������� FROM public.������� ORDER BY ���������� DESC LIMIT 1;");
            
            foreach (DataRow dr in dataTable.Rows)
            {
                nakNomer = Convert.ToInt32(dr[0]);
            }
               return nakNomer;
        }


        public string getRoundDecimal(double number)
        {
            return number.ToString("0.00");
            //return Math.Round(number, 2);
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
                    else if (columnName1 != "" && columnName2 != "" && columnName3 == "" && columnName4 == "")
                    {

                        summa1 = summa1 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName1].Value);
                        summa2 = summa2 + Convert.ToDouble(dataGridView.Rows[i].Cells[columnName2].Value);
                        
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
                    if (columnName1 != "" && columnName2 != "" && columnName3 != "" && columnName4 != "")
                    {
                        summa1 = summa1 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName1].Value);
                        summa2 = summa2 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName2].Value);
                        summa3 = summa3 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName3].Value);
                        summa4 = summa4 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName4].Value);

                    }

                    else if (columnName1 != "" && columnName2 != "" && columnName3 == "" && columnName4 == "")
                    {
                        summa1 = summa1 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName1].Value);
                        summa2 = summa2 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName2].Value);
                        
                    }
                    else
                    {
                        summa1 = summa1 - Convert.ToDouble(dataGridView.Rows[index].Cells[columnName1].Value);

                    }

                }
                

                if (columnName1 != "" && columnName2 != "" && columnName3 != "" && columnName4 != "")
                {
                    dataGridView.Rows[index].Cells[columnName1].Value = summa1.ToString("0.00");
                    dataGridView.Rows[index].Cells[columnName2].Value = summa2.ToString("0.00");
                    dataGridView.Rows[index].Cells[columnName3].Value = summa3.ToString("0.00");
                    dataGridView.Rows[index].Cells[columnName4].Value = summa4.ToString("0.00");
                    
                    
                }

                else if (columnName1 != "" && columnName2 != "" && columnName3 == "" && columnName4 == "")
                {
                    dataGridView.Rows[index].Cells[columnName1].Value = summa1.ToString("0.00");
                    dataGridView.Rows[index].Cells[columnName2].Value = summa2.ToString("0.00");
                    
                }
                else
                {
                    dataGridView.Rows[index].Cells[columnName1].Value = summa1.ToString("0.00");
                }
                dataGridView.Rows[index].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            }

            return dataGridView;
        }


        public void InsertProdazha(double kurs, int skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
                {
            //skidka ������__%_,     + skidka + "', '"
            db.insertUpdateToDB("INSERT INTO public.������� ( ����_������,  ��������, ��������, ����������, ���������_�����, chek) VALUES " +
                "('" + kurs + "', '" + prodovets + "'," +
                " '" + propis + "', '" + primech + "', '" + naklText + "', '" + chek + "')");            
            
        }

        public void insertKursValyuti(double kurs)
        {
            
            db.insertUpdateToDB("INSERT INTO public.����_������ ( ����_������) VALUES " +
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
            DataTable dt= db.GetByQuery("Select ����������  FROM public.����� WHERE ������� LIKE '" + artikul + "'");
            int kolTovara = 0;
            foreach (DataRow dr in dt.Rows)
            {
                kolTovara = Convert.ToInt32(dr[0]);
            }

            return kolTovara;

        }


        public void updateTovarKol(string artikul, int kolichestvo, string plyusMinus)
        {
            int kolTovara=0;
            if (plyusMinus == "+") kolTovara = getKolTovara(artikul) + kolichestvo;
            if (plyusMinus == "-") kolTovara = getKolTovara(artikul) - kolichestvo;


            db.insertUpdateToDB("UPDATE public.����� SET ���������� = '" + kolTovara + "' WHERE �������='" + artikul + "'");
        }


       
        public DataTable chekProdazhaQuery(string naklTxt)
        {
            return db.GetByQuery("SELECT e.���� as date, e.���������_����� as nakText, e.chek as chek, e.�������� as propis, e.������ as skidka, c.�����_��_������ as mesto, " +
                                        "d.������� as artikul, d.���������� as kolichestvo, d.���� as tsena, c.����� as brand, " +
                                        "c.����� as marka, c.������ as model,c.������������ as naimenovanie, g.���������������� as komp FROM public.������� e , public.�������_������ d, " +
                                        "public.����� c, public.��������_��_����������� g WHERE d.����������=e.���������� and d.�������=c.������� " +
                                        "AND e.���������_�����='" + naklTxt + "'");
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

        public string SummaPropis(double summa)
        {
            string diram = summa.ToString("0.00");
            diram = diram.Remove(0, diram.Length - 2) + " ���";
            long suma = (long)summa;

            string summaPropisyu = FirstCharToUpper(RussianConverter.Format(suma, UnitOfMeasure.Ruble) + " " + diram);

            return summaPropisyu;
        }

        public void RestartKodProdazhi(double summa)
        {
            db.insertUpdateToDB("ALTER SEQUENCE public.�������_����������_seq RESTART WITH 1");
        }
        



        public string GetColumnName(int index)
        {
            const int alphabetsCount = 26;

            if (index > alphabetsCount)
            {
                int mod = index % alphabetsCount;
                int columnIndex = index / alphabetsCount;

                // if mod is 0 (clearly divisible) we reached end of one combination. Something like AZ
                if (mod == 0)
                {
                    // reducing column index as index / alphabetsCount will give the next value and we will miss one column.
                    columnIndex -= 1;
                    // passing 0 to the function will return character '@' which is invalid
                    // mod should be the alphabets count. So it takes the last char in the alphabet.
                    mod = alphabetsCount;
                }
                return GetColumnName(columnIndex) + GetColumnName(mod);
            }
            else
            {
                int code = (index - 1) + (int)'A';
                return char.ConvertFromUtf32(code);
            }
        }



    }

}