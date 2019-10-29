using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class PlayerRolls
    {
        private List<Roll> _rolls;

        public PlayerRolls()
        {
            _rolls = new List<Roll>();
        }

        public int GetTurn()
        {
            return _rolls.Count;
        }

        public void AddRoll(Roll roll)
        {
            _rolls.Add(roll);
        }
        public int GetTotalScore()
        {
            return _rolls.Sum(s => s.GetScore());
        }
    }
}