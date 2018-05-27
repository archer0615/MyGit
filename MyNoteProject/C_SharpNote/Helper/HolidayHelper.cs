using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Helper
{
    public static class HolidayHelper
    {
        public static bool IsHolidays(DateTime date)
        {
            // 週休二日
            if (date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday) return true;
            // 國定假日(國曆)
            if (date.ToString("MM/dd").Equals("01/01")) return true;
            if (date.ToString("MM/dd").Equals("02/28")) return true;
            if (date.ToString("MM/dd").Equals("04/04")) return true;
            if (date.ToString("MM/dd").Equals("04/05")) return true;
            if (date.ToString("MM/dd").Equals("05/01")) return true;
            if (date.ToString("MM/dd").Equals("10/10")) return true;

            // 國定假日(農曆)
            if (GetLeapDate(date, false).Equals("12/" + GetDaysInLeapMonth(date))) return true;
            if (GetLeapDate(date, false).Equals("1/1")) return true;
            if (GetLeapDate(date, false).Equals("1/2")) return true;
            if (GetLeapDate(date, false).Equals("1/3")) return true;
            if (GetLeapDate(date, false).Equals("1/4")) return true;
            if (GetLeapDate(date, false).Equals("1/5")) return true;
            if (GetLeapDate(date, false).Equals("5/5")) return true;
            if (GetLeapDate(date, false).Equals("8/15")) return true;

            // 公司假日
            //日期是否在特定節日，資料庫有資料則為假日
            //if (CheckHoliday(date)) return true;
            //日期是否在公司設定節日，資料庫有資料則為假日
            //if (CheckDeductionSh(date)) return true;

            return false;
        }

        ///<summary>
        /// 取得農曆日期
        ///</summary>
        public static string GetLeapDate(DateTime Date, bool bShowYear = true, bool bShowMonth = true)
        {
            int L_ly, nLeapYear, nLeapMonth;

            ChineseLunisolarCalendar MyChineseLunisolarCalendar = new ChineseLunisolarCalendar();

            nLeapYear = MyChineseLunisolarCalendar.GetYear(Date);
            nLeapMonth = MyChineseLunisolarCalendar.GetMonth(Date);
            if (MyChineseLunisolarCalendar.IsLeapYear(nLeapYear)) //判斷此農曆年是否為閏年
            {
                L_ly = MyChineseLunisolarCalendar.GetLeapMonth(nLeapYear); //抓出此閏年閏何月

                if (nLeapMonth >= L_ly)
                {
                    nLeapMonth--;
                }
            }
            else
            {
                nLeapMonth = MyChineseLunisolarCalendar.GetMonth(Date);
            }

            if (bShowYear)
            {
                return "" + MyChineseLunisolarCalendar.GetYear(Date) + "/" + nLeapMonth + "/" + MyChineseLunisolarCalendar.GetDayOfMonth(Date);
            }
            else if (bShowMonth)
            {
                return "" + nLeapMonth + "/" + MyChineseLunisolarCalendar.GetDayOfMonth(Date);
            }
            else
            {
                return "" + MyChineseLunisolarCalendar.GetDayOfMonth(Date);
            }
        }

        ///<summary>
        /// 取得某一日期的該農曆月份的總天數
        ///</summary>
        public static string GetDaysInLeapMonth(DateTime date)
        {
            ChineseLunisolarCalendar MyChineseLunisolarCalendar = new ChineseLunisolarCalendar();

            return "" + MyChineseLunisolarCalendar.GetDaysInMonth(MyChineseLunisolarCalendar.GetYear(date), date.Month);
        }
    }
}
