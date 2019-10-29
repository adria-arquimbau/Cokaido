using System;
using System.Collections.Generic;
using YatzyGame;

namespace Yatzy
{
    public abstract class Roll
    {
        protected const int NumberOfDiceInATriple = 3;
        protected const int NumberOfDiceInAPair = 2;
        protected const int NumberOfDiceInACuadruple = 4;
        protected readonly Dice[] DiceRolls;

        protected Roll(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5)
        {
            DiceRolls = new Dice[5];
            DiceRolls[0] = dice1;
            DiceRolls[1] = dice2;
            DiceRolls[2] = dice3;
            DiceRolls[3] = dice4;
            DiceRolls[4] = dice5;
        }

        public abstract int GetScore();
    }
}