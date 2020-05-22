using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Validations
{
    interface Order
    {
        int Order_Id { get; set; }
        [Required(ErrorMessage = "Customer id cannot be left blank")]
        [DisplayName("Customer Id")]
        int Customer_Id { get; set; }
        [Required(ErrorMessage = "Customer id cannot be left blank")]
        [DisplayName("Customer Id")]
        bool Submit_Status { get; set; }
        Nullable<System.DateTime> Order_date { get; set; }
        Nullable<int> Total_Quantity { get; set; }
        Nullable<int> Total_Price { get; set; }
        Nullable<int> Food_Store_Id { get; set; }
        Nullable<int> Employee_Id { get; set; }
        bool isActive { get; set; }
        System.DateTime Creation_Date { get; set; }
    }
}