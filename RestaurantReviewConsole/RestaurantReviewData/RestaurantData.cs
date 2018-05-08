using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Migrations;

namespace RestaurantReviewData
{
    public class RestaurantData
    {
        RestaurantReviewDBEntities data = new RestaurantReviewDBEntities();

        public List<Restaurant> PrintRestaurants()
        {
            return data.Restaurants.ToList();
        }

        public Restaurant FindRestByID(int restID)
        {
            return data.Restaurants.Find(restID);
        }

        public Review FindRevByID(int revID)
        {
            return data.Reviews.Find(revID);
        }

        public void DeleteRestaurant(Restaurant remove)
        {
            data.Restaurants.Remove(remove);
            data.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant newInfo)
        {
            data.Restaurants.AddOrUpdate(newInfo);
            data.SaveChanges();
        }

        public void AddReview(Review newReview)
        {
            data.Reviews.AddOrUpdate(newReview);
            data.SaveChanges();
        }

        public void DeleteReview(Review delReview)
        {
            data.Reviews.Remove(delReview);
            data.SaveChanges();
        }
    }
}
