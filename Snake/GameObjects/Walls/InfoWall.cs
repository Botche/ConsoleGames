using System;

using SnakeGame.GameObjects.Points;

namespace SnakeGame.GameObjects.Walls
{
    public class InfoWall : Point
    {
        public InfoWall(int leftX, int topY)
              : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public void InitializeWallBorders()
        {
            Console.SetCursorPosition(GameConstraits.GameCols + 2, 0);

            string startLine = "╔";
            startLine += new string('═', this.LeftX);
            startLine += "╗";

            Console.Write(startLine);

            for (int row = 1; row <= this.TopY; row++)
            {
                Console.SetCursorPosition(GameConstraits.GameCols + 2, row);

                string middleLine = "║";
                middleLine += new string(' ', this.LeftX);
                middleLine += "║";

                Console.Write(middleLine);
            }

            Console.SetCursorPosition(GameConstraits.GameCols + 2, TopY + 1);

            string endLine = "╚";
            endLine += new string('═', this.LeftX);
            endLine += "╝";

            Console.Write(endLine);
        }
    }
}
