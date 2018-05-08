using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewWeb;
using RestaurantReviewWeb.Controllers;
using System.Web.Mvc;

namespace RestaurantReviewWebTests
{
    [TestClass]
    public class RestaurantsControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new RestaurantsController();
            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }
    }
}
