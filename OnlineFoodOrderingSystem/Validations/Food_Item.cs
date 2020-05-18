using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{

    public interface IFood_Item
    {
        [Required(ErrorMessage = "Food Item's id cannot be left blank")]
        [DisplayName("Food Item Id")]
        int Food_Item_Id { get; set; }

        [Required(ErrorMessage = "Food Name Can not be left blank")]
        [StringLength(255,ErrorMessage = "Food Name can be of maximum 255 characters")]
        [DisplayName("Food Name")]
        string Food_Name { get; set; }

        [Required(ErrorMessage = "Food Type Can not be left blank")]
        [StringLength(255, ErrorMessage = "Food Type can be of maximum 255 characters")]
        [DisplayName("Food Type")]
        string Food_Type { get; set; }

        [Required(ErrorMessage = "Price Can not be left blank")]
        [Range(1,100000,ErrorMessage ="Price range should be  between 1 and 100000")]
        decimal Price { get; set; }

        [Required(ErrorMessage = "Food Name Can not be left blank")]
        string ImagePath { get; set; }

        bool IsActive { get; set; }

        System.DateTime Creation_Date { get; set; }
    }


    [MetadataType(typeof(IFood_Item))]
    public partial class Food_Item
    {

    }
}