using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeV2
{
    public class GameOfLifeShould
    {
        [Fact]
        public void ShowErrorMessageWhenThereIsNotACell()
        {
            var currentGeneration = new List<CellPosition>();

            GameOfLife gameOfLife = new GameOfLife(currentGeneration);

            Assert.Throws<Exception>(() => gameOfLife.Play());
        }

        [Fact]
        public void ReturnNullIfCurrentGenerationIsOneCell()
        {
            var currentGeneration =  new List<CellPosition>{ new CellPosition(0,0) };

            GameOfLife gameOfLife = new GameOfLife(currentGeneration);

            var result = gameOfLife.Play();

            Assert.Null(result);
        }

        [Fact]
        public void ReturnNullIfCurrentGenerationAreTwoCells()
        {
            var currentGeneration =  new List<CellPosition>{ new CellPosition(0,0), new CellPosition(0,1) };
            GameOfLife gameOfLife = new GameOfLife(currentGeneration);
            var result = gameOfLife.Play();
            Assert.Null(result);
        }
    }
}