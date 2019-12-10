namespace MarsRoverTrioPrograming
{
    public class BoostedNavigate : INavigate
    {
        public Direction Direction;
        private readonly Axis _axis;


        public BoostedNavigate(Compass direction = Compass.N, int positionY = 0, int positionX = 0)
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
            if (Direction == new Direction(Compass.N) && DoNotExceedLimits(Compass.N))
            {
                _axis.MoveNorth();
                _axis.MoveNorth();
            }

            if (Direction == new Direction(Compass.E) && DoNotExceedLimits(Compass.E))
            {
                _axis.MoveEast();
                _axis.MoveEast();
            }

            if (Direction == new Direction(Compass.S) && DoNotExceedLimits(Compass.S))
            {
                _axis.MoveSouth();
                _axis.MoveSouth();
            }

            if (Direction == new Direction(Compass.W) && DoNotExceedLimits(Compass.W))
            {
                _axis.MoveWest();
                _axis.MoveWest();
            }

            if (Direction == new Direction(Compass.NE) && DoNotExceedLimits(Compass.NE))
            {
                _axis.MoveNorthEast();
                _axis.MoveNorthEast();
            }

            if (Direction == new Direction(Compass.SE) && DoNotExceedLimits(Compass.SE))
            {
                _axis.MoveSouthEast();
                _axis.MoveSouthEast();
            }

            if (Direction == new Direction(Compass.SW) && DoNotExceedLimits(Compass.SW))
            {
                _axis.MoveSouthWest();
                _axis.MoveSouthWest();
            }

            if (Direction == new Direction(Compass.NW) && DoNotExceedLimits(Compass.NW))
            {
                _axis.MoveNorthWest();
                _axis.MoveNorthWest();
            }
        }

        private bool DoNotExceedLimits(Compass compass)
        {
            const int upRightLimitPosition = 10;
            const int downLeftLimitPosition = 0;

            if (compass == Compass.N)
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