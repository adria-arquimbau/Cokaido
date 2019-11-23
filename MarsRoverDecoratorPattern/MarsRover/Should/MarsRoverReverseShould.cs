using Xunit;

namespace MarsRover
{
    public class MarsRoverReverseShould
    {
        private readonly RoverReverse _roverReverse;

        public MarsRoverReverseShould()
        {
            _roverReverse = new RoverReverse(new RoverBase());
        }   

        [Fact]
        public void TurnLeftGivenCommandRWithReverseCommandsActivated()
        {
            var position = _roverReverse.Execute("R");
            Assert.Equal("0:0:W", position.ToString());
        }

        [Fact]
        public void TurnRightGivenCommandLWithReverseCommandsActivated()
        {
            var position = _roverReverse.Execute("L");
            Assert.Equal("0:0:E", position.ToString());
        }

        [Fact]
        public void TurnLeftThreeTimesGivenThreeR()
        {
            var position = _roverReverse.Execute("RRR");
            Assert.Equal("0:0:E", position.ToString());
        }

        [Fact]
        public void TurnLeftTwoTimesAndRightOneTimeGivenTwoRAndOneL()
        {
            var position = _roverReverse.Execute("RRL");
            Assert.Equal("0:0:W", position.ToString());
        }
    }
}