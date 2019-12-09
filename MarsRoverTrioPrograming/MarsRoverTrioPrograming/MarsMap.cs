namespace MarsRoverTrioPrograming
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        public MarsMap(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public static void OutOfBoundsAndMove(Compass compass, Axis axis)
        {
            const int upRightLimitPosition = 10;
            const int downLeftLimitPosition = 0;
            
            if (compass == Compass.N && axis.PositionY < upRightLimitPosition)
            {
                axis.MoveNorth();
            }
            
            if (compass == Compass.NE && axis.PositionY < upRightLimitPosition && axis.PositionX < upRightLimitPosition)
            {
                axis.MoveNorthEast();
            }

            if (compass == Compass.E && axis.PositionX < upRightLimitPosition)
            {
                axis.MoveEast();
            }
            
            if (compass == Compass.SE && axis.PositionY > downLeftLimitPosition && axis.PositionX < upRightLimitPosition)
            {
                axis.MoveSouthEast();
            }
            
            if (compass == Compass.S && axis.PositionY > downLeftLimitPosition)
            {
                axis.MoveSouth();
            }

            if (compass == Compass.SW && axis.PositionY > downLeftLimitPosition &&
                axis.PositionX > downLeftLimitPosition)
            {
                axis.MoveSouthWest();
            }
            
            if (compass == Compass.W && axis.PositionX > downLeftLimitPosition)
            {
                axis.MoveWest();
            }
            
            if (compass == Compass.NW && axis.PositionY < upRightLimitPosition && axis.PositionX > downLeftLimitPosition)
            {
               axis.MoveNorthWest();
            }
        }
    }
}