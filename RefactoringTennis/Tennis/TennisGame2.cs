using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int playerOnePoints;
        private int playerTwoPoints;

        private string playerOneResult = String.Empty;
        private string playerTwoResult = String.Empty;
        private string player1Name;
        private string player2Name;

        readonly Dictionary<int, string> scoreDictionary = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public TennisGame2(string player1Name, string player2Name)
        {
            PlayersNames(player1Name, player2Name);
        }

        public string GetScore()
        {
            var equalResultAnd3OrMorePoints = playerOnePoints == playerTwoPoints && playerOnePoints > 2;
            var regularScoreAndNoAdvantageNoDraw = playerOnePoints > playerTwoPoints && playerOnePoints < 4 || playerTwoPoints > playerOnePoints && playerTwoPoints < 4;
            var totalScore = String.Empty;

            if (playerOnePoints == playerTwoPoints) totalScore = EqualResult(totalScore);

            if (equalResultAnd3OrMorePoints) totalScore = "Deuce";

            if (regularScoreAndNoAdvantageNoDraw) totalScore = RegularResult();
            
            totalScore = AdvantageResult(totalScore);
            return totalScore;
        }
        
        private string RegularResult()
        {
            string totalScore;

            playerOneResult = scoreDictionary[playerOnePoints];
            playerTwoResult = scoreDictionary[playerTwoPoints];
            totalScore = playerOneResult + "-" + playerTwoResult;
            return totalScore;
        }


        private string EqualResult(string totalScore)
        {
            if (playerOnePoints == 0) totalScore = "Love";
            if (playerOnePoints == 1) totalScore = "Fifteen";
            if (playerOnePoints == 2) totalScore = "Thirty";
            if (playerOnePoints == 3) playerOneResult = "Forty";
            totalScore += "-All";
            return totalScore;
        }

        private string AdvantageResult(string totalScore)
        {
            if (playerOnePoints > playerTwoPoints && playerTwoPoints >= 3)
                totalScore = "Advantage player1";

            if (playerTwoPoints > playerOnePoints && playerOnePoints >= 3)
                totalScore = "Advantage player2";

            if (playerOnePoints >= 4 && playerTwoPoints >= 0 && (playerOnePoints - playerTwoPoints) >= 2)
                totalScore = "Win for player1";

            if (playerTwoPoints >= 4 && playerOnePoints >= 0 && (playerTwoPoints - playerOnePoints) >= 2)
                totalScore = "Win for player2";

            return totalScore;
        }

        public void WonPoint(string player)
        {
            if (player == "player1") playerOnePoints++;
            if (player == "player2") playerTwoPoints++;
        }

        private void PlayersNames(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }
    }
}