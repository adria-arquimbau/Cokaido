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
    }

    public class MarsRover
    {
        public string Execute(string empty)
        {
            return "0:0:N";
        }
    }
}
    