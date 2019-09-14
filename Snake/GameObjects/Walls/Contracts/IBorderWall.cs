using SnakeGame.GameObjects.Points;

namespace SnakeGame.GameObjects.Walls.Contracts
{
    public interface IBorderWall
    {
        void InitializeWallBorders();

        bool IsPointOfWall(Point snake);
    }
}
