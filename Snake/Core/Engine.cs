using System;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

using SnakeGame.Enums;
using SnakeGame.Core.Contracts;
using SnakeGame.GameObjects.Walls;
using SnakeGame.GameObjects.Points;
using SnakeGame.GameObjects.SnakeObject;

namespace SnakeGame.Core
{
    public class Engine : IEngine
    {
        private const Direction defaultSnakeDirection = Direction.Right;
        private const string scoresFileName = "../../../Scores.txt";

        private int highScore = 0;

        private Direction snakeDirection;

        private Snake snake;
        private BorderWall wall;
        private InfoWall infoWall;
        private Point[] pointsOfDirection;

        public Engine(BorderWall wall, InfoWall infoWall, Snake snake)
        {
            this.snake = snake;
            this.wall = wall;
            this.infoWall = infoWall;
            pointsOfDirection = new Point[4];

            snakeDirection = defaultSnakeDirection;
        }

        public void Run()
        {
            double sleepTime = 200;
            this.CreateDirection();

            highScore = DisplayHighscore(scoresFileName, highScore);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake
                    .IsMoving(this.pointsOfDirection[(int)snakeDirection]);
                // TODO Save score after press Y
                SetsInfo(snake, highScore);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                if (sleepTime>20)
                {
                    sleepTime -= 0.001;
                }

                Thread.Sleep((int)sleepTime);
            }
        }
        private static void SetsInfo(Snake snake, int highScore)
        {
            int scoreRow = 3;
            int scoreColIncresment = 7;

            Console.SetCursorPosition(GameConstraits.GameCols + scoreColIncresment, scoreRow);
            Console.Write($"Score: {snake.Score}");

            int highScoreRow = 5;
            int highScoreColIncresment = 5;

            Console.SetCursorPosition(GameConstraits.GameCols + highScoreColIncresment, highScoreRow);
            if (snake.Score <= highScore)
            {
                Console.Write($"Highscore: {highScore}");
            }
            else
            {
                Console.Write($"Highscore: {snake.Score}");
            }
        }

        private void AskUserForRestart()
        {
            int row = 7;
            int col = 5;
            Write("Would you like", row, col);

            col += 4;
            row++;
            Write("to continue?", row, col);

            col += 2;
            row++;
            Write("Y/N", row, col);

            Console.SetCursorPosition(col, row + 1);
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                SaveScore();
                Console.Clear();
                Game.Main();
            }
            else
            {
                StopGame();
            }
        }

        private static int DisplayHighscore(string scoresFileName, int highScore)
        {
            if (!File.Exists(scoresFileName))
            {
                File.Create(scoresFileName);
            }

            if (File.Exists(scoresFileName))
            {
                var allScores = File.ReadAllLines(scoresFileName);

                foreach (var score in allScores)
                {
                    var match = Regex.Match(score, @" => (?<score>[0-9]+)");
                    highScore = Math.Max(highScore, int.Parse(match.Groups["score"].Value));
                }
            }

            return highScore;
        }

        private void StopGame()
        {
            Console.Clear();

            wall.InitializeWallBorders();
            infoWall.InitializeWallBorders();
            SetsInfo(snake, highScore);

            SaveScore();
            PrintMessageForNewHighScore();

            GameOver();

            Thread.Sleep(1000000);
            Environment.Exit(0);
        }

        private void SaveScore()
        {
            File.AppendAllLines(scoresFileName,
                            new string[] {
                    $"[{DateTime.Now.ToString()}] {Environment.UserName} => {snake.Score}"
                            });
        }

        private void PrintMessageForNewHighScore()
        {
            if (snake.Score > highScore)
            {
                int row = 2;
                int col = 7;

                Write("Congrats for", row, col);
                Write("new Highscore!!!", ++row, --col);
            }
        }

        private static void GameOver()
        {
            int row = 4;
            int col = 7;

            Write("╔═════════╗", ++row, col);
            Write("║ Game    ║", ++row, col);
            Write("║   over! ║", ++row, col);
            Write("╚═════════╝", ++row, col);
        }

        private static void Write(string line, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(line);
        }

        private void CreateDirection()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
            {
                if (snakeDirection != Direction.Right)
                {
                    snakeDirection = Direction.Left;
                }
            }
            else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
            {
                if (snakeDirection != Direction.Left)
                {
                    snakeDirection = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
            {
                if (snakeDirection != Direction.Up)
                {
                    snakeDirection = Direction.Down;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
            {
                if (snakeDirection != Direction.Down)
                {
                    snakeDirection = Direction.Up;
                }
            }
            Console.CursorVisible = false;
        }
    }
}