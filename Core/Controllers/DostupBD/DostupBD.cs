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


       

    }
}
