using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularProject.ViewModel.helper
{
    public class TimeHelper
    {
        public static string GetTimeStamp()
        {
            var timeStamp = Convert.ToInt32(
                                    DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            var result = $"{timeStamp}";

            return result;
        }
        /// <summary>
        /// 取得日期 當月的最後一天
        /// </summary>
        /// <param name="date">日期(yyyy/MM/dd)</param>
        /// <returns></returns>
        public static string GetMonthLastDate(string date)
        {
            int day;
            DateTime dt;
            string lastDate = "";

            if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out dt))
            {
                day = new System.Globalization.GregorianCalendar().GetDaysInMonth(dt.Year, dt.Month);
                lastDate = new DateTime(dt.Year, dt.Month, day).ToString("yyyy/MM/dd");
            }

            return lastDate;
        }
    }
}