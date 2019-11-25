namespace MarsRoverTrioPrograming
{
    public class Axis
    {
        public int PositionY;
        public int PositionX;

        public Axis(int positionY, int positionX)
        {
            PositionY = positionY;
            PositionX = positionX;
        }

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