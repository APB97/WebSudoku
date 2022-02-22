namespace WebSudoku.Shared
{
    public class SudokuNeighbors
    {
        public IEnumerable<CellPosition> WithinSquare(int row, int column)
        {
            return Enumerable.Range(row / 3 * 3, 3)
                .Join(Enumerable.Range(column / 3 * 3, 3), outer => 0, inner => 0, (r, c) => new CellPosition(r, c));
        }

        public IEnumerable<CellPosition> WithinRow(int row)
        {
            return Enumerable.Range(0, 9).Select(column => new CellPosition(row, column));
        }

        public IEnumerable<CellPosition> WithinColumn(int column)
        {
            return Enumerable.Range(0, 9).Select(row => new CellPosition(row, column));
        }
    }
}
