using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private Token _lastToken;
        private int? _lastPositionX;
        private int? _lastPositionY;

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

            if (_lastPositionX == positionX && _lastPositionY == positionY)
            {
                throw new Exception();
            }

            _lastPositionX = positionX;
            _lastPositionY = positionY;
            _lastToken = token;
        }
    }
}
