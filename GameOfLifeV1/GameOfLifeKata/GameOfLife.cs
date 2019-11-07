using System;
using System.Collections.Generic;

namespace GameOfLifeChallenge
{
    public class GameOfLife
    {
        private List<CellPosition> _initialCells;

        public GameOfLife(List<CellPosition> initialCells)
        {
            _initialCells = initialCells;
        }
        public List<CellPosition> Play()
        {
            if (_initialCells.Count == 0)
                throw new Exception();

            if (_initialCells.Count < 3)
                return null;

            var newCells = new List<CellPosition>();
            var allNeighbors = new List<CellPosition>();
            
            AddSurvivedCellsToNewCells(allNeighbors, newCells);

            AddRevivedCellsToNewCells(allNeighbors, newCells);
            
            return newCells;
        }
        
        private void AddSurvivedCellsToNewCells(List<CellPosition> allNeighbors, List<CellPosition> newCells)
        {
            foreach (var cell in _initialCells)
            {
                var neighborsList = cell.GetNeighbors();

                foreach (var neighbor in neighborsList)
                {
                    if (!allNeighbors.Contains(neighbor)) allNeighbors.Add(neighbor);
                }

                var numberOfAliveAndDeadNeighbors = GetAliveAndDeadNeighbors(neighborsList, _initialCells);

                newCells.AddRange(GetSurvivedCells(numberOfAliveAndDeadNeighbors, cell));
            }
        }

        private void AddRevivedCellsToNewCells(List<CellPosition> allNeighbors, List<CellPosition> newCells)
        {
            foreach (var neighbor in allNeighbors)
            {
                if (!_initialCells.Contains(neighbor))
                {
                    var neighborList = neighbor.GetNeighbors();

                    var numberOfAliveAndDeadNeighbors = GetAliveAndDeadNeighbors(neighborList, _initialCells);

                    newCells.AddRange(GetRevivedCells(numberOfAliveAndDeadNeighbors, neighbor));
                }
            }
        }

        private List<CellPosition> GetRevivedCells(int numberOfAliveAndDeadNeighbors, CellPosition neighbor)
        {
            List<CellPosition> newCells = new List<CellPosition>();

            if (numberOfAliveAndDeadNeighbors == 3)
            {
                newCells.Add(neighbor);
            }

            return newCells;
        }


        private List<CellPosition> GetSurvivedCells(int numberOfNeighbors, CellPosition cell)
        {
            List<CellPosition> newCells = new List<CellPosition>();

            if (numberOfNeighbors == 2 || numberOfNeighbors == 3)
            {
                newCells.Add(cell);
            }

            return newCells;
        }

        private int GetAliveAndDeadNeighbors(List<CellPosition> neighborsList, List<CellPosition> _initialCells)
        {
            var aliveNeighbors = 0;

            foreach (var neighborPosition in neighborsList)
            {
                if (_initialCells.Contains(neighborPosition))
                    aliveNeighbors++;
            }

            return aliveNeighbors;
        }   
    }   
}