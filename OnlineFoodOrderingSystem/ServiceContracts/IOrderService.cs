using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.ServiceContracts
{
    /// <summary>
    /// Interface that will be implemented by OrderService class
    /// </summary>
    interface IOrderService
    {
        List<Order> GetOrdersByCustomerId(int customerId, int fromEntryNo, int toEntryNo);
        Order GetCartByCustomerId(int customerId);
        bool UpdateCart(int customerId, ICollection<Order_Item> orderItems);
        bool SubmitOrder(int customerId);
    }
}
