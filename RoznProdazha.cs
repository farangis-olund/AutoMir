using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using Npgsql;
using System.Windows.Forms;
using Core.Controllers.RoznProdazha;
namespace AutoMir2022
{
    public partial class retail : Form

    {
    //    class DataTableInfoGetSet
    //    {
    //        public string sqlString;
    //        public DataTable GetDataFromDatabaseinDataTable()
    //        {
    //            DataTable dt = new DataTable();

    //            //connection to database
    //            string connstring = "server=localhost;port=5432;user id=postgres;password=1234;database=AutoMir2022;";
    //            // Making connection with Npgsql provider
    //            NpgsqlConnection conn = new NpgsqlConnection(connstring);
    //            conn.Open();
    //            NpgsqlCommand comm = new NpgsqlCommand();
    //            comm.Connection = conn;
    //            comm.CommandType = CommandType.Text;
    //            comm.CommandText = sqlString;
                
    //            NpgsqlDataReader dr = comm.ExecuteReader();
    //            if (dr.HasRows)
    //            {
    //                dt.Load(dr);

    //            }

    //            comm.Dispose();
    //            conn.Close();
    //            return dt;
    //        }

    //        public DataTable selectColundDistinct(DataTable mydataTable, string columnName)
    //        {
    //            DataView view = new DataView(mydataTable);
    //            DataTable distinctValues = view.ToTable(true, columnName);
    //            return distinctValues;


    //        }

    //    }

    //    class Cleaner
    //    {
    //        public void cleanCombobox()
    //        {
    //            if (myCombobox.Text != "")
    //            {
    //                string brandText = myCombobox.Text;
    //            }
    //            else
    //            {
    //                myCombobox.SelectedItem = null;
    //            }
    //        }

    //        private ComboBox myCombobox; // field
    //        public ComboBox MyCombobox   // property
    //        {
    //            get { return myCombobox; }
    //            set { myCombobox = value; }
                
    //        }

            

    //}
        public retail()
        {
            InitializeComponent();

            showAllTovar();


        }

        //public void dbconncectionTovar(string sqlString)
        //{

        //    RoznichProdazha roznProdazhaObj = new RoznichProdazha();
        //    dataGridView1.AutoGenerateColumns = true;
        //    dataGridView1.DataSource = roznProdazhaObj.Index();


        //    //fill the ComboBoxs for search
            
            
           
        //}


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
            

        }

        private void search_Click(object sender, EventArgs e)
        {
            string[] combovalue = new string[5] { Brand.Text, marka.Text, gruppa.Text, artikul.Text, naimenovanie.Text };
            int result = combovalue.Count(s => s != "");

            string[,] comboColName= new string [5,2] { { "бренд", Brand.Text.Trim() } , {"марка", marka.Text.Trim() }, {"группа", gruppa.Text.Trim() }, {"артикул", artikul.Text.Trim() }, { "наименование", naimenovanie.Text.Trim() } };
            
            string[,] filterQueryColumn= new string[result, 2];
            int j = 0;
            
            for (int i = 0;i< comboColName.Length/2-1; i++)
            {
                if (comboColName[i, 1] != "")
                {
                    filterQueryColumn[j, 0] = comboColName[i, 0];
                    filterQueryColumn[j, 1] = comboColName[i, 1];
                    j = j+1;
                }

            }

            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.ByFilter(filterQueryColumn);
            dataGridView1.DataSource = mydataTable;

            
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            showAllTovar();
        }

        public void showAllTovar()
        {
            RoznichProdazha roznProdazhaObj = new RoznichProdazha();
            dataGridView1.AutoGenerateColumns = true;
            DataTable mydataTable = new DataTable();
            mydataTable = roznProdazhaObj.Index();
            dataGridView1.DataSource = mydataTable;

            Brand.DisplayMember = "бренд";
            Brand.DataSource = roznProdazhaObj.selectColundDistinct(mydataTable, "бренд");

            marka.DisplayMember = "марка";
            marka.DataSource = roznProdazhaObj.selectColundDistinct(mydataTable, "марка");

            gruppa.DisplayMember = "группа";
            gruppa.DataSource = roznProdazhaObj.selectColundDistinct(mydataTable, "группа");

            artikul.DisplayMember = "артикул";
            artikul.DataSource = roznProdazhaObj.selectColundDistinct(mydataTable, "артикул");

            naimenovanie.DisplayMember = "наименование";
            naimenovanie.DataSource = roznProdazhaObj.selectColundDistinct(mydataTable, "наименование");

            Brand.SelectedItem = null;
            marka.SelectedItem = null;
            gruppa.SelectedItem = null;
            artikul.SelectedItem = null;
            naimenovanie.SelectedItem = null;

        }
    }

    }
