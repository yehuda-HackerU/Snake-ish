using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    static class Player
    {

        private static (int x, int y) prevPlayerPosition;
        private static (int x, int y) _playerPosition;
        public static (int x, int y) PlayerPosition
        {
            get { return _playerPosition; }
            set
            {
                prevPlayerPosition = _playerPosition;
                _playerPosition = value;
            }
        }

        public static void SetFirstPlayerPosition()
        {
            Random rnd = new Random();
            (int x, int y) position;

            do
            {
                position = (rnd.Next(Console.WindowWidth), rnd.Next(Console.WindowHeight));
            } while (!Board.ValidPosition(position));

            Board.AddInvalidPosition(position);
            prevPlayerPosition = position;
            _playerPosition = position;
        }

        public static void SetPlayerPosition()
        {
            Random rnd = new Random();
            (int x, int y) position;
            int tryes = 0;

            do
            {
                position = (rnd.Next(Console.WindowWidth), rnd.Next(Console.WindowHeight));
                tryes++;
                if (tryes >= 30)
                {
                    throw new StartPointException();
                }
            } while (!Board.ValidPosition(position));

            Board.AddInvalidPosition(position);
            PlayerPosition = position;
        }

        public static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PlayerPosition.x, PlayerPosition.y);
            Console.Write('*');
            Console.CursorVisible = false;
        }

        public static void Move()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(prevPlayerPosition.x, prevPlayerPosition.y);
            Console.Write('*');
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PlayerPosition.x, PlayerPosition.y);
            Console.Write('*');
            Console.CursorVisible = false;
        }


    }
}
