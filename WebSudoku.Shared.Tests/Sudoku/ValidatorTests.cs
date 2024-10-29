using apb97.github.io.WebSudoku.Shared.Sudoku;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace apb97.github.io.WebSudoku.Shared.Tests.Sudoku;

public class ValidatorTests
{
    private static readonly Validator validator;

    static ValidatorTests()
    {
        validator = new Validator(new Neighbors());
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 8)]
    [InlineData(8, 0)]
    [InlineData(8, 8)]
    [InlineData(5, 5)]
    public void GivenEmptyBoard_DefaultEmptyCellValueIsValid(int row, int column)
    {
        validator.IsValid(new Board(), (row, column))
            .Should()
            .BeTrue();
    }

    [Theory]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, 5)]
    [InlineData(0, 0, 9)]
    public void GivenEmptyBoard_EnteredSingleValueIsValid(int row, int column, int value)
    {
        Board emptyboard = new();
        emptyboard.FillCell((row, column), value);
        
        validator.IsValid(emptyboard, (row, column))
            .Should()
            .BeTrue();
    }

    [Theory]
    [MemberData(nameof(GivenBoardWithNearlyFilledColumn_OnlyRemainingValueIsValid_Data))]
    public void GivenBoardWithNearlyFilledColumn_OnlyRemainingValueIsValid(int row, int column, int value, int[] valuesInColummn, bool expectedValue)
    {
        Board board = new();
        int valueIndex = 0;
        foreach (var currentRow in Enumerable.Range(0, 9).Where(r => r != row))
        {
            board.FillCell((currentRow, column), valuesInColummn[valueIndex++]);
        }

        board.FillCell((row, column), value);

        validator.IsValid(board, (row, column))
            .Should().Be(expectedValue);
    }

    [ExcludeFromCodeCoverage]
    public static TheoryData<int, int, int, int[], bool> GivenBoardWithNearlyFilledColumn_OnlyRemainingValueIsValid_Data()
    {
        return new TheoryData<int, int, int, int[], bool>
        {
            { 0, 0, 1, Enumerable.Range(1, 9).Where(v => v != 1).ToArray(), true },
            { 0, 0, 5, Enumerable.Range(1, 9).Where(v => v != 5).ToArray(), true },
            { 0, 0, 9, Enumerable.Range(1, 9).Where(v => v != 9).ToArray(), true },
            { 0, 0, 1, Enumerable.Range(1, 9).Where(v => v != 2).ToArray(), false },
            { 0, 0, 5, Enumerable.Range(1, 9).Where(v => v != 4).ToArray(), false },
            { 0, 0, 9, Enumerable.Range(1, 9).Where(v => v != 7).ToArray(), false },
            { 5, 5, 6, Enumerable.Range(1, 9).Where(v => v != 5).ToArray(), false },
            { 8, 8, 7, Enumerable.Range(1, 9).Where(v => v != 6).ToArray(), false }
        };
    }
}
