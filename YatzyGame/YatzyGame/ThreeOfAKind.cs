using System.Linq;
using YatzyGame;

namespace Yatzy
{
    public class ThreeOfAKind : Roll
    {

        public ThreeOfAKind(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculateThreeOfAKindCategory();
        }

        private int CalculateThreeOfAKindCategory()
        {
            var tripleList = DiceRolls.GroupBy(dice => dice)
                .Where(groupedDice => groupedDice.Count() == NumberOfDiceInATriple)
                .Select(s => s.Key);

            return tripleList.Any() ? NumberOfDiceInATriple * (int)tripleList.Single() : 0;
        }
    }
}