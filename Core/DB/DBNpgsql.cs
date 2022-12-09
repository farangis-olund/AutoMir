using System;
using System.Data;
using System.Windows.Forms;
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
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();
            DataTable dataTable = new DataTable();
            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                dataTable.Load(dr);
            }

            //try
            //{
            //    NpgsqlDataReader dr = comm.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        dataTable.Load(dr);
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка в запросе!");
            
            //}
            

            comm.Dispose();
            conn.Close();

            return dataTable;

        }


        public DataTable GetByParametrDate(string query, string parametr)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            

            // Connect to a PostgreSQL database
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            try
            {
                comm.Parameters.Add(parametr, NpgsqlDbType.Date).Value = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));

                NpgsqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");
            }
            
            

            comm.Dispose();
            conn.Close();

            return dataTable;
        }




        public void insertUpdateToDB(string query)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.ExecuteNonQuery();
            try
            {
                
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");
            }
            
            comm.Dispose();
            conn.Close();
        }

        //public void insertUpdateToDBDateParametr(string query, DateTime dataStart, DateTime dataEnd)
        //{
        //    NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
        //    NpgsqlCommand comm = new NpgsqlCommand();

        //    // Connect to a PostgreSQL database
        //    conn.Open();
        //    comm.Connection = conn;
        //    comm.CommandType = CommandType.Text;
        //    comm.CommandText = query;
        //    comm.Parameters.Add("dataStart", NpgsqlDbType.Date).Value = dataStart;
        //    comm.Parameters.Add("dataEnd", NpgsqlDbType.Date).Value = dataEnd;

        //    comm.ExecuteNonQuery();
        //    try
        //    {

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка в запросе!");
        //    }

        //    comm.Dispose();
        //    conn.Close();
        //}

        public void insertUpdateToDBbyArrayParametr(string query, string [,] array)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            for (int i=0; i<array.Length/3; i++)
            {
                if (array[i, 1] == "double precision" )
                {
                    if (array[i, 2] == "") { array[i, 2] = "0"; }

                    comm.Parameters.Add(array[i, 0], NpgsqlDbType.Double).Value = Convert.ToDouble(array[i, 2]);
                }
                else if (array[i, 1] == "character varying")
                    comm.Parameters.Add(array[i, 0], NpgsqlDbType.Text).Value = array[i, 2].ToString();
                else if (array[i, 1] == "date")
                    comm.Parameters.Add(array[i, 0], NpgsqlDbType.Date).Value = Convert.ToDateTime(array[i, 2]);
                else if (array[i, 1] == "integer")
                {
                    if (array[i, 2] == "") { array[i, 2] = "0"; }
                    comm.Parameters.Add(array[i, 0], NpgsqlDbType.Integer).Value = Convert.ToInt64(array[i, 2]);
                } 

            }

            comm.ExecuteNonQuery();
            try
            {
              
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");
            }

            comm.Dispose();
            conn.Close();
        }


        public void insertWithParametrDouble(string query, string parametr, double suma)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.Parameters.Add(parametr, NpgsqlDbType.Double).Value = suma;
            comm.ExecuteNonQuery();

            try
            {
            
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");
            }


            comm.Dispose();
            conn.Close();
        }

        public void insertWithParametrTwoDouble(string query, string parametr1, double suma1, string parametr2, double suma2)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.Parameters.Add(parametr1, NpgsqlDbType.Double).Value = suma1;
            comm.Parameters.Add(parametr2, NpgsqlDbType.Double).Value = suma2;
            comm.ExecuteNonQuery();

            try
            {
            
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");

            }
            comm.Dispose();
            conn.Close();
        }

        public void insertWithParametrTwoDoubleAndDate(string query, string parametr1, double suma1, string parametr2, double suma2, string parametr3, DateTime date1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.Parameters.Add(parametr1, NpgsqlDbType.Double).Value = suma1;
            comm.Parameters.Add(parametr2, NpgsqlDbType.Double).Value = suma2;
            comm.Parameters.Add(parametr3, NpgsqlDbType.Date).Value = date1;
            comm.ExecuteNonQuery();

            try
            {

            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");

            }
            comm.Dispose();
            conn.Close();
        }

        public void InsertWithParametrDate(string query, string parametr, DateTime date)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            // Connect to a PostgreSQL database
            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            try
            {
                comm.Parameters.Add(parametr, NpgsqlDbType.Date).Value = date;
                comm.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");

            }
            comm.Dispose();
            conn.Close();
        }

        //ALTER SEQUENCE продажа_№_накладной_seq RESTART WITH 1;

        public void insertProdazha(double kurs, int skidka, string prodovets,
            string propis, string primech, string naklText, bool chek)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);

            // Connect to a PostgreSQL database
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
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка в запросе!");

                }
                
            }

                                    
            conn.Close();
        }


        public void UpdateOtmenaProdazh(string naklText, string artikul, int kol, double suma, int kod)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("update public.отмена_продажи set код_отмена = :kod, количество_возврата = :kol, " +
                "сумма = :suma where накладной_текст = :nakl AND код_отмена IS NULL AND артикул = :artikul;", conn);
            
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

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");

            }


            
            conn.Close();
        }



        public void insertKurs(double kurs)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);

            // Connect to a PostgreSQL database
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.курс_валюты (курс_валюты) VALUES ( @курс_валюты)", conn))
            {

                cmd.Parameters.AddWithValue("@курс_валюты", kurs);


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка в запросе!");

                }


            }

            
            conn.Close();
        }

        public void insertProdazhaTovar(string artikul, int kolich, double tsena,
                           int kodprodazhi)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);

            // Connect to a PostgreSQL database
            conn.Open();

            using (var cmd = new NpgsqlCommand(" INSERT INTO public.продажа_товара (артикул, количество, цена, кодпродажи) VALUES" +
                " ( @артикул, @количество, " +
                "@цена, @кодпродажи)", conn))
            {

                cmd.Parameters.AddWithValue("@артикул", artikul);
                cmd.Parameters.AddWithValue("@количество", kolich);
                cmd.Parameters.AddWithValue("@цена", tsena);
                cmd.Parameters.AddWithValue("@кодпродажи", kodprodazhi);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка в запросе!");

                }


            }

         
            conn.Close();
        }



        public DataTable GetByParametrPeriod(string query, DateTime dataStart, DateTime dataEnd)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.Parameters.Add("dataStart", NpgsqlDbType.Date).Value = dataStart;
            comm.Parameters.Add("dataEnd", NpgsqlDbType.Date).Value = dataEnd;
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                dataTable.Load(dr);
            }

            //try
            //{
            //    NpgsqlDataReader dr = comm.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        dataTable.Load(dr);
            //    }

            //}
            //catch (InvalidCastException e)
            //{
            //    MessageBox.Show("Ошибка в запросе! " + e.ToString());

            //}



            comm.Dispose();
            conn.Close();

            return dataTable;
        }

        public DataTable GetByParametrDateByUser(string query, DateTime data)
        {
            DataTable dataTable = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            NpgsqlCommand comm = new NpgsqlCommand();

            conn.Open();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            comm.Parameters.Add("data", NpgsqlDbType.Date).Value = data;

            try
            {
                NpgsqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }

            }
            catch
            {
                MessageBox.Show("Ошибка в запросе!");

            }

            comm.Dispose();
            conn.Close();

            return dataTable;
        }



    }
}