using System.Collections.Generic;
using Xunit;

namespace MarsRover
{
    public class MarsRoverShould
    {
        private readonly RoverBase _roverBase;    

        public MarsRoverShould()
        {
            _roverBase = new RoverBase();
        }

        [Fact]
        public void StayInTheSamePositionGivenNoCommands()
        {
            var position = _roverBase.Execute(string.Empty);
            Assert.Equal("0:0:N", position.ToString());  
        }

        [Fact]
        public void TurnRightGivenCommandR()
        {
            var position = _roverBase.Execute("R");
            Assert.Equal("0:0:E", position.ToString());
        }

        [Theory]
        [InlineData("L", "0:0:W")]
        [InlineData("LL", "0:0:S")]
        [InlineData("LLL", "0:0:E")]
        [InlineData("LLLL", "0:0:N")]
        public void TurnLeftAsManyTimesAsLCommands(string command, string expectedPosition)
        {
            var position = _roverBase.Execute(command);
            Assert.Equal(expectedPosition, position.ToString());
        }

        [Theory]
        [InlineData("R", "0:0:E")]
        [InlineData("RR", "0:0:S")]
        [InlineData("RRR", "0:0:W")]
        [InlineData("RRRR", "0:0:N")]
        public void TurnRightAsManyTimesAsRCommands(string command, string expectedPosition)
        {
            var position = _roverBase.Execute(command);
            Assert.Equal(expectedPosition, position.ToString());
        }

        [Theory]
        [InlineData("M", "0:1:N")]
        [InlineData("MM", "0:2:N")]
        [InlineData("MMM", "0:3:N")]
        [InlineData("MMMM", "0:4:N")]
        public void MoveAsManyTimesAsMCommands(string command, string expectedPosition)
        {
            var position = _roverBase.Execute(command);
            Assert.Equal(expectedPosition, position.ToString());
        }

        [Theory]
        [InlineData("RM", "1:0:E")]
        [InlineData("RMM", "2:0:E")]
        public void MoveRightAndForwardAsManyTimesAsCommanded(string command, string expectedPosition)
        {
            var position = _roverBase.Execute(command);
            Assert.Equal(expectedPosition, position.ToString());
        }

        [Fact]
        public void TurnLeftMoveForward()
        {
            _roverBase.Execute("RML");

            var position = _roverBase.Execute("LM");
            
            Assert.Equal("0:0:W", position.ToString());
        }

        [Fact]
        public void TurnSouthAndMoveForward()
        {
            _roverBase.Execute("ML");

            var position = _roverBase.Execute("LM");

            Assert.Equal("0:0:S", position.ToString());
        }

        [Fact]
        public void WalkThePathOfHappiness()
        {
            var position = _roverBase.Execute("RMMLMMRMRMRMM");

            Assert.Equal("1:1:W", position.ToString());
        }

        [Fact]
        public void MoveTwiceUsingRoverBoosters()
        {
            var boostedRover = new RoverBooster(new RoverBase());
            var position = boostedRover.Execute("M");
            Assert.Equal("0:2:N", position.ToString());
        }

        [Fact]
        public void WalkThePathOfHappinessWithBoosterActivated()
        {
            var roverBooster = new RoverBooster(new RoverBase());
            var position = roverBooster.Execute("RMMLMMRMRMRMM");

            Assert.Equal("2:2:W", position.ToString());
        }

        [Fact]
        public void MoveTwiceUsingRoverSuperBooster()
        {
            var roverSuperBooster = new RoverSuperBooster(new RoverBase());
            var position = roverSuperBooster.Execute("M");
            Assert.Equal("0:3:N", position.ToString());
        }

        [Fact]
        public void WalkThePathOfHappinessWithSuperBoosterActivated()
        {
            var roverSuperBooster = new RoverSuperBooster(new RoverBase());
            var position = roverSuperBooster.Execute("RMMLMMRMRMRMM");
            Assert.Equal("3:3:W", position.ToString());
        }

        [Fact]
        public void MoveTwiceUsingRoverSuperBoosterAndRoverBooster()
        {
            var roverSuperBooster = new RoverSuperBooster(new RoverBooster(new RoverBase()));
            var position = roverSuperBooster.Execute("M");
            Assert.Equal("0:6:N", position.ToString());
        }

        [Fact]
        public void TurnLeftGivenCommandRWithReverseCommandsActivated()
        {
            var roverReverse = new RoverReverse(new RoverBase());
            var position = roverReverse.Execute("R");
            Assert.Equal("0:0:W", position.ToString());
        }

        [Fact]
        public void TurnRightGivenCommandLWithReverseCommandsActivated()
        {
            var roverReverse = new RoverReverse(new RoverBase());
            var position = roverReverse.Execute("L");
            Assert.Equal("0:0:E", position.ToString());
        }   
    }
}
    