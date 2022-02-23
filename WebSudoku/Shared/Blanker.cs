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
            Random random = new Random();
            (int row, int column) lastClearedCell = new ValueTuple<int, int>();
            var range0To9 = Enumerable.Range(0, 9).ToArray();
            List<(int row, int column)> busyCells = range0To9.Join(range0To9, _ => 0, _ => 0, (r, c) => (r, c)).ToList();
            bool hasOneAndOnlySolution = true;
            int lastClearedCellValue = 0;
            for (int i = 0; i < targetAmount && hasOneAndOnlySolution; i++)
            {
                var chosenOne = SelectPositionToBlank(random, busyCells);
                lastClearedCell = chosenOne;
                lastClearedCellValue = board.Cells[chosenOne.row, chosenOne.column];
                board.Cells[chosenOne.row, chosenOne.column] = 0;
                board.Predefined[chosenOne.row, chosenOne.column] = false;
                hasOneAndOnlySolution = HasOneAndOnlySolution(board.Cells);
            }

            if (!hasOneAndOnlySolution)
            {
                board.Cells[lastClearedCell.row, lastClearedCell.column] = lastClearedCellValue;
                board.Predefined[lastClearedCell.row, lastClearedCell.column] = true;
            }
        }

        private (int row, int column) SelectPositionToBlank(Random random, List<(int row, int column)> busyCells)
        {
            var index = random.Next(busyCells.Count);
            var selectedPositionToBlank = busyCells[index];
            busyCells.RemoveAt(index);
            return selectedPositionToBlank;
        }

        public bool HasOneAndOnlySolution(int[,] board)
        {
            int[,] solutionFromOne = _solver.Solve(board, OptionOrder.Default);
            int[,] solutionFromNine = _solver.Solve(board, OptionOrder.Reverse);

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (solutionFromOne[i, j] != solutionFromNine[i, j])
                        return false;
            return true;
        }
    }
}
