


//=============================================
//  Developer:	<Virendra Pratap Singh Jhala>
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

    public interface IFood_Item
    {
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
        [RegularExpression("^[1-9][0-9]*.[0-9]*$",ErrorMessage ="Price should be greater than zero and should not be negative")]
        decimal Price { get; set; }

        [Required(ErrorMessage = "Image Path Can not be left blank")]
        [StringLength(2000, ErrorMessage = "Image Path can be of maximum 2000 characters")]
        [DisplayName("Image Path")]
        string ImagePath { get; set; }

      
    }


    [MetadataType(typeof(IFood_Item))]
    public partial class Food_Item
    {

    }
}