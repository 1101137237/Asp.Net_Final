using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao
{
     public interface IEmployeeDao
    {
         void AddEmployee(Employee Employee);

         void UpdateEmployee(Employee Employee);

         void DeleteEmployee(Employee Employee);

         IList<Employee> GetAllEmployee();

         Employee GetEmployeeByName(string name);

         Employee GetEmployeeById(string id);

    }
}
