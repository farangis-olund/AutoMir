using System;
using System.Data;
using System.Windows.Forms;
using Core.DB;
using Npgsql;
using NpgsqlTypes;

namespace Core.Controllers.ProverkaNaOshibku
    {
    class ProverkaNaOshibku
    {
        private DBNpgsql db = new DBNpgsql();

        public bool GetEmptyCellDVG(ref DataGridView dgv, int rowIndex, string columnName)
        {
            bool value = false;
            if (dgv.Rows[rowIndex].Cells[columnName].Value == null
                     || dgv.Rows[rowIndex].Cells[columnName].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace(dgv.Rows[rowIndex].Cells[columnName].Value.ToString()))
                value=true;
            return value;
        }

        public bool CheckReapetedValueInDVG(ref DataGridView dgv, string columnName, string chekingValue)
        {
            bool value = false;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[columnName].Value.ToString() == chekingValue)
                    value = true;
            }
                
            return value;
        }



    }
}
