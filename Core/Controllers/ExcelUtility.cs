using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;



namespace Core.Controllers
{
 class ExcelUtility
    {
        
        public bool ExportExcel(DataTable dt, string date)
        {
            bool isExported = false;
           OrgInfo.OrgInfo orgInfoObj = new OrgInfo.OrgInfo();
            string org_kod = orgInfoObj.org_kod;
            string exportPath = orgInfoObj.exportPath;
            
            using (XLWorkbook workBook=new XLWorkbook())
            {
                string excelFilePath=exportPath + org_kod + "_" + date + ".xlsx";
                dt.Columns[0].ColumnName = "артикул";
                dt.Columns[1].ColumnName = "количество";
                var ws = workBook.Worksheets.Add(dt, "Лист1");
                ws.Cells().Style.Fill.BackgroundColor= XLColor.White;
                ws.Cells().Style.Font.FontColor = XLColor.White;
                ws.Protect("1234");

                if (!Directory.Exists(exportPath))
                {
                    MessageBox.Show("Проверьте путь!", "Путь не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                  workBook.SaveAs(exportPath + org_kod + "_" + date + ".xlsx");
                    isExported = true;
                    MessageBox.Show("Данные успешно экспортированы!");
                }
                
            }
            return isExported;
        }


  }
    
}
