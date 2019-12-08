using MarsRoverTrioPrograming.Tests;
using Xunit.Abstractions;

namespace MarsRoverTrioPrograming
{
    public class Position : IPosition
    {
        private readonly Axis _obstacle;
        public Direction Direction;
        private readonly Axis _axis;

        public Position(Compass direction, int positionY, int positionX, Axis _obstacle = null)
        {
            this._obstacle = _obstacle;
            _axis = new Axis(positionY, positionX);
            Direction = new Direction(direction);   
        }

        public override string ToString()   
        {
            return $"{_axis}:{Direction}";
        }

        public void Move()
        {
            const int upRightLimitPosition = 10;
            const int downLeftLimitPosition = 0;

            if (Equals(Direction, new Direction(Compass.N)) && _axis.PositionY < upRightLimitPosition)
            {
                if (_obstacle != null && _obstacle.PositionX == _axis.PositionX && _obstacle.PositionY == _axis.PositionY + 1)
                {
                    Direction.TurnRight(); _axis.MoveEast(); Direction.TurnLeft(); _axis.MoveNorth(); _axis.MoveNorth(); Direction.TurnLeft(); _axis.MoveWest(); Direction.TurnRight();
                }

                _axis.MoveNorth();
            }

            if (Equals(Direction, new Direction(Compass.E)) && _axis.PositionX < upRightLimitPosition)
            {
                _axis.MoveEast();
            }

            if (Equals(Direction, new Direction(Compass.S)) && _axis.PositionY > downLeftLimitPosition)
            {
                _axis.MoveSouth();
            }

            if (Equals(Direction, new Direction(Compass.W)) && _axis.PositionX > downLeftLimitPosition)
            {
                _axis.MoveWest();
            }
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