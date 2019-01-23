using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class Badge
    {
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