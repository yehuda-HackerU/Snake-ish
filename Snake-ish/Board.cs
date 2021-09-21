using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    static class Board
    {
        private static List<(int, int)> InvalidPositions = new List<(int, int)>();
        private static List<(int, int)> BoardFrame = CreateBoardFrame();

        static private List<(int, int)> CreateBoardFrame()
        {
            List<(int, int)> frame = new List<(int, int)>();

            for (int x = 0; x < Console.WindowWidth ; x++)
            {
                frame.Add((x, 0));
                frame.Add((x, Console.WindowHeight - 1));
            }
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                frame.Add((0, y));
                frame.Add((Console.WindowWidth - 1, y));
            }

            AddInvalidPosition(frame);
            return frame;
        }

        static public void DrawFrame()
        {
            foreach ((int x, int y) position in BoardFrame)
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write('#');
            }
            Console.ResetColor();
        }

        static public bool ValidPosition((int x, int y) position)
        {
            int x = position.x;
            int y = position.y;
            if (x < 0 || y < 0 || x >= Console.WindowWidth || y >= Console.WindowHeight)
            {
                return false;
            }
            return !InvalidPositions.Contains(position);
        }

        public static void AddInvalidPosition((int, int) position)
        {
            InvalidPositions.Add(position);
        }

        public static void AddInvalidPosition(List<(int, int)> positions)
        {
            InvalidPositions.AddRange(positions);
        }

        public static void ResetInvalidPositions()
        {
            InvalidPositions.Clear();
            InvalidPositions.AddRange(BoardFrame);
        }
    }
}
