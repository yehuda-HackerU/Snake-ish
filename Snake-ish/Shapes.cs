﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Shape
    {
        protected Board board;

        public Shape(Board board)
        {
            this.board = board;
        }
        protected bool ValidShapePositions(List<(int, int)> positions)
        {
            foreach ((int, int) position in positions)
            {
                if (!board.ValidPosition(position))
                {
                    return false;
                }
            }
            return true;
        }
    }


    class Line : Shape
    {
        public Line(Board board) : base(board)
        {
            Create();
        }
        public void Create()
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

            board.AddInvalidPosition(positions);
            foreach ((int x, int y) position in positions)
            {
                board.GameBoard[position.y, position.x] = '=';
            }
        }
    }


    class Square : Shape
    {
        public Square(Board board) : base(board)
        {
            Create();
        }
        public void Create()
        {
            Random rnd = new Random();
            int length = rnd.Next(3, 10);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(Console.WindowWidth - length), rnd.Next(Console.WindowHeight -length / 2));
                positions = new List<(int, int)>();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length / 2; j++)
                    {
                        positions.Add((startPoint.x + i, startPoint.y + j));
                    }
                }
            } while (!ValidShapePositions(positions));

            board.AddInvalidPosition(positions);
            foreach ((int x, int y) position in positions)
            {
                board.GameBoard[position.y, position.x] = '█';
            }
        }
    }


    class Rectangele : Shape
    {
        public Rectangele(Board board) : base(board)
        {
            Create();
        }
        public void Create()
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

            board.AddInvalidPosition(positions);
            foreach ((int x, int y) position in positions)
            {
                board.GameBoard[position.y, position.x] = '▒';
            }
        }
    }


    class Triangle : Shape
    {
        public Triangle(Board board) : base(board)
        {
            Create();
        }
        public void Create()
        {
            Random rnd = new Random();
            int length = rnd.Next(3, 9);
            List<(int x, int y)> positions;

            do
            {
                (int x, int y) startPoint = (rnd.Next(0, Console.WindowWidth - length), rnd.Next(length, Console.WindowHeight - length));
                positions = new List<(int, int)>();
                for (int i = 1; i < length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        positions.Add((startPoint.x + j, startPoint.y + i));
                        positions.Add((startPoint.x - j, startPoint.y + i));
                    }
                }
            } while (!ValidShapePositions(positions));

            board.AddInvalidPosition(positions);
            foreach ((int x, int y) position in positions)
            {
                board.GameBoard[position.y, position.x] = '^';
            }
        }
    }
}