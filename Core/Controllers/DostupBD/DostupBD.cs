using System;
using System.Data;
using System.Windows.Forms;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.DostupBD
{
    class DostupBD
    {
        private DBNpgsql db = new DBNpgsql();

        
        public DataTable SelectDB( string db_name)
        {
           return db.GetByQuery("Select * FROM public." + db_name + "");
        }

        public void UdateDBFromDGV(ref DataGridView dgv, int dgvRowNum, string db_name)
        {
            string query= "UPDATE public." + db_name + " SET ";
            for (int i=0; i < dgv.Columns.Count; i++)
            {   if (dgv.Rows[dgvRowNum].Cells[dgv.Columns[i].Name].Value.ToString() != "")
                {
                    query = query + "" + dgv.Columns[i].Name + " = '" + dgv.Rows[dgvRowNum].Cells[dgv.Columns[i].Name].Value + "', ";
                }
                
            }

            string result = query.Remove(query.Length - 2, 2);

            db.insertUpdateToDB(result);
          
        }

        public void DeleteDBFromDGV(ref DataGridView dgv, int dgvRowNum, string db_name)
        {
            db.insertUpdateToDB("DELETE FROM public." + db_name + " WHERE "+ dgv.Columns[0].Name +"='"+ dgv.Rows[dgvRowNum].Cells[dgv.Columns[0].Name].Value.ToString() + "'");
        }

        public void InsertDBFromDGV(ref DataGridView dgv, int dgvRowNum, string db_name)
        {
            string query = "INSERT INTO public." + db_name + "(";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Rows[dgvRowNum].Cells[dgv.Columns[i].Name].Value.ToString() != "")
                    query = query + dgv.Columns[i].Name + ", ";
            }
            query = query.Remove(query.Length - 2, 2)+") VALUES(";

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Rows[dgvRowNum].Cells[dgv.Columns[i].Name].Value.ToString() != "")
                {
                    query = query + "'" + dgv.Rows[dgvRowNum].Cells[dgv.Columns[i].Name].Value + "', ";
                }
            }

            string result = query.Remove(query.Length - 2, 2)+")";

            db.insertUpdateToDB(result);
        }

       public void DeleteAll(string db_name)
        {
            db.insertUpdateToDB("DELETE FROM public." + db_name + "");
        }

        public DataTable GetTableInfo(string tableName)
        {

            return db.GetByQuery("SELECT column_name, data_type " +
                "FROM information_schema.columns WHERE table_name = '"+ tableName + "'");
        }


        public void InsertAllDBFromDGV(ref DataGridView dgv, string db_name)
        {
            db.insertUpdateToDB("DELETE FROM public." + db_name + "");

            DataTable dt = GetTableInfo(db_name);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString().Contains("id") == true)
                {
                    db.insertUpdateToDB("ALTER SEQUENCE " + db_name + "_" + dr[0] + "_seq RESTART WITH 1");
                    break;
                }
            }
            

                string [,] columnArray = new string [dt.Rows.Count, 2];
            string[,] dataArray = new string[dt.Rows.Count, 3];



            for (int i=0; i<dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Contains("id") == false)
                {
                    columnArray[i, 0] = dt.Rows[i][0].ToString();
                    columnArray[i, 1] = dt.Rows[i][1].ToString();
                }
                
            }

            
            string query= "INSERT INTO public." + db_name + "(";
            
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Name.Contains("id") == false)
                {
                    query = query + dgv.Columns[i].Name + ", ";
                }
            }

            query = query.Remove(query.Length - 2, 2) + ") VALUES (";
            
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Name.Contains("id") == false)
                {
                    query = query + "@" + dgv.Columns[i].Name + ", ";
                }
            }
            query = query.Remove(query.Length - 2, 2) + ")";

            
            for (int i = 0; i < dgv.Rows.Count-1; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Name.Contains("id") == false )
                    {
                        dataArray[j, 0] = columnArray[j, 0];
                        dataArray[j, 1] = columnArray[j, 1];
                        dataArray[j, 2] = dgv.Rows[i].Cells[dgv.Columns[j].Name].Value.ToString();
                    }
                }
                db.insertUpdateToDBbyArrayParametr(query, dataArray);
            }
           
            
            
        }



    }
}
