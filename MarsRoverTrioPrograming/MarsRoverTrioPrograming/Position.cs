namespace MarsRoverTrioPrograming
{
    public class Position
    {
        public Direction _direction;
        private readonly IAxisBase _axisBase;

        public Position(Compass direction, int positionY, int positionX)
        {
            _axisBase = new Axis(positionY, positionX);
            _direction = new Direction(direction);
        }

        public Position(IAxisBase axisBase, Direction direction)
        {
            _axisBase = axisBase;
            _direction = direction;
        }

        public override string ToString()
        {
            return $"{_axisBase}:{_direction}";
        }

        public void Move()
        {
            if (Equals(_direction, new Direction(Compass.N)))
            {
                _axisBase.MoveNorth();
            }

            if (Equals(_direction, new Direction(Compass.E)))
            {
                _axisBase.MoveEast();
            }

            if (Equals(_direction, new Direction(Compass.S)))
            {
                _axisBase.MoveSouth();
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                _axisBase.MoveWest();
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