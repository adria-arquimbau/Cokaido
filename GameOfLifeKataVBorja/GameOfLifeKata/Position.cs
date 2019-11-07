namespace GameOfLifeKata
{
    internal class Position
    {
        private int _positionX;
        private int _positionY;

        public Position(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        protected bool Equals(Position other)
        {
            return _positionX == other._positionX && _positionY == other._positionY;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_positionX * 397) ^ _positionY;
            }
        }

        public Position ToThe(Direction direction)
        {
            if (Equals(direction, Direction.Left))
            {
                return new Position(_positionX - 1, _positionY);
            }

            if (Equals(direction, Direction.Right))
            {
                return new Position(_positionX + 1, _positionY);
            }

            if (Equals(direction, Direction.Above))
            {
                return new Position(_positionX, _positionY + 1);
            }

            if (Equals(direction, Direction.Below))
            {
                return new Position(_positionX, _positionY - 1);
            }

            if (Equals(direction, Direction.AboveLeft))
            {
                return new Position(_positionX - 1, _positionY + 1);
            }

            if (Equals(direction, Direction.AboveRight))
            {
                return new Position(_positionX + 1, _positionY + 1);
            }

            if (Equals(direction, Direction.BelowLeft))
            {
                return new Position(_positionX - 1, _positionY - 1);
            }

            if (Equals(direction, Direction.BelowRight))
            {
                return new Position(_positionX + 1, _positionY - 1);
            }

            return null;
        }
    }
}