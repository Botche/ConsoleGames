using System;
using System.Linq;
using System.Collections.Generic;

using SnakeGame.GameObjects.Walls;
using SnakeGame.GameObjects.Points;
using SnakeGame.GameObjects.FoodPoints.Models;
using SnakeGame.GameObjects.SnakeObject.Contracts;

namespace SnakeGame.GameObjects.SnakeObject
{
    public class Snake : ISnake
    {
        private const char snakeSymbol = '*';
        private const char emptySpace = ' ';
        private const int snakeLenght = 4;
        private const double scoreMultiplier = 0.1;

        private BorderWall wall;

        private Food[] foods;
        private Queue<Point> SnakeElements;

        private int foodIndex;
        private int RandomFoodNumber =>
            new Random().Next(0, foods.Length);

        private int nextLeftX;
        private int nextTopY;

        public Snake(BorderWall wall)
        {
            this.wall = wall;

            this.SnakeElements = new Queue<Point>();
            this.foods = new Food[3];

            this.foodIndex = RandomFoodNumber;

            this.GetFoods();
            this.CreateSnake();
            Score = 0;

            foods[foodIndex].SetRandomPosition(SnakeElements);
        }

        public int Score { get; private set; }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.SnakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.SnakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.SnakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            Point snakeTail = this.SnakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeNewHead);
            }

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            int leftX = currentSnakeHead.LeftX;
            int topY = currentSnakeHead.TopY;

            CalculateScore();

            GetNextPoint(direction, currentSnakeHead);
            for (int i = 0; i < length; i++)
            {
                var point = new Point(this.nextLeftX, this.nextTopY);
                this.SnakeElements.Enqueue(point);

                point.Draw(snakeSymbol);
                leftX += direction.LeftX;
                topY += direction.TopY;

                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.SnakeElements);
        }

        private void CalculateScore()
        {
            double foodPoints = foods[foodIndex].FoodPoints;
            double scoreBonusFromLength = scoreMultiplier * SnakeElements.Count;

            double scoreEarnedFromThisFood = foodPoints + scoreBonusFromLength;

            int parsedScore = (int)Math.Round(scoreEarnedFromThisFood);

            Score += parsedScore;
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodPercent(wall);
            this.foods[1] = new FoodDollar(wall);
            this.foods[2] = new FoodHash(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= snakeLenght; leftX++)
            {
                Point snakePoint = new Point(leftX, 2);

                this.SnakeElements.Enqueue(snakePoint);

                snakePoint.Draw(snakeSymbol);
            }
        }
    }
}
