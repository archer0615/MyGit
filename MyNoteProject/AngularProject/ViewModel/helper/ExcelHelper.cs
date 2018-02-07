using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace AngularProject.ViewModel.helper
{
    public class ExcelHelper
    {
        /// <summary>
        /// 將Excel stream轉成List<DataTable>DataTable
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static List<DataTable> ImportExcel(Stream stream, bool firstRow = true)
        {
            List<DataTable> dTs = new List<DataTable>();

            try
            {
                var workbook = new XLWorkbook(stream);

                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    DataTable dt = new DataTable();

                    foreach (IXLRow row in worksheet.Rows())
                    {
                        //第一行如果是標題則塞到欄位名
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            //將row寫到DataTable
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                    }
                    if (dt != null)
                        dTs.Add(dt);
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return dTs;
        }
    }
}