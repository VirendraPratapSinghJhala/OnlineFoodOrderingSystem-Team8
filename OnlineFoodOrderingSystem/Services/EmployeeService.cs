
//=============================================
//  Developer:	<Subin Sunu Jacob>
//  Create date: <15th May,2020>
//  Description : To perform business logic and accordingly return response to EmployeeController
//=============================================

using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Services
{
    /// <summary>
    /// class EmployeeService implements IEmployeeService interface And manages CRUD operations on the Employees table
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Method GetAllEmployees() to get a list of all the Employees
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<Employee> GetAllEmployees()
        {
            //instantiating Online_Food_Ordering_SystemEntities1 Context class
            try
            {
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to fetch list of employees from table Employees
                    List<Employee> employeeList = db.Employees.Where(f => f.IsActive == true).ToList();

                    //assigning lazy loading to be false
                    db.Configuration.LazyLoadingEnabled = false;

                    //return obtained data 
                    return employeeList;

                }
            }
            catch (Exception ex)
            {
                //throw user defined EmployeeException
                throw new EmployeeException(ex.Message);
            }

        }

        /// <summary>
        /// AddEmployee(Employees employee) adds the employee to the Employees table
        /// </summary>
        /// <param name="employee">Employee type value that is to be added</param>
        /// <returns>bool value indicating the employeeId of the added employee</returns>
        public bool AddEmployee(Employee employee)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //check if the employee already exists
                    Employee item = db.Employees.Where(f => f.Email.Equals(employee.Email, StringComparison.OrdinalIgnoreCase) && f.IsActive == true).FirstOrDefault();

                    if (item != null)
                    {
                        //if exists then throw exception
                        throw new FoodOrderException("Employee already present");
                    }

                    //set IsActive to true
                    employee.IsActive = true;

                    //set Creation Date to be the 
                    employee.Creation_Date = DateTime.Now;

                    //use LINQ query to Add Employee to table Employees
                    db.Employees.Add(employee);

                    //save changes to the database
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                //throw user defined EmployeeException
                throw new EmployeeException(ex.Message);
            }

        }


        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeId
        /// </summary>
        /// <param name="employeeId">indicates id of the employee to be searched</param>
        /// <returns>returns Employee type value</returns>
        public Employee GetEmployeeById(int employeeId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Employee corresponding to passed employeeId
                    Employee employee = db.Employees.Where(f => f.Employee_Id == employeeId && f.IsActive == true).FirstOrDefault();

                    //return response
                    return employee;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined EmployeeException
                throw new EmployeeException(ex.Message);
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
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the Employee with id employeeId
                    Employee employee = db.Employees.Where(f => f.Employee_Id == employeeId && f.IsActive == true).FirstOrDefault();

                    if (employee != null)
                    //use LINQ query to delete employee from table Employees
                    {
                        //remove employee from Employees
                        db.Employees.Remove(employee);

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    else
                    {
                        throw new EmployeeException("Employee does not exist");
                    }

                }
            }
            catch (Exception ex)
            {
                //throw user defined EmployeeException
                throw new EmployeeException(ex.Message);
            }
        }


        /// <summary>
        /// Method updates or edits the changes of the passed employee in the Employees table
        /// </summary>
        /// <param name="employee">Employee type value to be updated</param>
        /// <returns>boolean value true shows the value is updated and false shows it failed to do so</returns>
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the employee with id employee.Employee_Id
                    Employee item = db.Employees.Where(f => f.Employee_Id == employee.Employee_Id && f.IsActive == true).FirstOrDefault();

                    if (item != null)
                    {
                        //update Employee details 
                        item.Employee_Name = employee.Employee_Name;
                        item.Age = employee.Age;
                        item.Store_Id = employee.Store_Id;
                        item.Password = employee.Password;
                        item.Mobile_No = employee.Mobile_No;
                        item.Email = employee.Email;
                        item.City = employee.City;

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    else
                    {
                        throw new EmployeeException("Employee does not exist");
                    }

                }

            }
            catch (Exception ex)
            {
                //throw user defined EmployeeException
                throw new EmployeeException(ex.Message);
            }

        }

        /// <summary>
        /// Method fetches the Employee corresponding to the passed employeeName
        /// </summary>
        /// <param name="employeeName">name of employee to be searched</param>
        /// <returns>returns List of Employees with same name </returns>
        public List<Employee> GetEmployeeByName(string employeeName)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Employees corresponding to passed employee name with case insensitivity of Employee Name
                    List<Employee> employees = db.Employees.Where(f => f.Employee_Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase) && f.IsActive == true).ToList();

                    //return response
                    return employees;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined EmployeeException
                throw new EmployeeException(ex.Message);
            }
        }

    }
}