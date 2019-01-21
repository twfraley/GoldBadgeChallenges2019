using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class BadgeRepository
    {
        //  A badge repository that will have methods that do the following:
        //      1. Create a dictionary of badges.
        //      2. The key for the dictionary will be the BadgeID.
        //      3. The value for the dictionary will be the List of Door Names.

        Dictionary<int, List<string>> badges = new Dictionary<int, List<string>>();
        List<string> doors = new List<string>();

        // Add door to list
        public void AddToDoorList(string door)
        {
            doors.Add(door);
        }

        // Remove door from badge list
        public void RemoveDoorFromList(string door)
        {
            doors.Remove(door);
        }

        // Return a list (dictionary?) of all badges
        public Dictionary<int,List<string>> GetBadgeList()
        {

            return badges;
        }

    }
}
