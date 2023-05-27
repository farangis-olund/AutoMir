using System;
using System.Data;
using System.Windows.Forms;
using Core.Controllers.Zakazi;
using Core.Controllers.Tovar;
using Core.Controllers.OrgInfo;
using Core.Reports.ReportPoItogom;
using Core.Controllers.PriyomSdacha;
using Core.Controllers;

using ClosedXML.Excel;
using System.IO;

namespace AutoMir2022.DobavitTovarIsBDForm
{
    public partial class DobavitIsBD : Form
    {

        private Zakazi zakaziObj = new Zakazi();

        
        public DobavitIsBD()
        {
            InitializeComponent();
        }

        private void DobavitIsBD_Load(object sender, EventArgs e)
        {
             
        dateZakaz.DataSource = zakaziObj.GetDateObnovlenieTovara();
            dateZakaz.DisplayMember = "Дата";
            dateZakaz.Text = null;
            this.reportViewer1.RefreshReport();
        }

        private void dateZakaz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PriyomSdacha priyomSdachaObj = new PriyomSdacha();

            dateZakaz.Text = dateZakaz.GetItemText(dateZakaz.SelectedItem);
            
            dataGridView1.DataSource = zakaziObj.GetZakazByDate(Convert.ToDateTime(dateZakaz.Text));
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[5].Width = 200;
            
            //administrator has a privilage to print the report how much he wants the other user only one time,
            //the status will be saved if report is printed once 
            if (MainMenu.userPrintFree == true)
            {
                print.Enabled = true;
            }
            
            if (MainMenu.userUpdateFree == true)
            {
                update.Enabled = true;
            }
            
            //if (MainMenu.userExportFree == true)
            //{
            //    export.Enabled = true;
            //}

            if (MainMenu.userPrintFree == false)
            {
                if (priyomSdachaObj.IsPrintTrue(Convert.ToDateTime(dateZakaz.Text)) == false)
                    print.Enabled = true;
                else
                    print.Enabled = false;
            }

            if (priyomSdachaObj.IsExportTrue(Convert.ToDateTime(dateZakaz.Text)) == false)
                export.Enabled = true;
            else
                export.Enabled = false;

            //if (MainMenu.userExportFree == false)
                
            //{
                
            //}


        }

