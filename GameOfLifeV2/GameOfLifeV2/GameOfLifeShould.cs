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

        [Fact]
        public void KeepAliveMiddleCellWhenThereIsThreeCellsInARow()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(1,0);
                
            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);
            ecosystem.AddCell(1,0);
            ecosystem.AddCell(2,0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KeepAliveMiddleCellWhenIsThreeCellsInARow()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(5,6);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(5,5);
            ecosystem.AddCell(5,6);
            ecosystem.AddCell(5,7);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            Assert.Equal(expectedEcosystem, ecosystem);
        }
    }
}