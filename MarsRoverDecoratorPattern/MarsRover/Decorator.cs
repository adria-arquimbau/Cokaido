namespace MarsRover
{
    public abstract class Decorator : Rover
    {
        private readonly Rover _roverBase;

        protected Decorator(Rover roverBase)
        {
            this._roverBase = roverBase;
        }

        public override Position Execute(string commands)
        {
            return _roverBase.Execute(commands);
        }
    }
}