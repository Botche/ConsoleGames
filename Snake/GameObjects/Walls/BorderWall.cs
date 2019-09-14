using System;

using SnakeGame.GameObjects.Points;
using SnakeGame.GameObjects.Walls.Contracts;

namespace SnakeGame.GameObjects.Walls
{
    public class BorderWall : Point, IBorderWall
    {
        public BorderWall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public void InitializeWallBorders()
        {
            Console.SetCursorPosition(0, 0);

            string startLine = "╔";
            startLine += new string('═', this.LeftX);
            startLine += "╗";

            Console.Write(startLine);

            for (int i = 1; i <= this.TopY; i++)
            {
                Console.SetCursorPosition(0, i);

                string middleLine = "║";
                middleLine += new string(' ', this.LeftX);
                middleLine += "║";

                Console.Write(middleLine);
            }

            Console.SetCursorPosition(0, this.TopY + 1);

            string endLine = "╚";
            endLine += new string('═', this.LeftX);
            endLine += "╝";

            Console.Write(endLine);
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                snake.LeftX == this.LeftX + 1 || snake.TopY == this.TopY + 1;
        }
    }
}
