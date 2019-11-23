namespace MarsRover
{
    public class Position
    {
        public int PositionX;
        public int PositionY;
        public Compass Compass;

        public Position(int positionX, int positionY, Compass compass)
        {
            PositionX = positionX;
            PositionY = positionY;
            Compass = compass;
        }

        public override string ToString()
        {
            return $"{PositionX}:{PositionY}:{Compass}";
        }
    }
}