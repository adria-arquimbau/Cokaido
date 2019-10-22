using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private Token _lastToken;
        private Token[,] _board = new Token[3,3];

        public string Play(Token token, int positionX, int positionY)
        {
            ValidateFirstPlaceIsAnX(token);

            ValidateAlternationOfTokens(token);

            ValidateThePositionIsEmpty(positionX, positionY);

            SaveLastPlayPlayed(token, positionX, positionY);

            if (_board[0,0] == Token.X && _board[1,0] == Token.X && _board[2,0] == Token.X)
            {
                return "Player X Wins";
            }

            return "Next";
        }

        private void SaveLastPlayPlayed(Token token, int positionX, int positionY)
        {
            _board[positionX, positionY] = token;
            _lastToken = token;
        }

        private void ValidateAlternationOfTokens(Token token)
        {
            if (_lastToken == token)
            {
                throw new Exception();
            }
        }

        private void ValidateThePositionIsEmpty(int positionX, int positionY)
        {
            if (_board[positionX, positionY] != Token.Unknown)
            {
                throw new Exception();
            }
        }

        private void ValidateFirstPlaceIsAnX(Token token)
        {
            if (_lastToken == Token.Unknown && token == Token.O)
            {
                throw new Exception();
            }
        }
    }
}
