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
            int value = board.GetValueAt((row, column));
            if (value == 0)
            {
                return true;
            }

            return _neighbors.CellNeighbors[row, column].Count(cell => board.GetValueAt((cell.Row, cell.Column)) == value) == 1;
        }
    }
}
