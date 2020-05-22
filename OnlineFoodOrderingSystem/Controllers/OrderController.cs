using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineFoodOrderingSystem.Controllers
{
    /// <summary>
    /// OrderController responds to all requests regarding orders and cart
    /// </summary>
    public class OrderController : ApiController
    {
        OrderService os;

        public OrderController()
        {
            os = new OrderService();
        }

        /// <summary>
        /// Fetches order history of the customer
        /// </summary>
        /// <param name="customerId">Uniquely identifies the customer</param>
        /// <param name="fromEntryNo">From which entry of database to provide response?</param>
        /// <param name="toEntryNo">To which entry of database to provide response?</param>
        /// <returns>Order History of the user as a List of Order(s)</returns>
        public List<Order> GetCustomerOrders(int customerId, int fromEntryNo, int toEntryNo)
        {
                List<Order> OrderHistory = new List<Order>();
                try
                {
                    OrderHistory = os.GetOrdersByCustomerId(customerId, fromEntryNo, toEntryNo);
                }
                catch (FoodOrderException fe)
                {
                    BadRequest(fe.Message);
                }
                return OrderHistory;
        }
        /// <summary>
        /// Gets the cart and its items for the customer
        /// </summary>
        /// <param name="customerId">Uniquely identify the customer</param>
        /// <returns>Cart which is not submitted as an order yet</returns>
        public Order GetCustomerCart(int customerId)
        {
                Order Cart = null;
                try
                {
                    Cart = os.GetCartByCustomerId(customerId);
                }
                catch (FoodOrderException e)
                {
                    BadRequest(e.Message);
                }
                return Cart;
        }
        /// <summary>
        /// Updates cart of a customer in terms of new food item added or quantity changed
        /// </summary>
        /// <param name="customerId">Uniquely identifies the customer</param>
        /// <param name="foodItemId">Uniquely identifies a food item</param>
        /// <param name="foodItemQuantity">Quantity of the food item to be updated in the database</param>
        /// <returns>Boolean value true if the cart is updated successfully and vice-versa</returns>
        [HttpPut]
        [Route("api/order/updatecart")]
        public bool UpdateCart(Order order)
        {
            if (true)
            {
                bool isCartUpdated = false;
                try
                {
                    OrderService os = new OrderService();
                    isCartUpdated = os.UpdateCart(order.Customer_Id, order.Order_Items);
                }
                catch (FoodOrderException e)
                {
                    BadRequest(e.Message);
                }
                return isCartUpdated;
            }
            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to update the cart are not valid");
            }
        }
        /// <summary>
        /// Submits the cart items to create an order
        /// </summary>
        /// <param name="customerId">Uniquely identifies a customer</param>
        /// <returns>Boolean value true if order is submitted successfully and vice-versa</returns>
        public bool SubmitOrder(int customerId)
        {
            if (ModelState.IsValid)
            {
                bool isOrderSubmitted = false;
                try
                {
                    isOrderSubmitted = os.SubmitOrder(customerId);
                }
                catch (FoodOrderException)
                {
                    throw;
                }
                return isOrderSubmitted;
            }
            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to submit the order are not valid");
            }
        }
    }
}