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
            //처음 세팅
            Excel.Application excelApp = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;

            //try - catch 를 통해 PC에 엑셀이 설치되어있지 않는 경우를 예외처리함
            try
            {
                //워크시트, 워크북 사전세팅
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add();
                workSheet = workBook.Worksheets.Add(Type.Missing, workBook.Worksheets[1]);
                workSheet.Name = "항타일지";

                //양식세팅
                //1. 최상단 타이틀
                Excel.Range celTitle = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 9]];
                celTitle.Merge();
                celTitle.Value = "H-Pile 시공현황";
                celTitle.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
                celTitle.Font.Bold = true;
                celTitle.Font.Size = 22;

                //2. 시공수량
                //2-1. 공종
                Excel.Range celType = workSheet.Range[workSheet.Cells[4, 1], workSheet.Cells[5, 1]];
                celType.Merge();
                celType.Value = "공종";
                Excel.Range celTypeValue = workSheet.Cells[6, 1];
                celTypeValue.Value = "H-Pile";

                //2-2. 시공일
                Excel.Range celDate = workSheet.Range[workSheet.Cells[4, 2], workSheet.Cells[5, 2]];
                celDate.Merge();
                celDate.Value = "시공일";
                Excel.Range celDateValue = workSheet.Cells[6, 2];

                //2-3. 시공수량
                Excel.Range celQuantityTitle = workSheet.Range[workSheet.Cells[4, 3], workSheet.Cells[4, 9]];
                celQuantityTitle.Merge();
                celQuantityTitle.Value = "시공수량(단위 : 공)";
                Excel.Range celQuanHeader1 = workSheet.Cells[5, 3];
                celQuanHeader1.Value = "설계수량";
                Excel.Range celQuanValue1 = workSheet.Cells[6, 3];
                celQuanValue1.Value = pileCount;

                Excel.Range celQuanHeader2 = workSheet.Range[workSheet.Cells[5, 4], workSheet.Cells[5, 5]];
                celQuanHeader2.Merge();
                celQuanHeader2.Value = "구분";
                Excel.Range celQuanValue2 = workSheet.Range[workSheet.Cells[6, 4], workSheet.Cells[6, 5]];
                celQuanValue2.Merge();
                celQuanValue2.Value = "H-Pile";

                Excel.Range celQuanHeader3 = workSheet.Cells[5, 6];
                celQuanHeader3.Value = "기시공";
                Excel.Range celQuanValue3 = workSheet.Cells[6, 6];
                celQuanValue3.Value = 0;

                Excel.Range celQuanHeader4 = workSheet.Cells[5, 7];
                celQuanHeader4.Value = "금일";
                Excel.Range celQuanHeader5 = workSheet.Cells[5, 8];
                celQuanHeader5.Value = "누계";
                Excel.Range celQuanHeader6 = workSheet.Cells[5, 9];
                celQuanHeader6.Value = "잔량";

                //3. 일일 시공현황

                //저장경로 세팅 및 파일저장
                string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                string fileName = "항타일지.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);
                workBook.SaveAs(filePath);

                //메모리 관리
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
