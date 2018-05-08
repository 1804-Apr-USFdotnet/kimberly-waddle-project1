using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary.Models;
using RestaurantReviewData;

namespace RestaurantReviewLibrary.Tests
{
    [TestClass()]
    public class RestaurantReviewManagerTests
    {
        RestaurantReviewManager testManager = new RestaurantReviewManager();

        LibRestaurant test1 = new Models.LibRestaurant
        {
            ID = 1,
            Name = "McDonald's",
            Address = "123 Fake St",
            City = "Barcelona",
            Country = "Spain",
            ZIP = "67890",
            AvgRating = 1.2
        };
        LibRestaurant test2 = new Models.LibRestaurant
        {
            ID = 2,
            Name = "Carrabba's",
            Address = "456 Seventh Ave",
            City = "Kumquat",
            Country = "Mars",
            ZIP = "12345",
            AvgRating = 5.0
        };
        LibRestaurant test3 = new Models.LibRestaurant
        {
            ID = 3,
            Name = "Cruickshank Group",
            Address = "910 Forest Junction",
            City = "Zamora",
            Country = "Spain",
            ZIP = "49008",
            AvgRating = 3.0
        };
        LibRestaurant test4 = new Models.LibRestaurant
        {
            ID = 4,
            Name = "Schuster-Bogisich",
            Address = "0375 Gateway Parkway",
            City = "Lublin",
            Country = "Poland",
            ZIP = "20-960",
            AvgRating = 2.4
        };
        LibRestaurant test5 = new Models.LibRestaurant
        {
            ID = 5,
            Name = "Witting, Corkery and Wiza",
            Address = "50 Village Circle",
            City = "Consuelo",
            Country = "Philippines",
            ZIP = "1128",
            AvgRating = 1.8
        };
        LibRestaurant test6 = new Models.LibRestaurant
        {
            ID = 6,
            Name = "Dickens Group",
            Address = "52522 Loftsgordon Street",
            City = "Tabūk",
            Country = "Saudi Arabia",
            ZIP = null,
            AvgRating = 2.8
        };

        [TestMethod]
        public void SortByRatingTestAscending()
        {
            string order = "asc";
            List<Models.LibRestaurant> testRestaurants = new List<Models.LibRestaurant>();

            testRestaurants.Add(test1);
            testRestaurants.Add(test2);
            testRestaurants.Add(test3);
            testRestaurants.Add(test4);
            testRestaurants.Add(test5);
            testRestaurants.Add(test6);

            int expected = testRestaurants[0].ID;
            List<RestaurantReviewLibrary.Models.LibRestaurant> convertedList = new List<RestaurantReviewLibrary.Models.LibRestaurant>();
            foreach(Models.LibRestaurant mr in testRestaurants)
            {
                convertedList.Add(mr);
            }
            List<RestaurantReviewData.Restaurant> expectedList = new List<RestaurantReviewData.Restaurant>();
            foreach(RestaurantReviewLibrary.Models.LibRestaurant dbr in testManager.SortByRating(order, convertedList))
            {
                expectedList.Add(ModelConverter.ResObjToDB(dbr));
            }
            int actual = expectedList[0].ID;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SortByRatingTestDescending()
        {
            string order = "descending";
            List<LibRestaurant> testRestaurants = new List<LibRestaurant>();

            testRestaurants.Add(test1);
            testRestaurants.Add(test2);
            testRestaurants.Add(test3);
            testRestaurants.Add(test4);
            testRestaurants.Add(test5);
            testRestaurants.Add(test6);

            int expected = testRestaurants[4].ID;
            List<LibRestaurant> sortedList = new List<LibRestaurant>();
            foreach (LibRestaurant dbr in testManager.SortByRating(order, testRestaurants))
            {
                sortedList.Add(dbr);
            }
            int actual = sortedList[0].ID;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SortByNameTestAscending()
        {
            string order = "ascending";
            List<LibRestaurant> testRestaurants = new List<LibRestaurant>();

            testRestaurants.Add(test1);
            testRestaurants.Add(test2);
            testRestaurants.Add(test3);
            testRestaurants.Add(test4);
            testRestaurants.Add(test5);
            testRestaurants.Add(test6);

            int expected = testRestaurants[4].ID;
            List<LibRestaurant> sortedList = new List<LibRestaurant>();
            foreach (LibRestaurant dbr in testManager.SortByName(order, testRestaurants))
            {
                sortedList.Add(dbr);
            }
            int actual = sortedList[0].ID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortByNameTestDescending()
        {
            string order = "descending";
            List<LibRestaurant> testRestaurants = new List<LibRestaurant>();

            testRestaurants.Add(test1);
            testRestaurants.Add(test2);
            testRestaurants.Add(test3);
            testRestaurants.Add(test4);
            testRestaurants.Add(test5);
            testRestaurants.Add(test6);

            int expected = testRestaurants[4].ID;
            List<LibRestaurant> sortedList = new List<LibRestaurant>();
            foreach(LibRestaurant dbr in testManager.SortByName(order, testRestaurants))
            {
                sortedList.Add(dbr);
            }
            int actual = sortedList[0].ID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializerTest()
        {
            List<Models.LibRestaurant> restaurantList = new List<Models.LibRestaurant>();
            restaurantList.Add(test1);
            restaurantList.Add(test2);
            restaurantList.Add(test3);
            restaurantList.Add(test4);
            restaurantList.Add(test5);
            restaurantList.Add(test6);

            Serializer.SerializeObj<Models.LibRestaurant>(restaurantList, "test.txt", true);
        }

        [TestMethod]
        public void DeserializerTest()
        {
            string fileName = "test.txt";
            string actualResult;
            string expectedResult = "Name: shitbees\nAddress: 123 st\nAverage Rating: 0";
            List<Models.LibRestaurant> restaurants = new List<Models.LibRestaurant>();

            restaurants = Serializer.DeserializeObj<Models.LibRestaurant>(fileName);
            actualResult = restaurants[0].ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}