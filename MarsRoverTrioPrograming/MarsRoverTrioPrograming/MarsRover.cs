namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private int _position;
        private const char MoveCommand = 'M';

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Move(command);
            }

            return $"0:{_position}:N";
        }

        private void Move(char command)
        {
            if (command == MoveCommand)
            {
                _position++;
            }
        }
    }
}