using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Console;

namespace Snake_ish
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.StartGame();
            //Console.SetCursorPosition(0, 0);
            //Console.Write('0');
            //Console.SetCursorPosition(1, 0);
            //Console.Write('0');
            //Console.SetCursorPosition(1, 1);
            //Console.Write('0');
            //Console.SetCursorPosition(2, 1);
            //Console.Write('0');



            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.ReadKey(true);
        }
    }
}
