using Core;
using KuasCore.Models;
using KuasCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class EmployeeServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeService EmployeeService { get; set; }

        [TestMethod]
        public void TestEmployeeService_AddEmployee()
        {

            Employee Employee = new Employee();
            Employee.Id = "UnitTests";
            Employee.Name = "單元測試";
            Employee.Description = "請做出單元測試";
            EmployeeService.AddEmployee(Employee);

            Employee dbEmployee = EmployeeService.GetEmployeeByName(Employee.Name);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(Employee.Name, dbEmployee.Name);

            Console.WriteLine("課程編號為 = " + dbEmployee.Id);
            Console.WriteLine("課程名稱為 = " + dbEmployee.Name);
            Console.WriteLine("課程描述為 = " + dbEmployee.Description);

            EmployeeService.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeService.GetEmployeeByName(Employee.Name);
            Assert.IsNull(dbEmployee);
        }

    }
}
