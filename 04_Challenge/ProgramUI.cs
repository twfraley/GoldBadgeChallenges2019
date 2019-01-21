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
        // Menu
        //  Hello Security Admin, What would you like to do?
        //      1. Add a badge
        //      2. Edit a badge.
        //      3. List all Badges
        //
        //  #1 Add a badge
        //      What is the number on the badge:  12345
        //      List a door that it needs access to: A5
        //      Any other doors(y/n)? y
        //      List a door that it needs access to: A7
        //      Any other doors(y/n)? n
        //      (Return to main menu.)
        //
        //  #2 Update a badge
        //       What is the badge number to update? 12345
        //      12345 has access to doors A5 & A7.
        //      What would you like to do?
        //	    1. Remove a door
        //	    2. Add a door
        //      > 1
        //      Which door would you like to remove? A5
        //      Door removed.
        //      12345 has access to door A7.
        //
        //  #3 List all badges view
        //      Key
        //      Badge #			 Door Access       
        //      12345			 A7			 
        //      22345			 A1, A4, B1, B2		 
        //      32345			 A4, A5
        //
        //  Out of scope:
        //  You do not need to consider tying an individual badge to a particular user.Just the Badge # will do.
        //

        List<string> doors = new List<string>();
        Dictionary<int, List<string>> badges = new Dictionary<int, List<string>>();

        public void Run()
        {

        }
    }
}