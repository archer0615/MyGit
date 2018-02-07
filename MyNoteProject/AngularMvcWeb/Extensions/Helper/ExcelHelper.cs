using ClosedXML.Excel;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
//using Excel;
using System.Reflection;

namespace AngularMvcWeb.Extensions.helper
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

        /// <summary>
        /// 將List轉為帶標題的DataTable
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTableWithHeader<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                string columnName = "";

                if (prop.CustomAttributes == null || prop.CustomAttributes.Count() == 0)
                    columnName = prop.Name;

                var displayNameAttribute = prop.CustomAttributes.Where(x => x.AttributeType == typeof(DisplayNameAttribute)).FirstOrDefault();

                if (displayNameAttribute == null || displayNameAttribute.ConstructorArguments == null || displayNameAttribute.ConstructorArguments.Count == 0)
                    columnName = prop.Name;
                else
                    columnName = displayNameAttribute.ConstructorArguments[0].Value.ToString();

                dataTable.Columns.Add(columnName, prop.PropertyType);

            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// 將Excel stream轉為DataTable
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelStreamToDataTable(Stream file)
        {
            try
            {
                var workbook = new XLWorkbook(file);
                IXLWorksheet workSheet = workbook.Worksheet(1);

                DataTable dt = new DataTable();

                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (row.FirstCellUsed() == null && row.LastCellUsed() == null)
                    {
                        break;
                    }
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}