using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class Position : IPosition
    {
        public Direction Direction;
        private readonly Axis _axis;

        public Position(Compass direction, int positionY, int positionX, Axis _obstacle = null)
        {
            _axis = new Axis(positionY, positionX);
            Direction = new Direction(direction);   
        }

        public override string ToString()   
        {
            return $"{_axis}:{Direction}";
        }

        public void Move()
        {
            if (Equals(Direction, new Direction(Compass.N)) && DoNotExceedLimits(Compass.N))
            {
                _axis.MoveNorth();
            }

            if (Equals(Direction, new Direction(Compass.E)) && DoNotExceedLimits(Compass.E))
            {
                _axis.MoveEast();
            }

            if (Equals(Direction, new Direction(Compass.S)) && DoNotExceedLimits(Compass.S))
            {
                _axis.MoveSouth();
            }

            if (Equals(Direction, new Direction(Compass.W)) && DoNotExceedLimits(Compass.W))
            {
                _axis.MoveWest();
            }
        }

        private bool DoNotExceedLimits(Compass compass)
        {
            const int upRightLimitPosition = 10;
            const int downLeftLimitPosition = 0;

            if(compass == Compass.N)
            {
                return _axis.PositionY < upRightLimitPosition;
            }

            if (compass == Compass.W)
            {
                return _axis.PositionX > downLeftLimitPosition;
            }

            if (compass == Compass.E)
            {
                return _axis.PositionX < upRightLimitPosition;
            }

            return _axis.PositionY > downLeftLimitPosition;
        }

        public void TurnRight() 
        {
            Direction.TurnRight();
        }

        public void TurnLeft()
        {
            Direction.TurnLeft();
        }
    }
}   