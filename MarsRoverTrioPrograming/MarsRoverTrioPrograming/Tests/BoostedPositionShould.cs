using Xunit;

namespace MarsRoverTrioPrograming.Tests
{
    public class BoostedPositionShould
    {
        public BoostedPositionShould()
        {
        }

        [Theory]
        [InlineData("0:2:N", "M")]
        [InlineData("0:4:N", "MM")]
        [InlineData("2:2:N", "RMLM")]
        public void MoveTwoPositionsGivenOneMCommand(string expectedPosition, string commands)
        {
            var marsRover = new MarsRover(new BoostedPosition());
            var position = marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }
    }
}