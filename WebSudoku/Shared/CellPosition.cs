namespace WebSudoku.Shared
{
    public record struct CellPosition(int Row, int Column)
    {
        public static implicit operator (int row, int column)(CellPosition value)
        {
            return (value.Row, value.Column);
        }

        public static implicit operator CellPosition((int row, int column) value)
        {
            return new CellPosition(value.row, value.column);
        }
    }
}
