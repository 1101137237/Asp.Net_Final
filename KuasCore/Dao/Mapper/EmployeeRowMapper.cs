using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class EmployeeRowMapper : IRowMapper<Employee>
    {
        public Employee MapRow(IDataReader dataReader, int rowNum)
        {
            Employee target = new Employee();

            target.Id = dataReader.GetInt32(dataReader.GetOrdinal("Employee_Id"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("Employee_Name"));
            target.Department = dataReader.GetString(dataReader.GetOrdinal("Employee_Department"));
            target.Description = dataReader.GetString(dataReader.GetOrdinal("Employee_Description"));

            return target;
        }
    }
}
