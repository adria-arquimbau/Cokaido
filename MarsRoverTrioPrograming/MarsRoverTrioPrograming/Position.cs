namespace MarsRoverTrioPrograming
{
    public class Position
    {
        public Compass Compass;
        public int PositionY;
        public int PositionX;

        public Position(Compass compass, int positionY, int positionX)
        {
            Compass = compass;
            PositionY = positionY;
            PositionX = positionX;
        }

        public override string ToString()
        {
            return $"{PositionX}:{PositionY}:{Compass}";
        }
    }
}   