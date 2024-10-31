using apb97.github.io.WebSudoku.Pages;
using FluentAssertions;

namespace apb97.github.io.WebSudoku.Tests.Pages;

public class SudokuTests
{
    [Theory]
    [InlineData(1, +1)]
    [InlineData(2, +1)]
    [InlineData(3, +1)]
    [InlineData(4, +1)]
    [InlineData(5, +1)]
    [InlineData(6, +1)]
    [InlineData(7, +1)]
    [InlineData(8, +1)]
    [InlineData(2, -1)]
    [InlineData(3, -1)]
    [InlineData(4, -1)]
    [InlineData(5, -1)]
    [InlineData(6, -1)]
    [InlineData(7, -1)]
    [InlineData(8, -1)]
    [InlineData(9, -1)]
    public void GivenValueAndIncrementWithSumBetween1AndSudokuSize_ReturnsSumOfInputs(int number, int increment)
    {
        Sudoku.WrapAroundBetweenEdges(number, increment)
            .Should()
            .Be(number + increment);
    }

    [Theory]
    [InlineData(1, -1, 9)]
    public void GivenValueAndIncrementWithSumLessThan1_ReturnsSumWrappedAround(int number, int increment, int expectedValue)
    {
        Sudoku.WrapAroundBetweenEdges(number, increment)
            .Should()
            .Be(expectedValue);
    }

    [Theory]
    [InlineData(9, +1, 1)]
    public void GivenValueAndIncrementWithSumAboveSudokuSize_ReturnsSumWrappedAround(int number, int increment, int expectedValue)
    {
        Sudoku.WrapAroundBetweenEdges(number, increment)
            .Should()
            .Be(expectedValue);
    }

    [Theory]
    [InlineData(9, +123)]
    [InlineData(0, -321)]
    [InlineData(123, +321)]
    [InlineData(321, -123)]
    [InlineData(-123, +1)]
    [InlineData(321, -1)]
    public void GivenAnyValueOrAnyIncrementOutsideOfRange1to9_ThrowsArgumentOutOfRangeException(int number, int increment)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Sudoku.WrapAroundBetweenEdges(number, increment));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void GivenAnyValueAndNoIncrement_ReturnsOriginalValue(int number)
    {
        Sudoku.WrapAroundBetweenEdges(number, 0)
            .Should()
            .Be(number);
    }
}