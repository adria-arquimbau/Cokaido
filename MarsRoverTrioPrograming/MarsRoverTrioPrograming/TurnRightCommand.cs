namespace MarsRoverTrioPrograming
{
    public class TurnRightCommand : ICommand
    {
        private readonly Position _position;

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