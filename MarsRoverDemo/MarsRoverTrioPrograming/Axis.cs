namespace MarsRoverDemo
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

        public void MoveNorthEast()
        {
            PositionX++;
            PositionY++;    
        }

        public void MoveSouthEast()
        {
            PositionX++;
            PositionY--;
        }

        public void MoveSouthWest()
        {
            PositionX--;
            PositionY--;
        }

        public void MoveNorthWest()
        {
            PositionX--;
            PositionY++;
        }

        public override string ToString()
        {
            return PositionX+":"+PositionY;
        }

        public Axis CloneAxis()
        {   
            var cloneAxis = new Axis(PositionY, PositionX);
            return cloneAxis;
        }
    }
}   