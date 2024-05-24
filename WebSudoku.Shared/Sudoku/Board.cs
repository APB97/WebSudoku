using WebSudoku.Shared.General;

namespace WebSudoku.Shared.Sudoku
{
    public class Board
    {
        private readonly Solver? solver;

        private readonly HashSet<CellPosition> emptyCells = [];
        
        public IReadOnlySet<CellPosition> EmptyCells => emptyCells;

        private readonly int[,] cells;
        private readonly bool[,] predefined;

        public Board()
        {
            cells = new int[9, 9];
            predefined = new bool[9, 9];
        }

        public Board(Solver solver, IOptionOrder<int> optionOrder)
        {
            this.solver = solver;

            cells = new int[9, 9];
            predefined = new bool[9, 9];

            cells = solver.Solve(cells, optionOrder, out _);
            MarkAllAsPredefined();
        }

        private void MarkAllAsPredefined()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    predefined[row, column] = true;
                }
            }
        }

        public Board(Solver solver, IOptionOrder<int> optionOrder, Blanker blanker, int targetBlanks)
            : this(solver, optionOrder)
        {
            blanker.MakeBlanks(this, targetBlanks);
            DetermineEmptyCells();
        }

        private void DetermineEmptyCells()
        {
            emptyCells.Clear();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (cells[row, col] == 0)
                    {
                        emptyCells.Add((row, col));
                    }
                }
            }
        }

        public int UndefineCell(CellPosition cellPosition)
        {
            var value = cells[cellPosition.Row, cellPosition.Column];

            cells[cellPosition.Row, cellPosition.Column] = 0;
            predefined[cellPosition.Row, cellPosition.Column] = false;

            return value;
        }

        public void RedefineCell(CellPosition cellPosition, int value)
        {
            cells[cellPosition.Row, cellPosition.Column] = value;
            predefined[cellPosition.Row, cellPosition.Column ] = true;
        }

        public void ClearCell(CellPosition cellPosition)
        {
            cells[cellPosition.Row, cellPosition.Column] = 0;
            emptyCells.Add(cellPosition);
        }

        public void FillCell(CellPosition cellPosition, int value)
        {
            cells[cellPosition.Row, cellPosition.Column] = value;
            emptyCells.Remove(cellPosition);
        }

        public int GetValueAt(CellPosition cellPosition)
        {
            return cells[cellPosition.Row, cellPosition.Column];
        }

        public bool IsPredefined(CellPosition cellPosition)
        {
            return predefined[cellPosition.Row, cellPosition.Column];
        }

        public List<CellPosition> GetInvalidCells(Validator validator)
        {
            var invalidCells = new List<CellPosition>();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!predefined[row, col] && !validator.IsValid(this, (row, col)))
                    {
                        invalidCells.Add((row, col));
                    }
                }
            }

            return invalidCells;
        }

        public bool HasOneAndOnlySolution()
        {
            if (solver == null)
            {
                return false;
            }

            _ = solver.Solve(cells, new DefaultOptionOrder<int>(), out int solutionCount);
            return solutionCount == 1;
        }
    }
}
