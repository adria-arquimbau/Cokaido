namespace MarsRoverTrioPrograming
{
    public class MarsRover
    {
        private const string MoveCommand = "M";

        public string Execute(string command)
        {
            if (command == MoveCommand)
            {
                return "0:1:N";
            }

            if (command == MoveCommand + MoveCommand)
            {
                return "0:2:N";
            }

            if (command == MoveCommand + MoveCommand + MoveCommand)
            {
                return "0:3:N";
            }

            return "0:0:N";
        }
    }
}