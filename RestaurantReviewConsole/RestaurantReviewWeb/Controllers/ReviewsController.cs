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
        [ValidateAntiForgeryToken]
        public ActionResult CreateReview(/*[Bind(Include = "ID, RestID, Reviewer, Text, Rating")]*/LibReview newReview)
        {
            try
            {
                controllerManager.AddReviewToDB(newReview);
                controllerManager.CalculateAvgRating(controllerManager.SearchResByID(newReview.RestID));
                return RedirectToAction("Index", "Restaurants");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview(/*[Bind(Include = "ID, RestID, Reviewer, Text, AvgRating")]*/LibReview delReview)
        {
            try
            {
                controllerManager.DelReviewFromDB(delReview.ID);
                return RedirectToAction("Index", "Restaurants");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview(/*[Bind(Include = "ID, RestID, Reviewer, Text, AvgRating")]*/LibReview editReview)
        {
            try
            {
                controllerManager.EditReview(editReview);
                return RedirectToAction("Index", "Restaurants");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}