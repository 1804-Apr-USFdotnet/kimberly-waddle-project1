using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;
using RestaurantReviewLibrary;
using RestaurantReviewData;

namespace RestaurantReviewLibrary.Interfaces
{
    interface IDataAccess
    {
        List<Restaurant> PrintRestaurants();
        Restaurant FindRestByID(int restID);
        Review FindRevByID(int revID);
        void DeleteRestaurant(Restaurant remove);
        void UpdateRestaurant(Restaurant newInfo);
        void AddReview(Review newReview);
        void DeleteReview(Review delReview);
    }
}
