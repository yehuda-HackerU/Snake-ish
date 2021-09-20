using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Player
    {
        //private int prevX;
        //private int _x;
        //public int X
        //{
        //    get
        //    {
        //        return _x;
        //    }
        //    set
        //    {

        //        prevX = _x;
        //        _x = value;
        //    }
        //}

        //private int prevY;
        //private int _y;
        //public int Y
        //{
        //    get
        //    {
        //        return _y;
        //    }
        //    set
        //    {
        //        prevY = _y;
        //        _y = value;
        //    }
        //}

        private (int x, int y) prevPlayerPosition;
        private (int x, int y) _playerPosition;
        public (int x, int y) PlayerPosition
        {
            get { return _playerPosition; }
            set
            {
                prevPlayerPosition = _playerPosition;
                _playerPosition = value;
            }
        }
        public int Score { get; set; }

        public void InitializePlayerPosition(Board board)
        {
            Random rnd = new Random();
            (int x, int y) position;

            do
            {
                position = (rnd.Next(Console.WindowWidth), rnd.Next(Console.WindowHeight));
            } while (!board.ValidPosition(position));

            board.AddInvalidPosition(position.x, position.y);
            prevPlayerPosition = position;
            _playerPosition = position;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PlayerPosition.x, PlayerPosition.y);
            Console.Write('*');
            Console.CursorVisible = false;
        }

        public void Move()
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
