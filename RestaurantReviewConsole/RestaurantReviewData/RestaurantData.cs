using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace RestaurantReviewData
{
    public class RestaurantData
    {
        RestaurantReviewDBEntities data = new RestaurantReviewDBEntities();

        public ICollection<Restaurant> PrintRestaurants()
        {
            return data.Restaurants.ToList();
        }

        public Restaurant FindRestByID(int restID)
        {
            return data.Restaurants.Find(restID);
        }

        public void DeleteRestaurant(Restaurant remove)
        {
            data.Restaurants.Remove(remove);
        }

        public void UpdateRestaurant(Restaurant newInfo)
        {
            Restaurant oldInfo = FindRestByID(newInfo.ID);

            oldInfo.Name = newInfo.Name;
            oldInfo.Address = newInfo.Address;
            oldInfo.City = newInfo.City;
            oldInfo.Country = newInfo.Country;
            oldInfo.ZIP = newInfo.ZIP;
            oldInfo.AvgRating = newInfo.AvgRating;

            Review tempReview = null;
            Review oldReview;
            int i = 0;
            while(i< oldInfo.Reviews.Count)
            {
                oldReview = oldInfo.Reviews.ElementAt(i);
                tempReview = newInfo.Reviews.Where(x => x.ID == oldReview.ID).FirstOrDefault();
                if(tempReview != null)
                {
                    oldReview.Text = tempReview.Text;
                    oldReview.Rating = tempReview.Rating;
                    oldReview.Reviewer = tempReview.Reviewer;
                }
                else
                {
                    oldInfo.Reviews.Remove(oldReview);
                }
            }

            foreach(Review newReview in newInfo.Reviews)
            {
                tempReview = oldInfo.Reviews.Where(x => x.ID == newReview.ID).FirstOrDefault();
                if(tempReview == null)
                {
                    oldInfo.Reviews.Add(newReview);
                }
            }

            data.SaveChanges();
        }

        
    }
}
