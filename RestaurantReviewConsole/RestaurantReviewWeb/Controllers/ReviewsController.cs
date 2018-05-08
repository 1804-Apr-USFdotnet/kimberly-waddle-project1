using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviewLibrary;
using RestaurantReviewLibrary.Models;

namespace RestaurantReviewWeb.Controllers
{
    public class ReviewsController : Controller
    {
        RestaurantReviewManager controllerManager = new RestaurantReviewManager();

        // GET: Reviews
        public ActionResult PrintReviews(int id)
        {
            List<LibReview> printReviews = controllerManager.GetAllRestaurantReviews(id);
            return View(printReviews);
        }

        public ActionResult CreateReview(int id)
        {
            LibRestaurant findRestaurant = controllerManager.SearchResByID(id);
            LibReview newReview = new LibReview();
            ViewBag.RestName = findRestaurant.Name;
            newReview.RestID = id;
            return View(newReview);
        }

        public ActionResult DeleteReview(int id)
        {
            LibReview delReview = controllerManager.GetReview(id);
            return View(delReview);
        }

        public ActionResult EditReview(int id)
        {
            LibReview edit = controllerManager.GetReview(id);
            return View(edit);
        }

        public ActionResult DisplayReview(int id)
        {
            LibReview detailReview = controllerManager.GetReview(id);
            return View(detailReview);
        }

        [HttpPost]
        public ActionResult CreateReview(LibReview newReview)
        {

            controllerManager.AddReviewToDB(newReview);

            return RedirectToAction("Index", "Restaurants");
        }

        [HttpPost]
        public ActionResult DeleteReview(LibReview delReview)
        {
            controllerManager.DelReviewFromDB(delReview.ID);
            return RedirectToAction("Index", "Restaurants");
        }

        [HttpPost]
        public ActionResult EditReview(LibReview editReview)
        {
            controllerManager.EditReview(editReview);
            return RedirectToAction("Index", "Restaurants");
        }
    }
}