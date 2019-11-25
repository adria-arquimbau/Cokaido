using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverTrioPrograming
{
    public class MarsRoverTrioProgramingShould
    {
        [Fact]
        public void StayInPlaceGivenNoCommand()
        {
            var marsRover = new MarsRover();
            var result = marsRover.Execute(string.Empty);
            Assert.Equal("0:0:N", result);
        }

        [Fact]
        public void MoveOnePositionGivenCommandM()
        {
            var marsRover = new MarsRover();
            var result = marsRover.Execute("M");
            Assert.Equal("0:1:N", result);
        }

        [Fact]
        public void MoveTwoPositionsGivenTwoMCommands()
        {
            var marsRover = new MarsRover();
            var result = marsRover.Execute("MM");
            Assert.Equal("0:2:N", result);
        }

        [Fact]
        public void MoveThreePositionsGivenTwoMCommands()
        {
            var marsRover = new MarsRover();
            var result = marsRover.Execute("MMM");
            Assert.Equal("0:3:N", result);
        }
    }
}   
    