using System;
using System.Collections.Generic;

namespace Tetris.GameModels
{
    public class TetrisObjects
    {
        public TetrisObjects()
        {
            TetrisFigures = new List<bool[,]>()
            {
                new bool[,] // ----
                {
                    { true, true, true, true }
                },
                new bool[,] // O
                {
                    { true, true },
                    { true, true }
                },
                new bool[,] // T
                {
                    { false, true, false },
                    { true, true, true },
                },
                new bool[,] // S
                {
                    { false, true, true, },
                    { true, true, false, },
                },
                new bool[,] // Z
                {
                    { true, true, false },
                    { false, true, true },
                },
                new bool[,] // J
                {
                    { true, false, false },
                    { true, true, true }
                },
                new bool[,] // L
                {
                    { false, false, true },
                    { true, true, true }
                },
            };
        }

        public List<bool[,]> TetrisFigures { get; set; }

        public int Count => TetrisFigures.Count;

        public bool[,] GetCurrentFigure()
        {
            var random = new Random();

            return this.TetrisFigures[random.Next(0, this.Count)];
        }
    }
}
