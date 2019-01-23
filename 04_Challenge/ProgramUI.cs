using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    class ProgramUI
    {
        //  Create Dictionary of employee badge information.
        //  Badge needs number for access to specific set of doors.
        //
        //  The Program will allow a security staff member to do the following:
        //      create a new badge
        //      update doors on an existing badge.
        //      delete all doors from an existing badge.
        //
        //  Out of scope:
        //  You do not need to consider tying an individual badge to a particular user.Just the Badge # will do.
        //

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
                int menuChoice = int.Parse(Console.ReadLine());

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
            int badgeID = int.Parse(Console.ReadLine());

            bool continueMenu = true;
            while (continueMenu)
            {
                Console.WriteLine("List a door that it needs access to:");
                string door = Console.ReadLine();

                _repo.AddBadgeToDictionary(badgeID, door);

                Console.WriteLine("Does it need access to any other doors? Y/N");
                string menuChoiceYN = Console.ReadLine().ToLower();

                if (menuChoiceYN == "y")
                    continueMenu = true;
                else
                    continueMenu = false;
            }
        }

        public void EditABadge()
        {
            Console.WriteLine("What is the badge number to update?");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to do?\n" +
                "1: Remove a door\n" +
                "2: Add a door");
            int menuChoice = int.Parse(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    RemoveDoorFromList(badgeID);
                    break;
                case 2:
                default:
                    AddDoorToList(badgeID);
                    break;
            }
        }

        public void RemoveDoorFromList(int badgeID)
        {
            Console.WriteLine("Which door would you like to remove?");
            string door = Console.ReadLine();

            _repo.RemoveDoorFromList(badgeID, door);

            Console.WriteLine("Door Removed");
            Console.ReadKey();

            // Display new list of doors available to the key
        }

        public void AddDoorToList(int badgeID)
        {
            Console.WriteLine("Which door would you like to add?");
            string door = Console.ReadLine();

            _repo.AddToDoorList(badgeID, door);

            Console.WriteLine("Door added");
            Console.ReadKey();

            // Display new list of doors available to the key
        }

        public void ListAllBadges()
        {
            Dictionary<int,List<string>> badgeList = _repo.GetBadgeList();

            foreach (KeyValuePair<int, List<string>> badgeID in badgeList)
            {
                //foreach list item (door), write it to the console, one after the other. Maybe?

                Console.WriteLine("Key Badge #: \tDoorAccess");
                Console.WriteLine($"{badgeID.Key} \t\t {badgeID.Value}");
            }
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