using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Player
    {
        private int prevX;
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {

                prevX = _x;
                _x = value;
            }
        }

        private int prevY;
        private int _y;
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                prevY = _y;
                _y = value;
            }
        }
        public int Score {get; set;}

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(_x, _y);
            Console.CursorVisible = false;
            Console.Write('*');
        }

        public void Move()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (_x != prevX)
            {
                Console.SetCursorPosition(prevX, _y);
                Console.CursorVisible = false;
            }
            else if (_y != prevY)
            {
                Console.SetCursorPosition(_x, prevY);
                Console.CursorVisible = false;
            }
            Console.Write('*');
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X, Y);
            Console.Write('*');

        }


    }
}
