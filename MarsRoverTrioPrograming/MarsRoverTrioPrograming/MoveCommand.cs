namespace MarsRoverTrioPrograming
{
    public class MoveCommand : ICommand
    {
        private readonly Position _position;

        public MoveCommand(Position position)
        {
            _position = position;
        }

        public void Execute()   
        {
            _position.Move();
        }
    }
}