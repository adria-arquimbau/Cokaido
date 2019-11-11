using System;
using System.Collections.Generic;

namespace GameOfLifeV2
{
    public class GameOfLife
    {
        private Ecosystem _ecosystem;

        public GameOfLife(Ecosystem ecosystem)
        {
            _ecosystem = ecosystem;
        }

        public GameOfLife Play()
        {
            _ecosystem = _ecosystem.NewGeneration();
            return new GameOfLife(_ecosystem);
        }

        protected bool Equals(GameOfLife other)
        {
            if (this._ecosystem.Equals(other._ecosystem)) return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameOfLife)obj);
        }

        public override int GetHashCode()
        {
            return (_ecosystem != null ? _ecosystem.GetHashCode() : 0);
        }

    }
}