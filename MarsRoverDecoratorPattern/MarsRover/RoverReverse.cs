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
            const string commandTurnRight = "R";
            const string commandTurnLeft = "L";
            
            if (commands.Contains("R"))
            {
                _reverseCommands = commands.Replace(commandTurnRight, commandTurnLeft);
            }

            if (commands.Contains("L"))
            {
                _reverseCommands = commands.Replace(commandTurnLeft, commandTurnRight);
            }

            var position = base.Execute(_reverseCommands);
            return position;
        }
    }   
}   