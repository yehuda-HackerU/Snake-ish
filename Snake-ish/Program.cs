﻿using System;
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


            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.ReadKey(true);
        }
    }
}
