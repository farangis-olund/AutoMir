using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;


namespace Core.DB 
{

    class DBNpgsql
    {
        public const string CONNECTION_STRING = "server=localhost;" +
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


        public DataTable GetByParametrDate(string query, string parametr)
        {
            DataTable dataTable = new DataTable();

            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            NpgsqlCommand sql = conn.CreateCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText = query;
            sql.Parameters.Add(parametr, NpgsqlDbType.Date).Value =Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            
            NpgsqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dataTable.Load(dr);
            }

            sql.Dispose();
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


        public void updateDB(string query)
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

        public void insertProdazha(double kurs, int skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.продажа (курс_валюты, скидка,  продавец, " +
                "прописью, примечание, накладной_текст, chek) VALUES ( @курс_валюты, @скидка,  @продавец, " +
                "@прописью, @примечание, @накладной_текст, @chek)", conn))
            {

                cmd.Parameters.AddWithValue("@курс_валюты", kurs);
                cmd.Parameters.AddWithValue("@скидка", skidka);
                cmd.Parameters.AddWithValue("@продавец", prodovets);
                cmd.Parameters.AddWithValue("@прописью", propis);
                cmd.Parameters.AddWithValue("@примечание", primech);
                cmd.Parameters.AddWithValue("@накладной_текст", naklText);
                cmd.Parameters.AddWithValue("@chek", chek);

                cmd.ExecuteNonQuery();

            }


        }


        public void UpdateOtmenaProdazh(string naklText, string artikul, int kol, double suma, int kod)
        {

            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("update public.отмена_продажи set код_возврата = :kod, количество_возврата = :kol, " +
                "сумма = :suma where накладной_текст = :nakl AND код_возврата IS NULL AND артикул = :artikul;", conn);
            
                command.Parameters.Add(new NpgsqlParameter("kol", NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("suma", NpgsqlTypes.NpgsqlDbType.Double));
                command.Parameters.Add(new NpgsqlParameter("nakl", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("artikul", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("kod", NpgsqlTypes.NpgsqlDbType.Integer));

                command.Parameters[0].Value = kol;
                command.Parameters[1].Value = suma;
                command.Parameters[2].Value = naklText;
                command.Parameters[3].Value = artikul;
                command.Parameters[4].Value = kod;


                command.ExecuteNonQuery();


        }






        public void insertKurs(double kurs)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.курс_валюты (курс_валюты) VALUES ( @курс_валюты)", conn))
            {

                cmd.Parameters.AddWithValue("@курс_валюты", kurs);
                
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



        //public void updateTovarKolich(string artikul, int kolich)
        //{
        //    // Connect to a PostgreSQL database
        //    NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
        //    conn.Open();

        //    using (var cmd = new NpgsqlCommand(" INSERT INTO public.продажа_товара (артикул, количество, цена, кодпродажи) VALUES" +
        //        " ( @артикул, @количество, " +
        //        "@цена, @кодпродажи)", conn))
        //    {

        //        cmd.Parameters.AddWithValue("@артикул", artikul);
        //        cmd.Parameters.AddWithValue("@количество", kolich);
        //        cmd.Parameters.AddWithValue("@цена", tsena);
        //        cmd.Parameters.AddWithValue("@кодпродажи", kodprodazhi);

        //        cmd.ExecuteNonQuery();

        //    }

        //}



    }
}