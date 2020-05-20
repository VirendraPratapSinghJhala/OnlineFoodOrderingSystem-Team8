
//=============================================
//  Developer:	<Subin Sunu Jacob>
//  Create date: <15th May,2020>
//  Description: Defines contract for EmployeeService and all related classes to implement all its methods
//=============================================


using OnlineFoodOrderingSystem.Models;
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
    public interface IEmployeeService
    {
        /// <summary>
        /// Method GetAllEmployees() to get a list of all the Employees
        /// </summary>
        /// <returns>List of Employee</returns>
        List<Employee> GetAllEmployees();

        /// <summary>
        /// AddEmployee(Employees employee) adds the employee to the Employees table
        /// </summary>
        /// <param name="employee">Employee type value that is to be added</param>
        /// <returns>bool value indicating the employeeId of the added employee</returns>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeId
        /// </summary>
        /// <param name="employeeId">indicates id of the employee to be searched</param>
        /// <returns>returns Employee type value</returns>
        Employee GetEmployeeById(int employeeId);

        /// <summary>
        /// Method Deletes the Employee with employeeId from table Employees
        /// </summary>
        /// <param name="employeeId">the id of employee to be deleted</param>
        /// <returns>boolean value true denoting successful deletion and false for failure in such</returns>
        bool DeleteEmployeeById(int employeeId);

        /// <summary>
        /// Method updates or edits the changes of the passed employee in the Employees table
        /// </summary>
        /// <param name="employee">Employee type value to be updated</param>
        /// <returns>boolean value true shows the value is updated and false shows it failed to do so</returns>
        bool UpdateEmployee(Employee employee);

        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeName
        /// </summary>
        /// <param name="employeeName">name of employee to be searched</param>
        /// <returns>returns List of Employees with same name </returns>
        List<Employee> GetEmployeeByName(string employeeName);
    }
}
