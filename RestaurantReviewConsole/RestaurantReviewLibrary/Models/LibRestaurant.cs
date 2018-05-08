using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;
using RestaurantReviewLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewLibrary.Models
{
    public class LibRestaurant : IReviewable
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No restaurant has a name that long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "All restaurants have a location")]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Invalid ZIP")]
        public string ZIP { get; set; }
        [Range(1, 5, ErrorMessage = "We couldn't afford a rating system higher than 5. Please donate.")]
        public double AvgRating { get; set; }

        public List<LibReview> Reviews;

        public LibRestaurant()
        {
            Reviews = new List<LibReview>();
        }

        public void AddReview(LibReview newReview)
        {
            Reviews.Add(newReview);
        }

        public List<LibReview> RestaurantReviews()
        {
            return Reviews;
        }

        public double CalculateAverageRating()
        {
            double runningTotal = 0.0;
            double avg = 0.0;
            foreach(LibReview r in Reviews)
            {
                runningTotal += r.Rating;
            }
            avg = runningTotal / Reviews.Count;

            return avg;
        }
    }
}
