



//=============================================
//  Developer:	<Virendra Pratap Singh Jhala>
//  Create date: <15th May,2020>
//  Related To : To perform business logic and accordingly return response to FoodController
//=============================================


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
    /// class FoodService implements IFoodService interface And manages CRUD operations on the Food_Items table
    /// </summary>
    public class FoodService : IFoodService
    {
        /// <summary>
        /// Method GetAllFoodItems() to get a list of all the Food Items
        /// </summary>
        /// <returns>List of Food Items</returns>
        public List<Food_Item> GetAllFoodItems()
        {
            //instantiating Online_Food_Ordering_SystemEntities3 Context class
            try
            {
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to fetch list of Food Items from table Food_Items
                    List<Food_Item> foodItemsList = db.usp_GetFoodItemDetails().ToList();

                    //assigning lazy loading to be false
                    db.Configuration.LazyLoadingEnabled = false;

                    //return obtained data 
                    return foodItemsList;

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }

        }

        /// <summary>
        /// AddFoodItem(Food_Items foodItem) adds the foodItem to the Food_Items table
        /// </summary>
        /// <param name="foodItem">object of type Food_Item</param>
        /// <returns>integer value indicating the Id of the added foodItem</returns>
        public int AddFoodItem(Food_Item foodItem)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //set IsActive to true for the item to be present
                    foodItem.IsActive = true;

                    //set creation date of item 
                    foodItem.Creation_Date = DateTime.Now;

                    //check if the foodItem already exists
                    Food_Item item = db.Food_Items.Where(f=>f.Food_Name.Equals(foodItem.Food_Name,StringComparison.OrdinalIgnoreCase) && f.Food_Type.Equals(foodItem.Food_Type,StringComparison.OrdinalIgnoreCase) && f.IsActive==true).FirstOrDefault();

                    if (item != null)
                    {
                        //if exists then throw exception
                        throw new FoodOrderException("Food Item already present");

                    }

                    //use LINQ query to Add Food Items from table Food_Items
                    db.Food_Items.Add(foodItem);

                    //save changes to the database
                    db.SaveChanges();

                    int foodId = db.Food_Items.Where(f => f.Food_Item_Id == foodItem.Food_Item_Id %% f.IsActive == true).FirstOrDefault();

                    return foodId;

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }

        }


        /// <summary>
        /// Method fetches the Food Item corresponding to the passed foodItemId
        /// </summary>
        /// <param name="foodItemId">indicates id of food item</param>
        /// <returns>returns Food_Item type value</returns>
        public Food_Item GetFoodItemById(int foodItemId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed foodItemId
                    Food_Item item = db.Food_Items.Where(f => f.Food_Item_Id == foodItemId && f.IsActive==true).FirstOrDefault();

                    //return response
                    return item;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }



        /// <summary>
        /// Method Deletes the Food item with foodItemId from table Food_Items
        /// </summary>
        /// <param name="foodItemId">integer indicating id of Food item</param>
        /// <returns>boolean value indicating whether food item is deleted or not</returns>
        public bool DeleteFoodItemById(int foodItemId)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the Food Item with id foodItemId
                    Food_Item item = db.Food_Items.Where(f => f.Food_Item_Id == foodItemId && f.IsActive == true).FirstOrDefault();

                    if (item != null)
                    //use LINQ query to Add Food Items from table Food_Items
                    {
                        //remove item from Food_Items
                        db.Food_Items.Remove(item);

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }

                   else
                    {
                        throw new FoodOrderException("Food item does not exist");
                    }

                }
            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }


        /// <summary>
        /// Method updates or edits the changes of the passed foodItem in the Food_Items table
        /// </summary>
        /// <param name="foodItem">object of type FoodItem </param>
        /// <returns>boolean value indicating whether fooItem is updated or not</returns>
        public bool UpdateFoodItem(Food_Item foodItem)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //use LINQ query to find the Food Item with id foodItem.Food_Item_Id
                    Food_Item item = db.Food_Items.Where(f => f.Food_Item_Id == foodItem.Food_Item_Id && f.IsActive == true).FirstOrDefault();

                    if (item != null)
                    {
                        //update  Food Item details 
                        item.Food_Name = foodItem.Food_Name;
                        item.Food_Type = foodItem.Food_Type;
                        item.Price = foodItem.Price;

                        //save changes to the database
                        db.SaveChanges();

                        return true;
                    }


                    else
                    {
                        throw new FoodOrderException("Food item does not exist");
                    }

                }

            }
            catch (Exception ex)
            {
                //throw user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
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
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed foodItemType  with case insensitivity of Food Item Type
                    List<Food_Item> items = db.Food_Items.Where(f => f.Food_Type.Equals(foodItemType, StringComparison.OrdinalIgnoreCase) && f.IsActive == true).ToList();

                    //return response
                    return items;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
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
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed food Item name with case insensitivity of Food Item Name
                    List<Food_Item> items = db.Food_Items.Where(f => f.Food_Name.Equals(foodItemName, StringComparison.OrdinalIgnoreCase) && f.IsActive == true).ToList();

                    //return response
                    return items;

                }
            }
            catch (Exception ex)
            {
                //throw our user defined FoodOrderException
                throw new FoodOrderException(ex.Message);
            }
        }

        /// <summary>
        /// Method fetches the Food Items corresponding to the passed Food Price Range
        /// </summary>
        /// <param name="min">minimum value of price</param>
        /// <param name="max">maximum value of price</param>
        /// <returns>returns list of Food_Item</returns>
        public List<Food_Item> GetFoodItemByPriceRange(decimal min, decimal max)
        {
            try
            {
                //instantiating Online_Food_Ordering_SystemEntities3 Context class
                using (Online_Food_Ordering_SystemEntities1 db = new Online_Food_Ordering_SystemEntities1())
                {
                    //LINQ query to find Food Item corresponding to passed food Item Price Range
                    List<Food_Item> items = db.Food_Items.Where(f => f.Price >= min && f.Price <= max && f.IsActive == true).ToList();

                    //return response
                    return items;

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