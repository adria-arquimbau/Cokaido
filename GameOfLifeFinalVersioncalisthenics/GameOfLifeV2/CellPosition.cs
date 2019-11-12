using System.Collections.Generic;

namespace GameOfLife
{
    public class CellPosition
    {
        private readonly int _positionX;
        private readonly int _positionY;

        public CellPosition(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public List<CellPosition> GetNeighbors()
        {
            return new List<CellPosition> { new CellPosition(_positionX + 1, _positionY), new CellPosition(_positionX - 1, _positionY), new CellPosition(_positionX, _positionY + 1), new CellPosition(_positionX, _positionY - 1), new CellPosition(_positionX + 1, _positionY + 1), new CellPosition(_positionX - 1, _positionY - 1), new CellPosition(_positionX + 1, _positionY - 1), new CellPosition(_positionX - 1, _positionY + 1) };
        }

        protected bool Equals(CellPosition other)
        {
            return _positionX == other._positionX && _positionY == other._positionY;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CellPosition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_positionX * 397) ^ _positionY;
            }
        }
    }
}