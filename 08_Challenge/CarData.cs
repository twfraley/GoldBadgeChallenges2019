using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    public class CarData
    {
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public float AvgSpeed { get; set; }
        public float AvgGForce { get; set; }
        public float AvgStopSignRollthrough { get; set; }
        public float AvgFollowDistance { get; set; }
        public TimeSpan TimeSinceLastAccident { get; set; }
        public decimal InsuranceCost { get; set; }

        public CarData(string driverFirstName, string driverLastName, float avgSpeed, float avgGForce, float avgStopSignRollthrough, float avgFollowDistance, TimeSpan timeSinceLastAccident)
        {
            DriverFirstName = driverFirstName;
            DriverLastName = driverLastName;
            AvgSpeed = avgSpeed;
            AvgGForce = avgGForce;
            AvgStopSignRollthrough = avgStopSignRollthrough;
            AvgFollowDistance = avgFollowDistance;
            TimeSinceLastAccident = timeSinceLastAccident;
            InsuranceCost = CalculateInsuranceCosts();
        }

        public CarData()
        {

        }

        public decimal CalculateInsuranceCosts()
        {
            decimal insuranceCosts = 100m;

            if (AvgSpeed >= 65f)
                insuranceCosts += 50m;
            if (AvgGForce >= 2f)
                insuranceCosts += 50m;
            if (AvgStopSignRollthrough >= 4f)
                insuranceCosts += 50m;
            if (AvgFollowDistance <= 30f)
                insuranceCosts += 75m;
            if (TimeSinceLastAccident.TotalDays <= 1826)
                insuranceCosts += 100m;

            InsuranceCost = insuranceCosts;
            return insuranceCosts;
        }

        public override string ToString()
        {
            return $"|| {DriverLastName}, {DriverFirstName}\n" +
                $"|| Average speed: {AvgSpeed}\n" +
                $"|| Average G-forces during stopping: {AvgGForce}\n" +
                $"|| Average number of stop sign roll-throughs: {AvgStopSignRollthrough}\n" +
                $"|| Average following distance: {AvgFollowDistance}\n" +
                $"|| Time since last accident: {TimeSinceLastAccident}\n" +
                $"|| Premium: {InsuranceCost}";
        }
    }
}
