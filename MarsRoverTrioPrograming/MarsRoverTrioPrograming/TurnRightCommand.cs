namespace MarsRoverTrioPrograming
{
    public class TurnRightCommand : ICommand
    {
        private Position _position;

        public TurnRightCommand(Position position)
        {
            _position = position;
        }

        public void Execute()   
        {
            _position.TurnRight();
        }
    }
}