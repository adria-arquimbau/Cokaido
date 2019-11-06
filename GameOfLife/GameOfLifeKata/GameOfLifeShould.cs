using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeChallenge
{
    public class GameOfLifeShould
    {
        [Fact]
        public void ShowErrorMessageWhenThereIsNoCell()
        {
            var cellPositions = new List<CellPosition> {};

            GameOfLife gameOfLife = new GameOfLife(cellPositions);

            Assert.Throws<Exception>(() => gameOfLife.Play());
        }

        [Fact]
        public void EndIfOnlyOneCellIsIntroduced()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 1) };
            GameOfLife gameOfLife = new GameOfLife(cellPositions);

            var result = gameOfLife.Play();

            Assert.Null(result);
        }

        [Fact]
        public void EndIfOnlyTwoCellsAreIntroduced()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 1), new CellPosition(1, 1) };
            GameOfLife gameOfLife = new GameOfLife(cellPositions);

            var result = gameOfLife.Play();

            Assert.Null(result);
        }

        [Fact]
        public void ReturnAliveCellsOnAnSquarePattern()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(1, 0), new CellPosition(1, 1) };
            GameOfLife gameOfLife = new GameOfLife(cellPositions);

            var result = gameOfLife.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(1, 0), new CellPosition(1, 1) }, result);
        }

        [Fact]
        public void ReturnAliveCellsAfterTwoGenerationsOnAnSquarePattern()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(1, 0), new CellPosition(1, 1) };

            GameOfLife gameOfLifeFirstRound = new GameOfLife(cellPositions);

            var resultFirstRound = gameOfLifeFirstRound.Play();

            GameOfLife gameOfLifeSecondRound = new GameOfLife(resultFirstRound);

            var resultSecondRound = gameOfLifeSecondRound.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(1, 0), new CellPosition(1, 1) }, resultSecondRound);
        }

        [Fact]
        public void ReturnAliveCellsAndRevivedCellsOnAThreeOnHoritzontalLineCellsPattern()
        {
            var cellPosition = new List<CellPosition> { new CellPosition(0,0), new CellPosition(0,1), new CellPosition(0,2) };

            GameOfLife gameOfLife = new GameOfLife(cellPosition);

            var result = gameOfLife.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(0,1), new CellPosition(1,1), new CellPosition(-1,1) }, result );
        }

        [Fact]
        public void ReturnAliveCellsAndRevivedCellsOnAThreeOnVerticalLineCellsPattern()
        {
            var cellPosition = new List<CellPosition> { new CellPosition(1, 1), new CellPosition(2, 1), new CellPosition(3, 1) };

            GameOfLife gameOfLife = new GameOfLife(cellPosition);

            var result = gameOfLife.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(2, 1), new CellPosition(2, 2), new CellPosition(2, 0) }, result);
        }

        [Fact]
        public void ReturnNewPatternAfterTwoGenerationsOnThreeVerticalLinePattern()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(0, 2)};

            GameOfLife gameOfLifeFirstRound = new GameOfLife(cellPositions);

            var resultFirstRound = gameOfLifeFirstRound.Play();

            GameOfLife gameOfLifeSecondRound = new GameOfLife(resultFirstRound);

            var resultSecondRound = gameOfLifeSecondRound.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(0, 1), new CellPosition(0, 2), new CellPosition(0, 0)}, resultSecondRound);
        }

        [Fact]
        public void ReturnNewPatternAfterThreeGenerationsOnFourVerticalLinePattern()
        {
            var cellPositions = new List<CellPosition> { new CellPosition(0, 0), new CellPosition(0, 1), new CellPosition(0, 2), new CellPosition(0, 3) };

            GameOfLife gameOfLifeFirstRound = new GameOfLife(cellPositions);

            var resultFirstRound = gameOfLifeFirstRound.Play();

            GameOfLife gameOfLifeSecondRound = new GameOfLife(resultFirstRound);

            var resultSecondRound = gameOfLifeSecondRound.Play();

            GameOfLife gameOfLifeThirdRound = new GameOfLife(resultSecondRound);

            var resultThirdRound = gameOfLifeThirdRound.Play();

            Assert.Equal(new List<CellPosition> { new CellPosition(1, 1), new CellPosition(-1,1), new CellPosition(1,2), new CellPosition(-1,2), new CellPosition(0,0), new CellPosition(0,3) }, resultThirdRound);
        }
    }
}
