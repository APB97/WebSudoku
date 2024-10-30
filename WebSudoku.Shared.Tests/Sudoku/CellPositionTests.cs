using apb97.github.io.WebSudoku.Shared.Sudoku;
using FluentAssertions;

namespace apb97.github.io.WebSudoku.Shared.Tests.Sudoku;

public class CellPositionTests
{
    [Fact]
    public void InitAllowsAssignment()
    {
        var initedCell = new CellPosition() { Column = 1, Row = 2 };

        initedCell.Column
            .Should()
            .Be(1);

        initedCell.Row
            .Should()
            .Be(2);
    }
}
