using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.ServiceContracts
{

    /// <summary>
    /// Interface IFoodsService having methods to be implemented by class FoodService 
    /// </summary>
    interface IFoodService
    {
        /// <summary>
        /// Method GetAllFoodItems() to get a list of all the Food Items
        /// </summary>
        /// <returns>List of Food Items</returns>
        List<Food_Item> GetAllFoodItems();

        /// <summary>
        /// AddFoodItem(Food_Items foodItem) adds the foodItem to the Food_Items table
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns>integer value indicating the Food_Item_Id of the added foodItem</returns>
        bool AddFoodItem(Food_Item foodItem);

        /// <summary>
        /// Method Deletes the Food item with foodItemId from table Food_Items
        /// </summary>
        /// <param name="foodItemId"></param>
        /// <returns>boolean value</returns>
        bool DeleteFoodItemById(int foodItemId);

        /// <summary>
        /// Method updates or edits the changes of the passed foodItem in the Food_Items table
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns>boolean value</returns>
        bool UpdateFoodItem(Food_Item foodItem);

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemId
        /// </summary>
        /// <param name="foodItemId"></param>
        /// <returns>returns Food_Item type value</returns>
        Food_Item GetFoodItemById(int foodItemId);

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemName
        /// </summary>
        /// <param name="foodItemName"></param>
        /// <returns>returns List of Food_Items </returns>
        List<Food_Item> GetFoodItemByFoodName(string foodItemName);

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemType
        /// </summary>
        /// <param name="foodItemType"></param>
        /// <returns>returns List of Food_Items </returns>
        List<Food_Item> GetFoodItemByFoodType(string foodItemType);


        /// <summary>
        /// Method fetches the Food Items corresponding to the passed Food Price Range
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>returns list of Food_Item</returns>
        List<Food_Item> GetFoodItemByPriceRange(decimal min, decimal max);

       

    }
}
