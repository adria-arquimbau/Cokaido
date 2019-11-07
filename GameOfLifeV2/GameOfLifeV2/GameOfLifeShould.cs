using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeV2
{
    public class GameOfLifeShould
    {
        [Fact]
        public void ThrowExceptionIfNumberOfCellsIsZero()
        {
            Ecosystem ecosystem = new Ecosystem();

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            Assert.Throws<Exception>(()=>gameOfLife.Play());
        }

        [Fact]
        public void ThrowExceptionIfNumberOfCellsIsOne()
        {
            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            Assert.Throws<Exception>(() => gameOfLife.Play());
        }

        [Fact]
        public void ThrowExceptionIfNumberOfCellsIsTwo()
        {
            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);
            ecosystem.AddCell(0,1);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            Assert.Throws<Exception>(() => gameOfLife.Play());
        }
    }
}