using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private string _lastToken;

        public void Play(string token)
        {
            if (string.IsNullOrEmpty(_lastToken) && token == "O")
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
