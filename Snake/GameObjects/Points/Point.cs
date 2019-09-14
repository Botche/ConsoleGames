using System;

using SnakeGame.Exceptions;
using SnakeGame.GameObjects.Points.Contracts;

namespace SnakeGame.GameObjects.Points
{
    public class Point : Contracts.Point
    {
        private int leftX;
        private int topY;

        public Point(int lextX, int topY)
        {
            LeftX = lextX;
            TopY = topY;
        }

        public int LeftX
        {
            get => leftX;
            set
            {
                leftX = value;
            }
        }
        public int TopY
        {
            get => topY;
            set
            {
                topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
