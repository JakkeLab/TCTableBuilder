using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TCTableBuilder.MSExcel
{
    public class MSExcelReport
    {
        public void ExcelTest(int pileCount, int idxStart, int idxEnd)
        {
            //Initial creating Xlsx object
            Excel.Application excelApp = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;

            //try - catch : Filtering the case that there is no excel installed.
            try
            {
                //Worksheet Setting
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add();
                workSheet = workBook.Worksheets.Add(Type.Missing, workBook.Worksheets[1]);
                workSheet.Name = "Report";

                //Path setting - saving at Desktop directory
                string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                string fileName = "Report.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);
                workBook.SaveAs(filePath);

                //Memory management
                workBook.Close();
                excelApp.Quit();
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(workBook);
                ReleaseExcelObject(excelApp);
            }
            catch
            {

            }
        }
        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
