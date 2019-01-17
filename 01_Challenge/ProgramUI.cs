using System;
using System.Collections.Generic;

namespace _01_Challenge
{
    public class ProgramUI
    {
        ClaimsRepository _claimsRepository = new ClaimsRepository();
        Claim _claim = new Claim();
        List<Claim> _claims = new List<Claim>();

        //-------------------
        // Add sample claims to list here
        //-------------------


        public void Run()
        {
            //Start program

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
            List<Claim> _claims = new List<Claim>();
            _claimsRepository.GetClaims();

            foreach (Claim _claim in _claims)
            {
                Console.WriteLine(_claim);
            }
            Console.ReadKey();
        }

        public void TakeCareOfNextClaim()
        {

            int menuItem = 2;
            bool correctMenuItem = false;

            //------------------------
            //Add CONSOLE.WRITELINE for the claims info
            //------------------------

            Console.WriteLine("Do you want to finalize the claim now?\n" +
                "1: Yes\n" +
                "2: No");
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
                    _claimsRepository.RemoveFirstItemFromList(_claim);
                    _claimsRepository.GetClaims();
                    foreach (Claim _claim in _claims)
                    {
                        Console.WriteLine(_claim);
                    }
                    Console.ReadKey();
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
            _claimsRepository.GetClaims();
            foreach (Claim _claim in _claims)
            {
                Console.WriteLine(_claim);
            }
            Console.ReadKey();

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
            Console.WriteLine("Enter the date of the accident (mm/dd/yyyy):");
            correctDateOfClaim = DateTime.TryParse(Console.ReadLine(), out dateOfClaim);
            while (!correctDateOfClaim)
            {
                Console.WriteLine("You have entered an invalid date.\n" +
                    "Please follow the format mm/dd/yyyy\n" +
                    "Enter the date of the claim (mm/dd/yyyy");
                correctDateOfClaim = DateTime.TryParse(Console.ReadLine(), out dateOfClaim);
            }

            Claim _claim = new Claim(claimID,claimType,description,amount,dateOfAccident,dateOfClaim);
            _claimsRepository.AddClaimToList(_claim);
            _claimsRepository.GetClaims();
            foreach (Claim _claim in _claims)
            {
                Console.WriteLine(_claim);
            }
            Console.ReadKey();
        }
    }
}