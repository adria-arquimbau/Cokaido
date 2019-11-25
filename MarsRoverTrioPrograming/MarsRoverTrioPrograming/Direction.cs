namespace MarsRoverTrioPrograming
{
    public class Direction
    {
        private Compass _compass;

        public Direction(Compass compass = Compass.N)
        {
            _compass = compass;
        }

        public void TurnRight()
        {
            if (_compass == Compass.W)
            {
                _compass = Compass.N;
                return;
            }

            _compass++;
        }

        public void TurnLeft()
        {
            if (_compass == Compass.N)
            {
                _compass = Compass.W;
                return;
            }

            _compass--;
        }

        public override string ToString()
        {
            return _compass.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return ((Direction) obj)._compass == this._compass;
        }
    }
}