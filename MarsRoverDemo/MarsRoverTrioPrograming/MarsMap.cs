using System;
using System.Collections.Generic;
using MarsRoverDemo.Tests;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Axis> _gridPositions = new List<Axis>();
        private Dictionary<Compass, Action> _navigateTo;
        private Dictionary<Compass, Action> _simulateNavigateTo;

        public MarsMap()
        {
            _width = 10;
            _height = 10;
            GenerateGridPositionsList(_width, _height);
        }

        public void NavigateTo(Compass compass, Axis axis)
        {
            var cloneAxis = axis.CloneAxis();
            _navigateTo = new Dictionary<Compass, Action>
            {
                {Compass.N, axis.MoveNorth},
                {Compass.NE, axis.MoveNorthEast},       
                {Compass.E, axis.MoveEast},
                {Compass.SE, axis.MoveSouthEast},
                {Compass.S, axis.MoveSouth},
                {Compass.SW, axis.MoveSouthWest},
                {Compass.W, axis.MoveWest},
                {Compass.NW, axis.MoveNorthWest},
            };
            _simulateNavigateTo = new Dictionary<Compass, Action>
            {
                {Compass.N, cloneAxis.MoveNorth},
                {Compass.NE, cloneAxis.MoveNorthEast},
                {Compass.E, cloneAxis.MoveEast},
                {Compass.SE, cloneAxis.MoveSouthEast},
                {Compass.S, cloneAxis.MoveSouth},
                {Compass.SW, cloneAxis.MoveSouthWest},
                {Compass.W, cloneAxis.MoveWest},
                {Compass.NW, cloneAxis.MoveNorthWest},
            };

            _simulateNavigateTo[compass]();

            if (_gridPositions.Contains(new Axis(cloneAxis.PositionY, cloneAxis.PositionX)))
            {
                _navigateTo[compass]();
            }
            
            
            //if (compass == Compass.NE && axis.PositionY < _height && axis.PositionX < _width)
            //{
            //    axis.MoveNorthEast();
            //}

            //if (compass == Compass.E && axis.PositionX < _width)
            //{
            //    axis.MoveEast();
            //}
            
            //if (compass == Compass.SE && axis.PositionY > downLeftLimitPosition && axis.PositionX < _width)
            //{
            //    axis.MoveSouthEast();
            //}
            
            //if (compass == Compass.S && axis.PositionY > downLeftLimitPosition)
            //{
            //    axis.MoveSouth();
            //}

            //if (compass == Compass.SW && axis.PositionY > downLeftLimitPosition &&
            //    axis.PositionX > downLeftLimitPosition)
            //{
            //    axis.MoveSouthWest();
            //}
            
            //if (compass == Compass.W && axis.PositionX > downLeftLimitPosition)
            //{
            //    axis.MoveWest();
            //}
            
            //if (compass == Compass.NW && axis.PositionY < _height && axis.PositionX > downLeftLimitPosition)
            //{
            //   axis.MoveNorthWest();
            //}
        }

        private void GenerateGridPositionsList(int width, int height)
        {
            var count = 0;
            for (int i = 0; i <= width; i++)
            {
                for (int y = 0; y <= width; y++)
                {
                    _gridPositions.Add(new Axis(count, y));
                }
                count++;
            }
        }
    }
}