namespace MarsRoverTrioPrograming
{
    public class FlightMode : IPosition
    {
        public Direction Direction;
        private readonly Axis _axis;

        public FlightMode(Compass direction = Compass.N, int positionY = 0, int positionX = 0)
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
            const int upRightLimitPosition = 10;
            const int downLeftLimitPosition = 0;

            if (Equals(Direction, new Direction(Compass.N)))
            {
                _axis.MoveNorth();
            }

            if (Equals(Direction, new Direction(Compass.E)))
            {
                _axis.MoveEast();
            }

            if (Equals(Direction, new Direction(Compass.S)))
            {
                _axis.MoveSouth();
            }

            if (Equals(Direction, new Direction(Compass.W)))
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
