using SnakeGame.GameObjects.Points;

namespace SnakeGame.GameObjects.SnakeObject.Contracts
{
    public interface ISnake
    {
        bool IsMoving(Point direction);
    }
}
