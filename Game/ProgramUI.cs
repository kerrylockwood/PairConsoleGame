using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Game
{
    public class ProgramUI
    {
        private readonly GameRepo _gameRepo = new GameRepo();
        public void Run()
        {
            _gameRepo.BuildCities();
            _gameRepo.BuildHazards();
            StartYourEngine();
        }
        private void StartYourEngine()
        {
            int timeLeft = 1000;
            int callAAALeft = 3;//never used
            int gasLeft = 50;
            //int distTraveled = 0;
            int points = 0;
            string startingCity = "Fishers, IN";
            //string cityPrompt;
            List<City> cities = new List<City>();
            cities = _gameRepo.RtnCities();
            string cityPromptStr = "What City do you want to go to?\n";
            foreach (City cityInfo in cities)
            {
                cityPromptStr += $"  {cityInfo.CityID}. {cityInfo.CityName}\n";
            }
            while (gasLeft > 0 && callAAALeft > 0 && timeLeft > 0)
            {
                City FndCityInfo = new City();
                int selection;
                string answer = "";
                // get City
                bool leaveLoop = false;
                while (!leaveLoop)
                {
                    Console.Write($"You have {gasLeft} gallons of gas.\n" +
                        $"You have {timeLeft} minutes to travel.\n" +
                        $"You're current points are {points}.\n" +
                        $"You are starting from {startingCity}.\n" +
                        $"=======================================\n" +
                        $"{cityPromptStr}");
                    answer = Console.ReadLine();
                    if (String.IsNullOrEmpty(answer) || !int.TryParse(answer, out selection))
                    {
                        Console.WriteLine($"Please select an option.\n" +
                            $" Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    foreach (City cityInfo in cities)
                    {
                        if (selection == cityInfo.CityID)
                        {
                            leaveLoop = true;
                            FndCityInfo = cityInfo;
                            break;
                        }
                    }
                    if (String.IsNullOrEmpty(FndCityInfo.CityName))
                    {
                        Console.WriteLine($"'{selection}' is an invalid option.\n" +
                            $" Press any key to continue");
                        Console.ReadKey();
                    }
                    else if (startingCity == FndCityInfo.CityName)
                    {
                        leaveLoop = false;
                        Console.WriteLine($"You are already in {startingCity}.  Please select another city.\n Press any key to continue");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }   //WHILE loop

                // Leave program?
                if (FndCityInfo.CityName == "Exit")
                {
                    Console.WriteLine($"Thanks for playing!\n" +
                        $"You've scored {points} points.\n" +
                        $"Press any key to continue");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine($"You have chosen to go to {FndCityInfo.CityName}");

                // get Hazzard
                Hazard hazInfo = _gameRepo.GetHazard();
                while (answer != "c" && answer != "r")
                {
                    answer = "";
                    if (hazInfo.CostMinutes == 0 && hazInfo.CostGas == 0)
                    { 
                        Console.WriteLine($"{hazInfo.HazardDesc}.");
                    }
                    else
                    {
                        Console.WriteLine($"You ran into {hazInfo.HazardDesc}.");
                        Console.WriteLine($"This will cost you {hazInfo.CostMinutes} minutes and {hazInfo.CostGas} gallons of gas.\n\n");
                    }
                    Console.WriteLine($"\nDo you want to continue on to {FndCityInfo.CityName} or do you want to return to {startingCity} to save time and gas?\n" +
                        $"Enter C to contunue to {FndCityInfo.CityName}\n" +
                        $"   or R to return to {startingCity}");
                    answer = Console.ReadLine().ToLower();
                    Console.Clear();
                }
                if (answer == "r")
                {
                    gasLeft = gasLeft - (FndCityInfo.GasRequired / 2);
                    timeLeft = timeLeft - (FndCityInfo.TravelMinutes / 2);
                    if (gasLeft <= 0 || timeLeft <= 0)
                    {
                        string sorryEnd = _gameRepo.BuildSorryEnd(gasLeft, timeLeft);
                        Console.WriteLine(sorryEnd);
                        Console.WriteLine($"Game over.....\n" +
                            $"You've scored {points} points." +
                            $"\n\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Returning to {startingCity}.\n" +
                            $"This will cost you {FndCityInfo.GasRequired / 2} gallons of gas and {FndCityInfo.TravelMinutes / 2} minutes.\n" +
                            $"You now have {gasLeft} gallons of gas and {timeLeft} minutes remaining.\n" +
                            $"Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    continue;
                }

                // Calc gas and time remaining
                gasLeft = gasLeft - hazInfo.CostGas;
                timeLeft = timeLeft - hazInfo.CostMinutes;
                if (gasLeft <= 0 || timeLeft <= 0)
                {
                    string sorryEnd = _gameRepo.BuildSorryEnd(gasLeft, timeLeft);
                    Console.WriteLine(sorryEnd);
                    Console.WriteLine($"Game over.....\n" +
                        $"You've scored {points} points." +
                        $"\n\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }
                gasLeft = gasLeft - FndCityInfo.GasRequired + FndCityInfo.GasOnArrival;
                timeLeft = timeLeft - FndCityInfo.TravelMinutes;
                // Out of time or gas?
                if (gasLeft <= 0 || timeLeft <= 0)
                {
                    string sorryEnd = _gameRepo.BuildSorryEnd(gasLeft, timeLeft);
                    Console.WriteLine(sorryEnd);
                    Console.WriteLine($"Game over.....\n" +
                        $"You've scored {points} points." +
                        $"\n\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }

                //moving car
                for (int x = 1;  x <= 1+(FndCityInfo.Distance / 10); x++)
                {
                    Console.Clear();
                    Console.Write("\n\n\n\n\n");
                    Console.Write(new String(' ', x));
                    Console.WriteLine(@"  ___");
                    Console.Write(new String(' ', x));
                    Console.WriteLine(@"    _-_-  _/\______\\__");
                    Console.Write(new String(' ', x));
                    Console.WriteLine(@" _-_-__  / ,-. -|-  ,-.`-.");
                    Console.Write(new String(' ', x));
                    Console.WriteLine(@"    _-_- `( o )----( o )-'");
                    Console.Write(new String(' ', x));
                    Console.WriteLine(@"           `-'      `-'");
                    Thread.Sleep(125);
                }
                Thread.Sleep(1000);
                Console.Clear();

                // Accumulate Points
                points = points + FndCityInfo.PointsGain;

                // User want to continue?
                Console.WriteLine($"\nCongratulations! you have just arrived at {FndCityInfo.CityName}.\n" +
                    $"You have just refueled with {FndCityInfo.GasOnArrival} gallons of gas.\n" +
                    $"You have {gasLeft} gallons of gas left and {timeLeft} minutes left\n" +
                    $"Your new points are {points}.");

                while (answer != "y" && answer != "n")
                {
                    answer = "";
                    Console.Write($"Do you want to continue? (Y or N) ");
                    answer = Console.ReadLine().ToLower();
                    Console.Clear();
                }
                if (answer == "n")
                {
                    Console.WriteLine($"Thanks for playing!\n" +
                        $"You've scored {points} points.\n" +
                        $"Press any key to continue");
                    Console.ReadKey();
                    break;
                }

                // Save Starting city
                startingCity = FndCityInfo.CityName;

            }  //end WHILE
        }
    }
}