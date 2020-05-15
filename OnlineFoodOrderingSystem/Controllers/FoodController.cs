using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodOrderingSystem.Controllers
{
    /// <summary>
    /// FoodController class manages the request/response scenerio for the Food_Items table in database by calling FoodService class's respective methods 
    /// to implement the corresponding operation
    /// </summary>
    public class FoodController : ApiController
    {

        /// <summary>
        /// Method GetAllFoodItems() to get a list of all the Food Items
        /// </summary>
        /// <returns>List of Food Items</returns>
        public List<Food_Item> GetAllFoodItems()
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetAllFoodItems() to fetch all Food Items 
                    List<Food_Item> foodItemsList = fs.GetAllFoodItems();

                    //return the response
                    return foodItemsList;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }


        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemId
        /// </summary>
        /// <param name="foodItemId"></param>
        /// <returns>returns Food_Item type value</returns>
        public Food_Item GetFoodItemById(int Food_Item_Id)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetAllFoodItems() to fetch all Food Items 
                    Food_Item foodItem = fs.GetFoodItemById(Food_Item_Id);

                    //return the response
                    return foodItem;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemName
        /// </summary>
        /// <param name="foodItemName"></param>
        /// <returns>returns List of Food_Items </returns>
        public List<Food_Item> GetFoodItemByFoodName(string foodItemName)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetFoodItemByFoodName method to fetch all Food Items corresponding to  foodItemName
                    List<Food_Item> foodItems = fs.GetFoodItemByFoodName(foodItemName);

                    //return the response
                    return foodItems;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemType
        /// </summary>
        /// <param name="foodItemType"></param>
        /// <returns>returns List of Food_Items </returns>
        public List<Food_Item> GetFoodItemByFoodType(string foodItemType)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetFoodItemByFoodType method to fetch all Food Items corresponding to  foodItemType
                    List<Food_Item> foodItems = fs.GetFoodItemByFoodType(foodItemType);

                    //return the response
                    return foodItems;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Items corresponding to the passed Food Price Range
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>returns list of Food_Item</returns>
        public List<Food_Item> GetFoodItemByPriceRange(decimal min, decimal max)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetFoodItemByFoodName method to fetch all Food Items corresponding to Price Range of the food item
                    List<Food_Item> foodItems = fs.GetFoodItemByPriceRange(min, max);

                    //return the response
                    return foodItems;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }


        /// <summary>
        /// Method Deletes the Food item with foodItemId from table Food_Items
        /// </summary>
        /// <param name="foodItemId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteFoodItemById(int foodItemId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call GetAllFoodItems() to fetch all Food Items 
                    bool isDeleted = fs.DeleteFoodItemById(foodItemId);

                    //return the response
                    return isDeleted;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The foodItemId is required ");
            }
        }


        /// <summary>
        /// AddFoodItem(Food_Items foodItem) adds the foodItem to the Food_Items table
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns>integer value indicating the Food_Item_Id of the added foodItem</returns>
        public bool AddFoodItem(Food_Item foodItem)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call AddFoodItem method to fetch all Food Items 
                    bool isAdded = fs.AddFoodItem(foodItem);

                    //return the response
                    return isAdded;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }

        /// <summary>
        /// Method updates or edits the changes of the passed foodItem in the Food_Items table
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns>boolean value</returns>
        public bool UpdateFoodItem(Food_Item foodItem)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodService fs = new FoodService();

                    //Call AddFoodItem method to fetch all Food Items 
                    bool isUpdated = fs.UpdateFoodItem(foodItem);

                    //return the response
                    return isUpdated;
                }
                catch (FoodOrderException)
                {
                    //rethrow
                    throw;
                }
            }

            else
            {
                //throw user defined exception object 
                throw new FoodOrderException("The entered details to fetch the Food Items are not valid");
            }
        }



    }
}
