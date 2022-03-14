namespace WebSudoku.Shared.Sudoku
{
    public class Neighbors
    {
        public HashSet<CellPosition>[,] CellNeighbors { get; private set; }

        public Neighbors()
        {
            CellNeighbors = new HashSet<CellPosition>[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    CellNeighbors[row, column] = new HashSet<CellPosition>(WithinSquare(row, column)
                        .Concat(WithinRow(row)
                        .Concat(WithinColumn(column))));
                }
            }
        }

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
