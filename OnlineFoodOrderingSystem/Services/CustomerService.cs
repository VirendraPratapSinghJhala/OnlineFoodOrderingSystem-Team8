

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
    /// class CustomerService implements ICustomerService interface And manages CRUD operations on the Customers table
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Method GetAllCustomers() to get a list of all the Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetAllCustomers()
        {
            //instantiating Online_Food_Ordering_SystemEntities3 Context class
            try
            {
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to fetch list of customers from table Customers
                    List<OnlineFoodOrderingSystem.Models.Customer> customersList = db.Customers.ToList();

                    //return obtained data 
                    return customersList;

                }
            }
            catch (Exception ex)
            {
                //throw user defined CustomerException
                throw new CustomerException(ex.Message);
            }

        }

        /// <summary>
        /// AddCustomer(Customers customer) adds the customer to the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>integer value indicating the Customer_Id of the added foodItem</returns>
        public bool AddCustomer(Customer customer)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to Add Customers into table Customers
                    db.Customers.Add(customer);

                    //save changes to the database
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                //throw user defined CustomerException
                throw new CustomerException(ex.Message);
            }

        }


        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>returns Customer type value</returns>
        public Customer GetCustomerById(int customerId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed foodItemId
                   Customer item = db.Customers.Where(c => c.Customer_Id == customerId && c.IsActive == true).FirstOrDefault();

                    //return response
                    return item;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined CustomerException
                throw new CustomerException(ex.Message);
            }
        }



        /// <summary>
        /// Method Deletes the Customer with customerId from table Customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteCustomerById(int customerId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the Customer with id customerId
                    Customer item = db.Customers.Where(c => c.Customer_Id == customerId && c.IsActive == true).FirstOrDefault();

                    if (item != null)
                    {
                        //remove item from Customers
                        db.Customers.Remove(item);

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    return false;

                }
            }
            catch (Exception ex)
            {
                //throw user defined CustomerException
                throw new CustomerException(ex.Message);
            }
        }


        /// <summary>
        /// Method updates or edits the changes of the passed customer in the Customers table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>boolean value</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the Food Item with id foodItem.Food_Item_Id
                    Customer item = db.Customers.Where(c => c.Customer_Id == customer.Customer_Id && c.IsActive == true).FirstOrDefault();

                    if (item != null)
                    {
                        //update  Customer details 
                        item.Customer_Name = customer.Customer_Name;
                        item.Age = customer.Age;
                        item.Password = customer.Password;
                        item.Mobile_No = customer.Mobile_No;
                        item.Email = customer.Email;
                        item.City = customer.City;

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    return false;

                }

            }
            catch (Exception ex)
            {
                //throw user defined CustomerException
                throw new CustomerException(ex.Message);
            }

        }


        /// <summary>
        /// Method fetches the Customer corresponding to the passed customerName
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns>returns List of Customers </returns>
        public List<Customer> GetCustomerByCustomerName(string customerName)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed food Item name with case insensitivity of Food Item Name
                    List<Customer> items = db.Customers.Where(c => c.Customer_Name.Equals(customerName, StringComparison.OrdinalIgnoreCase) && c.IsActive == true).ToList();

                    //return response
                    return items;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined CustomerException
                throw new CustomerException(ex.Message);
            }
        }

       
    }
}