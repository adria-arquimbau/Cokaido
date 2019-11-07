using System;
using System.Collections.Generic;

namespace GameOfLifeV2
{
    public class GameOfLife
    {
        private List<CellPosition> _currentGeneration;

        public GameOfLife(List<CellPosition> currentGeneration)
        {
            _currentGeneration = currentGeneration;
        }

        public List<CellPosition> Play()
        {
            if (_currentGeneration.Count == 0)
                throw new Exception();

            return null;
        }
    }
}