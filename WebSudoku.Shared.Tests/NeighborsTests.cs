using System;
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
        [MemberData(nameof(GetCellPositionsData))]
        public void Any_Given_Cell_Has_21_Neighbors_Including_Itself(int row, int column)
        {
            Assert.Equal(21, neighbors.CellNeighbors[row, column].Count);
        }

        [Theory, MemberData(nameof(GetRange0Through9))]
        public void Column_Has_9_Correct_Cells(int column)
        {
            var columnPositions = Neighbors.WithinColumn(column);

            Assert.Equal(9, columnPositions.Count());
            Assert.Equal(columnPositions.Select(position => position.Row), Enumerable.Range(0, 9));
            Assert.All(columnPositions, position => Assert.Equal(column, position.Column));
        }


        [Theory, MemberData(nameof(GetRange0Through9))]
        public void Row_Has_9_Correct_cells(int row)
        {
            var rowPositions = Neighbors.WithinRow(row);

            Assert.Equal(9, rowPositions.Count());
            Assert.Equal(rowPositions.Select(position => position.Column), Enumerable.Range(0, 9));
            Assert.All(rowPositions, position => Assert.Equal(row, position.Row));
        }

        public static TheoryData<int, int> GetCellPositionsData()
        {
            var positionsData = new TheoryData<int, int>();
            foreach (var cellPosition in GetCellPositions())
            {
                positionsData.Add(cellPosition.Row, cellPosition.Column);
            }
            return positionsData;
        }

        public static IEnumerable<CellPosition> GetCellPositions()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    yield return new CellPosition { Row = row, Column = column };
                }
            }
        }

        public static TheoryData<int> GetRange0Through9()
        {
            var data = new TheoryData<int>();
            foreach (var number in Enumerable.Range(0, 9))
            {
                data.Add(number);
            };
            return data;
        }
    }
}