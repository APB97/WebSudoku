namespace WebSudoku.Shared.Sudoku
{
    public class CountingSolver : Solver
    {
        public int MaxSolutionCount { get; set; } = 2;
        
        public CountingSolver(Neighbors neighbors) : base(neighbors)
        {

        }

        public override bool ShouldStopAtSolution(int currentCount) => currentCount >= MaxSolutionCount;
    }
}
