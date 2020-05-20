
//=============================================
//  Developer:	<Subin Sunu Jacob>
//  Create date: <14th May,2020>
//  Related To : To validate the incoming inputs 
//=============================================

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
        [DisplayName("Employee Id")]
        int Employee_Id { get; set; }

        [Required(ErrorMessage = "Employee Name Can not be left blank")]
        [StringLength(255,ErrorMessage = "Employee Name can be of maximum 255 characters")]
        [DisplayName("Employee Name")]
        string Employee_Name { get; set; }

        [Required(ErrorMessage = "Age Can not be left blank")]
        int Age { get; set; }

        [DisplayName("Store Id")]
        int Store_Id { get; set; }

        [Required(ErrorMessage = "Password Can not be left blank")]
        [StringLength(255, ErrorMessage = "Password can be of maximum 255 characters")]
        string Password { get; set; }

        [Required(ErrorMessage = "Mobile Number Can not be left blank")]
        [StringLength(13, ErrorMessage = "Mobile number can only be 13 characters long with starting 3 characters defining the country code")]
        [DisplayName("Mobile Number")]
        string Mobile_No { get; set; }

        [Required(ErrorMessage = "Email Can not be left blank")]
        [StringLength(255, ErrorMessage = "Employee' email can be of maximum 255 characters")]
        string Email { get; set; }

        [Required(ErrorMessage = "City Can not be left blank")]
        [StringLength(255, ErrorMessage = "City Name can be of maximum 255 characters")]
        string City { get; set; }

        bool IsActive { get; set; }

        System.DateTime Creation_Date { get; set; }
    }


    [MetadataType(typeof(IEmployee))]
    public partial class Employee
    {

    }
}