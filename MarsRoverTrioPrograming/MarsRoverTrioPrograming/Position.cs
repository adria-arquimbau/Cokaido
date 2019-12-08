using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class Position : IPosition
    {
        public Direction Direction;
        private readonly Axis _axis;

        public Position(Compass direction, int positionY, int positionX)
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

            if (Equals(Direction, new Direction(Compass.NE)) && DoNotExceedLimits(Compass.NE))
            {
                _axis.MoveNorthEast();
            }

            if (Equals(Direction, new Direction(Compass.E)) && DoNotExceedLimits(Compass.E))
            {
                _axis.MoveEast();
            }

            if (Equals(Direction, new Direction(Compass.SE)) && DoNotExceedLimits(Compass.SE))
            {
                _axis.MoveSouthEast();
            }
                
            if (Equals(Direction, new Direction(Compass.S)) && DoNotExceedLimits(Compass.S))
            {
                _axis.MoveSouth();
            }

            if (Equals(Direction, new Direction(Compass.SW)) && DoNotExceedLimits(Compass.SW))
            {
                _axis.MoveSouthWest();
            }

            if (Equals(Direction, new Direction(Compass.W)) && DoNotExceedLimits(Compass.W))
            {
                _axis.MoveWest();
            }

            if (Equals(Direction, new Direction(Compass.NW)) && DoNotExceedLimits(Compass.NW))
            {
                _axis.MoveNorthWest();
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

            if (compass == Compass.S)
            {
                return _axis.PositionY > downLeftLimitPosition;
            }

            if (compass == Compass.NE)
            {
                return _axis.PositionY < upRightLimitPosition && _axis.PositionX < upRightLimitPosition;
            }

            if (compass == Compass.NW)
            {
                return _axis.PositionY < upRightLimitPosition && _axis.PositionX > downLeftLimitPosition;
            }

            if (compass == Compass.SE)
            {
                return _axis.PositionY > downLeftLimitPosition && _axis.PositionX < upRightLimitPosition;
            }

            return _axis.PositionY > downLeftLimitPosition && _axis.PositionX > downLeftLimitPosition;
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