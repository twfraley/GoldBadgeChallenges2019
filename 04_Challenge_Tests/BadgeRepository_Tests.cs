using System;
using System.Collections.Generic;
using System.Linq;
using _04_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Tests
{
    [TestClass]
    public class BadgeRepository_Tests
    {
        BadgeRepository _repo = new BadgeRepository();

        [TestMethod]
        public void AddBadgeToDictionary_Test()
        {
            _repo.AddBadgeToDictionary(12345, "A5");
            _repo.AddBadgeToDictionary(22345, "A3");
            _repo.AddBadgeToDictionary(32345, "A3");

            int actual = _repo.GetBadgeList().Count();
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(22345, "a2")]
        [DataRow(22345, "a22")]
        public void AddDoorToList_Test(int key, string door)
        {
            _repo.AddBadgeToDictionary(22345, "A3");
            _repo.AddToDoorList(22345, "A2");
            _repo.AddToDoorList(key, door);

            int actual = _repo.GetDoorList(22345).Count();
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveDoorFromList_Test()
        {
            _repo.AddBadgeToDictionary(22345, "A3");
            _repo.AddToDoorList(22345, "A2");
            _repo.AddToDoorList(22345, "A1");

            _repo.RemoveDoorFromList(22345, "A2");

            int actual = _repo.GetDoorList(22345).Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
