using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.ViewModel.Employee
{
    public class EmployeeViewModel : BaseViewModel
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
    }
}