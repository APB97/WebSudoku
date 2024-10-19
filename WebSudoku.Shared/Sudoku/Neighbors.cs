namespace apb97.github.io.WebSudoku.Shared.Sudoku;

public class Neighbors
{
    public HashSet<CellPosition>[,] CellNeighbors { get; private set; }

    public Neighbors()
    {
        CellNeighbors = new HashSet<CellPosition>[9, 9];

        InitializeCellNeighbors(CreateSquareCellsArray());
    }

    private void InitializeCellNeighbors(IEnumerable<CellPosition>[,] squareCells)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                CellNeighbors[row, column] = new(WithinRow(row).Concat(WithinColumn(column)).Concat(squareCells[row / 3, column / 3]));
            }
        }
    }

    private static IEnumerable<CellPosition>[,] CreateSquareCellsArray()
    {
        var squareCells = new IEnumerable<CellPosition>[3, 3];
        for (int squareRow = 0; squareRow < 3; squareRow++)
        {
            for (int squareColumn = 0; squareColumn < 3; squareColumn++)
            {
                squareCells[squareRow, squareColumn] = WithinSquare(squareRow, squareColumn);
            }
        }

        return squareCells;
    }

    public static IEnumerable<CellPosition> WithinSquare(int row, int column)
    {
        return Enumerable.Range(row * 3, 3)
            .Join(Enumerable.Range(column * 3, 3), outer => 0, inner => 0, (r, c) => new CellPosition(r, c));
    }

    public static IEnumerable<CellPosition> WithinRow(int row)
    {
        return Enumerable.Range(0, 9).Select(column => new CellPosition(row, column));
    }

    public static IEnumerable<CellPosition> WithinColumn(int column)
    {
        return Enumerable.Range(0, 9).Select(row => new CellPosition(row, column));
    }
}
