using System;
using System.Data;
using Npgsql;
namespace Core.DB
{

    class DBNpgsql
    {
        private const string CONNECTION_STRING = "server=localhost;" +
                                                    "port=5432;" +
                                                    "user id=postgres;" +
                                                    "password=1234;" +
                                                    "database=AutoMir2022;";

        // return query to datatable
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

        public void insertToDB(string query)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.ExecuteNonQuery();
        }
        //ALTER SEQUENCE продажа_№_накладной_seq RESTART WITH 1;

        public void insertProdazha(double kurs, double skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.продажа (курс_валюты, скидка%,  продавец, " +
                "прописью, примечание, накладной_текст, chek) VALUES ( @курс_валюты,@скидка%,  @продавец, " +
                "@прописью, @примечание, @накладной_текст, @chek)", conn))
            {

                cmd.Parameters.AddWithValue("@курс_валюты", kurs);
                cmd.Parameters.AddWithValue("@скидка%", skidka);

                cmd.Parameters.AddWithValue("@продавец", prodovets);
                cmd.Parameters.AddWithValue("@прописью", propis);
                cmd.Parameters.AddWithValue("@примечание", primech);
                cmd.Parameters.AddWithValue("@накладной_текст", naklText);
                cmd.Parameters.AddWithValue("@chek", chek);

                cmd.ExecuteNonQuery();

            }


        }

        public void insertProdazhaTovar(string artikul, int kolich, double tsena,
                           int kodprodazhi)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            using (var cmd = new NpgsqlCommand(" INSERT INTO public.продажа_товара (артикул, количество, цена, кодпродажи) VALUES" +
                " ( @артикул, @количество, " +
                "@цена, @кодпродажи)", conn))
            {

                cmd.Parameters.AddWithValue("@артикул", artikul);
                cmd.Parameters.AddWithValue("@количество", kolich);
                cmd.Parameters.AddWithValue("@цена", tsena);
                cmd.Parameters.AddWithValue("@кодпродажи", kodprodazhi);

                cmd.ExecuteNonQuery();

            }

        }

    }
}