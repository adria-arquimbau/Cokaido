using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yatzy;

namespace YatzyGame
{
    class Chance : Roll
    {
        public Chance(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore() => CalculateChance();

        private int CalculateChance()
        {
            return DiceRolls.Sum(dice => (int)dice);
        }
    }
}
