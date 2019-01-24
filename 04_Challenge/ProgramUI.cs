using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    class ProgramUI
    {
        BadgeRepository _repo = new BadgeRepository();

        public void Run()
        {
            PopulateBadgeList();

            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("Hello security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                bool menuCorrect = int.TryParse(Console.ReadLine(), out int menuChoice);

                while (!menuCorrect)
                {
                    Console.WriteLine("You have entered an incorrect character.\n" +
                        "Please type the NUMBER of the menu item you want.");
                    Console.WriteLine("Hello security Admin, what would you like to do?\n" +
                        "1. Add a badge\n" +
                        "2. Edit a badge\n" +
                        "3. List all Badges\n" +
                        "4. Exit");
                    menuCorrect = int.TryParse(Console.ReadLine(), out menuChoice);
                }

                switch (menuChoice)
                {
                    case 1:
                        AddABadge();
                        break;
                    case 2:
                        EditABadge();
                        break;
                    case 3:
                        ListAllBadges();
                        Console.Clear();
                        break;
                    case 4:
                    default:
                        runProgram = false;
                        break;
                }
            }
        }

        public void AddABadge()
        {
            Console.WriteLine("Add a badge:\n...\n...\n" +
                "What is the number on the badge? (ex: #####)");
            bool menuCorrect = int.TryParse(Console.ReadLine(), out int badgeID);

            while (!menuCorrect)
            {
                Console.WriteLine("You have entered an incorrect character.\n" +
                    "Please type the NUMBER of the menu item you want.");
                Console.WriteLine("Add a badge:\n...\n...\n" +
                    "What is the number on the badge? (ex: #####)");
                menuCorrect = int.TryParse(Console.ReadLine(), out badgeID);
            }

            Console.WriteLine("List a door that it needs access to:");
            string doorToAdd = Console.ReadLine();

            _repo.AddBadgeToDictionary(badgeID, doorToAdd);

            DisplayDoorList(badgeID);

            Console.WriteLine("Does it need access to any other doors? Y/N");
            string menuChoiceYN = Console.ReadLine().ToLower();

            if (menuChoiceYN == "y")
                AddDoorToList(badgeID);
            if (menuChoiceYN == "n") ;
            else
            {
                Console.WriteLine("You have entered an incorrect character.\n" +
                    "Returning to main Menu");
            }

            Console.Clear();
        }

        public void EditABadge()
        {
            ListAllBadges();

            Console.WriteLine("What is the badge number to update?");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to do?\n" +
                "1: Remove a door\n" +
                "2: Add a door");
            bool menuCorrect = int.TryParse(Console.ReadLine(), out int menuChoice);

            while (!menuCorrect)
            {
                Console.WriteLine("You have entered an incorrect character.\n" +
                    "Please type the NUMBER of the menu item you want.");
                Console.WriteLine("What would you like to do?\n" +
                    "1: Remove a door\n" +
                    "2: Add a door");
                menuCorrect = int.TryParse(Console.ReadLine(), out menuChoice);
            }

            switch (menuChoice)
            {
                case 1:
                    RemoveDoorFromList(badgeID);
                    Console.Clear();
                    break;
                case 2:
                default:
                    AddDoorToList(badgeID);
                    Console.Clear();
                    break;
            }
        }

        public void RemoveDoorFromList(int badgeID)
        {
            Console.WriteLine("Which door would you like to remove?");
            string doorToRemove = Console.ReadLine();

            _repo.RemoveDoorFromList(badgeID, doorToRemove);

            Console.WriteLine($"Door {doorToRemove} Removed");

            DisplayDoorList(badgeID);

            Console.ReadKey();

            Console.WriteLine("Would you like to remove another door? Y/N");
            string menuChoiceYN = Console.ReadLine().ToLower();

            if (menuChoiceYN == "y")
                RemoveDoorFromList(badgeID);
            if (menuChoiceYN == "n") ;
            else
            {
                Console.WriteLine("You have entered an incorrect character.\n" +
                    "Returning to main Menu");
            }

            Console.Clear();
        }

        public void AddDoorToList(int badgeID)
        {
            DisplayDoorList(badgeID);

            Console.WriteLine("Which door would you like to add?");
            string doorToAdd = Console.ReadLine();

            _repo.AddToDoorList(badgeID, doorToAdd);

            Console.WriteLine("Door added");

            DisplayDoorList(badgeID);

            Console.ReadKey();

            Console.WriteLine("Does it need access to any other doors? Y/N");
            string menuChoiceYN = Console.ReadLine().ToLower();

            if (menuChoiceYN == "y")
                AddDoorToList(badgeID);
            if (menuChoiceYN == "n") ;
            else
            {
                Console.WriteLine("You have entered an incorrect character.\n" +
                    "Returning to main Menu");
            }

            Console.Clear();
        }

        public void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeList = _repo.GetBadgeList();

            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                List<string> doors = _repo.GetDoorList(badge.Key);
                string doorsAccessed = null;

                foreach (string door in doors)
                {
                    doorsAccessed = doorsAccessed + door + " ";
                }

                Console.WriteLine("Key Badge #: \tDoorAccess");
                Console.WriteLine($"{badge.Key} \t\t {doorsAccessed}");
            }
            Console.ReadKey();
        }

        public void DisplayDoorList(int badgeID)
        {
            List<string> doors = _repo.GetDoorList(badgeID);
            Console.WriteLine("Current list of doors available to this badge:\n...");
            string doorsAccessed = null;
            foreach (string door in doors)
            {
                doorsAccessed = doorsAccessed + door + " ";
            }
            Console.WriteLine($"{doorsAccessed}\n");
        }

        public void PopulateBadgeList()
        {
            _repo.AddBadgeToDictionary(12345, "A5");
            _repo.AddToDoorList(12345, "B7");
            _repo.AddBadgeToDictionary(22345, "A3");
            _repo.AddToDoorList(22345, "A2");
            _repo.AddToDoorList(22345, "A1");
            _repo.AddBadgeToDictionary(32345, "A3");
        }
    }
}
