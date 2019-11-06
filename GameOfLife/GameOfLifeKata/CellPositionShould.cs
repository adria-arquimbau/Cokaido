using System.Collections.Generic;
using Xunit;

namespace GameOfLifeChallenge
{
    public class CellPositionShould
    {
        [Fact]
        public void ReturnNeighborCellsWhenIntroducingOneCell()
        {
            CellPosition cellPosition = new CellPosition(0,0);

            var result = cellPosition.GetNeighbors();

            Assert.Equal(new List<CellPosition> { new CellPosition(1, 0), new CellPosition(-1, 0), new CellPosition(0, 1), new CellPosition(0, -1), new CellPosition(1, 1), new CellPosition(-1, -1), new CellPosition(1, -1), new CellPosition(-1, 1) }, result);
        }
    }
}
