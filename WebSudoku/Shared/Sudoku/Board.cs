namespace WebSudoku.Shared.Sudoku
{
    public class Board
    {
        public int[,] Cells { get; set; }
        public bool[,] Predefined { get; set; }

        public Board()
        {
            Cells = new int[9, 9];
            Predefined = new bool[9, 9];
        }
    }
}
