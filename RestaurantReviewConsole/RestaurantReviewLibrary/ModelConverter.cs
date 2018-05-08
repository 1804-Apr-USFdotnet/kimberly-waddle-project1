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
        public static LibRestaurant DBToResObject(Restaurant DBRestaurant)
        {
            LibRestaurant restObj = new LibRestaurant()
            {
                ID = DBRestaurant.ID,
                Name = DBRestaurant.Name,
                Address = DBRestaurant.Address,
                City = DBRestaurant.City,
                Country = DBRestaurant.Country,
                ZIP = DBRestaurant.ZIP,
                AvgRating = (double?)DBRestaurant.AvgRating ?? 0.0,
                Reviews = new List<LibReview>()
            };
            foreach (Review r in DBRestaurant.Reviews)
            {
                restObj.Reviews.Add(DBToRevObj(r));
            }
            return restObj;
        }

        public static Restaurant ResObjToDB(LibRestaurant objRest)
        {
            Restaurant DBRest = new Restaurant()
            {
                ID = objRest.ID,
                Name = objRest.Name,
                Address = objRest.Address,
                City = objRest.City,
                Country = objRest.Country,
                ZIP = objRest.ZIP,
                AvgRating = objRest.AvgRating,
                Reviews = new List<Review>()
            };
            foreach (Models.LibReview r in objRest.Reviews)
            {
                DBRest.Reviews.Add(RevObjToDB(r));
            }
            return DBRest;
        }

        public static LibReview DBToRevObj(Review DBRev)
        {
            LibReview newReview = new LibReview(DBRev.Reviewer, DBRev.Text, DBRev.Rating)
            {
                ID = DBRev.ID,
                Reviewer = DBRev.Reviewer,
                Text = DBRev.Text,
                Rating = DBRev.Rating,
                RestID = DBRev.RestID
            };

            return newReview;
        }

        public static Review RevObjToDB(LibReview revObj)
        {
            Review addReview = new Review()
            {
                ID = revObj.ID,
                RestID = revObj.RestID,
                Reviewer = revObj.Reviewer,
                Text = revObj.Text,
                Rating = revObj.Rating
            };

            return addReview;
        }
    }
}
