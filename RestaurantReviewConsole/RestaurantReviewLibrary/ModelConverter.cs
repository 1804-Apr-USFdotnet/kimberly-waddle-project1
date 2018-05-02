using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewData;
using RestaurantReviewLibrary;
using RestaurantReviewLibrary.Models;

namespace RestaurantReviewLibrary
{
    public static class ModelConverter
    {
        public static Models.Restaurant DBToResObject(RestaurantReviewData.Restaurant DBRestaurant)
        {
            Models.Restaurant restObj = new Models.Restaurant()
            {
                ID = DBRestaurant.ID,
                Name = DBRestaurant.Name,
                Address = DBRestaurant.Address,
                City = DBRestaurant.City,
                Country = DBRestaurant.Country,
                ZIP = DBRestaurant.ZIP,
                AvgRating = (double)DBRestaurant.AvgRating,
                Reviews = new List<Models.Review>()
            };
            foreach (RestaurantReviewData.Review r in DBRestaurant.Reviews)
            {
                restObj.Reviews.Add(DBToRevObj(r));
            }
            return restObj;
        }

        public static RestaurantReviewData.Restaurant ResObjToDB(Models.Restaurant objRest)
        {
            RestaurantReviewData.Restaurant DBRest = new RestaurantReviewData.Restaurant()
            {
                ID = objRest.ID,
                Name = objRest.Name,
                Address = objRest.Address,
                City = objRest.City,
                Country = objRest.Country,
                ZIP = objRest.ZIP,
                AvgRating = objRest.AvgRating,
                Reviews = new List<RestaurantReviewData.Review>()
            };
            foreach (Models.Review r in objRest.Reviews)
            {
                DBRest.Reviews.Add(RevObjToDB(r));
            }
            return DBRest;
        }

        public static Models.Review DBToRevObj(RestaurantReviewData.Review DBRev)
        {
            Models.Review newReview = new Models.Review(DBRev.Reviewer, DBRev.Text, DBRev.Rating)
            {
                Reviewer = DBRev.Reviewer,
                Text = DBRev.Reviewer,
                Rating = DBRev.Rating,
                RestID = DBRev.RestID
            };

            return newReview;
        }

        public static RestaurantReviewData.Review RevObjToDB(Models.Review revObj)
        {
            RestaurantReviewData.Review addReview = new RestaurantReviewData.Review()
            {
                ID = revObj.ID,
                Reviewer = revObj.Reviewer,
                Text = revObj.Text,
                Rating = revObj.Rating,
            };

            return addReview;
        }
    }
}
