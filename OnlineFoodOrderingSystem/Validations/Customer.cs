using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{

    public interface ICustomer
    {

        int Customer_Id { get; set; }

        [Required(ErrorMessage = "Customer Name Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Customer Name")]
        string Customer_Name { get; set; }

        [Required(ErrorMessage = "Age Can not be left blank")]
        [DisplayName("Age")]
        int Age { get; set; }

        [Required(ErrorMessage = "Password Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Password")]
        string Password { get; set; }

        [Required(ErrorMessage = "Mobile No Can not be left blank")]
        [StringLength(13)]
        [DisplayName("Mobile No")]
        string Mobile_No { get; set; }

        [Required(ErrorMessage = "Email Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Email")]
        string Email { get; set; }

        [Required(ErrorMessage = "City Can not be left blank")]
        [StringLength(50)]
        [DisplayName("City")]
        string City { get; set; }

        bool IsActive { get; set; }

        System.DateTime Creation_Date { get; set; }
    }

    [MetadataType(typeof(ICustomer))]
    public partial class Customer
    {



    }
}