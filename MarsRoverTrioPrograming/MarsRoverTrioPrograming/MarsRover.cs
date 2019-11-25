namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private readonly Position _position;
        private const char MoveCommand = 'M';
        private const char TurnRightCommand = 'R';
        private const char TurnLeftCommand = 'L';

        public MarsRover(Position position = null)
        {
            _position = position ?? new Position(Compass.N,0,0);
        }

        public string Execute(string commands)
        {
            foreach (var command in commands)
            {
                Move(command);
                TurnRight(command);
                TurnLeft(command);
            }

            return _position.ToString();
        }

        private void TurnRight(char command)
        {
            if (command == TurnRightCommand)
            {
                if (_position.Compass == Compass.W)
                {
                    _position.Compass = Compass.N;
                    return;
                }

                _position.Compass++;
            }
        }
        private void TurnLeft(char command)
        {
            if (command == TurnLeftCommand)
            {
                if (_position.Compass == Compass.N)
                {
                    _position.Compass = Compass.W;
                    return;
                }

                _position.Compass--;
            }
        }

        private void Move(char command)
        {
            if (command == MoveCommand && _position.Compass == Compass.N)
            {
                _position.PositionY++;
            }

            if (command == MoveCommand && _position.Compass == Compass.E)
            {
                _position.PositionX++;
            }
        }
    }
}