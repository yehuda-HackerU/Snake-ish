using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake_ish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Welcome to Snake-ish game!");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nUse the arrow keys to move (or the W,A,S,D keys...)");
            Console.WriteLine("\npress Q any time to exit...");
            Console.ResetColor();
            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey(true);

            Game myGame = new Game();
            myGame.StartGame();


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\nGame Over!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nTotal score: {myGame.Score}!");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey(true);
        }
    }
}
