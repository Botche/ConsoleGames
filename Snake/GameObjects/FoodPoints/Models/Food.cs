using System;
using System.Linq;
using System.Collections.Generic;

using SnakeGame.GameObjects.FoodPoints.Contracts;
using SnakeGame.GameObjects.Points;
using SnakeGame.GameObjects.Walls;

namespace SnakeGame.GameObjects.FoodPoints.Models
{
    public abstract class Food : Point, IFood
    {
        private BorderWall wall;
        private Random random;
        private char foodSymbol;

        protected Food(BorderWall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
