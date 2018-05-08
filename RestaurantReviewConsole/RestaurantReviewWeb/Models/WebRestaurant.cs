using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewWeb.Models
{
    public class WebRestaurant
    {
        [Required]
        [Key]
        private int ID { get; set; }
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
    }
}