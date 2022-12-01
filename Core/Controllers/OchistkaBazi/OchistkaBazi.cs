using System;
using System.Data;
using Core.DB;
using System.Windows.Forms;
using System.Drawing;

namespace Core.Controllers.OchistkaBazi
{
    class OchistkaBazi
    {
        private DBNpgsql db = new DBNpgsql();

        public DataTable ProsmotrTable(string tableName)
        {
            return db.GetByQuery("SELECT * FROM public." + tableName + "");
        }

        public void DeleteRowsInTable(string tableName)
        {
            db.insertUpdateToDB("TRUNCATE TABLE public." + tableName + " CASCADE");
            
        }

        public void RestartIdColumn(string tableName, string column)
        {
            db.insertUpdateToDB("ALTER SEQUENCE " + tableName + "_" + column + "_seq RESTART WITH 1");
        }

    }
}
