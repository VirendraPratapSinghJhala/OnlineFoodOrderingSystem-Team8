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
    /// FoodController class manages the request/response scenerio for the Food_Stores table in database by calling FoodService class's respective methods 
    /// to implement the corresponding operation
    /// </summary>
public class FoodStoreController : ApiController
    {

        /// <summary>
        /// Method GetAllFoodStores() to get a list of all the Food Stores
        /// </summary>
        /// <returns>List of Food Stores</returns>
        public List<Food_Store> GetAllFoodStores()
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetAllFoodStores() to fetch all Food stores 
                    List<Food_Store> foodStoresList = fs.GetAllFoodStores();

                    //return the response
                    return foodStoresList;
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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }


        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreId
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>returns Food_Store type value</returns>
        public Food_Store GetFoodStoreById(int foodStoreId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetAllFoodStores() to fetch all Food Stores 
                    Food_Store foodStore = fs.GetFoodStoreById(foodStoreId);

                    //return the response
                    return foodStore;
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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreName
        /// </summary>
        /// <param name="foodStoreName"></param>
        /// <returns>returns List of Food_Store </returns>
        public List<Food_Store> GetFoodStoreByStoreName(string foodStoreName)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetFoodStoreByFoodName method to fetch all Food Stores corresponding to  foodStoreName
                    List<Food_Store> foodStores = fs.GetFoodStoreByStoreName(foodStoreName);

                    //return the response
                    return foodStores;
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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns List of Food_Stores </returns>
        public Food_Store GetFoodStoreByEmail(string email)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetFoodStoreByEmail method to fetch all Food Stores corresponding to  Email
                    Food_Store foodStore = fs.GetFoodStoreByEmail(email);

                    //return the response
                    return foodStore;
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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }

        /// <summary>
        /// Method fetches the Food Stores corresponding to the Location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>returns list of Food_Stores</returns>
        public List<Food_Store> GetFoodStoreByLocation(string location)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetFoodStoreByStoreName method to fetch all Food Stores corresponding to the Location  of the food store
                    List<Food_Store> foodStores = fs.GetFoodStoreByLocation(location);

                    //return the response
                    return foodStores;
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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }


        /// <summary>
        /// Method Deletes the Food store with foodStoreId from table Food_Stores
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteFoodStoreById(int foodStoreId)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call GetAllFoodStores() to fetch all Food Stores 
                    bool isDeleted = fs.DeleteFoodStoreById(foodStoreId);

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
                throw new FoodOrderException("The foodStoreId is required ");
            }
        }


        /// <summary>
        /// AddFoodStore(Food_Stores foodStore) adds the foodStore to the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>integer value indicating the Food_Store_Id of the added foodStore</returns>
        public bool AddFoodStore(Food_Store foodStore)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call AddFoodStore method to fetch all Food Stores 
                    bool isAdded = fs.AddFoodStore(foodStore);

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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }

        /// <summary>
        /// Method updates or edits the changes of the passed foodStore in the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>boolean value</returns>
        public bool UpdateFoodStore(Food_Store foodStore)
        {
            //check the validity of the input
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate FoodStoreService class
                    FoodStoreService fs = new FoodStoreService();

                    //Call AddFoodStore method to fetch all Food Stores 
                    bool isUpdated = fs.UpdateFoodStore(foodStore);

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
                throw new FoodOrderException("The entered details to fetch the Food Stores are not valid");
            }
        }



    }
}
