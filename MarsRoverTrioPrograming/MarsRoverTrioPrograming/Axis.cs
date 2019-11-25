namespace MarsRoverTrioPrograming
{
    public class Axis : IAxisBase
    {

        public Axis(int positionY = 0, int positionX = 0)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        private int PositionY { get; set; }

        private int PositionX { get; set; }

        public void MoveNorth()
        {
            PositionY++;
        }

        public void MoveEast()
        {
            PositionX++;
        }

        public void MoveSouth()
        {
            PositionY--;
        }

        public void MoveWest()
        {
            PositionX--;
        }

        public override string ToString()
        {
            return PositionX+":"+PositionY;
        }
    }
}