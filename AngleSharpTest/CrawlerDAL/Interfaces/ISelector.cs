using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Interfaces
{
    public interface ISelector
    {
        string mainSelector { get; set; }
        void SetMainSelector(string mainSelector);
    }
    public interface ISelectorList
    {
        string mainSelector { get; set; }
        void SetMainSelector(string _mainSelector);
    }
}
