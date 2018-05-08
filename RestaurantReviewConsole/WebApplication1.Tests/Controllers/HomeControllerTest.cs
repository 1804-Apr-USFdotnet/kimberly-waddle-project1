using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewWeb;
using RestaurantReviewWeb.Controllers;
using RestaurantReviewLibrary;
using RestaurantReviewLibrary.Models;

namespace RestaurantReviewWeb.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class RestaurantsControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            RestaurantsController controller = new RestaurantsController();
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.Details(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateRestaurantTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.CreateRestaurant() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteRestaurantTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.DeleteRestaurant(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.Edit(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SortByRatingDescendingTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.SortByRatingDescending() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SortByRatingAscendingTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.SortByRatingAscending() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SortByNameAscending()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.SortByNameAscending() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SortByNameDescendingTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.SortByNameDescending() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DisplayTop3Test()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.DisplayTop3() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchTest()
        {
            RestaurantsController controller = new RestaurantsController();

            ViewResult result = controller.Search("car") as ViewResult;

            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class ReviewsControllerTest
    {
        [TestMethod]
        public void PrintReviewsTest()
        {
            ReviewsController controller = new ReviewsController();

            ViewResult result = controller.PrintReviews(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateReviewTest()
        {
            ReviewsController controller = new ReviewsController();

            ViewResult result = controller.CreateReview(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteReviewTest()
        {
            ReviewsController controller = new ReviewsController();

            ViewResult result = controller.DeleteReview(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditReviewTest()
        {
            ReviewsController controller = new ReviewsController();

            ViewResult result = controller.EditReview(2) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DisplayReviewTest()
        {
            ReviewsController controller = new ReviewsController();

            ViewResult result = controller.DisplayReview(2) as ViewResult;

            Assert.IsNotNull(result);
        }
    }

}
