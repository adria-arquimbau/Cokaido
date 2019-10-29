using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int playerOneScore;
        private int playerTwoScore;
        private string _player1Name;
        private string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                playerOneScore += 1;
            if (playerName != "player1")
                playerTwoScore += 1;
        }

        public string GetScore()
        {
            string score = String.Empty;
            if (playerOneScore == playerTwoScore)
                return score = EqualScoreResult();

            if (playerOneScore >= 4 || playerTwoScore >= 4)
                return score = AdvantageScoreResult();

            return score = RegularScoreCalculate(score);
        }

        private string RegularScoreCalculate(string score)
        {
            int tempScore = 0;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = playerOneScore;
                if (i > 1)
                {
                    score += "-";
                    tempScore = playerTwoScore;
                }

                if (tempScore == 0) score += "Love";
                if (tempScore == 1) score += "Fifteen";
                if (tempScore == 2) score += "Thirty";
                if (tempScore == 3) score += "Forty";
            }

            return score;
        }

        private string AdvantageScoreResult()
        {
            string score;
            var advantageScore = playerOneScore - playerTwoScore;
            if (advantageScore == 1) return score = "Advantage player1";
            if (advantageScore == -1) return score = "Advantage player2";
            if (advantageScore >= 2) return score = "Win for player1";
            return score = "Win for player2";
        }

        private string EqualScoreResult()
        {
            string score;
            if (playerOneScore == 0) return score = "Love-All";
            if (playerOneScore == 1) return score = "Fifteen-All";
            if (playerOneScore == 2) return score = "Thirty-All";
            return score = "Deuce";
        }
    }
}