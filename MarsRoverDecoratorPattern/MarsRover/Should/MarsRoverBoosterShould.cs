using Xunit;

namespace MarsRover
{
    public class MarsRoverBoosterShould
    {
        private readonly RoverBooster _roverBooster;
        private readonly RoverSuperBooster _roverSuperBooster;

        public MarsRoverBoosterShould()
        {
            _roverBooster = new RoverBooster(new RoverBase());
            _roverSuperBooster = new RoverSuperBooster(new RoverBase());
        }
        
        [Fact]
        public void MoveTwiceUsingRoverBoosters()
        {
            var position = _roverBooster.Execute("M");
            Assert.Equal("0:2:N", position.ToString());
        }
            
        [Fact]
        public void WalkThePathOfHappinessWithBoosterActivated()
        {
            var position = _roverBooster.Execute("RMMLMMRMRMRMM");
            Assert.Equal("2:2:W", position.ToString());
        }

        [Fact]
        public void MoveTwiceUsingRoverSuperBooster()
        {
            var position = _roverSuperBooster.Execute("M");
            Assert.Equal("0:3:N", position.ToString());
        }

        [Fact]
        public void WalkThePathOfHappinessWithSuperBoosterActivated()
        {
            var position = _roverSuperBooster.Execute("RMMLMMRMRMRMM");
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