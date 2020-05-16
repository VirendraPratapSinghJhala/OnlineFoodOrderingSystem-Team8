using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{

    public interface IFood_Store
    {

        int Food_Store_Id { get; set; }

        [Required(ErrorMessage = "Store Name Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Store Name")]
        string Food_Store_Name { get; set; }

        [Required(ErrorMessage = "Location Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Location")]
        string Location { get; set; }

        [Required(ErrorMessage = "Mobile Number Can not be left blank")]
        [StringLength(13)]
        [DisplayName("Mobile Number")]
        string Mobile_No { get; set; }

        [Required(ErrorMessage = "Email Can not be left blank")]
        [StringLength(255)]
        [DisplayName("Email")]
        string Email { get; set; }

        [Required(ErrorMessage = "Rating Can not be left blank")]
        int Rating { get; set; }

        bool IsActive { get; set; }

        System.DateTime Creation_Date { get; set; }
    }

    [MetadataType(typeof(IFood_Store))]
    public partial class Food_Store
    {



    }
}