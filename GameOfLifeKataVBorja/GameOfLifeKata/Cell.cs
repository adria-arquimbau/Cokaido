namespace GameOfLifeKata
{
    internal class Cell
    {
        private int _neighbourCount;
        private CellState _state;

        public Cell(CellState cellState = CellState.Alive)
        {
            _state = cellState;
            _neighbourCount = 0;
        }

        public void AddNeighbour()
        {
            _neighbourCount++;
        }

        public bool HasEnoughNeighborsToSurvive()
        {
            return _neighbourCount <= 3 && _neighbourCount >= 2;
        }

        public bool IsAlive()
        {
            return _state == CellState.Alive;
        }

        public bool IsDead()
        {
            return _state == CellState.Dead;
        }

        public bool HasEnoughNeighborsToRevive()
        {
            return _neighbourCount == 3;
        }

        public Cell Evolve()
        {
            if (IsAlive() && HasEnoughNeighborsToSurvive())
            {
                return new Cell();
            }

            if (IsDead() && HasEnoughNeighborsToRevive())
            {
                return new Cell();
            }

            return new Cell(CellState.Dead);
        }
    }

    internal enum CellState
    {
        Dead,
        Alive
    }
}