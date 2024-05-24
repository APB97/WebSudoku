using WebSudoku.Shared.Extensions;

namespace WebSudoku.Shared.Sudoku
{
    public class Blanker
    {
        public void MakeBlanks(Board board, int targetAmount)
        {
            CellPosition clearedCell = new();
            var range0To9 = Enumerable.Range(0, 9).ToArray();
            List<CellPosition> busyCells = range0To9.Join(range0To9, _ => 0, _ => 0, (r, c) => new CellPosition(r, c)).ToList();
            bool hasOneAndOnlySolution = true;
            int lastClearedCellValue = 0;
            int attemptsToRemove = 4;
            for (int i = 0; i < targetAmount && attemptsToRemove > 0; i++)
            {
                clearedCell = busyCells.PopRandomElement();
                lastClearedCellValue = board.UndefineCell(clearedCell);
                hasOneAndOnlySolution = board.HasOneAndOnlySolution();

                if (!hasOneAndOnlySolution)
                {
                    attemptsToRemove--;
                    board.RedefineCell(clearedCell, lastClearedCellValue);
                    busyCells.Add(clearedCell);
                }
            }
        }
    }
}
