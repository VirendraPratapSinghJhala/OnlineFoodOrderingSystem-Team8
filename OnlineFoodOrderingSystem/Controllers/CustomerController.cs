//=============================================
//  Developer:	<Mehul Jain>
//  Create date: <15th May,2020>
//  Description : To manage Customers related requests/response scenerio
//=============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.Services;


namespace OnlineFoodOrderingSystem.Controllers
{

    /// <summary>
    /// CustomerController class manages the request/response scenerio for the Customers table in database by calling CustomerService class's respective methods 
    /// to implement the corresponding operation
    /// </summary>
    public class CustomerController : ApiController
    {

        //instantiate CustomerService class
        CustomerService cs;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerController()
        {
            cs = new CustomerService();
        }


        /// <summary>
        /// Method GetAllCustomers() to get a list of all the Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetAllCustomers()
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //Call GetAllCustomers() to fetch all Customers 
                    List<Customer> customersList = cs.GetAllCustomers();

                    //return the response
                    return customersList;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The entered details to fetch the Customers are not valid");
            }
        }


        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>returns Customer type value</returns>
        public Customer GetCustomerById(int customerId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {

                    //Call GetCustomerById() to fetch the Customer 
                    Customer customer = cs.GetCustomerById(customerId);

                    //return the response
                    return customer;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The entered details to fetch the Customer are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerName
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns>returns List of Customers </returns>
        public List<Customer> GetCustomerByCustomerName(string customerName)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate CustomerService class
                    CustomerService cs = new CustomerService();

                    //Call GetCustomerByCustomerName method to fetch all Customers corresponding to  customerName
                    List<Customer> customers = cs.GetCustomerByCustomerName(customerName);

                    //return the response
                    return customers;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The entered details to fetch the Customers are not valid");
            }
        }


        /// <summary>
        /// Method Deletes the Customer with customerId from table Customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteCustomerById(int customerId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate CustomerService class
                    CustomerService cs = new CustomerService();

                    //Call DeleteCustomerById() to delete the Customer 
                    bool isDeleted = cs.DeleteCustomerById(customerId);

                    //return the response
                    return isDeleted;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The customerId is required ");
            }
        }


        /// <summary>
        /// AddCustomer(Customer customer) adds the customer to the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>integer value indicating the Customer_Id of the added Customer</returns>
        public bool AddCustomer(Customer customer)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate CustomerService class
                    CustomerService cs = new CustomerService();

                    //Call AddCustomer method to fetch all Food Items 
                    bool isAdded = cs.AddCustomer(customer);

                    //return the response
                    return isAdded;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The entered details to fetch the Customers are not valid");
            }
        }

        /// <summary>
        /// Method updates or edits the changes of the passed customer in the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>boolean value</returns>
        public bool UpdateCustomer(Customer customer)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    CustomerService cs = new CustomerService();

                    //Call UpdateCustomer method to update the Customer 
                    bool isUpdated = cs.UpdateCustomer(customer);

                    //return the response
                    return isUpdated;
                }
                catch (CustomerException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new CustomerException("The entered details to update the Customer are not valid");
            }
        }



    }
}
