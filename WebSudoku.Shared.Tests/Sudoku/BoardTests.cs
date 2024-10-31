﻿using apb97.github.io.WebSudoku.Shared.General;
using apb97.github.io.WebSudoku.Shared.Sudoku;
using FluentAssertions;

namespace apb97.github.io.WebSudoku.Shared.Tests.Sudoku;

public class BoardTests
{
    private readonly Neighbors neighbors;
    private readonly CountingSolver countingSolver;
    private readonly Blanker blanker;
    private readonly Validator validator;

    public BoardTests()
    {
        neighbors = new();
        countingSolver = new(neighbors);
        blanker = new(countingSolver);
        validator = new(neighbors);
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

    [Fact]
    public void ThrowIfInvalidDimensions_GivenMultidimensionalArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Board.ThrowIfInvalidDimensions(new int[Board.BoardSize, Board.BoardSize], "Board"));
    }

    [Fact]
    public void ThrowIfInvalidDimensions_GivenSmallerArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Board.ThrowIfInvalidDimensions(new int[Board.BoardSize * Board.BoardSize - 1], "Board"));
    }

    [Fact]
    public void ThrowIfInvalidDimensions_GivenBiggerArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Board.ThrowIfInvalidDimensions(new int[Board.BoardSize * Board.BoardSize + 1], "Board"));
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 4)]
    [InlineData(8, 1)]
    [InlineData(4, 6)]
    public void ClearCell_GivenValidPosition_EmptiesCell(int row, int column)
    {
        var board = new Board(countingSolver, new DefaultOptionOrder<int>());

        board.ClearCell((row, column));

        board.GetValueAt((row, column))
            .Should()
            .Be(0);

        board.EmptyCells
            .Should()
            .Contain((row, column));
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(-9, 1)]
    [InlineData(9, -1)]
    [InlineData(9, -9)]
    [InlineData(-9, -9)]
    [InlineData(-1, -1)]
    public void ClearCell_GivenInvalidPosition_ThrowsIndexOutOfRangeException(int row, int column)
    {
        var board = new Board(countingSolver, new DefaultOptionOrder<int>());

        Assert.Throws<IndexOutOfRangeException>(() => board.ClearCell((row, column)));
    }

    [Fact]
    public void GetInvalidCells_GivenEmptyBoard_ReturnsNoInvalidCells()
    {
        var board = new Board();

        board.GetInvalidCells(validator)
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void GetInvalidCells_GivenSolvedBoard_ReturnsNoInvalidCells()
    {
        var board = new Board(countingSolver, new DefaultOptionOrder<int>());

        board.GetInvalidCells(validator)
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void GetInvalidCells_GivenBlankedBoard_ReturnsNoInvalidCells()
    {
        var board = new Board(countingSolver, new DefaultOptionOrder<int>(), blanker, 21, 1);

        board.GetInvalidCells(validator)
            .Should()
            .BeEmpty();
    }

    [Theory]
    [InlineData(1, 1, 2, 2, 7)]
    public void GetInvalidCells_GivenEmptyBoard_With2ConflictinFilledCells_ReturnsTheirPositions(int row1, int column1, int row2, int column2, int value)
    {
        var board = new Board();

        board.FillCell((row1,  column1), value);
        board.FillCell((row2,  column2), value);

        board.GetInvalidCells(validator)
            .Should()
            .Contain((row1, column1))
            .And
            .Contain((row2, column2))
            .And
            .HaveCount(2);
    }

    [Theory]
    [InlineData(7)]
    public void GetInvalidCells_GivenBlanckedBoard_WithConflictinFilledCells_ReturnsTheirPositions(int value)
    {
        var board = new Board(countingSolver, new DefaultOptionOrder<int>(), blanker, 21, 1);

        var emptyCells = board.EmptyCells.Take(4).ToList();
        foreach (var emptyCell in emptyCells)
        {
            board.FillCell(emptyCell, value);
        }

        board.GetInvalidCells(validator)
            .Should()
            .HaveCountGreaterThan(1)
            .And
            .HaveCountLessThanOrEqualTo(4)
            .And
            .AllSatisfy(p => emptyCells.Contains(p));
    }
}
