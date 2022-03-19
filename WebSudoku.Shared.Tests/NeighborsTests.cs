using System.Collections.Generic;
using System.Linq;
using WebSudoku.Shared.Sudoku;
using Xunit;

namespace WebSudoku.Shared.Tests
{
    public class NeighborsTests
    {
        private static readonly Neighbors neighbors;

        static NeighborsTests()
        {
            neighbors = new Neighbors();
        }

        [Theory]
        [MemberData(nameof(GetCellPositions))]
        public void Any_Given_Cell_Has_21_Neighbors_Including_Itself(int row, int column)
        {
            Assert.Equal(21, neighbors.CellNeighbors[row, column].Count);
        }

        [Theory, MemberData(nameof(GetSquarePositions))]
        public void Each_Square_Has_9_Correct_Cells(int row, int column, IEnumerable<CellPosition> validPositions)
        {
            var squarePositions = Neighbors.WithinSquare(row, column);

            Assert.Equal(9, squarePositions.Count());
            Assert.All(squarePositions, position => Assert.Contains(position, validPositions));
        }

        private static IEnumerable<object[]> GetCellPositions()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    yield return new object[] { row, column };
                }
            }
        }

        private static IEnumerable<object[]> GetSquarePositions()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    List<CellPosition> validSquarePositions = new();
                    for (int squareRow = 0; squareRow < 3; squareRow++)
                    {
                        for (int squareColumn = 0; squareColumn < 3; squareColumn++)
                        {
                            validSquarePositions.Add(new CellPosition(row * 3 + squareRow, column * 3 + squareColumn));
                        }
                    }

                    yield return new object[] { row, column, validSquarePositions };
                }
            }
        }
    }
}