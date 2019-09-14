using SnakeGame.GameObjects.Walls;

namespace SnakeGame.GameObjects.FoodPoints.Models
{
    class FoodPercent : Food
    {
        private const int foodPoints = 1;
        private const char foodSymbol = '%';

        public FoodPercent(BorderWall wall)
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
