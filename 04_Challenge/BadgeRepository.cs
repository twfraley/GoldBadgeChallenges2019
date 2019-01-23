using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        List<string> _doors = new List<string>();

        // Add door to list
        public void AddToDoorList(int badgeID, string door)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                if (badge.Key == badgeID)
                {
                    badge.Value.Add(door);
                }
            }
        }

        // Remove door from badge list
        public void RemoveDoorFromList(int badgeID, string door)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                if (badge.Key == badgeID)
                {
                    badge.Value.Remove(door);
                }
            }
        }

        // Return a list of all doors for each badge
        public List<string> GetDoorList(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                if (badge.Key == badgeID)
                {
                    List<string> doors = badge.Value;
                        return doors;
                }
            }
            return _doors;
        }

        // Add a new badge to dictionary
        public void AddBadgeToDictionary(int badgeID, string door)
        {
            List<string> doors = new List<string>();
            doors.Add(door);
            _badges.Add(badgeID, doors);
        }

        // Return a Dictionary of all badges
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badges;
        }
    }
}
