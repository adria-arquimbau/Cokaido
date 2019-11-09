using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeV2
{
    public class Neighbors
    {
        private readonly List<CellPosition> _neighbors = new List<CellPosition>();

        public Neighbors(List<CellPosition> neighbors)
        {
            _neighbors = neighbors;
        }

        protected bool Equals(Neighbors other)
        {
            return _neighbors.SequenceEqual(other._neighbors);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Neighbors) obj);
        }

        public override int GetHashCode()
        {
            return (_neighbors != null ? _neighbors.GetHashCode() : 0);
        }
    }
}