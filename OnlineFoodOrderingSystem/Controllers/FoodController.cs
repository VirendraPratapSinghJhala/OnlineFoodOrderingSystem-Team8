

 //=============================================
 //  Developer:	<Virendra Pratap Singh Jhala>
 //  Create date: <14th May,2020>
 //  Related To : To manage Food Items related requests/response scenerio
 //=============================================


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
        //declare FoodService type instance variable
        FoodService fs;

        FoodController()
        {
            //instantiate FoodService class
            fs = new FoodService();
        }

        /// <summary>
        /// Method GetAllFoodItems() to get a list of all the Food Items
        /// </summary>
        /// <returns>List of Food Items</returns>
        public List<Food_Item> GetAllFoodItems()
        {
           
                try
                {
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


        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemId
        /// </summary>
        /// <param name="foodItemId">indicates id of food item</param>
        /// <returns>returns Food_Item type value</returns>
        public Food_Item GetFoodItemById(int foodItemId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //Call GetAllFoodItems() to fetch all Food Items 
                    Food_Item foodItem = fs.GetFoodItemById(foodItemId);

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
        /// <param name="foodItemName">name of food item</param>
        /// <returns>returns List of Food_Items </returns>
        public List<Food_Item> GetFoodItemByFoodName(string foodItemName)
        {
           
                try
                {
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

        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemType
        /// </summary>
        /// <param name="foodItemType">type of food item</param>
        /// <returns>returns List of Food_Items </returns>
        public List<Food_Item> GetFoodItemByFoodType(string foodItemType)
        {
            
                try
                {

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

        /// <summary>
        /// Method fetches the Food Items corresponding to the passed Food Price Range
        /// </summary>
        /// <param name="min">minimum value of price </param>
        /// <param name="max">maximum value of price</param>
        /// <returns>returns list of Food_Item</returns>
        public List<Food_Item> GetFoodItemByPriceRange(decimal min, decimal max)
        {
            
                try
                {

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


        /// <summary>
        /// Method Deletes the Food item with foodItemId from table Food_Items
        /// </summary>
        /// <param name="foodItemId">indicates id of food item</param>
        /// <returns>boolean value</returns>
        public bool DeleteFoodItemById(int foodItemId)
        {
           try
                {
                   
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


        /// <summary>
        /// AddFoodItem(Food_Items foodItem) adds the foodItem to the Food_Items table
        /// </summary>
        /// <param name="foodItem">object of type FoodItem</param>
        /// <returns>integer value indicating the Food_Item_Id of the added foodItem</returns>
        public int AddFoodItem(Food_Item foodItem)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {

                    //Call AddFoodItem method to fetch all Food Items 
                   int foodId = fs.AddFoodItem(foodItem);

                    //return the response
                    return foodId;
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
        /// <param name="foodItem">object of type FoodItem</param>
        /// <returns>boolean value</returns>
        public bool UpdateFoodItem(Food_Item foodItem)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {

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
