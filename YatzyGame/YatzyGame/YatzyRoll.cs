using System.Linq;
using YatzyGame;

namespace Yatzy
{
    public class YatzyRoll : Roll
    {
        public YatzyRoll(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculateYatzy();
        }

        private int CalculateYatzy()
        {
            return DiceRolls.All(dice => dice == DiceRolls.First()) ? 50 : 0;
        }
    }
}