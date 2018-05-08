using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewWeb.Models
{
    public class WebReview
    {
        [Key]
        [Required]
        private int ID { get; set; }
        [Required]
        private int RestID { get; set; }
        [Required(ErrorMessage = "Every review must have a reviewer.")]
        [StringLength(50, ErrorMessage = "Your name is too long.")]
        public string Reviewer { get; set; }
        [StringLength(120, ErrorMessage = "Too many characters. Pretend it's twitter.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "You can't complain without providing numbers for the number crunchers.")]
        [Range(1, 5, ErrorMessage ="We could only afford five stars. Please donate.")]
        public double Rating { get; set; }
    }
}