using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeKata
{
    public class Ecosystem
    {
        private Dictionary<Position, Cell> _currentGeneration;

        const int MaximumNumberOfNeighbors = 8;

        public Ecosystem()
        {
            _currentGeneration = new Dictionary<Position, Cell>();
        }

        public void AddCell(int positionX, int positionY)
        {
            _currentGeneration.Add(new Position(positionX, positionY), new Cell());
        }

        public void Advance()
        {
            foreach (var cell in _currentGeneration.ToList())
            {
                FindCellNeighbors(cell.Key);
            }

            var nextGeneration = new Dictionary<Position, Cell>();

            foreach (var cell in _currentGeneration)
            {
                var newCell = cell.Value.Evolve();
                nextGeneration.Add(cell.Key, newCell);
            }

            _currentGeneration = nextGeneration.Where(s => s.Value.IsAlive()).ToDictionary(p => p.Key, p => p.Value);
        }

        private void FindCellNeighbors(Position cellPosition, int direction = 0)
        {
            if (direction < MaximumNumberOfNeighbors)
            {
                ShareEnergyWithNeighbors(cellPosition, cellPosition.ToThe((Direction)direction));

                FindCellNeighbors(cellPosition, direction + 1);
            }
        }

        private void ShareEnergyWithNeighbors(Position cellPosition, Position adjacentCellPosition)
        {
            if (_currentGeneration.ContainsKey(adjacentCellPosition) 
                && _currentGeneration[adjacentCellPosition].IsAlive())
            {
                _currentGeneration[cellPosition].AddNeighbour();
            }

            if (_currentGeneration.ContainsKey(adjacentCellPosition)
                && _currentGeneration[adjacentCellPosition].IsDead())
            {
                _currentGeneration[adjacentCellPosition].AddNeighbour();
            }

            if (!_currentGeneration.ContainsKey(adjacentCellPosition))
            {
                _currentGeneration.Add(adjacentCellPosition, new Cell(CellState.Dead));
                _currentGeneration[adjacentCellPosition].AddNeighbour();
            }
        }

        protected bool Equals(Ecosystem other)
        {
            if (this._currentGeneration.Count == other._currentGeneration.Count)
            {
                foreach (var cell in _currentGeneration)
                {
                    if (!other._currentGeneration.ContainsKey(cell.Key))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ecosystem) obj);
        }

        public override int GetHashCode()
        {
            return (_currentGeneration != null ? _currentGeneration.GetHashCode() : 0);
        }
    }
}