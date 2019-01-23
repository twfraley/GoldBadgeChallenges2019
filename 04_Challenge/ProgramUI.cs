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
            // Menu
            //  Hello Security Admin, What would you like to do?
            //      1. Add a badge
            //      2. Edit a badge.
            //      3. List all Badges
            //      4. Exit
        }

        public void AddABadge()
        {
            //  #1 Add a badge
            //      What is the number on the badge:  12345
            //      List a door that it needs access to: A5
            //      Any other doors(y/n)? y
            //      List a door that it needs access to: A7
            //      Any other doors(y/n)? n
            //      (Return to main menu.)

            Console.WriteLine("Add a badge:\n...\n...\n" +
                "What is the number on the badge? (ex: #####)");
            int badgeID = int.Parse(Console.ReadLine());

            bool continueMenu = true;
            while (continueMenu)
            {
                Console.WriteLine("List a door that it needs access to:");
                string door = Console.ReadLine();

                // add door to list

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
            Console.WriteLine(badgeList.Keys);
            Console.WriteLine(badgeList.Values);

            foreach (KeyValuePair<int, List<string>> badgeID in badgeList)
            {
                Console.WriteLine("Key Badge #: \tDoorAccess");
                Console.WriteLine($"{badgeList.Keys} \t\t {badgeList.Values}");
            }

        }

        public void PopulateBadgeList()
        {
            // Seed badge list to make it easier to work with
        }
    }
}