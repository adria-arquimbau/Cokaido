namespace MarsRover
{
    public class RoverReverse : Decorator
    {
        public RoverReverse(Rover roverBase) : base(roverBase)
        {   
        }

        public override Position Execute(string commands)
        {
            const string commandTurnRight = "R";
            const string commandTurnLeft = "L";
            var reverseCommands = commands.Replace(commandTurnRight, commandTurnLeft);
            var position = base.Execute(reverseCommands);
            return position;
        }
    }   
}