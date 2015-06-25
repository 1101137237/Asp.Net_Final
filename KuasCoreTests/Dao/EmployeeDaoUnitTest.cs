using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class EmployeeDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeDao EmployeeDao { get; set; }


        [TestMethod]
        public void TestEmployeeDao_AddEmployee()
        {
            Employee Employee = new Employee();
            Employee.Id = "UnitTests";
            Employee.Name = "單元測試";
            Employee.Description = "請做出單元測試";
            EmployeeDao.AddEmployee(Employee);

            Employee dbEmployee = EmployeeDao.GetEmployeeByName(Employee.Name);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(Employee.Name, dbEmployee.Name);

            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工名稱為 = " + dbEmployee.Name);
            Console.WriteLine("員工描述為 = " + dbEmployee.Description);

            EmployeeDao.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeDao.GetEmployeeByName(Employee.Name);
            Assert.IsNull(dbEmployee);
        }

    }
}
