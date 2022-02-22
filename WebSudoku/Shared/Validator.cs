namespace WebSudoku.Shared
{
    public class Validator
    {
        private readonly SudokuNeighbors _neighbors;

        public Validator(SudokuNeighbors neighbors)
        {
            _neighbors = neighbors;
        }

        public bool IsValidBoard(Board board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (!IsValid(board, (row, column)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsValid(Board board, CellPosition position)
        {
            var (row, column) = position;
            int value = board.Cells[row, column];
            if (value == 0)
            {
                return true;
            }

            bool uniqueInSquare = _neighbors.WithinSquare(row, column).Count(cell => board.Cells[cell.Row, cell.Column] == value) == 1;
            bool uniqueInRow = _neighbors.WithinRow(row).Count(cell => board.Cells[cell.Row, cell.Column] == value) == 1;
            bool uniqueInColumn = _neighbors.WithinColumn(row).Count(cell => board.Cells[cell.Row, cell.Column] == value) == 1;
            return uniqueInSquare && uniqueInRow && uniqueInColumn;
        }
    }
}
