using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private Token _lastToken;

        public void Play(Token token)
        {
            if (_lastToken == Token.Unknown && token == Token.O)
            {
                throw new Exception();
            }

            if (_lastToken == token)
            {
                throw new Exception();
            }

            _lastToken = token;
        }
    }
}
