using Xunit;

namespace MarsRoverTrioPrograming.Tests
{
    public class BoostedNavigateShould
    {

        [Theory]
        [InlineData("0:2:N", "M")]
        [InlineData("0:4:N", "MM")]
        [InlineData("2:2:N", "RRMLLM")]
        public void MoveTwoPositionsGivenOneMCommand(string expectedPosition, string commands)
        {
            var marsRover = new MarsRover(new BoostedNavigate());
            var position = marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }
    }
}