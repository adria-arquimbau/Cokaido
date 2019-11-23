namespace MarsRover
{
    public abstract class Rover
    {
        public abstract Position Execute(string commands);
        public abstract Position ExecuteReverse(string commands);
    }
}   