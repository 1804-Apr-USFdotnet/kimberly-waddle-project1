using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;
using RestaurantReviewData;

namespace RestaurantReviewLibrary
{
    public class RestaurantReviewManager
    {
         RestaurantData crud = new RestaurantData();

        public List<LibRestaurant> PrintRestaurants()
        {
            //RestaurantData crud = new RestaurantData();
            List<LibRestaurant> returnRestaurants = new List<LibRestaurant>();

            foreach(RestaurantReviewData.Restaurant dbr in crud.PrintRestaurants())
            {
                LibRestaurant tempRestaurant = ModelConverter.DBToResObject(dbr);
                foreach(Review rev in dbr.Reviews)
                {
                    tempRestaurant.Reviews.Add(ModelConverter.DBToRevObj(rev));
                }
                tempRestaurant.AvgRating = CalculateAvgRating(tempRestaurant);
                returnRestaurants.Add(tempRestaurant);
            }

            return returnRestaurants;
        }

        public List<LibRestaurant> SearchRestByName(string searchName)
        {
            List<LibRestaurant> searchResults = new List<LibRestaurant>();
            IEnumerable<LibRestaurant> findRestaurants = PrintRestaurants().Where(x => x.Name.ToLower().Contains(searchName.ToLower()));

            foreach(LibRestaurant libres in findRestaurants)
            {
                searchResults.Add(libres);
            }

            return searchResults;
            
        }
        public List<LibRestaurant> PrintRestaurantDetail(string searchName)
        {
            IEnumerable<LibRestaurant> findRestaurants = PrintRestaurants().Where(x => x.Name.ToLower().Contains(searchName.ToLower()));

            List<LibRestaurant> detailRestaurants = new List<LibRestaurant>();

            foreach(LibRestaurant r in findRestaurants)
            {
                detailRestaurants.Add(r);
            }

            return detailRestaurants;
            //Move this to Web Client
            //foreach(Restaurant r in findRestaurants)
            //{
            //    restaurantString.Append($"Detail for {r.Name}:\nAddress: {r.Address}\n\t{r.City}, {r.Country} {r.ZIP}");
            //    restaurantString.Append($"\nAverage Rating: {CalculateAvgRating(r)}\nNumber of Reviews: {r.Reviews.Count}\n\nReviews:");
            //    foreach(Review rev in r.Reviews)
            //    {
            //        restaurantString.Append($"\nReviewer: {rev.Reviewer}\nReview: {rev.Text}\nRating: {rev.Rating}\n");
            //    }
            //}
        }

        public LibRestaurant SearchResByID(int id)
        {
            return ModelConverter.DBToResObject(crud.FindRestByID(id));
        }

        public List<LibReview> GetAllRestaurantReviews(int restID)
        {
            LibRestaurant targetRestaurant = PrintRestaurants().Where(x => x.ID == restID).FirstOrDefault();

            List<LibReview> restaurantReviews = new List<LibReview>();

            foreach(LibReview lr in targetRestaurant.Reviews)
            {
                restaurantReviews.Add(lr);
            }

            return restaurantReviews;
        } 
        public LibReview GetReview(int ID)
        {
            Review foundRev = crud.FindRevByID(ID);

            return ModelConverter.DBToRevObj(foundRev);
        }

        public List<LibRestaurant> SortByRating(string order, List<LibRestaurant> sortRestaurants)
        {
            IOrderedEnumerable<RestaurantReviewLibrary.Models.LibRestaurant> sortedEnumerable = null;
            List<RestaurantReviewLibrary.Models.LibRestaurant> sortedList = new List<Models.LibRestaurant>();

            switch (order.ToLower())
            {
                case "desc":
                case "descending":
                    sortedEnumerable = sortRestaurants.OrderByDescending(o => o.AvgRating);
                    break;
                case "asc":
                case "ascending":
                    sortedEnumerable = sortRestaurants.OrderBy(o => o.AvgRating);
                    break;
            }

            foreach(Models.LibRestaurant resMod in sortedEnumerable)
            {
                sortedList.Add(resMod);
            }

            return sortedList;

            //Move this to Web Client
            //foreach (Restaurant res in sortedList)
            //{
            //    sortedString.Append($"{res.ID} || {res.Name} || {res.AvgRating}\n");
            //}

            //return sortedString.ToString();
        }
        public List<LibRestaurant> PrintTopThree()
        {
            IOrderedEnumerable<Models.LibRestaurant> topThreeList = null;
            List<Models.LibRestaurant> returnRestaurants = new List<Models.LibRestaurant>();
            
            topThreeList = PrintRestaurants().OrderByDescending(o => o.AvgRating);

            foreach(Models.LibRestaurant r in topThreeList)
            {
                returnRestaurants.Add(r);
            }

            return returnRestaurants;

            //move this to Web Client
            //for(int i = 0; i < 3; i++)
            //{
            //    topThreeString.Append($"{topThreeList.ElementAt(i).ID} || {topThreeList.ElementAt(i).Name} || {topThreeList.ElementAt(i).AvgRating}\n");
            //}

            //return topThreeString.ToString();
        }

        public List<LibRestaurant> SortByName(string order, List<LibRestaurant> sortRestaurants)
        {
            IOrderedEnumerable<Models.LibRestaurant> sortedList = null;
            List<Models.LibRestaurant> returnRestaurants = new List<Models.LibRestaurant>();

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

            foreach(Models.LibRestaurant r in sortedList)
            {
                returnRestaurants.Add(r);
            }

            return returnRestaurants;

            //TODO move this to Web Client
            //foreach (Restaurant res in sortedList)
            //{
            //    sortedString.Append($"{res.ID} || {res.Name} || {res.AvgRating}\n");
            //}

            //return sortedString.ToString();
        }
        public double CalculateAvgRating(LibRestaurant rateRestaurant)
        {
            double runningTotal = 0.0;
            double avg = 0.0;

            foreach(Models.LibReview r in rateRestaurant.Reviews)
            {
                runningTotal += r.Rating;
            }

            avg = runningTotal / rateRestaurant.Reviews.Count;

            return avg;
        }

        public void AddRestaurantToDB(LibRestaurant newRestaurant)
        {
            crud.UpdateRestaurant(ModelConverter.ResObjToDB(newRestaurant));
        }
        public void UpdateRestaurantInDB(LibRestaurant update)
        {
            crud.UpdateRestaurant(ModelConverter.ResObjToDB(update));
        }

        public void AddReviewToDB(LibReview newReview)
        {
            crud.AddReview(ModelConverter.RevObjToDB(newReview));
        }
        public void DelReviewFromDB(int delID)
        {
            Review delReview = crud.FindRevByID(delID);
            crud.DeleteReview(delReview);
        }

        public void EditReview(LibReview editReview)
        {
            crud.AddReview(ModelConverter.RevObjToDB(editReview));
        }
        
        public void DeleteRestaurantFromDB(int restID)
        {
            Restaurant delRestaurant = crud.FindRestByID(restID);
            crud.DeleteRestaurant(delRestaurant);
        }
    }
}
