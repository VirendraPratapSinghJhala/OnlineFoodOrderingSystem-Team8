using OnlineFoodOrderingSystem.ExceptionLayer;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Services
    
{
    /// <summary>
    /// class FoodStoreService implements IFoodStoreService interface And manages CRUD operations on the Food_Stores table
    /// </summary>
    public class FoodStoreService : IFoodStoreService
    {
        /// <summary>
        /// Method GetAllFoodStores() to get a list of all the Food Stores
        /// </summary>
        /// <returns>List of Food Stores</returns>
        public List<Food_Store> GetAllFoodStores()
        {
            //instantiating Online_Food_Ordering_SystemEntities Context class
            try
            {
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //use LINQ query to fetch list of Food Stores from table Food_Stores
                    List<Food_Store> foodStoresList = db.usp_GetFoodStores().ToList();

                    //assigning lazy loading to be false
                    db.Configuration.LazyLoadingEnabled = false;

                    //return obtained data 
                    return foodStoresList;

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }

        }

        /// <summary>
        /// AddFoodStore(Food_Stores foodStore) adds the foodStore to the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>integer value indicating the Food_Store_Id of the added foodStore</returns>
        public bool AddFoodStore(Food_Store foodStore)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //use LINQ query to Add Food Stores from table Food_Stores
                    db.Food_Stores.Add(foodStore);

                    //save changes to the database
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }

        }


        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreId
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>returns Food_Store type value</returns>
        public Food_Store GetFoodStoreById(int foodStoreId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //LINQ query to find Food Store corresponding to passed foodStoreId
                    Food_Store store = db.Food_Stores.Where(f => f.Food_Store_Id == foodStoreId).FirstOrDefault();

                    //return response
                    return store;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }



        /// <summary>
        /// Method Deletes the Food store with foodStoreId from table Food_Stores
        /// </summary>
        /// <param name="foodStoreId"></param>
        /// <returns>boolean value</returns>
        public bool DeleteFoodStoreById(int foodStoreId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //use LINQ query to find the Food Store with id foodStoreId
                    Food_Store store = db.Food_Stores.Where(f => f.Food_Store_Id == foodStoreId).FirstOrDefault();

                    if (store != null)
                    //use LINQ query to delete Food Stores from table Food_Stores
                    {
                        //remove item from Food_Stores
                        db.Food_Stores.Remove(store);

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    return false;

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }


        /// <summary>
        /// Method updates or edits the changes of the passed foodStore in the Food_Stores table
        /// </summary>
        /// <param name="foodStore"></param>
        /// <returns>boolean value</returns>
        public bool UpdateFoodStore(Food_Store foodStore)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //use LINQ query to find the Food Store with id foodStore.Food_Store_Id
                    Food_Store store = db.Food_Stores.Where(f => f.Food_Store_Id == foodStore.Food_Store_Id).FirstOrDefault();

                    if (store != null)
                    {
                        //update  Food Store details 
                        store.Food_Store_Name = foodStore.Food_Store_Name;
                        store.Location = foodStore.Location;
                        store.Mobile_No = foodStore.Mobile_No;
                        store.Email = foodStore.Email;
                        store.Rating = foodStore.Rating;

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                    return false;

                }

            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }

        }

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreLocation
        /// </summary>
        /// <param name="foodStoreLocation"></param>
        /// <returns>returns List of Food_Stores </returns>
        public List<Food_Store> GetFoodStoreByLocation(string location)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //LINQ query to find Food Store corresponding to passed location  with case insensitivity.
                    List<Food_Store> stores = db.Food_Stores.Where(f => f.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();

                    //return response
                    return stores;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }

        /// <summary>
        /// Method fetches the Food Store corresponding to the passed foodStoreName
        /// </summary>
        /// <param name="foodStoreName"></param>
        /// <returns>returns List of Food_Stores </returns>
        public List<Food_Store> GetFoodStoreByStoreName(string foodStoreName)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //LINQ query to find Food Store corresponding to passed food Store name with case insensitivity of Food Store Name
                    List<Food_Store> stores = db.Food_Stores.Where(f => f.Food_Store_Name.Equals(foodStoreName, StringComparison.OrdinalIgnoreCase)).ToList();

                    //return response
                    return stores;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }


        /// <summary>
        /// method fetches the food store corresponding to the passed email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns list of food_store </returns>
        public Food_Store GetFoodStoreByEmail(string email)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities Context class
                using (Online_Food_Ordering_SystemEntities db = new Online_Food_Ordering_SystemEntities())
                {
                    //LINQ query to find Food Store corresponding to passed food Store name with case insensitivity of Food Store Name
                    Food_Store store = db.Food_Stores.Where(f => f.Email.Equals(email)).FirstOrDefault();

                    //return response
                    return store;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }

    }
}