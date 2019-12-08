using Xunit;

namespace MarsRoverTrioPrograming.Tests
{
    public class FlightModeShould
    {
        public FlightModeShould()
        {
        }

        [Fact]
        public void MoveBeyondTheLimitsOfTheField()
        {
            var flightModeMarsRover =  new MarsRover(new FlightMode());

            var position = flightModeMarsRover.Execute("LLMMMMM");
            Assert.Equal("-5:0:W", position);
        }
    }
}