
using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.ServiceContracts
{
    /// <summary>
    /// Interface ICustomerService having methods to be implemented by class CustomerService 
    /// </summary>
    interface ICustomerService
    {
        /// <summary>
        /// Method GetAllCustomers() to get a list of all the Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// AddCustomer(Customer customer) adds the customer to the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>integer value indicating the Customer_Id of the added customer</returns>
        bool AddCustomer(Customer customer);

        /// <summary>
        /// Method Deletes the Customer with customerId from table Customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>boolean value</returns>
        bool DeleteCustomerById(int customerId);

        /// <summary>
        /// Method updates or edits the changes of the passed customer in the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>boolean value</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>returns Customer type value</returns>
        Customer GetCustomerById(int customerId);

        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerName
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns>returns List of Customers </returns>
        List<Customer> GetCustomerByCustomerName(string customerName);


    }
}
