﻿using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class EmployeeDao : GenericDao<Employee>, IEmployeeDao
    {
        override protected IRowMapper<Employee> GetRowMapper()
        {
            return new EmployeeRowMapper();
        }

        public void AddEmployee(Employee Employee) 
        {
            string command = @"INSERT INTO Employee (Employee_Name, Employee_Department, Employee_Description) VALUES (@Name, @Department, @Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Name", DbType.String).Value = Employee.Name;
            parameters.Add("Department", DbType.String).Value = Employee.Department;
            parameters.Add("Description", DbType.String).Value = Employee.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateEmployee(Employee Employee)
        {
            string command = @"UPDATE Employee SET Employee_Name = @Name, Employee_Department = @Department, Employee_Description = @Description WHERE Employee_Id = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.Int32).Value = Employee.Id;
            parameters.Add("Name", DbType.String).Value = Employee.Name;
            parameters.Add("Department", DbType.String).Value = Employee.Department;
            parameters.Add("Description", DbType.String).Value = Employee.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteEmployee(Employee Employee)
        {
            string command = @"DELETE FROM Employee WHERE Employee_Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.Int32).Value = Employee.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Employee> GetAllEmployee()
        {
            string command = @"SELECT * FROM Employee ORDER BY Employee_Id ASC";
            IList<Employee> Employee = ExecuteQueryWithRowMapper(command);
            return Employee;
        }

        public Employee GetEmployeeByName(string name)
        {
            string command = @"SELECT * FROM Employee WHERE Employee_Name = @Name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Name", DbType.String).Value = name;

            IList<Employee> Employee = ExecuteQueryWithRowMapper(command, parameters);
            if (Employee.Count > 0)
            {
                return Employee[0];
            }

            return null;
        }

        public Employee GetEmployeeById(int id)
        {
            string command = @"SELECT * FROM Employee WHERE Employee_Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.Int32).Value = id;

            IList<Employee> Employee = ExecuteQueryWithRowMapper(command, parameters);
            if (Employee.Count > 0)
            {
                return Employee[0];
            }

            return null;
        }
    }
}
