using System;
using System.Collections.Generic;
using _02_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class ClaimsRepository_Tests
    {
        ClaimsRepository _claimsRepository = new ClaimsRepository();
        Queue<Claim> _claims = new Queue<Claim>();
        Claim _claim = new Claim();

        [TestMethod]
        public void ClaimRepository_Tests_AddClaimToList()
        {
            //Arrange
            DateTime sampleAccidentDateOne = new DateTime(2018, 9, 1, 12, 00, 00);
            DateTime sampleAccidentDateTwo = new DateTime(2019, 1, 1, 12, 00, 00);
            DateTime sampleAccidentDateThree = new DateTime(1890, 2, 1, 12, 00, 00);
            DateTime sampleClaimDateOne = new DateTime(2018, 9, 15, 12, 00, 00);
            DateTime sampleClaimDateTwo = new DateTime(2019, 1, 2, 12, 00, 00);
            DateTime sampleClaimDateThree = new DateTime(1904, 1, 3, 12, 00, 00);

            Claim sampleClaimOne = new Claim(1, ClaimType.Home, "Mouse exploded", 4000.03m, sampleAccidentDateOne, sampleClaimDateOne);
            Claim sampleClaimTwo = new Claim(2, ClaimType.Theft, "Mouse stole car", 4000.05m, sampleAccidentDateTwo, sampleAccidentDateThree);
            Claim sampleClaimThree = new Claim(3, ClaimType.Car, "carriage stolen", 210.56m, sampleAccidentDateThree, sampleClaimDateThree);

            _claimsRepository.AddClaimToList(sampleClaimOne);
            _claimsRepository.AddClaimToList(sampleClaimTwo);
            _claimsRepository.AddClaimToList(sampleClaimThree);

            //Assert
            int actual = _claimsRepository.GetClaims().Count;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_Tests_GetClaims()
        {
            //Arrange
            DateTime sampleAccidentDateOne = new DateTime(2018, 9, 1, 12, 00, 00);
            DateTime sampleAccidentDateTwo = new DateTime(2019, 1, 1, 12, 00, 00);
            DateTime sampleAccidentDateThree = new DateTime(1890, 2, 1, 12, 00, 00);
            DateTime sampleClaimDateOne = new DateTime(2018, 9, 15, 12, 00, 00);
            DateTime sampleClaimDateTwo = new DateTime(2019, 1, 2, 12, 00, 00);
            DateTime sampleClaimDateThree = new DateTime(1904, 1, 3, 12, 00, 00);

            Claim sampleClaimOne = new Claim(1, ClaimType.Home, "Mouse exploded", 4000.03m, sampleAccidentDateOne, sampleClaimDateOne);
            Claim sampleClaimTwo = new Claim(2, ClaimType.Theft, "Mouse stole car", 4000.05m, sampleAccidentDateTwo, sampleAccidentDateThree);
            Claim sampleClaimThree = new Claim(3, ClaimType.Car, "carriage stolen", 210.56m, sampleAccidentDateThree, sampleClaimDateThree);

            _claimsRepository.AddClaimToList(sampleClaimOne);
            _claimsRepository.AddClaimToList(sampleClaimTwo);
            _claimsRepository.AddClaimToList(sampleClaimThree);

            //Assert
            int actual = _claimsRepository.GetClaims().Count;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_Tests_RemoveFirstItemFromList()
        {
            //Arrange
            DateTime sampleAccidentDateOne = new DateTime(2018, 9, 1, 12, 00, 00);
            DateTime sampleAccidentDateTwo = new DateTime(2019, 1, 1, 12, 00, 00);
            DateTime sampleAccidentDateThree = new DateTime(1890, 2, 1, 12, 00, 00);
            DateTime sampleClaimDateOne = new DateTime(2018, 9, 15, 12, 00, 00);
            DateTime sampleClaimDateTwo = new DateTime(2019, 1, 2, 12, 00, 00);
            DateTime sampleClaimDateThree = new DateTime(1904, 1, 3, 12, 00, 00);

            Claim sampleClaimOne = new Claim(1, ClaimType.Home, "Mouse exploded", 4000.03m, sampleAccidentDateOne, sampleClaimDateOne);
            Claim sampleClaimTwo = new Claim(2, ClaimType.Theft, "Mouse stole car", 4000.05m, sampleAccidentDateTwo, sampleAccidentDateThree);
            Claim sampleClaimThree = new Claim(3, ClaimType.Car, "carriage stolen", 210.56m, sampleAccidentDateThree, sampleClaimDateThree);

            _claimsRepository.AddClaimToList(sampleClaimOne);
            _claimsRepository.AddClaimToList(sampleClaimTwo);
            _claimsRepository.AddClaimToList(sampleClaimThree);

            //Act
            _claimsRepository.RemoveFirstItemFromList(_claim);

            //Assert
            int actual = _claimsRepository.GetClaims().Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}