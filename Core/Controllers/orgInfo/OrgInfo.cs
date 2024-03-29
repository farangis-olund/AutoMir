﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Core.DB;
using Microsoft.Reporting.WinForms;
using Npgsql;
using NpgsqlTypes;


namespace Core.Controllers.OrgInfo
{
    class OrgInfo
    {
        private DBNpgsql db = new DBNpgsql();

        public string org_kod { set; get; }
        public string org_name { set; get; }
        public string importPath { set; get; }
        public string exportPath { set; get; }
        public OrgInfo()
        {
            DataTable dt= db.GetByQuery("SELECT * FROM public.сведения_об_организации");
            org_kod = dt.Rows[0][0].ToString();
            org_name = dt.Rows[0][1].ToString();
            exportPath = dt.Rows[0][5].ToString();
            importPath = dt.Rows[0][6].ToString();

        }


    
    
    }
}
