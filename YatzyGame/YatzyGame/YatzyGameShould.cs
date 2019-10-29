using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using Xunit;
using YatzyGame;

namespace Yatzy
{
    public class YatzyGameShould
    {
        private YatzyGame _yatzyGame;

        public YatzyGameShould()
        {
            _yatzyGame = new YatzyGame();
        }

        [Fact]
        public void ScoreFiveGivenFiveDiceOfOneAndTheCategoryIsChance()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(5, result);
        }

        [Fact]
        public void ScoreFifteenGivenA1A2A3A4A5AndTheChanceCategory()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Two, Dice.Three, Dice.Four, Dice.Five));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(15, result);
        }

        [Fact]
        public void ScoreFiftyGivenFiveOnesAndTheCategoryIsYatzy()
        {
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(50, result);
        }

        [Fact]
        public void ScoreZeroWhenNotAllDiceAreTheSameAndTheCategoryIsYatzy()
        {
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.Two, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ScoreEightWhenTwoOfFiveDiceAreFourAndTheCategoryIsPair()
        {
            _yatzyGame.AddRoll(new PairRoll(Dice.One, Dice.Two, Dice.Three, Dice.Four, Dice.Four));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(8, result);
        }

        [Fact]
        public void ScoreTenWhenTwoOfFiveDiceAreFiveAndTheCategoryIsPair()
        {
            _yatzyGame.AddRoll(new PairRoll(Dice.One, Dice.Two, Dice.Three, Dice.Five, Dice.Five));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(10, result);
        }

        [Fact]
        public void ScoreEightWhenGivenAPairFoursAPairOfThreesAndAOneAndTheCategoryIsPair()
        {
            _yatzyGame.AddRoll(new PairRoll(Dice.One, Dice.Three, Dice.Three, Dice.Four, Dice.Four));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(8, result);
        }

        [Fact]
        public void ScoreZeroWhenThereIsNotAnExactPairAndTheCategoryIsPair()
        {
            _yatzyGame.AddRoll(new PairRoll(Dice.One, Dice.Three, Dice.Three, Dice.Three, Dice.Four));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ShowScoreFromPlayerOneAfterPlayerTwoThrows()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(5, result);
        }

        [Fact]
        public void ShowScoreFromPlayerTwoAfterPlayerTwoThrows()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.Two);

            Assert.Equal(9, result);
        }

        [Fact]
        public void ShowScoreFromPlayerOneAfterTwoRounds()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new PairRoll(Dice.Five, Dice.Five, Dice.One, Dice.Two, Dice.Three));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(15, result);
        }

        [Fact]
        public void ShowScoreFromPlayerTwoAfterSixRounds()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new PairRoll(Dice.Five, Dice.Five, Dice.One, Dice.Two, Dice.Three));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.Two, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.Two);

            Assert.Equal(109, result);
        }

        [Fact]
        public void ShowScoreFromPlayerOneAfterNineRounds()
        {
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new PairRoll(Dice.Five, Dice.Five, Dice.One, Dice.Two, Dice.Three));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.Two, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new YatzyRoll(Dice.One, Dice.One, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));
            _yatzyGame.AddRoll(new Chance(Dice.One, Dice.Five, Dice.One, Dice.One, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(33, result);
        }

        [Fact]
        public void ScoreNineGivenThreeDiceOfThreeAndTheCategoryIsThreeOfAKind()
        {
            _yatzyGame.AddRoll(new ThreeOfAKind(Dice.Three, Dice.One, Dice.Three, Dice.Three, Dice.Six));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(9, result);
        }

        [Fact]
        public void ScoreEightGivenFourDiceOfTwoAndTheCategoryIsFourOfAKind()
        {
            _yatzyGame.AddRoll(new FourOfAKind(Dice.Two, Dice.Two, Dice.Three, Dice.Two, Dice.Two));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(8, result);
        }

        [Fact]
        public void ScoreElevenGivenThreeDiceOfThreeAndTwoDiceOfOneAndTheCategoryIsFullHouse()
        {
            _yatzyGame.AddRoll(new FullHouse(Dice.Three, Dice.Three, Dice.One, Dice.Three, Dice.One));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(11, result);
        }

        [Fact]
        public void ScoreZeroGivenThreeDiceOfThreeAndOneDiceOfOneAndOneDiceOfTwoTheCategoryIsFullHouse()
        {
            _yatzyGame.AddRoll(new FullHouse(Dice.Three, Dice.Three, Dice.One, Dice.Three, Dice.Two));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ScoreFiveTeenGivenSmallStraightDicesAndTheCategoryIsSmallStraight()
        {
            _yatzyGame.AddRoll(new SmallStraight(Dice.One, Dice.Two, Dice.Three, Dice.Four, Dice.Five));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(15, result);
        }

        [Fact]
        public void ScoreTwentyGivenLargeStraightDicesAndTheCategoryIsLargeStraight()
        {
            _yatzyGame.AddRoll(new LargeStraight(Dice.Two, Dice.Three, Dice.Four, Dice.Five, Dice.Six));

            var result = _yatzyGame.CalculateScore(Player.One);

            Assert.Equal(20, result);
        }
    }
}
