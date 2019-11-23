using Xunit;

namespace MarsRover
{
    public class MarsRoverBoosterShould
    {
        
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
    }
}