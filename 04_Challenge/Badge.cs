using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class Badge
    {
        //  A badge class that has the following properties:
        //      BadgeID
        //      List of door names for access

        Dictionary<int,List<string>> badges = new Dictionary<int,List<string>>();
        List<string> doors = new List<string>();

        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }

        public Badge (int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        public Badge()
        {

        }
    }
}