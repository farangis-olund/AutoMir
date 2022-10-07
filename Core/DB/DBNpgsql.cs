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
        //ALTER SEQUENCE �������_�_���������_seq RESTART WITH 1;

        public void insertProdazha(double kurs, double skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.������� (����_������, ������%,  ��������, " +
                "��������, ����������, ���������_�����, chek) VALUES ( @����_������,@������%,  @��������, " +
                "@��������, @����������, @���������_�����, @chek)", conn))
            {

                cmd.Parameters.AddWithValue("@����_������", kurs);
                cmd.Parameters.AddWithValue("@������%", skidka);

                cmd.Parameters.AddWithValue("@��������", prodovets);
                cmd.Parameters.AddWithValue("@��������", propis);
                cmd.Parameters.AddWithValue("@����������", primech);
                cmd.Parameters.AddWithValue("@���������_�����", naklText);
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

            using (var cmd = new NpgsqlCommand(" INSERT INTO public.�������_������ (�������, ����������, ����, ����������) VALUES" +
                " ( @�������, @����������, " +
                "@����, @����������)", conn))
            {

                cmd.Parameters.AddWithValue("@�������", artikul);
                cmd.Parameters.AddWithValue("@����������", kolich);
                cmd.Parameters.AddWithValue("@����", tsena);
                cmd.Parameters.AddWithValue("@����������", kodprodazhi);

                cmd.ExecuteNonQuery();

            }

        }

    }
}