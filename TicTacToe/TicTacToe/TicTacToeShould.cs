using System;
using System.ComponentModel;
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
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.O, 0, 0)));
        }

        [Fact]
        public void ShowErrorMessageWhenPlayer2PlaceAnXAsTheSecondMove()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X, 0, 0);

            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.X, 0, 1)));
        }

        [Fact]
        public void ShowErrorMessageWhenThirdMoveIsAnO()
        {
            //Arrange
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X, 0, 0);
            ticTacToe.Play(Token.O, 0, 1);

            //Assert
            Assert.Throws<Exception>((() => ticTacToe.Play(Token.O, 0, 3)));
        }

        [Fact]
        public void ShowErrorWhenPlayingInAUsedPosition()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X, 0, 0);
            ticTacToe.Play(Token.O, 1, 2);
            ticTacToe.Play(Token.X, 0, 1);

            Assert.Throws<Exception>(() => ticTacToe.Play(Token.O, 1, 2));
        }

        [Fact]
        public void NamePlayerXTheWinnerWhenHeHas3XInAColumn()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X, 0, 0);
            ticTacToe.Play(Token.O, 1, 2);
            ticTacToe.Play(Token.X, 1, 0);
            ticTacToe.Play(Token.O, 2, 1);

            var result = ticTacToe.Play(Token.X, 2, 0);

            Assert.Equal("Player X Wins", result);
        }

        [Fact]
        public void NamePlayerOTheWinnerWhenHeHas3OInAColumn()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.Play(Token.X, 0, 0);
            ticTacToe.Play(Token.O, 0, 1);
            ticTacToe.Play(Token.X, 0, 2);
            ticTacToe.Play(Token.O, 1, 1);
            ticTacToe.Play(Token.X, 1, 0);

            var result = ticTacToe.Play(Token.O, 2, 1);

            Assert.Equal("Player O Wins", result);
        }
    }
}