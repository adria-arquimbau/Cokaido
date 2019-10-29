namespace Yatzy
{
    public class YatzyGame
    {
        private readonly PlayerRolls _rollPlayerOne = new PlayerRolls();
        private readonly PlayerRolls _rollPlayerTwo = new PlayerRolls();
        
        public int CalculateScore(Player player)
        {
            return player == Player.One ? _rollPlayerOne.GetTotalScore() : _rollPlayerTwo.GetTotalScore();
        }

        public void AddRoll(Roll roll)
        {
            if (IsPlayerTwoTurn())
            {
                _rollPlayerTwo.AddRoll(roll);
                return;
            }

            _rollPlayerOne.AddRoll(roll);
        }

        private bool IsPlayerOneTurn()
        {
            return _rollPlayerOne.GetTurn() == _rollPlayerTwo.GetTurn();
        }

        private bool IsPlayerTwoTurn()
        {
            return _rollPlayerOne.GetTurn() != _rollPlayerTwo.GetTurn();
        }
    }
}