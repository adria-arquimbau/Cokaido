namespace MarsRoverTrioPrograming
{
    public class TurnLeftCommand : ICommand
    {
        private readonly Position _position;

        public TurnLeftCommand(Position position)
        {
            _position = position;
        }

        public void Execute()   
        {
            _position.TurnLeft();
        }
    }
}