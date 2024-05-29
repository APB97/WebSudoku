namespace WebSudoku.Shared.Sudoku
{
    public readonly record struct BoardState(int[] Cells, bool[] Predefined) { }
}
