using System.Collections.Generic;
using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class FlightMode : IPosition
    {
        private readonly Direction _direction;
        private readonly Axis _axis;

        public FlightMode(Compass direction = Compass.N, int positionY = 0, int positionX = 0)    
        {
            _axis = new Axis(positionY, positionX);
            _direction = new Direction(direction);
        }    
    
        public override string ToString()
        {
            return $"{_axis}:{_direction}";
        }    
    
        public void Move()
        {
            if (Equals(_direction, new Direction(Compass.N)))
            {
                _axis.MoveNorth();
            }

            if (Equals(_direction, new Direction(Compass.NE)))
            {
                _axis.MoveNorthEast();
            }

            if (Equals(_direction, new Direction(Compass.E)))
            {
                _axis.MoveEast();
            }

            if (Equals(_direction, new Direction(Compass.SE)))
            {
                _axis.MoveSouthEast();
            }
                
            if (Equals(_direction, new Direction(Compass.S)))
            {
               _axis.MoveSouth();
            }

            if (Equals(_direction, new Direction(Compass.SW)))
            {
                _axis.MoveSouthWest();
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                _axis.MoveWest();
            }

            if (Equals(_direction, new Direction(Compass.NW)))
            {
                _axis.MoveNorthWest();
            }   
        }

        public void TurnRight() 
        {
            _direction.TurnRight();
        }

        public void TurnLeft()
        {
            _direction.TurnLeft();
        }
    }
}       