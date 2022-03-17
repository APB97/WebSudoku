using WebSudoku.Shared.General;

namespace WebSudoku.Shared.Sudoku
{
    public class Solver
    {
        private readonly Neighbors _neighbors;

        public Solver(Neighbors neighbors)
        {
            _neighbors = neighbors;
        }

        public int[,] Solve(int[,] board, IOptionOrder<int> optionOrder)
        {
            int[,] solvedBoard = new int[9, 9];
            Array.Copy(board, solvedBoard, 81);

            var emptyCells = new LinkedList<CellPosition>();
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

        private bool Fill(int[,] board, LinkedList<CellPosition> emptyCells, IOptionOrder<int> optionOrder)
        {
            var cell = emptyCells.First;
            emptyCells.RemoveFirst();

            if (cell == null)
            {
                return false;
            }
            var neighbors = _neighbors.CellNeighbors[cell.Value.Row, cell.Value.Column];

            var usedValues = new HashSet<int>();
            foreach ((int row, int column) neighbour in neighbors)
                usedValues.Add(board[neighbour.row, neighbour.column]);

            IEnumerable<int> availableValues = Enumerable.Range(1, 9).Except(usedValues);
            availableValues = optionOrder.Order(availableValues);

            foreach (int option in availableValues)
            {
                board[cell.Value.Row, cell.Value.Column] = option;
                if (emptyCells.Count == 0)
                    return true;
                if (Fill(board, emptyCells, optionOrder))
                    return true;
            }

            board[cell.Value.Row, cell.Value.Column] = 0;
            emptyCells.AddFirst(cell);
            return false;
        }
    }
}
