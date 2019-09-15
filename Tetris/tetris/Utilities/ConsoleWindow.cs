using System;

namespace Tetris.Utilities
{
    public static class ConsoleWindow
    {
        // Settings
        static int ConsoleRows = 1 + GameConstraits.TetrisRows + 1;
        static int ConsoleCols = 1 + GameConstraits.TetrisCols + 1 + GameConstraits.InfoCols + 1;

        public static void SetGameSettings()
        {
            Console.Title = "Tetris v1.0";
            Console.CursorVisible = false;
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
        }
    }
}
