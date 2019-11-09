namespace GameOfLifeV2
{
    public class Cell
    {
        private CellState _state;
        private int _neighbours;

        public Cell(CellState cellState = CellState.Alive)
        {
            _state = cellState;
            _neighbours = 0;
        }
    }

    public enum CellState
    {
        Dead,
        Alive
    }
}