using System.Collections.Generic;

namespace GameOfLifeChallenge
{
    public class CellPosition
    {
        private readonly int _x;
        private readonly int _y;

        public CellPosition(int x, int y)
        {
            _y = y;
            _x = x;
        }

        public List<CellPosition> GetNeighbors()
        {
            return new List<CellPosition> { new CellPosition(_x +1, _y), new CellPosition(_x - 1, _y), new CellPosition(_x, _y + 1), new CellPosition(_x, _y - 1), new CellPosition(_x + 1, _y + 1), new CellPosition(_x -1, _y - 1), new CellPosition(_x + 1, _y - 1), new CellPosition(_x -1, _y + 1) };
        }

        protected bool Equals(CellPosition other)   
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((CellPosition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x * 397) ^ _y;
            }
        }

    }

}