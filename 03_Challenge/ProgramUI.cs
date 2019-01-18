using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class ProgramUI
    {
        Outing _outing = new Outing();
        OutingsRepository _outingsRepository = new OutingsRepository();
        List<Outing> _outings = new List<Outing>();

        public void Run()
        {
            bool runProgram = true;
            PopulateList();

            Console.WriteLine("welcome to whatever");

            while (runProgram)
            {
                Console.WriteLine("MAIN MENU\n...\n" +
                    "1. Show List of all Outings\n" +
                    "2. Add New Outing to List\n" +
                    "3. Perform Cost Calculations\n" +
                    "4. End Program");
                bool correctMenuSelection = int.TryParse(Console.ReadLine(), out int mainMenuSelection);

                while (!correctMenuSelection)
                {
                    Console.WriteLine("You have entered an incorrect value.\n" +
                        "Please type the NUMBER of the desired menu item.\n");
                    Console.WriteLine("MAIN MENU\n...\n" +
                        "1. Show List of all Outings\n" +
                        "2. Add New Outing to List\n" +
                        "3. Perform Cost Calculations\n" +
                        "4. End Program");
                    correctMenuSelection = int.TryParse(Console.ReadLine(), out mainMenuSelection);
                }

                switch (mainMenuSelection)
                {
                    case 1:
                        SeeListOfOutings();
                        break;
                    case 2:
                        AddOutingToList();
                        break;
                    case 3:
                        CostCalculations();
                        break;
                    case 4:
                        runProgram = false;
                        break;
                }
            }
        }

        public void SeeListOfOutings()
        {
            _outings = _outingsRepository.GetList();
            DisplayListOfOutings(_outings);
        }

        public void AddOutingToList()
        {
            Console.WriteLine("Enter new event:");
            Console.WriteLine("What type of event would you like to enter?\n" +
                "1: Golf\n" +
                "2: Bowling\n" +
                "3: Amusement Park\n" +
                "4: Concert");
            bool eventMenuSelection = int.TryParse(Console.ReadLine(), out int eventSelection);

            while (!eventMenuSelection)
            {
                Console.WriteLine("You have entered an incorrect value.\n" +
                    "Please type the NUMBER of the desired menu item.\n");
                Console.WriteLine("Enter new event:");
                Console.WriteLine("What type of event would you like to enter?\n" +
                    "1: Golf\n" +
                    "2: Bowling\n" +
                    "3: Amusement Park\n" +
                    "4: Concert");
                eventMenuSelection = int.TryParse(Console.ReadLine(), out eventSelection);
            }

            EventType eventType = 0;
            switch (eventSelection)
            {
                case 1:
                    eventType = EventType.Golf;
                    break;
                case 2:
                    eventType = EventType.Bowling;
                    break;
                case 3:
                    eventType = EventType.AmusementPark;
                    break;
                case 4:
                default:
                    eventType = EventType.Concert;
                    break;
            }

            Console.WriteLine("How many people attended the event?");
            bool menuSelection = int.TryParse(Console.ReadLine(), out int attendance);
            while (!menuSelection)
            {
                Console.WriteLine("You have entered an incorrect character.  Please try again.\n" +
                    "How many people attended the event?");
                menuSelection = int.TryParse(Console.ReadLine(), out attendance);
            }

            Console.WriteLine("What was the date of the event? mm/dd/yyyy");
            menuSelection = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfEvent);
            while (!menuSelection)
            {
                Console.WriteLine("You have entered an incorrect character.  Please try again.\n" +
                    "What was the date of the event? mm/dd/yyyy");
                menuSelection = DateTime.TryParse(Console.ReadLine(), out dateOfEvent);
            }

            Console.WriteLine("How much did the event cost?");
            menuSelection = decimal.TryParse(Console.ReadLine(), out decimal costOfEvent);
            while (!menuSelection)
            {
                Console.WriteLine("You have entered an incorrect character.  Please try again.\n" +
                    "How much did the event cost?");
                menuSelection = decimal.TryParse(Console.ReadLine(), out costOfEvent);
            }

            Console.WriteLine($"The cost per person is {costOfEvent / attendance}");

            Outing outing = new Outing(eventType, attendance, dateOfEvent, costOfEvent);
            _outingsRepository.AddToList(outing);
            _outings = _outingsRepository.GetList();
            DisplayListOfOutings(_outings);
        }

        public void CostCalculations()
        {
            Console.WriteLine("What calculation would you like to perform?\n" +
                "Choose from the list below:\n\n" +
                "1: Show total cost of all outings\n" +
                "2: Show total cost of golf outings\n" +
                "3: Show total cost of bowling outings\n" +
                "4: Show total cost of amusement park outings\n" +
                "5: Show total cost of concert outings");
            bool correctMenuChoice = int.TryParse(Console.ReadLine(), out int menuChoice);

            while (!correctMenuChoice)
            {
                Console.WriteLine("You have entered an incorrect value.\n" +
                    "Please type the NUMBER of the desired menu item.\n");
                Console.WriteLine("What calculation would you like to perform?\n" +
                    "Choose from the list below:\n\n" +
                    "1: Show total cost of all outings\n" +
                    "2: Show total cost of golf outings\n" +
                    "3: Show total cost of bowling outings\n" +
                    "4: Show total cost of amusement park outings\n" +
                    "5: Show total cost of concert outings");
                correctMenuChoice = int.TryParse(Console.ReadLine(), out menuChoice);
            }

            switch (menuChoice)
            {
                case 1:
                    DisplayTotalCost();
                    break;
                case 2:
                    OutingCost(EventType.Golf);
                    break;
                case 3:
                    OutingCost(EventType.Bowling);
                    break;
                case 4:
                    OutingCost(EventType.AmusementPark);
                    break;
                case 5:
                default:
                    OutingCost(EventType.Concert);
                    break;
            }
        }

        public void DisplayListOfOutings(List<Outing> outings)
        {
            foreach (Outing outing in outings)
            {
                Console.WriteLine($"{outing.EventType} {outing.Attendance} {outing.DateOfEvent} {outing.CostOfEvent} {outing.CostPerPerson}");
            }
            Console.WriteLine("--------------------------");
            Console.ReadKey();
        }

        public void DisplayTotalCost()
        {
            decimal golf = _outingsRepository.CalculateIndividualCosts(EventType.Golf);
            decimal bowling = _outingsRepository.CalculateIndividualCosts(EventType.Bowling);
            decimal amusementPark = _outingsRepository.CalculateIndividualCosts(EventType.AmusementPark);
            decimal concert = _outingsRepository.CalculateIndividualCosts(EventType.Concert);

            decimal totalCost = golf + bowling + amusementPark + concert;

            Console.WriteLine($"The total cost of all outings was {totalCost}");
            Console.ReadKey();
        }

        public void OutingCost(EventType eventType)
        {
            decimal cost = _outingsRepository.CalculateIndividualCosts(eventType);
            Console.WriteLine($"The total cost for all {eventType} outings was {cost}.");
        }

        public void PopulateList()
        {
            Outing sampleOutingOne = new Outing(EventType.Golf, 20, DateTime.UtcNow, 450m);
            Outing sampleOutingTwo = new Outing(EventType.Concert, 50, DateTime.UtcNow, 1000m);
            Outing sampleOutingThree = new Outing(EventType.Golf, 4, DateTime.UtcNow, 1000m);

            _outingsRepository.AddToList(sampleOutingOne);
            _outingsRepository.AddToList(sampleOutingTwo);
            _outingsRepository.AddToList(sampleOutingThree);
        }
    }
}