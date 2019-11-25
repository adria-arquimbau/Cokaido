namespace MarsRoverTrioPrograming
{
    public abstract class AxisBaseDecorator : IAxisBase
    {
        protected readonly IAxisBase AxisBase;

        public virtual void MoveNorth()
        {
            AxisBase.MoveNorth();
        }

        public void MoveEast()
        {
            AxisBase.MoveEast();
        }

        public void MoveSouth()
        {
            AxisBase.MoveSouth();
        }

        public void MoveWest()
        {
            AxisBase.MoveWest();
        }

        public override string ToString()
        {
            return AxisBase.ToString();
        }

        protected AxisBaseDecorator(IAxisBase axisBase)
        {
            AxisBase = axisBase;
        }   
    }
}