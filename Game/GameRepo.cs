using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game
{
    class GameRepo
    {//define our lists
        List<City> _cities = new List<City>();
        List<Hazard> _hazards = new List<Hazard>();
        public void BuildCities()
        {
            _cities.Add(new City(1, "Indianapolis, IN", 10, 1, 1, 15, 1));//further city = more gas, rng?
            _cities.Add(new City(2, "Chicago, IL", 190, 8, 1, 180, 8));
            _cities.Add(new City(3, "Detroit, MI", 270, 11, 1, 250, 12));
            _cities.Add(new City(4, "Cincinnati, OH", 130, 8, 1, 125, 7));
            _cities.Add(new City(5, "Columbus, OH", 200, 10, 1, 175, 11));
            _cities.Add(new City(6, "Bloomington, IN", 125, 6, 1, 100, 5));
            _cities.Add(new City(7, "Nashville, TN", 300, 11, 1, 275, 12));
            _cities.Add(new City(8, "Lexington, KY", 100, 5, 1, 90, 5));
            _cities.Add(new City(9, "Springfield, IL", 270, 11, 1, 250, 12));
            _cities.Add(new City(10, "New York, NY", 500, 25, 2, 650, 26));
            _cities.Add(new City(99, "Exit", 0, 0, 0, 0, 0));
        }
        public void BuildHazards()
        {
            _hazards.Add(new Hazard(1, "Construction", 30, 2));
            _hazards.Add(new Hazard(2, "Potholes", 30, 2));
            _hazards.Add(new Hazard(3, "an Accident", 60, 4));
            _hazards.Add(new Hazard(4, "Life is a highway, drive it alllll night long", 0, 0));
            _hazards.Add(new Hazard(5, "Highway to the Danger Zone", 0, 0));
        }
        public List<City> RtnCities()
        {
            return _cities;
        }
        public Hazard GetHazard()
        {
            Random rnd = new Random();
            int hazardNum = rnd.Next(1, _hazards.Count);
            //return rnd.Next(1, 3);
            foreach (Hazard hazInfo in _hazards)
            {
                if (hazardNum == hazInfo.HazardID)
                {
                    return hazInfo;
                }
            }
            return new Hazard();
        }

        public string BuildSorryEnd(int gasLeft, int timeLeft)
        {
            string sorryEnd = "We're sorry.";
            if (gasLeft <= 0)
            {
                sorryEnd = sorryEnd + "  You ran out of gas.";
            }
            else
            {
                sorryEnd = sorryEnd + $"  You have {gasLeft} gallons of gas left.";
            }
            if (timeLeft <= 0)
            {
                sorryEnd = sorryEnd + "  You ran out of time.\n";
            }
            else
            {
                sorryEnd = sorryEnd + $"  You have {timeLeft} minutes left.\n";
            }
            return sorryEnd;
        }
    }
}
