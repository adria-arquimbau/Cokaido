using System.Linq;
using System.Security.Cryptography.X509Certificates;
using YatzyGame;

namespace Yatzy
{
    public class FullHouse : Roll
    {
        public FullHouse(Dice dice1, Dice dice2, Dice dice3, Dice dice4, Dice dice5) : base(dice1, dice2, dice3, dice4, dice5)
        {
        }

        public override int GetScore()
        {
            return CalculateFullHouseCategory();
        }

        private int CalculateFullHouseCategory()
        {
            var pairList = DiceRolls.GroupBy(dice => dice)
                .Where(groupedDice => groupedDice.Count() == NumberOfDiceInAPair)
                .Select(s => s.Key);

            var tripleList = DiceRolls.GroupBy(dice => dice)
                .Where(groupedDice => groupedDice.Count() == NumberOfDiceInATriple)
                .Select(s => s.Key);

            var pairListresult = pairList.Any() ? NumberOfDiceInAPair * (int) pairList.Single() : 0;

            var tripleListresult = tripleList.Any() ? NumberOfDiceInATriple * (int) tripleList.Single() : 0;

            if(pairList.Any() && tripleList.Any())
                return pairListresult + tripleListresult;

            return 0;
        }
    }
}