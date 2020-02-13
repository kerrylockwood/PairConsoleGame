using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game
{
    class ProgramObstacles
    {
        static void Main(string[] args)
        {
            ProgramUI _ui = new ProgramUI();
            _ui.Run();
        }
    }
    //private static List<string> GetEventsFromFile(string path)
    //{
    //    string text = File.ReadAllText(@"C:\Users\hessj\Desktop\ElevenFifty\PairProgrammingConsoleGame/game-sequence.txt");
    //    return text.Split(',').ToList();
    //}
}