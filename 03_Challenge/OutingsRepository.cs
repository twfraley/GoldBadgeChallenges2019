using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class OutingsRepository
    {
        List<Outing> outings = new List<Outing>();

        public void AddToList(Outing outing)
        {
            outings.Add(outing);
        }

        public List<Outing> GetList()
        {
            return outings;
        }

        public decimal CombinedGolfCosts(List<Outing> outings)
        {
            decimal golfCost = 0;
            foreach (Outing outing in outings)
            {
                if (outing.EventType == EventType.Golf)
                    golfCost = outing.CostOfEvent;
                else
                    golfCost = 0;
            }
            return golfCost;
        }

        public decimal CombinedBowlingCosts(List<Outing> outings)
        {
            decimal bowlingCost = 0;
            foreach (Outing outing in outings)
            {
                if (outing.EventType == EventType.Bowling)
                    bowlingCost = outing.CostOfEvent;
                else
                    bowlingCost = 0;
            }
            return bowlingCost;
        }

        public decimal CombinedAmusementParkCosts(List<Outing> outings)
        {
            decimal amusementParkCost = 0;
            foreach (Outing outing in outings)
            {
                if (outing.EventType == EventType.AmusementPark)
                    amusementParkCost = outing.CostOfEvent;
                else
                    amusementParkCost = 0;
            }
            return amusementParkCost;
        }

        public decimal CombinedConcertCosts(List<Outing> outings)
        {
            decimal concertCost = 0;
            foreach (Outing outing in outings)
            {
                if (outing.EventType == EventType.Concert)
                    concertCost = outing.CostOfEvent;
                else
                    concertCost = 0;
            }
            return concertCost;
        }
    }
}
