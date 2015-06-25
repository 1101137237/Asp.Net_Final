using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http; 

namespace KuasWebApp.Controllers
{
    public class EmployeeController : ApiController 
    {

        public IEmployeeService EmployeeService { get; set; }

        [HttpPost]
        public Employee AddEmployee(Employee Employee)
        {
            CheckEmployeeIsNotNullThrowException(Employee);

            try
            {
                return EmployeeService.AddEmployee(Employee);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Employee UpdateEmployee(Employee Employee)
        {
            CheckEmployeeIsNullThrowException(Employee);

            try
            {
                EmployeeService.UpdateEmployee(Employee);
                return EmployeeService.GetEmployeeByName(Employee.Name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteEmployee(Employee Employee)
        {
            try
            {
                EmployeeService.DeleteEmployee(Employee);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Employee> GetAllEmployee()
        {
            return EmployeeService.GetAllEmployee();
        }

        [HttpGet]
        public Employee GetEmployeeById(string id)
        {
            var Employee = EmployeeService.GetEmployeeById(id);

            if (Employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Employee;
        }

        [HttpGet]
        [ActionName("Name")]
        public Employee GetEmployeeByName(string input)
        {
            var Employee = EmployeeService.GetEmployeeByName(input);

            if (Employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Employee;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckEmployeeIsNullThrowException(Employee Employee)
        {
            Employee dbEmployee = EmployeeService.GetEmployeeById(Employee.Id);

            if (dbEmployee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckEmployeeIsNotNullThrowException(Employee Employee)
        {
            Employee dbEmployee = EmployeeService.GetEmployeeById(Employee.Id);

            if (dbEmployee != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}