using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewLibrary.Models
{
    public class LibReview
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public int RestID { get; set; }
        [Required(ErrorMessage = "Every review must have a reviewer.")]
        [StringLength(50, ErrorMessage = "Your name is too long.")]
        public string Reviewer { get; set; }
        [StringLength(120, ErrorMessage = "Too many characters. Pretend it's twitter.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "You can't complain without providing numbers for the number crunchers.")]
        [Range(1, 5, ErrorMessage = "We could only afford five stars. Please donate.")]
        public double Rating { get; set; }

        public LibReview()
        {

        }

        public LibReview(string submitter, string newText, double rating)
        {
            Reviewer = submitter;
            Text = newText;
            Rating = rating;
        }

        public void EditReview(string _text, double _rating)
        {
            Text = _text;
            Rating = _rating;
        }
    }
}
