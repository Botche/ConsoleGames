using SnakeGame.GameObjects.Points;
using System.Collections.Generic;

namespace SnakeGame.GameObjects.FoodPoints.Contracts
{
    public interface IFood
    {
        int FoodPoints { get; }

        void SetRandomPosition(Queue<Point> snakeElements);

        bool IsFoodPoint(Point snake);
    }
}
