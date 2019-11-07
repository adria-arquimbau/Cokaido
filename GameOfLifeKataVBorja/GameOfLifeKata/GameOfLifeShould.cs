using System;
using Xunit;

namespace GameOfLifeKata
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

        [Fact]
        public void KillCellsWithOneNeighbor()
        {
            Ecosystem expectedEcosystem = new Ecosystem();

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(0, 1);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KillCellWithMoreThan3Neighbors()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(1, 0);
            expectedEcosystem.AddCell(0, 1);
            expectedEcosystem.AddCell(2, 1);
            expectedEcosystem.AddCell(1, 2);


            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(0, 2);
            ecosystem.AddCell(1, 1);
            ecosystem.AddCell(2, 0);
            ecosystem.AddCell(2, 2);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KeepAliveMiddleCellWhenTheres3CellsInARow()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(1, -1);
            expectedEcosystem.AddCell(1, 0);
            expectedEcosystem.AddCell(1, 1);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(1, 0);
            ecosystem.AddCell(2, 0);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KeepAliveMiddleCellWhenTheres3CellsInAColumn()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(-1, 1);
            expectedEcosystem.AddCell(0, 1);
            expectedEcosystem.AddCell(1, 1);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(0, 1);
            ecosystem.AddCell(0, 2);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void KeepAliveMiddleCellWhenTheres3CellsInDiagonal()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(1, 1);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(1, 1);
            ecosystem.AddCell(2, 2);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }

        [Fact]
        public void ReviveACellWhenTheres3CellsNextToIt()
        {
            Ecosystem expectedEcosystem = new Ecosystem();
            expectedEcosystem.AddCell(0, 0);
            expectedEcosystem.AddCell(1, 0);
            expectedEcosystem.AddCell(1, 1);
            expectedEcosystem.AddCell(0, 1);

            Ecosystem ecosystem = new Ecosystem();
            ecosystem.AddCell(0, 0);
            ecosystem.AddCell(1, 0);
            ecosystem.AddCell(1, 1);
            GameOfLife gameOfLife = new GameOfLife(ecosystem);

            gameOfLife.Evolve();

            Assert.Equal(expectedEcosystem, ecosystem);
        }
    }
}
