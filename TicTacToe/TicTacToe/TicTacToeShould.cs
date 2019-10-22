using System;
using Xunit;

namespace TicTacToe
{
    public class TicTacToeShould
    {
        [Fact]
        public void ShowErrorMessageWhenPlayer1PlacesAnOAsTheFirstMove()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();

            //Act

            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play("O")));
        }
    }
}
