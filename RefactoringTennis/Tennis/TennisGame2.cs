namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int playerOnePoints;
        private int playerTwoPoints;

        private string playerOneResult = "";
        private string playerTowresult = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var totalScore = "";
            if (playerOnePoints == playerTwoPoints && playerOnePoints < 3)
            {
                if (playerOnePoints == 0) totalScore = "Love";
                if (playerOnePoints == 1) totalScore = "Fifteen";
                if (playerOnePoints == 2) totalScore = "Thirty";
                totalScore += "-All";
            }
            if (playerOnePoints == playerTwoPoints && playerOnePoints > 2)
                totalScore = "Deuce";

            if (playerOnePoints > 0 && playerTwoPoints == 0)
            {
                if (playerOnePoints == 2) playerOneResult = "Thirty";
                if (playerOnePoints == 3) playerOneResult = "Forty";

                playerTowresult = "Love";
                totalScore = playerOneResult + "-" + playerTowresult;
            }
            if (playerTwoPoints > 0 && playerOnePoints == 0)
            {
                if (playerTwoPoints == 1) playerTowresult = "Fifteen";
                if (playerTwoPoints == 2) playerTowresult = "Thirty";
                

                playerOneResult = "Love";
                totalScore = playerOneResult + "-" + playerTowresult;
            }

            if (playerOnePoints > playerTwoPoints && playerOnePoints < 4)
            {
                if (playerOnePoints == 1) playerOneResult = "Fifteen";
                if (playerOnePoints == 2) playerOneResult = "Thirty";
                if (playerOnePoints == 3) playerOneResult = "Forty";
                if (playerTwoPoints == 1) playerTowresult = "Fifteen";
                if (playerTwoPoints == 2) playerTowresult = "Thirty";
                if (playerTwoPoints == 3) playerTowresult = "Forty";

                totalScore = playerOneResult + "-" + playerTowresult;
            }
            if (playerTwoPoints > playerOnePoints && playerTwoPoints < 4)
            {
                if (playerTwoPoints == 2) playerTowresult = "Thirty";
                if (playerTwoPoints == 3) playerTowresult = "Forty";
                if (playerOnePoints == 1) playerOneResult = "Fifteen";
                if (playerOnePoints == 2) playerOneResult = "Thirty";

                totalScore = playerOneResult + "-" + playerTowresult;
            }

            totalScore = AdvantageResult(totalScore);

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
    }
}