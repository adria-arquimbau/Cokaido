namespace MarsRoverTrioPrograming
{
    public class MoveCommand : ICommand
    {
        private Position _position;

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