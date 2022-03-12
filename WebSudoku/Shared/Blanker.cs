namespace WebSudoku.Shared
{
    public class Blanker
    {
        private readonly Solver _solver;

        public Blanker(Solver solver)
        {
            _solver = solver;
        }

        public void MakeBlanks(Board board, int targetAmount)
        {
            (int row, int column) lastClearedCell = new();
            var range0To9 = Enumerable.Range(0, 9).ToArray();
            List<(int row, int column)> busyCells = range0To9.Join(range0To9, _ => 0, _ => 0, (r, c) => (r, c)).ToList();
            bool hasOneAndOnlySolution = true;
            int lastClearedCellValue = 0;
            int attemptsToRemove = 4;
            for (int i = 0; i < targetAmount && attemptsToRemove > 0; i++)
            {
                var chosenOne = busyCells.PopRandomElement();
                lastClearedCell = chosenOne;
                lastClearedCellValue = board.Cells[chosenOne.row, chosenOne.column];
                board.Cells[chosenOne.row, chosenOne.column] = 0;
                board.Predefined[chosenOne.row, chosenOne.column] = false;
                hasOneAndOnlySolution = HasOneAndOnlySolution(board.Cells);
                
                if (!hasOneAndOnlySolution)
                {
                    attemptsToRemove--;
                    board.Cells[lastClearedCell.row, lastClearedCell.column] = lastClearedCellValue;
                    board.Predefined[lastClearedCell.row, lastClearedCell.column] = true;
                    busyCells.Add(lastClearedCell);
                }
            }

        }

        public bool HasOneAndOnlySolution(int[,] board)
        {
            int[,] solutionFromOne = _solver.Solve(board, new DefaultOptionOrder<int>());
            int[,] solutionFromNine = _solver.Solve(board, new ReverseOptionOrder<int>());

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (solutionFromOne[i, j] != solutionFromNine[i, j])
                        return false;
            return true;
        }
    }
}
