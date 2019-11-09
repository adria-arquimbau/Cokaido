using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace GameOfLifeV2
{
    public class Ecosystem
    {
        private List<CellPosition> _currentGeneration = new List<CellPosition>();
        private const int MinCellsToSurvive = 2;
        private const int MaxCellsToSurvive = 3;
        private int _neighborsCount = 0;

        public void NewGeneration()
        {   
            var nextGeneration = new List<CellPosition>();

            if (_currentGeneration.Count == 0 || _currentGeneration.Count == 1 || _currentGeneration.Count == 2)
                throw new Exception();

            foreach (var cell in _currentGeneration)
                GetSurvivedCellsToNextGeneration(cell, nextGeneration);
            
            _currentGeneration = nextGeneration;
        }

        private void GetSurvivedCellsToNextGeneration(CellPosition cell, List<CellPosition> nextGeneration)
        {
            var cellNeighbors = cell.GetNeighbors();
            
            foreach (var neighbor in cellNeighbors)
            {
                _neighborsCount = IfNeighborIsOnCurrentGenerationPlusOneNeighborsCount(neighbor, _neighborsCount);
            }

            if (_neighborsCount == MinCellsToSurvive || _neighborsCount == MaxCellsToSurvive) nextGeneration.Add(cell);
        }

        private int IfNeighborIsOnCurrentGenerationPlusOneNeighborsCount(CellPosition neighbor, int neighborsCount)
        {
            if (_currentGeneration.Contains(neighbor)) neighborsCount++;
            return neighborsCount;
        }

        public void AddCell(int positionX, int positionY)
        {
            _currentGeneration.Add(new CellPosition(positionX, positionY));
        }

        protected bool Equals(Ecosystem other)
        {
            return _currentGeneration.SequenceEqual(other._currentGeneration);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ecosystem)obj);
        }

        public override int GetHashCode()
        {
            return (_currentGeneration != null ? _currentGeneration.GetHashCode() : 0);
        }
    }
}