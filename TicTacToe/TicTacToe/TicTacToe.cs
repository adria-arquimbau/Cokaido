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

            if (CheckWinConditionByColumn(token))
            {
                return $"Player {token.ToString()} Wins";
            }
            
            return "Next";
        }

        private bool CheckWinConditionByColumn(Token token)
        {
            for (var column = 0; column <= 2; column++)
            {
                if (_board[0, column] == token && _board[1, column] == token && _board[2, column] == token)
                {
                    return true;
                }
            }

            return false;
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
