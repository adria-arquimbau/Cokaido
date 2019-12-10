using System.Collections.Generic;
using MarsRoverDemo.Tests;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        private List<Axis> _gridPositions = new List<Axis>();

        public MarsMap()
        {
            _width = 10;
            _height = 10;
            
            GenerateGridPositionsList(_width, _height); 
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

        public void NavigateTo(Compass compass, Axis axis)
        {
            const int downLeftLimitPosition = 0;

            var cloneAxis = axis.CloneAxis();

            if (compass == Compass.N)
            {
                axis.MoveNorth();
            }
            
            if (compass == Compass.NE && axis.PositionY < _height && axis.PositionX < _width)
            {
                axis.MoveNorthEast();
            }

            if (compass == Compass.E && axis.PositionX < _width)
            {
                axis.MoveEast();
            }
            
            if (compass == Compass.SE && axis.PositionY > downLeftLimitPosition && axis.PositionX < _width)
            {
                axis.MoveSouthEast();
            }
            
            if (compass == Compass.S && axis.PositionY > downLeftLimitPosition)
            {
                axis.MoveSouth();
            }

            if (compass == Compass.SW && axis.PositionY > downLeftLimitPosition &&
                axis.PositionX > downLeftLimitPosition)
            {
                axis.MoveSouthWest();
            }
            
            if (compass == Compass.W && axis.PositionX > downLeftLimitPosition)
            {
                axis.MoveWest();
            }
            
            if (compass == Compass.NW && axis.PositionY < _height && axis.PositionX > downLeftLimitPosition)
            {
               axis.MoveNorthWest();
            }
        }
    }
}