using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game
{
    public class City //ctrl D duplicate
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int Distance { get; set; }
        public int GasRequired { get; set; }
        public int PointsGain { get; set; }
        public int TravelMinutes { get; set; } //minutes left
        public int GasOnArrival { get; set; }
        public City()
        {
        }
        public City(int cityID, string cityName, int distance, int gasRequired, int pointsGain, int travelMinutes, int gasOnArrival)
        {
            CityID = cityID;
            CityName = cityName;
            Distance = distance;
            GasRequired = gasRequired;
            PointsGain = pointsGain;
            TravelMinutes = travelMinutes;
            GasOnArrival = gasOnArrival;
        }
    }
    public class Hazard //rng out of 100
    {
        public int HazardID { get; set; }
        public string HazardDesc { get; set; }
        public int CostMinutes { get; set; }
        public int CostGas { get; set; }
        public Hazard()
        {
        }
        public Hazard(int hazardID, string hazardDesc, int costMinutes, int costGas)
        {
            HazardID = hazardID;
            HazardDesc = hazardDesc;
            CostMinutes = costMinutes;
            CostGas = costGas;
        }
    }
}