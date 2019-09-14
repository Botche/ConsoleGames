using System;
using System.Text;

namespace SnakeGame.Utilities
{
    public static class ConsoleWindow
    {
        // Console Constraits
        static int ConsoleRows = 1 + GameConstraits.GameRows + 1;
        static int ConsoleCols = 1 + GameConstraits.GameCols + 1 
            + 1 + GameConstraits.InfoCols + 1;

        public static void CustomizeConsole()
        {
            Console.Clear();

            Console.Title = "SnakeGame";
            Console.CursorVisible = false;

            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;

            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.OutputEncoding = Encoding.Unicode;
        }
    }
}
