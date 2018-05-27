using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.DateTimeHelper
{
    public enum Duration { Day, Week, Month };
    public enum ArrowChange { Increase, Reduce };
    public enum TaiwanFormat { YearMonthDay, YearMonth, OnlyYear }
    public static class DatetimeHelper
    {
        /// <summary>
        /// 增減時間
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="arrowChange"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime DateFrom(Duration duration, ArrowChange arrowChange, DateTime dateTime)
        {
            var positiveNegative = 1;
            switch (arrowChange)
            {
                case ArrowChange.Increase:
                    positiveNegative *= 1;
                    break;
                case ArrowChange.Reduce:
                    positiveNegative *= -1;
                    break;
            }
            switch (duration)
            {
                case Duration.Day:
                    dateTime = dateTime.AddDays(1 * positiveNegative);
                    break;
                case Duration.Week:
                    dateTime = dateTime.AddDays(7 * positiveNegative);
                    break;
                case Duration.Month:
                    dateTime = dateTime.AddMonths(1 * positiveNegative);
                    break;
            }
            return dateTime;
        }
        /// <summary>
        /// 西元轉民國年
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ParseToTaiwanDate(DateTime datetime, TaiwanFormat twFormat)
        {
            System.Globalization.TaiwanCalendar taiwanCa = new System.Globalization.TaiwanCalendar();

            string result = string.Empty;
            string year = taiwanCa.GetYear(datetime).ToString();
            string month = datetime.Month.ToString("00");
            string day = datetime.Day.ToString("00");
            switch (twFormat)
            {
                case TaiwanFormat.YearMonthDay:
                    result = $"{year}/{month}/{day}";
                    break;
                case TaiwanFormat.YearMonth:
                    result = $"{year}/{month}";
                    break;
                case TaiwanFormat.OnlyYear:
                    result = $"{year}";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 取得前一月最後一日
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetPreMonthLastDay(DateTime datetime)
        {
            return DateTime.Now.AddDays(-DateTime.Now.Day);
        }
        /// <summary>
        /// 取得前一個月第一日
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetPreMonthFirstDay(DateTime datetime)
        {
            return DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.AddMonths(-1).Day + 1);
        }
        /// <summary>
        /// 取得兩個時間的小時差
        /// </summary>
        /// <param name="preTime"></param>
        /// <param name="nextTime"></param>
        /// <returns></returns>
        public static double GetBetweenHours(DateTime preTime, DateTime nextTime)
        {
            if (preTime < nextTime)
                return new TimeSpan(nextTime.Ticks - preTime.Ticks).TotalHours;
            else
                return new TimeSpan(preTime.Ticks - nextTime.Ticks).TotalHours;
        }
    }
}
