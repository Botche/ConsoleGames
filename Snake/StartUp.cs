using SnakeGame.Core;
using SnakeGame.Utilities;
using SnakeGame.GameObjects.Walls;
using SnakeGame.GameObjects.SnakeObject;

namespace SnakeGame
{
    class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            BorderWall wall = new BorderWall(GameConstraits.GameCols, GameConstraits.GameRows);
            InfoWall infoWall = new InfoWall(GameConstraits.InfoCols, GameConstraits.InfoRows);

            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, infoWall, snake);
            engine.Run();
        }
    }
}
