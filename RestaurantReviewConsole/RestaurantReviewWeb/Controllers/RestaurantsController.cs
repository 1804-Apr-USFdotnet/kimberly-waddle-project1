using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviewLibrary.Models;
using RestaurantReviewLibrary;
using RestaurantReviewData;

namespace RestaurantReviewWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        static RestaurantReviewManager webManager = new RestaurantReviewManager();
        private static List<LibRestaurant> restaurants = webManager.PrintRestaurants();

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(webManager.PrintRestaurants());
        }

        public ActionResult SortedIndex(List<LibRestaurant> sortedRestaurants)
        {
            return View(sortedRestaurants);
        }

        public ActionResult Details(int ID)
        {
            return View(webManager.PrintRestaurants().First(x => x.ID == ID));
        }

        public ActionResult CreateRestaurant()
        {
            return View();
        }

        public ActionResult DeleteRestaurant(int id)
        {
            return View(restaurants.First(x => x.ID == id));
        }

        public ActionResult Edit(int ID)
        {
            return View(restaurants.First(x => x.ID == ID));
        }

        public ActionResult SortByRatingDescending()
        {
            List<LibRestaurant> sortedList = webManager.SortByRating("descending", restaurants);
            return View("Index", sortedList);
        }

        public ActionResult SortByRatingAscending()
        {
            List<LibRestaurant> sortedList = webManager.SortByRating("ascending", restaurants);
            return View("Index", sortedList);
        }

        public ActionResult SortByNameAscending()
        {
            List<LibRestaurant> sortedList = webManager.SortByName("ascending", restaurants);
            return View("Index", sortedList);
        }

        public ActionResult SortByNameDescending()
        {
            List<LibRestaurant> sortedList = webManager.SortByName("descending", restaurants);
            return View("Index", sortedList);
        }

        public ActionResult DisplayTop3()
        {
            List<LibRestaurant> top3List = new List<LibRestaurant>();

            for(int i = 0; i < 3; i++)
            {
                top3List.Add(webManager.SortByRating("descending", restaurants).ElementAt(i));
            }

            return View("Index", top3List);
        }

        public ActionResult Search(string name)
        {
            return View(webManager.SearchRestByName(name));
        }

        [HttpPost]
        public ActionResult CreateRestaurant(LibRestaurant restaurant)
        {
            try
            {
                webManager.AddRestaurantToDB(restaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, LibRestaurant newRestaurant)
        {
            try
            {
                var oldRestaurant = restaurants.First(x => x.ID == id);

                webManager.UpdateRestaurantInDB(newRestaurant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteRestaurant(LibRestaurant delete)
        {
            try
            {

                webManager.DeleteRestaurantFromDB(delete.ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}