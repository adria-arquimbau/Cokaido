namespace MarsRoverTrioPrograming
{
    public class BoosterAxisBase : AxisBaseDecorator
    {
        public BoosterAxisBase(IAxisBase axisBase) : base(axisBase)
        {
        }

        public override void MoveNorth()
        {
            base.MoveNorth();

            base.MoveNorth();

        }
    }
}