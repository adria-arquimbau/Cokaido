using System.Linq;
using YatzyGame;

namespace Yatzy
{
    public class SmallStraight : Roll
    {

        public SmallStraight(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculateSmallStraight();
        }

        private int CalculateSmallStraight()
        {
            if (DiceRolls.Distinct().Count() == 5 && !DiceRolls.Contains(Dice.Six))
                return 15;

            return 0;
        }
    }
}