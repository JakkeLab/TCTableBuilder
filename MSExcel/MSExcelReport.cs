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
        public int progressNum;
        public void ExcelTest(int pileCount, int idxStart, int idxEnd, List<List<string>> items)
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
                celTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

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


                #region Headers
                //3. 일일 시공현황
                Excel.Range celTitle2 = workSheet.Range[workSheet.Cells[8, 1], workSheet.Cells[8, 9]];
                celTitle2.Merge();
                celTitle2.Value = "일일 시공현황";
                celTitle2.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
                celTitle2.Font.Bold = true;
                celTitle2.Font.Size = 22;
                celTitle2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-1. 연번
                Excel.Range celNumbering = workSheet.Range[workSheet.Cells[10, 1], workSheet.Cells[12, 1]];
                celNumbering.Merge();
                celNumbering.Value = "연번";
                celNumbering.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-2. 파일번호
                Excel.Range celPileIdx = workSheet.Range[workSheet.Cells[10, 2], workSheet.Cells[12, 2]];
                celPileIdx.Merge();
                celPileIdx.Value = "파일번호";
                celPileIdx.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-1. 천공심도 title
                Excel.Range celExcTitle = workSheet.Range[workSheet.Cells[10, 3], workSheet.Cells[10, 8]];
                celExcTitle.Merge();
                celExcTitle.Value = "천공심도";
                celPileIdx.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-2. 설계 천공심도
                Excel.Range celExcDesigned = workSheet.Range[workSheet.Cells[11, 3], workSheet.Cells[12, 3]];
                celExcDesigned.Merge();
                celExcDesigned.Value = "설계\n천공심도(m)";
                celPileIdx.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-3. 시공파일
                Excel.Range celPileHeader = workSheet.Range[workSheet.Cells[11, 4], workSheet.Cells[11, 8]];
                celPileHeader.Merge();
                celPileHeader.Value = "시공파일";
                celPileHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-4. 파일상단(EL)
                Excel.Range celPileTop = workSheet.Cells[12, 4];
                celPileTop.Value = "파일상단(EL)";
                celPileTop.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-6. 파일하단(EL)
                Excel.Range celPileBottom = workSheet.Cells[12, 5];
                celPileBottom.Value = "파일하단(EL)";
                celPileBottom.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-7. 천공심도(EL)
                Excel.Range celPileRange = workSheet.Cells[12, 6];
                celPileRange.Value = "천공 심도";
                celPileRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-8. 토사구간
                Excel.Range celPileSandRange = workSheet.Cells[12, 7];
                celPileSandRange.Value = "토사구간";
                celPileSandRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-9. 암구간
                Excel.Range celRockRange = workSheet.Cells[12, 8];
                celRockRange.Value = "암구간";
                celRockRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //3-3-10. 비고
                Excel.Range celRemark = workSheet.Range[workSheet.Cells[10, 9], workSheet.Cells[12, 9]];
                celRemark.Merge();
                celRemark.Value = "비고";
                celRemark.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                #endregion

                #region 값 기록
                for(int i = idxStart-1; i<idxEnd; i++)
                {

                    List<string> currentLine = items[i];
                    //연번
                    Excel.Range recIdx = workSheet.Cells[14 + i - (idxStart), 1];
                    recIdx.Value = i - (idxStart) + 2;
                    //파일번호
                    Excel.Range recPileNum = workSheet.Cells[14 + i - (idxStart), 2];
                    recPileNum.Value = currentLine[0];
                    //설계천공심도
                    Excel.Range recDesignedLen = workSheet.Cells[14 + i - (idxStart), 3];
                    recDesignedLen.Value = currentLine[1];
                    //파일상단(EL)
                    Excel.Range recPileTop = workSheet.Cells[14 + i - (idxStart), 4];
                    recPileTop.Value = currentLine[2];
                    //파일하단(EL)
                    Excel.Range recPileBottom = workSheet.Cells[14 + i - (idxStart), 5];
                    recPileBottom.Value = currentLine[3];
                    //천공심도(EL)
                    Excel.Range recExcLen = workSheet.Cells[14 + i - (idxStart), 6];
                    recExcLen.Value = currentLine[4];
                    //토사구간(EL)
                    Excel.Range recSandRange = workSheet.Cells[14 + i - (idxStart), 7];
                    recSandRange.Value = currentLine[5];
                    //암구간(EL)
                    Excel.Range recRockRange = workSheet.Cells[14 + i - (idxStart), 8];
                    recRockRange.Value = currentLine[6];
                }
                #endregion
                //저장경로 세팅 및 파일저장
                string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                string fileName = $"항타일지";
                string fileExtension = ".xlsx";
                string newFileName = fileName + fileExtension;

                int index = 1;
                while(File.Exists(Path.Combine(desktopPath, newFileName)))
                {
                    newFileName = $"{fileName}{index}{fileExtension}";
                    index++;
                }
                string filePath = Path.Combine(desktopPath, newFileName);
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
