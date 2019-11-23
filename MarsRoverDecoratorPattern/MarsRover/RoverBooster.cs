namespace MarsRover
{
    public class RoverBooster : Decorator
    {
        public RoverBooster(Rover roverBase) : base(roverBase)
        {
        }

        public override Position Execute(string commands)
        {
            const string oneMovement = "M";
            var boostedCommands = commands.Replace(oneMovement, oneMovement + oneMovement );
            var position = base.Execute(boostedCommands);
            return position;
        }
    }
}