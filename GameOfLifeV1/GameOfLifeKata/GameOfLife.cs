using System;
using System.Collections.Generic;

namespace GameOfLifeChallenge
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

            if (_currentGeneration.Count < 3)
                return null;

            var newCells = new List<CellPosition>();
            var allNeighbors = new List<CellPosition>();

            foreach (var cell in _currentGeneration)
            {
                var neighborsList = cell.GetNeighbors();

                foreach (var neighbor in neighborsList)
                {
                    if (!allNeighbors.Contains(neighbor)) allNeighbors.Add(neighbor);
                }

                var aliveNeighbors = 0;

                foreach (var neighborPosition in neighborsList)
                {
                    if (_currentGeneration.Contains(neighborPosition))
                        aliveNeighbors++;
                }

                var numberOfAliveAndDeadNeighbors = aliveNeighbors;

                List<CellPosition> newCells1 = new List<CellPosition>();

                if (numberOfAliveAndDeadNeighbors == 2 || numberOfAliveAndDeadNeighbors == 3)
                {
                    newCells1.Add(cell);
                }

                newCells.AddRange(newCells1);
            }

            foreach (var neighbor1 in allNeighbors)
            {
                if (!_currentGeneration.Contains(neighbor1))
                {
                    var neighborList = neighbor1.GetNeighbors();

                    var aliveNeighbors = 0;

                    foreach (var neighborPosition in neighborList)
                    {
                        if (_currentGeneration.Contains(neighborPosition))
                            aliveNeighbors++;
                    }

                    var numberOfAliveAndDeadNeighbors1 = aliveNeighbors;

                    List<CellPosition> newCells1 = new List<CellPosition>();

                    if (numberOfAliveAndDeadNeighbors1 == 3)
                    {
                        newCells1.Add(neighbor1);
                    }

                    newCells.AddRange(newCells1);
                }
            }

            return newCells;
        }
    }   
}