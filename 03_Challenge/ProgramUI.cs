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

            //Start
            //menu
            // - 1: display list of all outings
            //  -- get list, display entire list, return to menu
            // -2: add new outing to list
            //  -- add to list, display entire list, return to menu
            // -3: cost calculations
            //  -- combined cost of all outings
            //   ---get combined cost method
            //  -- outing costs by type
            //   ---get combined costs by type method
            //  -- return to menu
            // -4: end program

            Console.WriteLine("welcome to whatever");

            while (runProgram)
            {
                Console.WriteLine("Menu\n" +
                    "1. display\n" +
                    "2. add to list\n" +
                    "3. cost calculations\n" +
                    "4. end program");

                int mainMenuSelection = int.Parse(Console.ReadLine());

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

        }

        public void CostCalculations()
        {

        }

        public void DisplayListOfOutings(List<Outing> outings)
        {
            foreach (Outing outing in outings)
            {
                Console.WriteLine($"{outing.EventType} {outing.Attendance} {outing.DateOfEvent} {outing.CostOfEvent} {outing.CostPerPerson}");
            }
        }
    }
}