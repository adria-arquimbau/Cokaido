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
            if (Compass == Compass.N)
            {
                MoveNorth();
            }

            if (Compass == Compass.E)
            {
                MoveEast();
            }

            if (Compass == Compass.S)
            {
                MoveSouth();
            }

            if (Compass == Compass.W)
            {
                MoveWest();
            }
        }

        private void MoveNorth()
        {
            PositionY++;
        }

        private void MoveEast()
        {
            PositionX++;
        }

        private void MoveSouth()
        {
            PositionY--;
        }

        private void MoveWest()
        {
            PositionX--;
        }

        public void TurnRight()
        {
            
            if (Compass == Compass.W)
            {
                Compass = Compass.N;
                return;
            }

            Compass++;
        }

        public void TurnLeft()
        {
            
            if (Compass == Compass.N)
            {
                Compass = Compass.W;
                return;
            }

            Compass--;
        }
    }
}   