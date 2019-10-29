using System.Linq;
using YatzyGame;

namespace Yatzy
{
    public class PairRoll : Roll
    {

        public PairRoll(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculatePairCategory();
        }

        private int CalculatePairCategory()
        {
            var pairList = DiceRolls.GroupBy(dice => dice)
                .Where(groupedDice => groupedDice.Count() == NumberOfDiceInAPair)
                .Select(s => s.Key);

            return pairList.Any() ? NumberOfDiceInAPair * (int) pairList.Max() : 0;
        }
    }
}