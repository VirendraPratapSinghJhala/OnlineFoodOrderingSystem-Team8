using FoodOrdering.Web.ExceptionLayer;
using FoodOrdering.Web.Models;
using FoodOrdering.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace OnlineFoodOrderingSystem.Controllers
{
    /// <summary>
    /// EmployeeController class manages the request/response scenerio for the Employees table in database by calling EmployeeService class's respective methods 
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Method GetAllEmployees() to get a list of all the employees
        /// </summary>
        /// <returns>List of Employees</returns>
        public List<Employee> GetAllEmployees()
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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

            else
            {
                // throw user defined exception object
                throw new EmployeeException("The entered details to fetch the Employees are not valid.");
            }
        }


        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>returns Employee type value</returns>
        public Employee GetEmployeeById(int employeeId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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

            else
            {
                //throw user defined exception object 
                throw new EmployeeException("The entered details to fetch the Employee are not valid");
            }
        }


        /// <summary>
        /// Method fetches the list of Employee corresponding to the passed employeeName
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns>returns List of Employee </returns>
        public List<Employee> GetEmployeeByName(string employeeName)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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

            else
            {
                //throw user defined exception object 
                throw new EmployeeException("The entered details to fetch the employees are not valid");
            }
        }


        /// <summary>
        /// Method Deletes the Employee with employeeId from table Employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteEmployeeById(int employeeId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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

            else
            {
                //throw user defined exception object 
                throw new EmployeeException("The employeeId is required ");
            }
        }

        /// <summary>
        /// AddEmployee(Employee employee) adds the employee to the Employees table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool value indicating the employeeId of the added employee</returns>
        public bool AddEmployee(Employee employee)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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
        /// <param name="employee"></param>
        /// <returns>boolean value</returns>
        public bool UpdateEmployee(Employee employee)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate EmployeeService class
                    EmployeeService fs = new EmployeeService();

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