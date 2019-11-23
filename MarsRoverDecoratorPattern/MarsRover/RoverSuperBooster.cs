namespace MarsRover
{
    public class RoverSuperBooster : Decorator
    {
        public RoverSuperBooster(Rover roverBase) : base(roverBase)
        {
        }

        public override Position Execute(string commands)
        {
            const string oneMovement = "M";
            var superBoostedCommands = commands.Replace(oneMovement, oneMovement + oneMovement + oneMovement);
            var position = base.Execute(superBoostedCommands);
            return position;
        }
    }
}