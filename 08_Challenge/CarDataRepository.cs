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

    }
}