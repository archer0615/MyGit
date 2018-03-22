using CrawlerDAL.Interfaces;
using CrawlerDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public abstract class BaseSelectorList<T> : ISelectorList
    {        
        public string mainSelector { get; set; }
        public void SetMainSelector(string _mainSelector) => mainSelector = _mainSelector;
        public int trCount { get; set; }
        public BaseSelectorList(string _mainSelector, int calcYear)
        {
            SetMainSelector(_mainSelector);
            GetCalcTR(calcYear);
        }
        public void GetCalcTR(int calcYear)
        {
            DateTime Now = DateTime.Now;

            var indexMonth = Now.Month;

            var stopYear = Now.Year - calcYear;
            for (int i = Now.Year; i >= stopYear; i--)
            {
                for (int j = indexMonth; j > 0; j--)
                {
                    trCount++;
                }
                indexMonth = 12;
            }
        }

    }
}
