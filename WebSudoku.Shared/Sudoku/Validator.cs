namespace WebSudoku.Shared.Sudoku
{
    public class Validator
    {
        private readonly Neighbors _neighbors;

        public Validator(Neighbors neighbors)
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
            int value = board.GetValueAt(position);
            if (value == 0)
            {
                return true;
            }

            return _neighbors.CellNeighbors[row, column].Count(cell => board.GetValueAt(cell) == value) == 1;
        }

        public IEnumerable<CellPosition> ConflictingCells(Board board, CellPosition editedPosition)
        {
            var (row, column) = editedPosition;
            int value = board.GetValueAt(editedPosition);
            if (value == 0) return [];

            return _neighbors.CellNeighbors[row, column].Where(cell => cell != editedPosition && board.GetValueAt(cell) == value);
        }
    }
}
