namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private int _position;
        private Compass _compass;
        private const char MoveCommand = 'M';
        private const char TurnRightCommand = 'R';
        private const char TurnLeftCommand = 'L';

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Move(command);
                TurnRight(command);
                TurnLeft(command);
            }

            return $"0:{_position}:{_compass}";
        }

        private void TurnRight(char command)
        {
            if (command == TurnRightCommand)
            {
                if (_compass == Compass.W)
                {
                    _compass = Compass.N;
                    return;
                }
                _compass++;
            }
        }
        private void TurnLeft(char command)
        {
            if (command == TurnLeftCommand)
            {
                if (_compass == Compass.N)
                {
                    _compass = Compass.W;
                    return;
                }
                _compass--;
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