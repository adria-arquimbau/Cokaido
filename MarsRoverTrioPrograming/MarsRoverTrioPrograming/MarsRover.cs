namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private int _position;
        private const char MoveCommand = 'M';
        private const string TurnRightCommand = "R";

        public string Execute(string commands)
        {
            if(commands == TurnRightCommand)
            {
                return "0:0:E";
            }

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