using System;
using System.Collections.Generic;

namespace GameOfLifeChallenge
{
    public class GameOfLife
    {
        private readonly List<CellPosition> _generation;

        public GameOfLife(List<CellPosition> generation)
        {
            _generation = generation;
        }
        public List<CellPosition> Play()
        {
            if (_generation.Count == 0)
            {
                throw new Exception();
            }

            if (_generation.Count < 3)
            {
                return null;
            }

            var cells = new List<CellPosition>();
            var neighbors = new List<CellPosition>();

            foreach (var cell in _generation)
            {
                var neighborsList = cell.GetNeighbors();

                foreach (var neighbor in neighborsList)
                {
                    if (!neighbors.Contains(neighbor))
                    {
                        neighbors.Add(neighbor);
                    }
                }

                var aliveNeighbors = 0;

                foreach (var neighbor in neighborsList)
                {
                    if (_generation.Contains(neighbor))
                    {
                        aliveNeighbors++;
                    }
                }

                var aliveAndDead = aliveNeighbors;

                List<CellPosition> newCells1 = new List<CellPosition>();

                if (aliveAndDead == 2 || aliveAndDead == 3)
                {
                    newCells1.Add(cell);
                }

                cells.AddRange(newCells1);
            }

            foreach (var neighbor1 in neighbors)
            {
                if (!_generation.Contains(neighbor1))
                {
                    var neighborList = neighbor1.GetNeighbors();

                    var aliveNeighbors = 0;

                    foreach (var neighborPosition in neighborList)
                    {
                        if (_generation.Contains(neighborPosition))
                        {
                            aliveNeighbors++;
                        }
                    }

                    var aliveAndDeadNeighbors1 = aliveNeighbors;

                    List<CellPosition> newCells1 = new List<CellPosition>();

                    if (aliveAndDeadNeighbors1 == 3)
                    {
                        newCells1.Add(neighbor1);
                    }

                    cells.AddRange(newCells1);
                }
            }

            return cells;
        }
    }   
}