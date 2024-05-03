using WebSudoku.Shared.Extensions;
using WebSudoku.Shared.General;

namespace WebSudoku.Shared.Sudoku
{
    public class Blanker
    {
        private readonly CountingSolver _solver;

        public Blanker(CountingSolver solver)
        {
            _solver = solver;
        }

        public void MakeBlanks(Board board, int targetAmount)
        {
            CellPosition lastClearedCell = new();
            var range0To9 = Enumerable.Range(0, 9).ToArray();
            List<CellPosition> busyCells = range0To9.Join(range0To9, _ => 0, _ => 0, (r, c) => new CellPosition(r, c)).ToList();
            bool hasOneAndOnlySolution = true;
            int lastClearedCellValue = 0;
            int attemptsToRemove = 4;
            for (int i = 0; i < targetAmount && attemptsToRemove > 0; i++)
            {
                var chosenOne = busyCells.PopRandomElement();
                lastClearedCell = chosenOne;
                lastClearedCellValue = board.Cells[chosenOne.Row, chosenOne.Column];
                board.Cells[chosenOne.Row, chosenOne.Column] = 0;
                board.Predefined[chosenOne.Row, chosenOne.Column] = false;
                hasOneAndOnlySolution = HasOneAndOnlySolution(board.Cells);

                if (!hasOneAndOnlySolution)
                {
                    attemptsToRemove--;
                    board.Cells[lastClearedCell.Row, lastClearedCell.Column] = lastClearedCellValue;
                    board.Predefined[lastClearedCell.Row, lastClearedCell.Column] = true;
                    busyCells.Add(lastClearedCell);
                }
            }
        }

        public bool HasOneAndOnlySolution(int[,] board)
        {
            _ = _solver.Solve(board, new DefaultOptionOrder<int>(), out int solutionCount);
            return solutionCount == 1;
        }
    }
}
