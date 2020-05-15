using FoodOrdering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.ServiceContracts
{
    /// <summary>
    /// Interface IEmployeeService having methods to be implemented by class EmployeeService 
    /// </summary>
    interface IEmployeeService
    {
        /// <summary>
        /// Method GetAllEmployees() to get a list of all the Employees
        /// </summary>
        /// <returns>List of Employee</returns>
        List<Employee> GetAllEmployees();

        /// <summary>
        /// AddEmployee(Employee employee) adds the employee to the Employees table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool value indicating the Employee_Id of the added employee</returns>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>returns Employee type value</returns>
        Employee GetEmployeeById(int employeeId);

        /// <summary>
        /// Method Deletes the Employee with employeeId from table Employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>boolean value</returns>
        bool DeleteEmployeeById(int employeeId);

        /// <summary>
        /// Method updates or edits the changes of the passed employee in the Employees table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>boolean value</returns>
        bool UpdateEmployee(Employee employee);

        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeName
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns>returns List of Employee </returns>
        List<Employee> GetEmployeeByName(string employeeName);
    }
}
