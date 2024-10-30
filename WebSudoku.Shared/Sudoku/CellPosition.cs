namespace apb97.github.io.WebSudoku.Shared.Sudoku;

[Serializable]
public record struct CellPosition(int Row, int Column)
{
    public static implicit operator CellPosition((int row, int column) value)
    {
        return new CellPosition(value.row, value.column);
    }
}
