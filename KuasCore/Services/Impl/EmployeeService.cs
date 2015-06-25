using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeDao EmployeeDao { get; set; }

        public Employee AddEmployee(Employee Employee)
        {
            EmployeeDao.AddEmployee(Employee);
            return GetEmployeeByName(Employee.Name);
        }

        public void UpdateEmployee(Employee Employee)
        {
            EmployeeDao.UpdateEmployee(Employee);
        }

        public void DeleteEmployee(Employee Employee)
        {
            Employee = EmployeeDao.GetEmployeeByName(Employee.Name);

            if (Employee != null)
            {
                EmployeeDao.DeleteEmployee(Employee);
            }
        }

        public IList<Employee> GetAllEmployee()
        {
            return EmployeeDao.GetAllEmployee();
        }

        public Employee GetEmployeeByName(string name)
        {
            return EmployeeDao.GetEmployeeByName(name);
        }

        public Employee GetEmployeeById(int id)
        {
           
            return EmployeeDao.GetEmployeeById(id);
        }
    }
}
