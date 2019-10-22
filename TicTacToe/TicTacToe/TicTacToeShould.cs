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
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.O)));
        }

        [Fact]
        public void ShowErrorMessageWhenPlayer2PlaceAnXAsTheSecondMove()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X);
            
            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.X)));
        }

        [Fact]
        public void ShowErrorMessageWhenThirdMoveIsAnO()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X);
            ticTacToe.Play(Token.O);

            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.O)));
        }
    }
}
