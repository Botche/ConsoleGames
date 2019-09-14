using SnakeGame.GameObjects.Walls;

namespace SnakeGame.GameObjects.FoodPoints.Models
{
    public class FoodHash : Food
    {
        private const int foodPoints = 3;
        private const char foodSymbol = '#';

        public FoodHash(BorderWall wall)
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
