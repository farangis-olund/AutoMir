using System;
using System.Data;
using Npgsql;
namespace Core.DB
{

    class DBNpgsql
    {
        private const string CONNECTION_STRING =    "server=localhost;" +
                                                    "port=5432;" +
                                                    "user id=postgres;" +
                                                    "password=1234;" +
                                                    "database=AutoMir2022;";

        /// <summary>
        /// Return response by query
        /// </summary>
        public DataTable GetByQuery(string query)
        {
            DataTable dataTable = new DataTable();

            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;

            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                dataTable.Load(dr);
            }

            comm.Dispose();
            conn.Close();

            return dataTable;
        }
    }
}