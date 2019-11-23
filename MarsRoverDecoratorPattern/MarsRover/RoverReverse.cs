namespace MarsRover
{
    public class RoverReverse : Decorator
    {
        private string _reverseCommands = string.Empty;

        public RoverReverse(Rover roverBase) : base(roverBase)
        {   
        }

        public override Position Execute(string commands)
        {
            _reverseCommands = commands.Replace("R", "I").Replace("L", "D");

            var position = base.Execute(_reverseCommands);
            return position;
        }
    }   
}   