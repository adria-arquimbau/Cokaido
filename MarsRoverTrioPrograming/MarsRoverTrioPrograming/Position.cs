namespace MarsRoverTrioPrograming
{
    public class Position
    {
        public Direction _direction;
        private readonly Axis _axis;

        public Position(Compass direction, int positionY, int positionX)
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

            if (Equals(_direction, new Direction(Compass.E)))
            {
                _axis.MoveEast();
            }

            if (Equals(_direction, new Direction(Compass.S)))
            {
                _axis.MoveSouth();
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                _axis.MoveWest();
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