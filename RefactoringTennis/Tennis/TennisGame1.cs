using System;
using System.Collections;
using System.Collections.Generic;

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
            if (playerName == "player1") playerOneScore += 1;
            if (playerName != "player1") playerTwoScore += 1;
        }

        public string GetScore()
        {
            var advantageScore = playerOneScore >= 4 || playerTwoScore >= 4;
            string score = String.Empty;

            if (playerOneScore == playerTwoScore) return score = EqualResult();

            if (advantageScore) return score = AdvantageResult();

            return score = RegularScoreCalculate(score);
        }

        private string RegularScoreCalculate(string score)
        {
            string playerOneResult = String.Empty;
            string playerTwoResult = String.Empty;
            string totalScore;
            var scoreDictionary = new Dictionary<int, string>
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };
            playerOneResult = scoreDictionary[playerOneScore];
            playerTwoResult = scoreDictionary[playerTwoScore];
            totalScore = playerOneResult + "-" + playerTwoResult;
            return totalScore;
        }

        private string AdvantageResult()
        {
            string score;
            var advantageScore = playerOneScore - playerTwoScore;
            if (advantageScore == 1) return score = "Advantage player1";
            if (advantageScore == -1) return score = "Advantage player2";
            if (advantageScore >= 2) return score = "Win for player1";
            return score = "Win for player2";
        }

        private string EqualResult()
        {
            string score;
            if (playerOneScore == 0) return score = "Love-All";
            if (playerOneScore == 1) return score = "Fifteen-All";
            if (playerOneScore == 2) return score = "Thirty-All";
            return score = "Deuce";
        }
    }
}