using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Shape
    {
        protected char shapeChar;
        protected ConsoleColor color;
        protected List<(int, int)> positions;

        public Shape()
        {
            
        }
        protected bool ValidShapePositions(List<(int, int)> positions)
        {
            foreach ((int, int) position in positions)
            {
                if (!Board.ValidPosition(position))
                {
                    return false;
                }
            }
            return true;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            foreach ((int x, int y) position in positions)
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.Write(shapeChar);
            }
            Console.ResetColor();
        }
    }


    class Line : Shape
    {
        public Line() 
        {
            shapeChar = '=';
            color = ConsoleColor.Red;
            positions = GeneratePositions();
            Board.AddInvalidPosition(positions);
        }

        private List<(int, int)> GeneratePositions()
        {
            Random rnd = new Random();
            int length = rnd.Next(5, 12);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(0, Console.WindowWidth - length), rnd.Next(Console.WindowHeight));
                positions = new List<(int, int)>();
                for (int i = 0; i < length; i++)
                {
                    positions.Add((startPoint.x + i, startPoint.y));
                }
            } while (!ValidShapePositions(positions));

            return positions;
        }
    }


    class Square : Shape
    {
        public Square() 
        {
            shapeChar = '█';
            color = ConsoleColor.Magenta;
            positions = GeneratePositions();
            Board.AddInvalidPosition(positions);
        }

        private List<(int, int)> GeneratePositions()
        {
            Random rnd = new Random();
            int length = rnd.Next(3, 12);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(Console.WindowWidth - length), rnd.Next(Console.WindowHeight - length / 2));
                positions = new List<(int, int)>();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length / 2; j++)
                    {
                        positions.Add((startPoint.x + i, startPoint.y + j));
                    }
                }
            } while (!ValidShapePositions(positions));

            return positions;
        }
    }


    class Rectangele : Shape
    {
        public Rectangele() 
        {
            shapeChar = '▒';
            color = ConsoleColor.Blue;
            positions = GeneratePositions();
            Board.AddInvalidPosition(positions);
        }
        private List<(int, int)> GeneratePositions()
        {
            Random rnd = new Random();
            int length = rnd.Next(3, 10);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(Console.WindowWidth - length), rnd.Next(Console.WindowHeight - length));
                positions = new List<(int, int)>();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        positions.Add((startPoint.x + i, startPoint.y + j));
                    }
                }
            } while (!ValidShapePositions(positions));

            return positions;
        }
    }


    class Triangle : Shape
    {
        public Triangle() 
        {
            shapeChar = '^';
            color = ConsoleColor.Yellow;
            positions = GeneratePositions();
            Board.AddInvalidPosition(positions);
        }

        private List<(int, int)> GeneratePositions()
        {

            Random rnd = new Random();
            int length = rnd.Next(3, 9);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(0, Console.WindowWidth - length), rnd.Next(length, Console.WindowHeight - length));
                positions = new List<(int, int)>();
                for (int i = 1; i <= length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        positions.Add((startPoint.x + j, startPoint.y + i));
                        positions.Add((startPoint.x - j, startPoint.y + i));
                    }
                }
            } while (!ValidShapePositions(positions));

            return positions;
        }
    }
}
