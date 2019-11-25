namespace MarsRoverTrioPrograming
{
    public class BoostedPosition : IPosition
    {
        public Direction _direction;
        private readonly Axis _axis;


        public BoostedPosition(Compass direction = Compass.N, int positionY = 0, int positionX = 0)
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
                _axis.MoveNorth();
            }

            if (Equals(_direction, new Direction(Compass.E)))
            {
                _axis.MoveEast();
                _axis.MoveEast();
            }

            if (Equals(_direction, new Direction(Compass.S)))
            {
                _axis.MoveSouth();
                _axis.MoveSouth();
            }

            if (Equals(_direction, new Direction(Compass.W)))
            {
                _axis.MoveWest();
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