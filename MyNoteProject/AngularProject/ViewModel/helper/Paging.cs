using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularProject.ViewModel.helper
{
    public class Paging
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}