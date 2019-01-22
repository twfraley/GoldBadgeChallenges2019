using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    public class ProgramUI
    {
        CarDataRepository _repo = new CarDataRepository();

        public void Run()
        {
            PopulateList();

            Console.WriteLine("Welcome to Komodo SmartCar Insurance!\n...\n..." +
                "Press any key to continue:");
            Console.ReadKey();

            bool runProgram = true;

            while (runProgram)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:\n" +
                    "1. View list of drivers\n" +
                    "2. View insurance premium calculations\n" +
                    "3. Edit list of drivers\n" +
                    "4. Exit");

                int menuChoice = int.Parse(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        ViewDriverList();
                        break;
                    case 2:
                        ViewInsurancePremiums();
                        break;
                    case 3:
                        EditDriverList();
                        break;
                    case 4:
                    default:
                        runProgram = false;
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }

        public void ViewDriverList()
        {
            List<CarData> cars = _repo.GetCarData();

            foreach (CarData carData in cars)
            {
                Console.WriteLine(carData);
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }

        public void ViewInsurancePremiums()
        {
            Console.WriteLine("-----------------------\n" +
                "INSURANCE CALCULATIONS\n...\n..." +
                "Base Insurance premium: $100/mo.\n" +
                "If your average speed is above 65mph, premiums increase by $50/mo.\n" +
                "If your average G-forces on stopping are over 2Gs, premiums increase by $50/mo.\n" +
                "If you roll through an average of 4 or more stop signs a month, premiums increase by $50/mo.\n" +
                "If you follow closer than an average of 30ft, premiums increase by $75/mo.\n" +
                "If you have had an accident in the past five years, premiums increase by $100/mo." +
                "\n...\n...\nPress any key to return to menu.");
            Console.ReadKey();
        }

        public void EditDriverList()
        {
            Console.WriteLine("Edit Driver List:\n" +
                "1. Add driver to list\n" +
                "2. Remove driver from list\n" +
                "3. View specific driver and premium\n" +
                "4. Exit to main menu.");
            int menuChoice = int.Parse(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    AddDriverToList();
                    break;
                case 2:
                    RemoveDriverFromList();
                    break;
                case 3:
                    ViewSpecificDriver();
                    break;
                case 4:
                default: break;
            }
        }

        public void AddDriverToList()
        {
            Console.WriteLine("ADD NEW DRIVER TO LIST\n...\n...");
            Console.WriteLine("Driver's LAST name?");
            string driversLastName = Console.ReadLine();

            Console.WriteLine("Driver's FIRST name?");
            string driversFirstName = Console.ReadLine();

            Console.WriteLine("Driver's average speed?");
            float avgSpeed = float.Parse(Console.ReadLine());

            Console.WriteLine("Driver's average stopping G's?");
            float avgGForce = float.Parse(Console.ReadLine());

            Console.WriteLine("Driver's average stop sign roll-throughs?");
            float avgStopSignRollthrough = float.Parse(Console.ReadLine());

            Console.WriteLine("Driver's average follow distance?");
            float avgFollowDistance = float.Parse(Console.ReadLine());

            Console.WriteLine("Driver's last accident?");
            DateTime lastAccident = DateTime.Parse(Console.ReadLine());

            DateTime today = DateTime.UtcNow;

            TimeSpan timeSinceLastAccident = today - lastAccident;

            CarData driver = new CarData(driversFirstName, driversLastName, avgSpeed, avgGForce, avgStopSignRollthrough, avgFollowDistance, timeSinceLastAccident);
            _repo.AddToList(driver);

            Console.WriteLine("Driver added to list.");
        }

        public void RemoveDriverFromList()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("REMOVE DRIVER FROM LIST:\n...\n...");
                Console.WriteLine("What is the LAST name of the driver you would like to remove?");
                string driverLastName = Console.ReadLine();

                Console.WriteLine("What is the FIRST name of the driver you would like to remove?");
                string driverFirstName = Console.ReadLine();

                bool success = _repo.RemoveCarData(driverFirstName, driverLastName);
                if (success)
                    Console.WriteLine($"{driverLastName}, {driverFirstName} removed from list");
                else
                    Console.WriteLine($"{driverLastName}, {driverFirstName} not found in list.");

                Console.WriteLine("Would you like to remove another driver?\n" +
                    "1: Yes\n" +
                    "2: No");
                int menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        runMenu = true;
                        break;
                    case 2:
                        runMenu = false;
                        break;
                }
            }
        }

        public void ViewSpecificDriver()
        {
            List<CarData> _cars = _repo.GetCarData();

            Console.WriteLine("What is the LAST name of the driver you would like to view?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the FIRST name of the driver you would like to view?");
            string firstName = Console.ReadLine();

            foreach (CarData _carData in _cars)
            {
                if (firstName == _carData.DriverFirstName && lastName == _carData.DriverLastName)
                {
                    Console.WriteLine(_carData);
                }
            }
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
        }

        public void PopulateList()
        {
            TimeSpan time = new TimeSpan(12000, 2, 2, 2, 2);
            TimeSpan timeTwo = new TimeSpan(45, 0, 0, 0, 0);
            TimeSpan timeThree = new TimeSpan(0, 45, 23);
            CarData driverOne = new CarData("Ed", "Harris", 23f, 1.2f, 1f, 35f, time);
            _repo.AddToList(driverOne);
            CarData driverTwo = new CarData("Michelle", "Rodrigues", 94f, 3.5f, 58f, 4f, timeTwo);
            _repo.AddToList(driverTwo);
            CarData driverThree = new CarData("Betty", "White", 123f, 10.1f, 1012, 1.3f, timeThree);
            _repo.AddToList(driverThree);
        }
    }
}