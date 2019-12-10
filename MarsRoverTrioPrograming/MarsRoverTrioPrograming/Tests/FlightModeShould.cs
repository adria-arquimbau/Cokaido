using Xunit;

namespace MarsRoverTrioPrograming.Tests
{
    public class FlightModeShould
    {
        
        //[Fact]
        //public void MoveBeyondTheLimitsOfTheField()
        //{
        //    const int fuel = 10;
        //    var flightModeMarsRover =  new MarsRover(new FlightMode(fuel));
        //    var position = flightModeMarsRover.Execute("LLMMMMM");
        //    Assert.Equal("-5:0:W", position);
        //}

        [Fact]
        public void MoveOnly4MovementsIfTheFuelIs8AndGoBackToStartPosition()
        {
            const int fuel = 8;
            var flightModeMarsRover = new MarsRover(new FlightMode(fuel));
            var position = flightModeMarsRover.Execute("MMMMMMMM");
            Assert.Equal("0:0:N", position);
        }
    }
}