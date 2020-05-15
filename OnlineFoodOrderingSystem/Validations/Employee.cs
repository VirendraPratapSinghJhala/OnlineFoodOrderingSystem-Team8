using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{
    public interface IEmployee
    {
        [Required(ErrorMessage = "Employee Id Can not be left blank")]
        [DisplayName("Employee Id")]
        int Employee_Id { get; set; }

        [Required(ErrorMessage = "Employee Name Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Employee Name")]
        string Employee_Name { get; set; }

        [Required(ErrorMessage = "Age Can not be left blank")]
        int Age { get; set; }

        [DisplayName("Store Id")]
        int Store_Id { get; set; }

        [Required(ErrorMessage = "Password Can not be left blank")]
        [StringLength(255)]
        string Password { get; set; }

        [Required(ErrorMessage = "Mobile Number Can not be left blank")]
        [StringLength(13)]
        [DisplayName("Mobile Number")]
        string Mobile_No { get; set; }

        [Required(ErrorMessage = "Email Can not be left blank")]
        [StringLength(255)]
        string Email { get; set; }

        [Required(ErrorMessage = "City Can not be left blank")]
        [StringLength(255)]
        string City { get; set; }

        bool IsActive { get; set; }

        System.DateTime Creation_Date { get; set; }
    }


    [MetadataType(typeof(IEmployee))]
    public partial class Employee
    {

    }
}