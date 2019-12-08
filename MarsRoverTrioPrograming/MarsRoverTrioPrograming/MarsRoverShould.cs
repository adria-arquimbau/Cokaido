using System.Collections.Generic;
using Xunit;

namespace MarsRoverTrioPrograming
{
    public class MarsRoverShould    
    {
        private readonly MarsRover _marsRover;
        private readonly BoostedPositionShould _boostedPositionShould;

        public MarsRoverShould()
        {
            _marsRover = new MarsRover();
            _boostedPositionShould = new BoostedPositionShould();   
        }

        [Fact]
        public void StayInPlaceGivenNoCommand()
        {
            var result = _marsRover.Execute(string.Empty);
            Assert.Equal("0:0:N", result);
        }

        [Theory]
        [InlineData("0:1:N", "M")]
        [InlineData("0:2:N", "MM")]
        [InlineData("0:3:N", "MMM")]
        public void MoveAnyPositionsGivenCommandM(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:E", "R")]
        [InlineData("0:0:S", "RR")]
        [InlineData("0:0:W", "RRR")]
        [InlineData("0:0:N", "RRRR")]
        public void TurnRightGivenCommandR(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:W", "L")]
        [InlineData("0:0:S", "LL")]
        [InlineData("0:0:E", "LLL")]
        [InlineData("0:0:N", "LLLL")]
        public void TurnLeftGivenCommandL(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);   
        }

        [Fact]
        public void TurnRightAndMoveOnePosition()
        {
            var position = _marsRover.Execute("RM");
            Assert.Equal("1:0:E", position);
        }   

        [Theory]
        [InlineData("2:1:E", "RM")]
        [InlineData("0:1:W", "LM")]
        [InlineData("1:0:S", "RRM")]
        public void MoveOnePositionForEachCompassDirection(string expectedPosition, string commands)
        {
            Position startPosition = new Position(Compass.N, 1, 1);
            var marsRover = new MarsRover(startPosition);
            var position = marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:W", "LM")]
        [InlineData("0:0:S", "RRM")]
        [InlineData("0:10:N", "MMMMMMMMMMM")]
        [InlineData("10:0:E", "RMMMMMMMMMMM")]
        [InlineData("0:2:W", "RMMMLMMLMMMM")]
        public void DoNotMoveIfTheNextMoveYouWillBeOverTheField(string expectedPosition, string commands)
        {
            var position = _marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }
    }   
}   
            