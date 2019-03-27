using System;
using System.Collections.Generic;

namespace _02_Challenge
{
    public class ProgramUI
    {
        ClaimsRepository _claimsRepository = new ClaimsRepository();
        Queue<Claim> _claims = new Queue<Claim>();

        public void Run()
        {
            //Start program

            PopulateList();

            Console.WriteLine("-------KOMODO CLAIMS SOFTWARE-------\n...\n...");

            bool runProgram = true;
            while (runProgram)
            {
                int menuItem = 4;
                bool correctMenuItem = false;

                Console.WriteLine("----MAIN MENU-----\n" +
                        "1: See all claims\n" +
                        "2: Take care of next claim\n" +
                        "3: Enter new claim\n" +
                        "4: Exit");
                correctMenuItem = int.TryParse(Console.ReadLine(), out menuItem);

                while (!correctMenuItem)
                {
                    Console.Clear();
                    Console.WriteLine("----MAIN MENU----\n");
                    Console.WriteLine("Please type the NUMBER of the item you want:\n" +
                        "1: See all claims\n" +
                        "2: Take care of next claim\n" +
                        "3: Enter new claim\n" +
                        "4: Exit");
                    correctMenuItem = int.TryParse(Console.ReadLine(), out menuItem);
                }


                switch (menuItem)
                {
                    case 1:
                        SeeClaims();
                        break;
                    case 2:
                        TakeCareOfNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                    default:
                        runProgram = false;
                        break;
                }
            }
        }

        public void SeeClaims()
        {
            _claims = _claimsRepository.GetClaims();
            DisplayClaimsList(_claims);
        }

        public void TakeCareOfNextClaim()
        {
            Claim claim = new Claim();


            //------------------------
            //Add CONSOLE.WRITELINE for the first claim's info
            //------------------------

            Console.WriteLine("Do you want to finalize the first claim in the queue?\n" +
                "1: Yes\n" +
                "2: No");
            int menuItem = 2;
            bool correctMenuItem = false;
            correctMenuItem = int.TryParse(Console.ReadLine(), out menuItem);

            while (!correctMenuItem)
            {
                Console.WriteLine("Please type the NUMBER of the item you want:\n" +
                    "1: Yes\n" +
                    "2: No");
                correctMenuItem = int.TryParse(Console.ReadLine(), out menuItem);
            }

            switch (menuItem)
            {
                case 1:
                    _claimsRepository.RemoveFirstItemFromList(claim);
                    _claims = _claimsRepository.GetClaims();
                    DisplayClaimsList(_claims);
                    break;
                case 2:
                default: break;
            }
        }

        public void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("----NEW CLAIM----\n...\n...");

            Console.WriteLine("Existing claim list:");
            _claims = _claimsRepository.GetClaims();
            DisplayClaimsList(_claims);

            Console.WriteLine("Enter the next available Claim ID #:");
            int claimID = 1;
            bool correctIDNumber = false;
            correctIDNumber = int.TryParse(Console.ReadLine(), out claimID);

            while (!correctIDNumber)
            {
                Console.WriteLine("You have entered an invalid character.\n" +
                    "Enter the next available Claim ID #:");
                correctIDNumber = int.TryParse(Console.ReadLine(), out claimID);
            }

            Console.WriteLine("Enter the type of claim:\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            int menuItem = 1;
            bool correctMenuItem = false;
            correctMenuItem = int.TryParse(Console.ReadLine(), out menuItem);

            while (!correctIDNumber)
            {
                Console.WriteLine("You have entered an invalid character.\n" +
                    "Enter the type of claim:\n" +
                    "1: Car\n" +
                    "2: Home\n" +
                    "3: Theft\n");
                correctIDNumber = int.TryParse(Console.ReadLine(), out menuItem);
            }

            ClaimType claimType;

            switch (menuItem)
            {
                case 1:
                    claimType = ClaimType.Car;
                    break;
                case 2:
                    claimType = ClaimType.Home;
                    break;
                case 3:
                default:
                    claimType = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Briefly describe the claim:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim:");
            bool correctClaimAmount = false;
            decimal amount;
            correctClaimAmount = decimal.TryParse(Console.ReadLine(), out amount);
            while (!correctClaimAmount)
            {
                Console.WriteLine("You have entered an invalid amount\n" +
                    "Enter the amount of the claim:");
                correctClaimAmount = decimal.TryParse(Console.ReadLine(), out amount);
            }

            bool correctDateOfAccident = false;
            DateTime dateOfAccident;
            Console.WriteLine("Enter the date of the accident (mm/dd/yyyy):");
            correctDateOfAccident = DateTime.TryParse(Console.ReadLine(), out dateOfAccident);
            while (!correctDateOfAccident)
            {
                Console.WriteLine("You have entered an invalid date.\n" +
                    "Please follow the format mm/dd/yyyy\n" +
                    "Enter the date of the accident (mm/dd/yyyy");
                correctDateOfAccident = DateTime.TryParse(Console.ReadLine(), out dateOfAccident);
            }

            bool correctDateOfClaim = false;
            DateTime dateOfClaim;
            Console.WriteLine("Enter the date of the claim (mm/dd/yyyy):");
            correctDateOfClaim = DateTime.TryParse(Console.ReadLine(), out dateOfClaim);
            while (!correctDateOfClaim)
            {
                Console.WriteLine("You have entered an invalid date.\n" +
                    "Please follow the format mm/dd/yyyy\n" +
                    "Enter the date of the claim (mm/dd/yyyy");
                correctDateOfClaim = DateTime.TryParse(Console.ReadLine(), out dateOfClaim);
            }

            Claim newClaim = new Claim(claimID, claimType, description, amount, dateOfAccident, dateOfClaim);
            _claimsRepository.AddClaimToList(newClaim);
            _claims = _claimsRepository.GetClaims();
            DisplayClaimsList(_claims);
        }

        public void DisplayClaimsList(Queue<Claim> claims)
        {
            Console.WriteLine("ClaimID\tType\tDescription\tAmount\tDate of Accident\tDate of Claim\t\tClaim is Valid?");
            foreach (Claim claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t${claim.Amount}\t{claim.DateOfAccident.ToShortDateString()}\t{claim.DateOfClaim.ToShortDateString()}\t{claim.ClaimValid}");
            }
            Console.WriteLine("-------------------------------------------");
            Console.ReadKey();
        }

        public void PopulateList()
        {
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
        }
    }
}