using System.Collections.Generic;
using MarsRoverDemo.Tests;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        public MarsMap()
        {
            _width = 10;
            _height = 10;
        }

        public void NavigateTo(Compass compass, Axis axis)
        {
            const int downLeftLimitPosition = 0;
            
            if (compass == Compass.N && axis.PositionY < _height)
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