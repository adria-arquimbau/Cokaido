using Xunit;

namespace MarsRover
{
    public class MarsRoverReverseShould
    {
        public MarsRoverReverseShould()
        {
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

        [Fact]
        public void TurnLeftThreeTimesGivenThreeR()
        {
            var roverReverse = new RoverReverse(new RoverBase());
            var position = roverReverse.Execute("RRR");
            Assert.Equal("0:0:E", position.ToString());
        }
    }
}