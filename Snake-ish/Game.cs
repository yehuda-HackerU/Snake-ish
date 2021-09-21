using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ish
{
    class Game
    {
        public int Score { get; set; }
        private int shapesCount = new Random().Next(3, 7);

        public void StartGame()
        {
            Console.Title = "Snake-ish";
            Console.Clear();

            Player.SetFirstPlayerPosition();

            while (shapesCount < 15)
            {
                Board.DrawFrame();
                Player.Draw();
                SetBoard();

                try
                {
                    Run();
                }
                catch (EndGameException)
                {
                    break;
                }
                shapesCount++;
                Console.Clear();
                Board.ResetInvalidPositions();
                if (shapesCount < 15)
                {
                    NextLevel();
                }
                Player.SetPlayerPosition();
            }
        }

        public void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            (int x, int y) position = Player.PlayerPosition;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (!Board.ValidPosition((position.x, position.y - 1)))
                    {
                        throw new PositionException();
                    }
                    position.y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (!Board.ValidPosition((position.x, position.y + 1)))
                    {
                        throw new PositionException();
                    }
                    position.y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (!Board.ValidPosition((position.x - 1, position.y)))
                    {
                        throw new PositionException();
                    }
                    position.x -= 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (!Board.ValidPosition((position.x + 1, position.y)))
                    {
                        throw new PositionException();
                    }
                    position.x += 1;
                    break;
                case ConsoleKey.Q:
                    throw new EndGameException();
                default:
                    break;
            }
            Player.PlayerPosition = position;
            Score++;
            Board.AddInvalidPosition(Player.PlayerPosition);
            Player.Move();
        }

        private void SetBoard()
        {
            Random rnd = new Random();

            for (int i = 0; i < shapesCount; i++)
            {
                int shapeChoise = rnd.Next(4);
                switch (shapeChoise)
                {
                    case 0:
                        new Line().Draw();
                        break;
                    case 1:
                        new Square().Draw();
                        break;
                    case 2:
                        new Rectangele().Draw();
                        break;
                    case 3:
                        new Triangle().Draw();
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
                    break;
                }

                System.Threading.Thread.Sleep(0);
            }
        }

        private void NextLevel()
        {
            Console.WriteLine("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nYour score is: {Score}!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\nYou have {15 - shapesCount} more levels!");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}

