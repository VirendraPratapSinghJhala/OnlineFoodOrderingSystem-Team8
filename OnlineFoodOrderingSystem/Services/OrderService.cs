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
    /// OrderService class provides service to the controller
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Provides the Cart details of a specific customer
        /// </summary>
        /// <param name="customerId">integer value to uniquely identify the customer</param>
        /// <returns>Cart in form of object of class Order</returns>
        public Order GetCartByCustomerId(int customerId)
        {
            using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
            {
                Order cart = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false));
                cart.Order_Items = db.Order_Items.Where(item => item.Order_Id == cart.Order_Id).ToList();
                return cart;
            }
        }

        /// <summary>
        /// Provides history of all previous orders of a specific customer
        /// </summary>
        /// <param name="customerId">integer value to uniquely identify the customer</param>
        /// <param name="fromEntryNo">integer value that will query the database from which entry number to begin from</param>
        /// <param name="toEntryNo">integer value that will query the database till which entry number to get record</param>
        /// <returns>List of all the past orders</returns>
        public List<Order> GetOrdersByCustomerId(int customerId, int fromEntryNo, int toEntryNo)
        {
            List<Order> OrdersList = new List<Order>();
            using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
            {
                try
                {
                    int totalOrdersCount = db.Orders.Select(o => o.isActive && o.Customer_Id == customerId).Count();
                    if (fromEntryNo > totalOrdersCount)
                    {
                        throw new FoodOrderException();
                    }
                    if (toEntryNo > totalOrdersCount)
                    {
                        toEntryNo = totalOrdersCount;
                    }
                    OrdersList = db.Orders.Where(o => o.isActive && o.Customer_Id == customerId).Skip(fromEntryNo - 1).Take(toEntryNo - fromEntryNo).ToList();
                    foreach (var order in OrdersList)
                    {
                        order.Order_Items = db.Order_Items.Where(item => item.Order_Id == order.Order_Id).ToList();
                    }
                }
                catch
                {
                    throw new FoodOrderException();
                }
                return OrdersList;
            }
        }

        /// <summary>
        /// Converts a "cart" into an order by submitting it
        /// </summary>
        /// <param name="customerId">integer value to uniquely identify the customer</param>
        /// <returns>boolean value true if successfully submitted, false if not submitted</returns>
        public bool SubmitOrder(int customerId)
        {
            using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
            {
                bool isSubmitted = false;
                try
                {
                    Order cart = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false));
                    cart.Submit_Status = true;
                    db.SaveChanges();
                }
                catch
                {
                    throw new FoodOrderException();
                }
                return isSubmitted;
            }
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="foodItemId"></param>
        /// <param name="foodItemQuantity"></param>
        /// <returns></returns>
        public bool UpdateCart(int customerId, int foodItemId, int foodItemQuantity)
        {
            using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
            {
                bool isUpdated = false;

                try
                {
                    int cartId = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false)).Order_Id;
                    decimal foodItemPrice = db.Food_Items.FirstOrDefault(item => item.IsActive && item.Food_Item_Id == foodItemId).Price;
                    Order_Item itemObject = db.Order_Items.FirstOrDefault(i => i.Order_Id == cartId);
                    if (itemObject == null || !Convert.ToBoolean(itemObject))
                    {
                        db.Order_Items.Add(new Order_Item(){ Order_Id = cartId, Food_Item_Id = foodItemId, Quantity = foodItemQuantity, Price = foodItemPrice });
                    }
                    else
                    {
                        itemObject.Quantity = foodItemQuantity;
                        itemObject.Price = foodItemPrice;
                    }
                    db.SaveChanges();
                }
                catch
                {
                    throw new FoodOrderException();
                }

                return isUpdated;
            }
        }
    }
}