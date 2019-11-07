using System.Collections.Generic;

namespace GameOfLifeV2
{
    public class Ecosystem
    {
        private Dictionary<CellPosition, Cell> _currentGeneration;

        public void AddCell(int positionX, int positionY)
        {
            _currentGeneration.Add(new CellPosition(positionX, positionY), new Cell());
        }

        public void NewGeneration()
        {
            
        }
    }
}