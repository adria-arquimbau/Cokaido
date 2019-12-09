using Xunit;

namespace MarsRoverTrioPrograming.Tests
{
    public class FlightModeShould
    {
        
        [Fact]
        public void MoveBeyondTheLimitsOfTheField()
        {
            const int fuel = 10;
            var flightModeMarsRover =  new MarsRover(new FlightMode(fuel));
            var position = flightModeMarsRover.Execute("LLMMMMM");
            Assert.Equal("-5:0:W", position);
        }
        
        [Fact]
        public void MoveOnly5MovementsOutOfTheFieldIfTheFuelIs5AndAreMoreMovements()
        {
            const int fuel = 5;
            var flightModeMarsRover =  new MarsRover(new FlightMode(fuel));
            var position = flightModeMarsRover.Execute("LLMMMMMMMM");
            Assert.Equal("-5:0:W", position);
        }

        [Fact]
        public void ReturnToTheInitialPositionIfAllTheFuelIsSpend()
        {
            const int fuel = 5;
            var flightModeMarsRover =  new MarsRover(new FlightMode(fuel));
            var position = flightModeMarsRover.Execute("MMMMMMMMMMMMM");
            Assert.Equal("0:0:N", position);
        }
    }
}