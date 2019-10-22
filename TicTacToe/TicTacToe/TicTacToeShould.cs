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
            
            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play("O")));
        }

        [Fact]
        public void ShowErrorMessageWhenPlayer2PlaceAnXAsTheSecondMove()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play("X");
            
            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play("X")));
        }
    }
}
