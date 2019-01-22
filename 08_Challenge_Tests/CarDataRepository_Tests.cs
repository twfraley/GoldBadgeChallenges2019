using System;
using System.Collections.Generic;
using _08_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_Challenge_Tests
{
    [TestClass]
    public class CarDataRepository_Tests
    {
        CarDataRepository _repo = new CarDataRepository();
        CarData _carData = new CarData();
        List<CarData> _cars = new List<CarData>();

        [TestMethod]
        public void AddCarsToList_GetCarsFromList_Test()
        {
            TimeSpan time = new TimeSpan(12000, 2, 2, 2, 2);
            TimeSpan timeTwo = new TimeSpan(45, 0, 0, 0, 0);
            TimeSpan timeThree = new TimeSpan(0, 45, 23);
            CarData driverOne = new CarData("Ed", "Harris", 23f, 1.2f, 1f, 35f, time);
            CarData driverTwo = new CarData("Michelle", "Rodrigues", 94f, 3.5f, 58f, 4f, timeTwo);
            CarData driverThree = new CarData("Betty", "White", 123f, 10.1f, 1012, 1.3f, timeThree);

            _repo.AddToList(driverOne);
            _repo.AddToList(driverTwo);
            _repo.AddToList(driverThree);

            int expected = 3;
            int actual = _repo.GetCarData().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveCarData_Test()
        {
            TimeSpan time = new TimeSpan(12000, 2, 2, 2, 2);
            TimeSpan timeTwo = new TimeSpan(45, 0, 0, 0, 0);
            TimeSpan timeThree = new TimeSpan(0, 45, 23);
            CarData driverOne = new CarData("Ed", "Harris", 23f, 1.2f, 1f, 35f, time);
            CarData driverTwo = new CarData("Michelle", "Rodrigues", 94f, 3.5f, 58f, 4f, timeTwo);
            CarData driverThree = new CarData("Betty", "White", 123f, 10.1f, 1012, 1.3f, timeThree);

            _repo.AddToList(driverOne);
            _repo.AddToList(driverTwo);
            _repo.AddToList(driverThree);

            _repo.RemoveCarData("Ed", "Harris");

            int expected = 2;
            int actual = _repo.GetCarData().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
