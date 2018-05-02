using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewData;

namespace RestaurantReviewLibrary
{
    public class RestaurantReviewManager
    {
        RestaurantData crud = new RestaurantData();
        public List<Restaurant> currentRestaurants = PrintRestaurants();

        private static List<Restaurant> PrintRestaurants()
        {
            RestaurantData crud = new RestaurantData();
            List<Restaurant> returnRestaurants = new List<Restaurant>();

            foreach(Restaurant r in crud.PrintRestaurants())
            {
                returnRestaurants.Add(r);
            }

            return returnRestaurants;
        }

        public string SearchRestByName(string searchName)
        {
            StringBuilder searchResults = new StringBuilder();
            IEnumerable<Restaurant> findRestaurants = currentRestaurants.Where(x => x.Name.ToLower().Contains(searchName.ToLower()));
            foreach(Restaurant r in findRestaurants)
            {
                searchResults.Append("Results:\n" + r.ID + " || " + r.Name);
            }
            return searchResults.ToString();
        }
        public string PrintRestaurantDetail(string searchName)
        {
            IEnumerable<Restaurant> findRestaurants = currentRestaurants.Where(x => x.Name.ToLower().Contains(searchName.ToLower()));

            StringBuilder restaurantString = new StringBuilder();

            foreach(Restaurant r in findRestaurants)
            {
                restaurantString.Append($"Detail for {r.Name}:\nAddress: {r.Address}\n\t{r.City}, {r.Country} {r.ZIP}");
                restaurantString.Append($"\nAverage Rating: {CalculateAvgRating(r)}\nNumber of Reviews: {r.Reviews.Count}\n\nReviews:");
                foreach(Review rev in r.Reviews)
                {
                    restaurantString.Append($"\nReviewer: {rev.Reviewer}\nReview: {rev.Text}\nRating: {rev.Rating}\n");
                }
            }

            return restaurantString.ToString();
        }

        public IOrderedEnumerable<Restaurant> SortByRating(string order, List<Restaurant> sortRestaurants)
        {
            IOrderedEnumerable<Restaurant> sortedList = null;
            StringBuilder sortedString = new StringBuilder();

            switch (order.ToLower())
            {
                case "desc":
                case "descending":
                    sortedList = sortRestaurants.OrderByDescending(o => o.AvgRating);
                    break;
                case "asc":
                case "ascending":
                    sortedList = sortRestaurants.OrderBy(o => o.AvgRating);
                    break;
            }

            return sortedList;
            //foreach (Restaurant res in sortedList)
            //{
            //    sortedString.Append($"{res.ID} || {res.Name} || {res.AvgRating}\n");
            //}

            //return sortedString.ToString();
        }
        public string PrintTopThree()
        {
            IOrderedEnumerable<Restaurant> topThreeList = null;
            StringBuilder topThreeString = new StringBuilder();

            foreach(Restaurant r in currentRestaurants)
            {
                r.AvgRating = CalculateAvgRating(r);
            }

            topThreeList = currentRestaurants.OrderByDescending(o => o.AvgRating);

            for(int i = 0; i < 3; i++)
            {
                topThreeString.Append($"{topThreeList.ElementAt(i).ID} || {topThreeList.ElementAt(i).Name} || {topThreeList.ElementAt(i).AvgRating}\n");
            }

            return topThreeString.ToString();
        }

        public IOrderedEnumerable<Restaurant> SortByName(string order, List<Restaurant> sortRestaurants)
        {
            IOrderedEnumerable<Restaurant> sortedList = null;
            StringBuilder sortedString = new StringBuilder();

            switch (order.ToLower())
            {
                case "desc":
                case "descending":
                    sortedList = sortRestaurants.OrderByDescending(o => o.Name);
                    break;
                case "asc":
                case "ascending":
                    sortedList = sortRestaurants.OrderBy(o => o.Name);
                    break;
            }

            return sortedList;
            //foreach (Restaurant res in sortedList)
            //{
            //    sortedString.Append($"{res.ID} || {res.Name} || {res.AvgRating}\n");
            //}

            //return sortedString.ToString();
        }
        private double CalculateAvgRating(Restaurant rateRestaurant)
        {
            double runningTotal = 0.0;
            double avg = 0.0;

            foreach(Review r in rateRestaurant.Reviews)
            {
                runningTotal += r.Rating;
            }

            avg = runningTotal / rateRestaurant.Reviews.Count;

            return avg;
        }
    }
}
