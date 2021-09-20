using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Game
    {
        private Board board;
        private Player player;

        public void StartGame()
        {
            //random start point, if after 30 times can't start trow exc.
            player = new Player();
            board = new Board();

            Console.Title = "Snake-ish";
            InitializeBoard();

            player.InitializePlayerPosition(board);
            player.Draw();

            Run();
        }

        public void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            (int x, int y) position = player.PlayerPosition;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (!board.ValidPosition((position.x, position.y - 1)))
                    {
                        throw new PositionException();
                    }
                    position.y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (!board.ValidPosition((position.x, position.y + 1)))
                    {
                        throw new PositionException();
                    }
                    position.y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (!board.ValidPosition((position.x - 1, position.y)))
                    {
                        throw new PositionException();
                    }
                    position.x -= 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (!board.ValidPosition((position.x + 1, position.y)))
                    {
                        throw new PositionException();
                    }
                    position.x += 1;
                    break;
                default:
                    break;
            }
            player.PlayerPosition = position;
            player.Score++;
            board.AddInvalidPosition(player.PlayerPosition.x, player.PlayerPosition.y);
            player.Move();
        }

        private void InitializeBoard()
        {
            Random rnd = new Random();
            int shapesCount = rnd.Next(3, 7);
            for (int i = 0; i < shapesCount; i++)
            {
                int shapeChoise = rnd.Next(4);
                switch (shapeChoise)
                {
                    case 0:
                        new Line(board).Draw();
                        break;
                    case 1:
                        new Square(board).Draw();
                        break;
                    case 2:
                        new Rectangele(board).Draw();
                        break;
                    case 3:
                        new Triangle(board).Draw();
                        break;
                }
            }
        }

        private void Run()
        {
            while (true)
            {
                try
                {
                    PlayerInput();
                }
                catch (PositionException)
                {
                    //fail += 1
                    break;
                }

                System.Threading.Thread.Sleep(0);
            }
        }
    }
}

