using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Board
    {
        public char[,] GameBoard;
        private List<(int, int)> InvalidPositions = new List<(int, int)>();

        public Board()
        {
            GameBoard = new char[Console.WindowHeight, Console.WindowWidth];
            for (int y = 0; y < GameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < GameBoard.GetLength(1); x++)
                {
                    GameBoard[y, x] = ' ';
                }
            }
        }

        public bool ValidPosition((int x, int y) position)
        {
            int x = position.x;
            int y = position.y;
            if (x < 0 || y < 0 || x >= Console.WindowWidth || y >= Console.WindowHeight)
            {
                return false;
            }
            return !InvalidPositions.Contains(position);
        }

        public void AddInvalidPosition(int x, int y)
        {
            InvalidPositions.Add((x, y));
        }

        public void AddInvalidPosition(List<(int, int)> positions)
        {
            InvalidPositions.AddRange(positions);
        }

        public void Draw()
        {
            for (int y = 0; y < GameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < GameBoard.GetLength(1); x++)
                {
                    Console.Write(GameBoard[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
