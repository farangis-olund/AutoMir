using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using Npgsql;
using System.Windows.Forms;

namespace AutoMir2022
{
    public partial class retail : Form

    {
        class DataTableInfoGetSet
        {
            public string sqlString;
            public DataTable GetDataFromDatabaseinDataTable()
            {
                DataTable dt = new DataTable();

                //connection to database
                string connstring = "server=localhost;port=5432;user id=postgres;password=1234;database=AutoMir2022;";
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlString;
                
                NpgsqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);

                }

                comm.Dispose();
                conn.Close();
                return dt;
            }

            public DataTable selectColundDistinct(DataTable mydataTable, string columnName)
            {
                DataView view = new DataView(mydataTable);
                DataTable distinctValues = view.ToTable(true, columnName);
                return distinctValues;


            }

            public ComboBox getDatatableinCombobox(DataTable dt, string column)
            {
                DataTableInfoGetSet myObj = new DataTableInfoGetSet();

                ComboBox myComboBox = new ComboBox();
                myComboBox.DataSource= myObj.selectColundDistinct(dt, column);
                myComboBox.DisplayMember = column;
                return myComboBox;
            }
        }


        public retail()
        {
            InitializeComponent();
            
            dbconncectionTovar("SELECT * FROM public.товар");

            Brand.SelectedItem = null;
            marka.SelectedItem = null;
            gruppa.SelectedItem = null;
            artikul.SelectedItem = null;
            naimenovanie.SelectedItem = null;

        }

        public void dbconncectionTovar(string sqlString)
        {

            DataTableInfoGetSet myObj = new DataTableInfoGetSet();
            myObj.sqlString = sqlString;
            DataTable mydataTable = new DataTable();

            mydataTable = myObj.GetDataFromDatabaseinDataTable();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = mydataTable;


            //add value to ComboBox brand from TOVAR2

            Brand= myObj.getDatatableinCombobox(mydataTable, "бренд");
            

            //Brand.DataSource = myObj.selectColundDistinct(mydataTable, "бренд");
            //Brand.DisplayMember = "бренд";




            //    //add value to ComboBox Марка TOVARA
            //    marka.DataSource = myObj.GetDataFromDatabaseinDataTable().DefaultView.ToTable(true, "марка");
            //    marka.DisplayMember = "марка";

            //    //add value to ComboBox group TOVARA
            //    gruppa.DataSource = myObj.GetDataFromDatabaseinDataTable().DefaultView.ToTable(true, "группа");
            //    gruppa.DisplayMember = "группа";

            //    //add value to ComboBox artikul TOVARA
            //    artikul.DataSource = myObj.GetDataFromDatabaseinDataTable().DefaultView.ToTable(true, "артикул");
            //    artikul.DisplayMember = "артикул";

            //    //add value to ComboBox naimenovanie TOVARA
            //    naimenovanie.DataSource = myObj.GetDataFromDatabaseinDataTable().DefaultView.ToTable(true, "наименование");
            //    naimenovanie.DisplayMember = "наименование";

        }


        private void button5_Click(object sender, EventArgs e)
        {
            dbconncectionTovar("SELECT * FROM public.товар");
        }

        private void retail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
        private void Brand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string comboValue = Brand.Text;
            //dbconncectionTovar("SELECT * FROM public.товар WHERE бренд LIKE '" + comboValue + "'");
       
        }
    }

    }
