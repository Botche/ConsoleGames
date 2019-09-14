using SnakeGame.GameObjects.Walls;

namespace SnakeGame.GameObjects.FoodPoints.Models
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 2;

        public FoodDollar(BorderWall wall) 
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
