using CrawlerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Selectors
{
    public class CategroySelector : ISelector
    {
        public string mainSelector { get; set; }
        public CategroySelector(string _mainSelector)
        {
            mainSelector = _mainSelector;
        }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }

    }
}
