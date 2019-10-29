using System.Linq;
using YatzyGame;

namespace Yatzy
{
    public class FourOfAKind : Roll
    {
        public FourOfAKind(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculateFourOfAKindCategory();
        }

        private int CalculateFourOfAKindCategory()
        {
            var cuadrupleList = DiceRolls.GroupBy(dice => dice)
                .Where(groupedDice => groupedDice.Count() == NumberOfDiceInACuadruple)
                .Select(s => s.Key);

            return cuadrupleList.Any() ? NumberOfDiceInACuadruple * (int)cuadrupleList.Single() : 0;
        }
    }
}