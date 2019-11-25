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

        public void Move()
        {
            MoveNorth();

            MoveEast();

            MoveSouth();

            MoveWest();

        }

        public void MoveNorth()
        {
            if (this.Compass == Compass.N)
            {
                this.PositionY++;
            }
        }

        public void MoveSouth()
        {
            if (Compass == Compass.S)
            {
                PositionY--;
            }
        }

        public void MoveEast()
        {
            if (Compass == Compass.E)
            {
                PositionX++;
            }
        }

        public void MoveWest()
        {
            if (Compass == Compass.W)
            {
                PositionX--;
            }
        }
    }
}   