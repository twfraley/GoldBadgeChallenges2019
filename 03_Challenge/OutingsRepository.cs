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

        public decimal CalculateIndividualCosts(EventType eventType)
        {
            decimal eventCost = 0;
            foreach (Outing outing in outings)
            {
                if (outing.EventType == eventType)
                    eventCost += outing.CostOfEvent;
            }
            return eventCost;
        }
    }
}