using OnlineFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.ServiceContracts
{
    /// <summary>
    /// Interface IFoodsStoreService having methods to be implemented by class FoodStoreService 
    /// </summary>
    interface IFoodStoreService
    {
        /// <summary>
        /// Method GetAllFoodStores() to get a list of all the Food Stores
        /// </summary>
        /// <returns>List of Food Stores</returns>
        List<Food_Store> GetAllFoodStores();

        /// <summary>
        /// AddFoodStore(Food_Stores foodStore) adds the foodStore to the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>integer value indicating the Food_Store_Id of the added foodStore</returns>
        bool AddFoodStore(Food_Store foodStore);

        /// <summary>
        /// Method Deletes the Food store with foodStoreId from table Food_Stores
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>boolean value</returns>
        bool DeleteFoodStoreById(int foodStoreId);

        /// <summary>
        /// Method updates or edits the changes of the passed foodStore in the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>boolean value</returns>
        bool UpdateFoodStore(Food_Store foodStore);

        /// <summary>
        /// Method fetches the Food store corresponding to the passed foodStoreId
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>returns Food_Store type value</returns>
        Food_Store GetFoodStoreById(int foodStoreId);

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreName
        /// </summary>
        /// <param name="foodStoreName"></param>
        /// <returns>returns List of Food_Stores </returns>
        List<Food_Store> GetFoodStoreByStoreName(string foodStoreName);

        /// <summary>
        /// method fetches the food store corresponding to the passed email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns list of food_store </returns>
         Food_Store GetFoodStoreByEmail(string email);

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreLocation
        /// </summary>
        /// <param name="foodStoreLocation"></param>
        /// <returns>returns List of Food_Store </returns>
        List<Food_Store> GetFoodStoreByLocation(string foodStoreLocation);
    }
}
