using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert };

    public class Outing
    {
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

        public Outing (EventType eventType, int attendance, DateTime dateOfEvent, decimal costOfEvent)
        {
            EventType = eventType;
            Attendance = attendance;
            DateOfEvent = dateOfEvent;
            CostOfEvent = costOfEvent;
            CostPerPerson = costOfEvent / attendance;
        }

        public Outing()
        {

        }


    }
}
