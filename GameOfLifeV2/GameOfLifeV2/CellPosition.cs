namespace GameOfLifeV2
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
    }
}