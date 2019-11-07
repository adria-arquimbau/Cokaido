using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeV2
{
    public class GameOfLifeShould
    {
        [Fact]
        public void ReturnNullIfNumberOfCellsIsZero()
        {
            Ecosystem ecosystem = new Ecosystem();

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            Assert.Throws<Exception>(()=>gameOfLife.Play());
        }

        [Fact]
        public void ReturnNullIfNumberOfCellsIsOne()
        {
            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            Assert.Throws<Exception>(() => gameOfLife.Play());
        }
    }
}