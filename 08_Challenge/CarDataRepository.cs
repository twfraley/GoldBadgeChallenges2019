using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    public class CarDataRepository
    {
        CarData _carData = new CarData();
        List<CarData> _cars = new List<CarData>();

        public void AddToList(CarData carData)
        {
            _cars.Add(carData);
        }

        public List<CarData> GetCarData()
        {
            return _cars;
        }

        public bool RemoveCarData(string firstName, string lastName)
        {
            bool success = false;
            foreach (CarData _carData in _cars)
            {
                if (firstName == _carData.DriverFirstName && lastName == _carData.DriverLastName)
                {
                    _cars.Remove(_carData);
                    success = true;
                    break;
                }
            }
            return success;
        }

        //public decimal InsuranceCosts(float avgSpeed, float avgGForce, float avgStopSignRollthrough, float avgFollowDistance, TimeSpan timeSinceLastAccident)
        //{
        //    decimal insuranceCosts = 100m;

        //    if (avgSpeed >= 65)
        //        insuranceCosts += 50m;
        //    if (avgGForce >= 2)
        //        insuranceCosts += 50m;
        //    if (avgStopSignRollthrough >= 4)
        //        insuranceCosts += 50m;
        //    if (avgFollowDistance <= 30)
        //        insuranceCosts += 75m;
        //    if (timeSinceLastAccident.TotalDays <= 1826)
        //        insuranceCosts += 100m;

        //    return insuranceCosts;
        //}
    }
}