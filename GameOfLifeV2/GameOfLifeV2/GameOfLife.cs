using System;
using System.Collections.Generic;

namespace GameOfLifeV2
{
    public class GameOfLife
    {
        private readonly Ecosystem _ecosystem;

        public GameOfLife(Ecosystem ecosystem)
        {
            _ecosystem = ecosystem;
        }

        public List<CellPosition> Play()
        {
            var nextGeneration = _ecosystem.NewGeneration();
            return nextGeneration;
        }
    }
}