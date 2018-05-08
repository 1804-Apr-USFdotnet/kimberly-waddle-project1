using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;

namespace RestaurantReviewLibrary.Interfaces
{
    interface IReviewable
    {
        void AddReview(LibReview newReview);
        double CalculateAverageRating();
    }
}
