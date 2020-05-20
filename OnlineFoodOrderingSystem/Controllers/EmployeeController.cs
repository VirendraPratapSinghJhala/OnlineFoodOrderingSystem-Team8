//=============================================
//  Developer:	<Subin Sunu Jacob>
//  Create date: <14th May,2020>
//  Related To : To manage Employee related requests/response scenerio
//=============================================

using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodOrderingSystem.Controllers
{
    /// <summary>
    /// EmployeeController class manages the request/response scenerio for the Employees table in database by calling EmployeeService class's respective methods 
    /// </summary>
    public class EmployeeController : ApiController
    {
        //declare EmployeeService type instance variable
        EmployeeService fs;

        EmployeeController()
        {
            //instantiate EmployeeService class
            fs = new EmployeeService();
        }

        /// <summary>
        /// Method GetAllEmployees() to get a list of all the employees
        /// </summary>
        /// <returns>List of Employees</returns>
        public List<Employee> GetAllEmployees()
        {
            try
            {
                //call GetAllEmployees() to fetch all Employees
                List<Employee> employeesList = fs.GetAllEmployees();

                //return the response
                return employeesList;
            }
            catch (EmployeeException)
            {
                //rethrow
                throw;
            }

        }


        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeId
        /// </summary>
        /// <param name="employeeId">indicates id of the employee to be searched</param>
        /// <returns>returns Employee type value </returns>
        public Employee GetEmployeeById(int employeeId)
        {
            try
            {
                //Call GetEmployeeById(int employeeId) to fetch the employee 
                Employee employee = fs.GetEmployeeById(employeeId);

                //return the response
                return employee;
            }
            catch (EmployeeException)
            {
                //rethrow
                throw;
            }
        }


        /// <summary>
        /// Method fetches the list of Employee corresponding to the passed employeeName
        /// </summary>
        /// <param name="employeeName">name of employee to be searched</param>
        /// <returns>returns List of Employees with same name</returns>
        public List<Employee> GetEmployeeByName(string employeeName)
        {
            try
            {
                //Call GetEmployeeByName method to fetch all Employees corresponding to employeeName
                List<Employee> employees = fs.GetEmployeeByName(employeeName);

                //return the response
                return employees;
            }
            catch (EmployeeException)
            {
                //rethrow
                throw;
            }
        }


        /// <summary>
        /// Method Deletes the Employee with employeeId from table Employees
        /// </summary>
        /// <param name="employeeId">the id of employee to be deleted</param>
        /// <returns>boolean value true denoting successful deletion and false for failure in such</returns>
        public bool DeleteEmployeeById(int employeeId)
        {
            try
            {
                //Call DeleteEmployeeById(int employeeId) to delete the Employee 
                bool isDeleted = fs.DeleteEmployeeById(employeeId);

                //return the response
                return isDeleted;
            }
            catch (EmployeeException)
            {
                //rethrow
                throw;
            }
        }

        /// <summary>
        /// AddEmployee(Employee employee) adds the employee to the Employees table
        /// </summary>
        /// <param name="employee">Employee type value that is to be added</param>
        /// <returns>bool value indicating the employeeId of the added employee</returns>
        public bool AddEmployee(Employee employee)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    employee.IsActive = true;
                    employee.Creation_Date = DateTime.Now;

                    //Call AddEmployee method to fetch add an Employee 
                    bool isAdded = fs.AddEmployee(employee);

                    //return the response
                    return isAdded;
                }
                catch (EmployeeException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new EmployeeException("The entered details to add the employee are not valid");
            }
        }


        /// <summary>
        /// Method updates or edits the changes of the passed employee in the Employees table
        /// </summary>
        /// <param name="employee"> Employee type value to be updated</param>
        /// <returns>boolean value true shows the value is updated and false shows it failed to do so</returns>
        public bool UpdateEmployee(Employee employee)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //Call UpdateEmployee method to fetch update Employee 
                    bool isUpdated = fs.UpdateEmployee(employee);

                    //return the response
                    return isUpdated;
                }
                catch (EmployeeException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new EmployeeException("The entered details to update the employee are not valid");
            }
        }


    }
}