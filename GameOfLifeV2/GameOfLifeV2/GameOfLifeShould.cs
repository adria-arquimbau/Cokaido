using System.Collections.Generic;
using Xunit;

namespace GameOfLifeV2
{
    public class GameOfLifeShould
    {
        [Fact]
        public void KillACellWithoutNeighbors()
        {
            Ecosystem expectedEcosystem = new Ecosystem();

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }
    }
}