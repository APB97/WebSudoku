using apb97.github.io.WebSudoku.Shared.General;
using apb97.github.io.WebSudoku.Shared.Sudoku;
using FluentAssertions;

namespace apb97.github.io.WebSudoku.Shared.Tests.Sudoku;

public class BoardTests
{
    private readonly Neighbors neighbors;
    private readonly CountingSolver countingSolver;
    private readonly Blanker blanker;

    public BoardTests()
    {
        neighbors = new();
        countingSolver = new(neighbors);
        blanker = new(countingSolver);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void MakeBlanks_GivenFilledBoard_And_LowTargetAmount_ClearsTargetAmountOfCells(int targetAmount)
    {
        Board board = new(countingSolver, new DefaultOptionOrder<int>(), blanker, targetAmount, 1);

        board.EmptyCells
            .Should()
            .HaveCount(targetAmount);
    }

    [Theory]
    [InlineData(30)]
    [InlineData(35)]
    [InlineData(45)]
    public void MakeBlanks_GivenFilledBoard_And_HighTargetAmount_ClearsAtMostTargetAmountOfCells(int targetAmount)
    {
        Board board = new(countingSolver, new DefaultOptionOrder<int>(), blanker, targetAmount, 1);

        board.EmptyCells
            .Should()
            .HaveCountLessThanOrEqualTo(targetAmount);
        board.EmptyCells
            .Should()
            .NotBeEmpty();
    }
}
