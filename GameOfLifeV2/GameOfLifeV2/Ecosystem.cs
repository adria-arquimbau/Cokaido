using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace GameOfLifeV2
{
    public class Ecosystem
    {
        private List<CellPosition> _currentGeneration = new List<CellPosition>();
        private const int MinNeighborsToSurvive = 2;
        private const int MaxNeighborsToSurviveAndCellsToStart = 3;

        public void NewGeneration()
        {   
            var nextGeneration = new List<CellPosition>();
            var allNeighbors = new List<CellPosition>();

            if (_currentGeneration.Count < MaxNeighborsToSurviveAndCellsToStart)
                throw new Exception("Game of Life ended, you need more than 3 cells of current generation to continue");

            foreach (var cell in _currentGeneration)
            {
                GetSurvivedCellsToNextGeneration(cell, nextGeneration);
                var cellNeighbors = cell.GetNeighbors();

                foreach (var neighbor in cellNeighbors)
                {
                    if(!allNeighbors.Contains(neighbor) && !_currentGeneration.Contains(neighbor))
                        allNeighbors.Add(neighbor);
                }
            }

            foreach (var neighbor in allNeighbors)
            {
                var neighborsOfNeighbor = neighbor.GetNeighbors();
                var neighborsCount = 0;

                foreach (var neighborOfNeighbor in neighborsOfNeighbor)
                {
                    if (_currentGeneration.Contains(neighborOfNeighbor)) neighborsCount++;
                }

                if (neighborsCount == 3) nextGeneration.Add(neighbor);
            }


            _currentGeneration = nextGeneration;
        }

        private void GetSurvivedCellsToNextGeneration(CellPosition cell, List<CellPosition> nextGeneration)
        {
            var cellNeighbors = cell.GetNeighbors();
            var neighborsCount = 0;
            
            foreach (var neighbor in cellNeighbors)
            {
                neighborsCount = IfNeighborIsOnCurrentGenerationPlusOneNeighborsCount(neighbor, neighborsCount);
            }

            if (neighborsCount == MinNeighborsToSurvive || neighborsCount == MaxNeighborsToSurviveAndCellsToStart) nextGeneration.Add(cell);
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