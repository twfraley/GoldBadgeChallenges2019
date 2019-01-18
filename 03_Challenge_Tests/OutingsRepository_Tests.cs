using System;
using System.Collections.Generic;
using _03_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge_Tests
{
    [TestClass]
    public class OutingsRepository_Tests
    {
        Outing _outing = new Outing();
        OutingsRepository _outingsRepository = new OutingsRepository();
        List<Outing> _outings = new List<Outing>();

        [TestMethod]
        public void OutingsRepository_Tests_AddToList_ShouldBeCorrect()
        {
            Outing sampleOutingOne = new Outing(EventType.Golf, 20, DateTime.UtcNow, 450m);

            _outingsRepository.AddToList(sampleOutingOne);

            int actual = sampleOutingOne.Attendance;
            int expected = 20;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingsRepository_Tests_GetFromList_ShouldBeCorrect()
        {
            //Arrange, Act, Assert

            Outing sampleOutingOne = new Outing(EventType.Golf, 20, DateTime.UtcNow, 450m);
            Outing sampleOutingTwo = new Outing(EventType.Concert, 50, DateTime.UtcNow, 1000m);
            Outing sampleOutingThree = new Outing(EventType.Golf, 4, DateTime.UtcNow, 1000m);

            _outingsRepository.AddToList(sampleOutingOne);
            _outingsRepository.AddToList(sampleOutingTwo);
            _outingsRepository.AddToList(sampleOutingThree);

            int actual = _outingsRepository.GetList().Count;
            int expected = 3;

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void OutingsRepository_Tests_CalculateIndividualCosts_ShouldBeCorrect()
        {
            Outing sampleOutingOne = new Outing(EventType.Golf, 20, DateTime.UtcNow, 450m);
            Outing sampleOutingTwo = new Outing(EventType.Concert, 50, DateTime.UtcNow, 1000m);
            Outing sampleOutingThree = new Outing(EventType.Golf, 4, DateTime.UtcNow, 1000m);

            _outingsRepository.AddToList(sampleOutingOne);
            _outingsRepository.AddToList(sampleOutingTwo);
            _outingsRepository.AddToList(sampleOutingThree);

            decimal actual = _outingsRepository.CalculateIndividualCosts(EventType.Golf);
            decimal expected = 1450m;

            Assert.AreEqual(expected, actual);
        }
    }
}