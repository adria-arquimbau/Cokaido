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
        private const int MaxNeighborsToSurviveAndCellsToStartAndNeighborsToRevive = 3;

        public Ecosystem(List<CellPosition> generation)
        {
            foreach (var cell in generation)
            {
               AddCell(cell);
            }
        }

        public Ecosystem()
        {
        }

        public Ecosystem NewGeneration()
        {   
            var nextGeneration = new List<CellPosition>();
            var allNeighbors = new List<CellPosition>();

            if (_currentGeneration.Count < MaxNeighborsToSurviveAndCellsToStartAndNeighborsToRevive)
                throw new Exception("Game of Life ended, you need more than 3 cells of current generation to continue");

            foreach (var cell in _currentGeneration)
            {
                GetSurvivedCellsToNextGeneration(cell, nextGeneration);
                GetAllNeighbors(cell, allNeighbors);
            }

            foreach (var neighbor in allNeighbors)
            {
                GetRevivedCells(neighbor, nextGeneration);
            }

            _currentGeneration = nextGeneration;
            return new Ecosystem(_currentGeneration);
        }

        private void GetRevivedCells(CellPosition neighbor, List<CellPosition> nextGeneration)
        {
            var neighborsOfNeighbor = neighbor.GetNeighbors();
            var neighborsCount = 0;

            foreach (var neighborOfNeighbor in neighborsOfNeighbor)
            {
                neighborsCount = NeighborsCountPlusOneIfNeighborOfNeighborsIsOnCurrentGeneration(neighborOfNeighbor, neighborsCount);
            }

            if (neighborsCount == MaxNeighborsToSurviveAndCellsToStartAndNeighborsToRevive) nextGeneration.Add(neighbor);
        }

        private int NeighborsCountPlusOneIfNeighborOfNeighborsIsOnCurrentGeneration(CellPosition neighborOfNeighbor,
            int neighborsCount)
        {
            if (_currentGeneration.Contains(neighborOfNeighbor)) neighborsCount++;
            return neighborsCount;
        }

        private void GetAllNeighbors(CellPosition cell, List<CellPosition> allNeighbors)
        {
            var cellNeighbors = cell.GetNeighbors();
            foreach (var neighbor in cellNeighbors)
            {
                AddNeighborToAllNeighbors(allNeighbors, neighbor);
            }
        }

        private void AddNeighborToAllNeighbors(List<CellPosition> allNeighbors, CellPosition neighbor)
        {
            if (!allNeighbors.Contains(neighbor) && !_currentGeneration.Contains(neighbor))
                allNeighbors.Add(neighbor);
        }

        private void GetSurvivedCellsToNextGeneration(CellPosition cell, List<CellPosition> nextGeneration)
        {
            var cellNeighbors = cell.GetNeighbors();
            var neighborsCount = 0;
            
            foreach (var neighbor in cellNeighbors)
            {
                neighborsCount = IfNeighborIsOnCurrentGenerationPlusOneNeighborsCount(neighbor, neighborsCount);
            }

            if (neighborsCount == MinNeighborsToSurvive || neighborsCount == MaxNeighborsToSurviveAndCellsToStartAndNeighborsToRevive) nextGeneration.Add(cell);
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

        private void AddCell(CellPosition cell)
        {
            _currentGeneration.Add(cell);
        }

        protected bool Equals(Ecosystem other)
        {
            if (this._currentGeneration.Count != other._currentGeneration.Count)
                return false;

            return _currentGeneration.All(cell => other._currentGeneration.Contains(cell));
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