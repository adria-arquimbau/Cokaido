using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private Token _lastToken;
        private Token[,] board = new Token[3,3];

        public void Play(Token token, int positionX, int positionY)
        {
            if (_lastToken == Token.Unknown && token == Token.O)
            {
                throw new Exception();
            }

            if (_lastToken == token)
            {
                throw new Exception();
            }

            if (board[positionX,positionY] != Token.Unknown)
            {
                throw new Exception();
            }

            board[positionX, positionY] = token;
            _lastToken = token;
        }
    }
}
