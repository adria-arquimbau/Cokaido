namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private int _position;
        private Compass _compass;
        private const char MoveCommand = 'M';
        private const char TurnRightCommand = 'R';

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Move(command);
                TurnRight(command);
            }

            return $"0:{_position}:{_compass}";
        }

        private void TurnRight(char command)
        {
            if (command == TurnRightCommand)
            {
                _compass++;
            }
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