namespace WebSudoku.Shared
{
    public class Solver
    {
        private readonly SudokuNeighbors _neighbors;

        public Solver(SudokuNeighbors neighbors)
        {
            _neighbors = neighbors;
        }

        public int[,] Solve(int[,] board, IOptionOrder<int> optionOrder)
        {
            int[,] solvedBoard = new int[9, 9];
            Array.Copy(board, solvedBoard, 81);

            var emptyCells = new LinkedList<(int row, int column)>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (solvedBoard[i, j] == 0)
                        emptyCells.AddLast((i, j));

            if (emptyCells.Count != 0)
            {
                Fill(solvedBoard, emptyCells, optionOrder);
            }
            return solvedBoard;
        }

        private bool Fill(int[,] board, LinkedList<(int row, int column)> emptyCells, IOptionOrder<int> optionOrder)
        {
            var cell = emptyCells.First;
            emptyCells.RemoveFirst();
            
            if (cell == null)
            {
                return false;
            }
            var neighbors = _neighbors.CellNeighbors[cell.Value.row, cell.Value.column];

            var usedValues = new HashSet<int>();
            foreach ((int row, int column) neighbour in neighbors)
                usedValues.Add(board[neighbour.row, neighbour.column]);

            IEnumerable<int> availableValues = Enumerable.Range(1, 9).Except(usedValues);
            availableValues = optionOrder.Order(availableValues);

            foreach (int option in availableValues)
            {
                board[cell.Value.row, cell.Value.column] = option;
                if (emptyCells.Count == 0)
                    return true;
                if (Fill(board, emptyCells, optionOrder))
                    return true;
            }

            board[cell.Value.row, cell.Value.column] = 0;
            emptyCells.AddFirst(cell);
            return false;
        }

        private IEnumerable<CellPosition> GetCellNeighbours((int row, int column) cell)
        {
            var (row, column) = cell;
            IEnumerable<CellPosition> vertical = _neighbors.WithinRow(row);
            IEnumerable<CellPosition> horizontal = _neighbors.WithinColumn(column);
            IEnumerable<CellPosition> withinSquare = _neighbors.WithinSquare(row, column);
            var neighbours = new HashSet<CellPosition>(vertical.Concat(horizontal).Concat(withinSquare));
            return neighbours;
        }
    }
}
