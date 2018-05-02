using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;
using RestaurantReviewLibrary.Interfaces;

namespace RestaurantReviewLibrary.Models
{
    public class Restaurant : IReviewable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
        public double AvgRating { get; set; }

        public List<Review> Reviews = new List<Review>();

        public void AddReview(Review newReview)
        {
            Reviews.Add(newReview);
        }

        public double CalculateAverageRating()
        {
            double runningTotal = 0.0;
            double avg = 0.0;
            foreach(Review r in Reviews)
            {
                runningTotal += r.Rating;
            }
            avg = runningTotal / Reviews.Count;

            return avg;
        }
    }
}
