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
            return "0:0:N";
        }
    }
}