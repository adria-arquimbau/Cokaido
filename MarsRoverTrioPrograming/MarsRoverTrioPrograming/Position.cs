using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class Position : IPosition
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly MarsMap _marsMap;

        public Position(Compass direction, int positionY, int positionX, MarsMap marsMap = null)
        {
            _axis = new Axis(positionY, positionX);
            _direction = new Direction(direction);   
            _marsMap = marsMap ?? new MarsMap(10, 10);
        }

        public override string ToString()
        {
            return $"{_axis}:{_direction}";
        }

        public void Move()
        {
            if (Equals(_direction, new Direction(Compass.N)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.N, _axis);
            }

            if (Equals(_direction, new Direction(Compass.NE)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.NE, _axis);
            }

            if (Equals(_direction, new Direction(Compass.E)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.E, _axis);
            }

            if (Equals(_direction, new Direction(Compass.SE)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.SE, _axis);
            }
                
            if (Equals(_direction, new Direction(Compass.S)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.S, _axis);
            }

            if (Equals(_direction, new Direction(Compass.SW)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.SW, _axis);
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                MarsMap.OutOfBoundsAndMove(Compass.W, _axis);
            }

            if (Equals(_direction, new Direction(Compass.NW)))
            {
               MarsMap.OutOfBoundsAndMove(Compass.NW, _axis);
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