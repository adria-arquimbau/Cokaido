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
        public void KeepAliveAllCellsWhenFirstGenerationIsASquare()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(0,0);
            expectedEcosystem.AddCell(0,1);     
            expectedEcosystem.AddCell(1,1);
            expectedEcosystem.AddCell(1,0);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);
            ecosystem.AddCell(0,1);
            ecosystem.AddCell(1,1);
            ecosystem.AddCell(1,0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KeepRevivedCellsWhenYouIntroduceThreeInARow()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(1,0);
            expectedEcosystem.AddCell(1,1);
            expectedEcosystem.AddCell(1,-1);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0,0);
            ecosystem.AddCell(2,0);
            ecosystem.AddCell(1, 0);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void ReturnNewPatternWhenYouIntroduceABeaconPattern()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(0,0);
            expectedEcosystem.AddCell(0,1);
            expectedEcosystem.AddCell(1,0);
            expectedEcosystem.AddCell(2,3);
            expectedEcosystem.AddCell(3,2);
            expectedEcosystem.AddCell(3,3);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(0, 1);
            ecosystem.AddCell(1, 1);
            ecosystem.AddCell(1, 0);
            ecosystem.AddCell(2,2);
            ecosystem.AddCell(2,3);
            ecosystem.AddCell(3,2);
            ecosystem.AddCell(3,3);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            Assert.Equal(expectedEcosystem,ecosystem);
        }

        [Fact]
        public void ReturnSecondEvolvePatternWhenYouIntroduceABeaconPattern()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(0, 0);
            expectedEcosystem.AddCell(0, 1);
            expectedEcosystem.AddCell(1, 0);
            expectedEcosystem.AddCell(2, 3);
            expectedEcosystem.AddCell(3, 2);
            expectedEcosystem.AddCell(3, 3);
            expectedEcosystem.AddCell(1, 1);
            expectedEcosystem.AddCell(2, 2);
            

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(0, 1);
            ecosystem.AddCell(1, 1);
            ecosystem.AddCell(1, 0);
            ecosystem.AddCell(2, 2);
            ecosystem.AddCell(2, 3);
            ecosystem.AddCell(3, 2);
            ecosystem.AddCell(3, 3);

            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Play();

            GameOfLife gameOfLife2 = new GameOfLife(ecosystem);

            gameOfLife2.Play();

            Assert.Equal(expectedEcosystem, ecosystem);
        }
    }
}