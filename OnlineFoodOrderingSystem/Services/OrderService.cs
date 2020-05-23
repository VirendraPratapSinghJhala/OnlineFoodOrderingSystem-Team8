using Microsoft.Ajax.Utilities;
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
            using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
            {
                var cartQuery = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false));
                var cart = new Order();
                if (cartQuery != null)
                {
                    cart.Customer_Id = cartQuery.Customer_Id;
                    cart.Order_Id = cartQuery.Order_Id;
                    cart.Order_Items = new List<Order_Item>();
                    cart.Creation_Date = cartQuery.Creation_Date;
                    cart.Employee_Id = cartQuery.Employee_Id;
                    cart.Food_Store_Id = cartQuery.Food_Store_Id;
                    cart.Order_date = cartQuery.Order_date;
                    cart.Total_Price = cartQuery.Total_Price;
                    cart.Total_Quantity = cartQuery.Total_Quantity;
                }
                List<Order_Item> cartItemsQuery = db.Order_Items.Where(item => item.Order_Id == cart.Order_Id).ToList();
                List<Order_Item> cartItems = new List<Order_Item>();
                if (cartItemsQuery != null)
                {
                    foreach (Order_Item singleItem in cartItemsQuery)
                    {
                        var currentItemFoodObject = db.Food_Items.FirstOrDefault(fitem => fitem.Food_Item_Id == singleItem.Food_Item_Id);
                        Food_Item food = currentItemFoodObject != null
                            ?
                            new Food_Item() { Food_Name = currentItemFoodObject.Food_Name, Food_Type = currentItemFoodObject.Food_Type, ImagePath = currentItemFoodObject.ImagePath }
                            : null;
                        cartItems.Add(new Order_Item() { Order_Id = singleItem.Order_Id, Food_Item_Id = singleItem.Food_Item_Id, Food_Items = food, Price = singleItem.Price, Quantity = singleItem.Quantity });
                    }
                }
                cart.Order_Items = cartItems;
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
            using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
            {
                try
                {
                    int totalOrdersCount = db.Orders.Select(o => o.isActive && o.Customer_Id == customerId && o.Submit_Status).Count();
                    if (fromEntryNo > totalOrdersCount)
                    {
                        throw new FoodOrderException($"Not enough entries to start from {fromEntryNo}");
                    }
                    if (toEntryNo > totalOrdersCount)
                    {
                        toEntryNo = totalOrdersCount;
                    }
                    IQueryable<Order> OrdersQuery = db.Orders.Where(o => o.isActive && o.Customer_Id == customerId && o.Submit_Status);
                    if (OrdersQuery != null)
                    {
                        foreach (Order singleOrder in OrdersQuery)
                        {
                            Order orderToAdd = new Order()
                            {
                                Customer_Id = singleOrder.Customer_Id,
                                Order_date = singleOrder.Order_date,
                                Order_Id = singleOrder.Order_Id,
                                Employee_Id = singleOrder.Employee_Id,
                                Food_Store_Id = singleOrder.Food_Store_Id,
                                Total_Price = singleOrder.Total_Price,
                                Total_Quantity = singleOrder.Total_Quantity,
                                isActive = singleOrder.isActive,
                                Submit_Status = singleOrder.Submit_Status
                            };
                            List<Order_Item> orderItemsQuery = db.Order_Items.Where(item => item.Order_Id == orderToAdd.Order_Id).ToList();
                            List<Order_Item> orderItems = new List<Order_Item>();
                            if (orderItemsQuery != null)
                            {
                                foreach (Order_Item singleItem in orderItemsQuery)
                                {
                                    var currentItemFoodObject = db.Food_Items.FirstOrDefault(fitem => fitem.Food_Item_Id == singleItem.Food_Item_Id);
                                    Food_Item food = currentItemFoodObject != null
                                        ?
                                        new Food_Item() { Food_Name = currentItemFoodObject.Food_Name, Food_Type = currentItemFoodObject.Food_Type, ImagePath = currentItemFoodObject.ImagePath }
                                        : null;
                                    orderItems.Add(new Order_Item() { Order_Id = singleItem.Order_Id, Food_Item_Id = singleItem.Food_Item_Id, Food_Items = food, Price = singleItem.Price, Quantity = singleItem.Quantity });
                                }
                            }
                            orderToAdd.Order_Items = orderItems;
                            OrdersList.Add(orderToAdd);
                        }
                    }
                }
                catch
                {
                    throw new FoodOrderException("Not able to fetch Order List");
                }
                OrdersList.Reverse();
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
            using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
            {
                bool isSubmitted = false;
                try
                {
                    Order cart = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false));
                    cart.Submit_Status = true;
                    cart.Order_date = DateTime.Now;
                    db.SaveChanges();
                    isSubmitted = true;
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
        public bool UpdateCart(int customerId, ICollection<Order_Item> orderItems)
        {
            using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
            {
                bool isUpdated = false;

                try
                {
                    //find if customer exists, if not then:
                    if (db.Customers.Where(c => c.Customer_Id == customerId).Count() == 0)
                    {
                        throw new FoodOrderException("Customer Doesn't Exist");
                    }
                    //find cart for given customer
                    Order cart = db.Orders.FirstOrDefault(o => (o.isActive && o.Customer_Id == customerId && o.Submit_Status == false));
                    //if cart doesn't exist for customer
                    int finalTotalPrice = 0;
                    int finalTotalQuantity = 0;
                    if (cart == null)
                    {
                        foreach (Order_Item o in orderItems)
                        {
                            //setting the latest price of the product in the cart
                            decimal foodItemPrice = db.Food_Items.FirstOrDefault(item => item.IsActive && item.Food_Item_Id == o.Food_Item_Id).Price;
                            o.Price = foodItemPrice;
                            if (o.Quantity < 1)
                            {
                                orderItems.Remove(o);
                            }
                        }

                        Order newCart = new Order()
                        {
                            Customer_Id = customerId,
                            Order_date = DateTime.Now,
                            Employee = null,
                            Order_Items = orderItems,
                            Food_Store_Id = null,
                            Submit_Status = false,
                            Creation_Date = DateTime.Now,
                            isActive = true
                        };
                        cart = newCart;
                        db.Orders.Add(newCart);
                    }
                    //else if cart exists for customer
                    else
                    {
                        foreach (Order_Item orderItem in orderItems)
                        {
                            //find latest price of given orderItem
                            Food_Item foodItemForPrice = db.Food_Items.FirstOrDefault(item => item.IsActive && item.Food_Item_Id == orderItem.Food_Item_Id);
                            if (foodItemForPrice == null)
                            {
                                continue;
                            }
                            decimal foodItemPrice = foodItemForPrice.Price;
                            //find if item already exist in cart
                            Order_Item existingOrderItem = db.Order_Items.FirstOrDefault(i => i.Order_Id == cart.Order_Id && i.Food_Item_Id == orderItem.Food_Item_Id);
                            //if item doesn't already exist in the cart add new item
                            if (existingOrderItem == null)
                            {
                                if (orderItem.Quantity > 0)
                                {
                                    db.Order_Items.Add(new Order_Item() { Order_Id = cart.Order_Id, Food_Item_Id = orderItem.Food_Item_Id, Quantity = orderItem.Quantity, Price = foodItemPrice });
                                }
                            }
                            //else if item exists in the cart update quantity and latest price
                            else
                            {
                                existingOrderItem.Quantity = orderItem.Quantity;
                                existingOrderItem.Price = foodItemPrice;
                            }
                        }
                    }
                    db.SaveChanges();
                    //Updating Total_Quantity and Total_Price in the db
                    IQueryable<Order_Item> orderItemList = db.Order_Items.Where(item => item.Order_Id == cart.Order_Id);
                    foreach (Order_Item orderItem in orderItemList)
                    {
                        finalTotalQuantity += (int)orderItem.Quantity;
                        finalTotalPrice += (int)orderItem.Price * (int)orderItem.Quantity;
                        if (orderItem.Quantity < 1)
                        {
                            db.Order_Items.Remove(orderItem);
                        }
                    }
                    cart.Total_Quantity = finalTotalQuantity;
                    cart.Total_Price = finalTotalPrice;

                    db.SaveChanges();
                    isUpdated = true;
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