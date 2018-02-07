using AngularMvcWeb.Models.DB;
using AngularMvcWeb.Models.Repository;
using AngularMvcWeb.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.Services.Employee
{
    public class EmployeeService : BaseService
    {
        private GenericRepository<Employees> GR_Employee;

        public EmployeeService()
        {
            GR_Employee = new GenericRepository<Employees>();
        }
        public EmployeeViewModel GetEmployee(int id)
        {
            var query = GR_Employee.Get(x => x.EmployeeID == id);
            EmployeeViewModel result = new EmployeeViewModel()
            {
                EmployeeID = query.EmployeeID,
                EmpName = query.LastName + query.FirstName,
                Country = query.Country,
                Title = query.Title,
            };
            return result;
        }
        public List<EmployeeViewModel> GetAllEmployees()
        {
            var result = GR_Employee.GetAll()
                .Select(x => new EmployeeViewModel()
                {
                    EmployeeID = x.EmployeeID,
                    EmpName = x.LastName + x.FirstName,
                    Country = x.Country,
                    Title = x.Title,
                }).ToList();
            return result;
        }
    }
}