        private void update_Click(object sender, EventArgs e)
        {
            int countTovar = 0;
            if (zakaziObj.IsExist(Convert.ToDateTime(dateZakaz.Text)) == false)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    Tovar tovarObj = new Tovar();

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        countTovar = countTovar + 1;
                        tovarObj.UpdateTovarKolichestvo(Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value), dataGridView1.Rows[i].Cells[0].Value.ToString(), "+");
                    }
                    zakaziObj.InsertObnovlenieTovara(Convert.ToDateTime(dateZakaz.Text), countTovar);
                    MessageBox.Show("Обновление успешно завершено!");
                    dataGridView1.Rows.Clear();
                    dateZakaz.DataSource = zakaziObj.GetDateObnovlenieTovara();
                    dateZakaz.Text = null;
                }
                else MessageBox.Show("Вы не выбрали данные для обновления");

            } else MessageBox.Show("На данную дату обновления уже оформлен!");
        }

        private void export_Click(object sender, EventArgs e)
        {

            DataTable dt = zakaziObj.ExportObnovlenieTovara(Convert.ToDateTime(dateZakaz.Text));

            ExcelUtility excelUtilityObj = new ExcelUtility();
            
            if (dateZakaz.Text != "" || dateZakaz.Text is null)
            {
                
                PriyomSdacha priyomSdachaObj = new PriyomSdacha();
                if (priyomSdachaObj.IsObnovlenieExportExist(Convert.ToDateTime(dateZakaz.Text)) == true)
                {
                    MessageBox.Show("Отчет по выбранной дате уже экспортирован!");
                    goto endProcess;
                }

                //if export heppened then save in database the status  
                if (excelUtilityObj.ExportExcel(dt, dateZakaz.Text) == true)
                {
                    if (priyomSdachaObj.IsObnovlenieExportPrintExist(Convert.ToDateTime(dateZakaz.Text))==true) 
                        priyomSdachaObj.UpdateObnovlenieExport(Convert.ToDateTime(dateZakaz.Text));
                    else
                        priyomSdachaObj.InsertObnovlenieExport(Convert.ToDateTime(dateZakaz.Text));

                }
                //если у пользователя нет открытого экспорта, кнопка экспорт
                //будет закрыть после первого экспорта
                if (MainMenu.userExportFree == false && priyomSdachaObj.IsExportTrue(Convert.ToDateTime(dateZakaz.Text)) == true)
                {
                    export.Enabled = false;
                }

            }
            else MessageBox.Show("Укажите дату!");

            endProcess: { }
        }

        private void print_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (dateZakaz.Text != "" || dateZakaz.Text is null)
            {
                PriyomSdacha priyomSdachaObj = new PriyomSdacha();
                
                OrgInfo org = new OrgInfo();

                string[,] parametr = {{ "kod_org", org.org_kod }, { "name_org", org.org_name },
                { "date", Convert.ToDateTime(dateZakaz.Text).ToString("dd.MM.yyyy") }};
                ReportPrikhodRaskhod reportPrikhodRaskhod = new ReportPrikhodRaskhod();

                //печать итогового отчета 
                    ReportPoItogom ReportPoItogomObj = new ReportPoItogom(); 
                    dt.Columns.Add("prodazhaRozn");
                    dt.Columns.Add("prodazhaOpt");
                    dt.Columns.Add("platezhRozn");
                    dt.Columns.Add("platezhOpt");
                    dt.Columns.Add("vozvratRozn");
                    dt.Columns.Add("vozvratOpt");
                    dt.Columns.Add("protsentiRozn");
                    dt.Columns.Add("protsentiOpt");
                    dt.Columns.Add("kassaRozn");
                    dt.Columns.Add("kassaOpt");
                    dt.Columns.Add("raskhodi");
                    dt.Columns.Add("ostatok");

                    dt.Rows.Add();
                    dt.Rows[0][0] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.prodazhaRozn);
                    dt.Rows[0][1] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.prodazhaOpt);
                    dt.Rows[0][2] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.platezhRozn);
                    dt.Rows[0][3] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.platezhOpt);
                    dt.Rows[0][4] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.vozvratRozn);
                    dt.Rows[0][5] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.vozvratOpt);
                    dt.Rows[0][6] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.protsentiRozn);
                    dt.Rows[0][7] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.protsentiOpt);
                    dt.Rows[0][8] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.kassaRozn);
                    dt.Rows[0][9] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.kassaOpt);
                    dt.Rows[0][10] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.raskhodi);
                    dt.Rows[0][11] = ReportPoItogomObj.ConverterToDoubleWithDot(ReportPoItogomObj.ostatok);
                
                    reportPrikhodRaskhod.StartReport("TotalReport", "ItogoviyOtchet", parametr, dt, "yes");
                
                
                //печать отчета об обновлении
                dt = zakaziObj.GetZakazReportByDate(Convert.ToDateTime(dateZakaz.Text));
                    reportPrikhodRaskhod.StartReport("ObnovlenieTovara", "PrikhodRaskhod", parametr, dt, "yes");

        
                
                //сохраняем статус печати, если пользователь (кроме админ) уже распечатал то
                //вторично не сможет распечатать
                if (priyomSdachaObj.IsObnovlenieExportPrintExist(Convert.ToDateTime(dateZakaz.Text)) == true)
                    priyomSdachaObj.UpdateObnovleniePrint(Convert.ToDateTime(dateZakaz.Text));
                else
                    priyomSdachaObj.InsertObnovleniePrint(Convert.ToDateTime(dateZakaz.Text));


                //administrator has a privilage to print the report how much he wants the other user only one time,
                //the status will be saved if report is printed once 
                if (MainMenu.userPrintFree == true)
                {
                    print.Enabled = true;
                    reportPrikhodRaskhod.Show();
                }
                else if (MainMenu.userPrintFree == false && priyomSdachaObj.IsPrintTrue(Convert.ToDateTime(dateZakaz.Text)) == true)
                {
                    print.Enabled = false;
                }

                

            }
        }

        
    }
}
