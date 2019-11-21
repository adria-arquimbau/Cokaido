using System.Collections.Generic;
using Xunit;

namespace MarsRover
{
    public class MarsRoverShould
    {
        private readonly Rover _rover;    

        public MarsRoverShould()
        {
            _rover = new Rover();
        }

        [Fact]
        public void StayInTheSamePositionGivenNoCommands()
        {
            var position = _rover.Execute(string.Empty);
            Assert.Equal("0:0:N", position);  
        }

        [Fact]
        public void TurnRightGivenCommandR()
        {
            var position = _rover.Execute("R");
            Assert.Equal("0:0:E", position);
        }

        [Theory]
        [InlineData("L", "0:0:W")]
        [InlineData("LL", "0:0:S")]
        [InlineData("LLL", "0:0:E")]
        [InlineData("LLLL", "0:0:N")]
        public void TurnLeftAsManyTimesAsLCommands(string command, string expectedPosition)
        {
            var position = _rover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("R", "0:0:E")]
        [InlineData("RR", "0:0:S")]
        [InlineData("RRR", "0:0:W")]
        [InlineData("RRRR", "0:0:N")]
        public void TurnRightAsManyTimesAsRCommands(string command, string expectedPosition)
        {
            var position = _rover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("M", "0:1:N")]
        [InlineData("MM", "0:2:N")]
        [InlineData("MMM", "0:3:N")]
        [InlineData("MMMM", "0:4:N")]
        public void MoveAsManyTimesAsMCommands(string command, string expectedPosition)
        {
            var position = _rover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("RM", "1:0:E")]
        [InlineData("RMM", "2:0:E")]
        public void MoveRightAndForwardAsManyTimesAsCommanded(string command, string expectedPosition)
        {
            var position = _rover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Fact]
        public void TurnLeftMoveForward()
        {
            _rover.Execute("RML");

            var position = _rover.Execute("LM");
            
            Assert.Equal("0:0:W", position);
        }

        [Fact]
        public void TurnSouthAndMoveForward()
        {
            _rover.Execute("ML");

            var position = _rover.Execute("LM");

            Assert.Equal("0:0:S", position);
        }

        [Fact]
        public void WalkThePathOfHappiness()
        {
            var position = _rover.Execute("RMMLMMRMRMRMM");

            Assert.Equal("1:1:W", position);
        }
    }
}
