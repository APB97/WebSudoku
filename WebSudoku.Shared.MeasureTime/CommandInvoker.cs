using System.Diagnostics;

namespace WebSudoku.Shared.MeasureTime
{
    internal class CommandInvoker
    {
        private readonly Dictionary<string, Func<Task>> _commands = new()
        {
            { "Solver.Solve", MeasureSolverSolve },
            { "Validator.IsValidBoard", MeasureValidatorIsValidBoard }
        };

        private static async Task MeasureValidatorIsValidBoard()
        {
            await Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var board = new Board();
                var neignbors = new SudokuNeighbors();
                var validator = new Validator(neignbors);
                var result = validator.IsValidBoard(board);
                stopwatch.Stop();
                Console.WriteLine("Validation of an empty board:");
                Console.WriteLine(stopwatch.Elapsed);
            });
        }

        private static async Task MeasureSolverSolve()
        {
            await Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var neighbors = new SudokuNeighbors();
                var solver = new Solver(neighbors);
                var solvedDefault = solver.Solve(new int[9, 9], new DefaultOptionOrder<int>());
                stopwatch.Stop();
                Console.WriteLine("Default order:");
                Console.WriteLine(stopwatch.Elapsed);
            });
        }

        internal async Task InputLoop()
        {
            bool continueExecution = true;
            while (continueExecution)
            {
                Console.WriteLine("Available commands:");
                foreach (var key in _commands.Keys)
                {
                    Console.WriteLine(key);
                }

                Console.WriteLine("Your input:");
                var input = await WaitForInput();
                Console.WriteLine();

                if (string.IsNullOrEmpty(input))
                {
                    continueExecution = false;
                }

                if (_commands.TryGetValue(input, out var action))
                {
                    await action();
                    Console.WriteLine();
                    continue;
                }
            }
        }

        internal static async Task<string> WaitForInput()
        {
            return await Task.Run(() =>
            {
                var input = Console.ReadLine();
                if (input == null) return string.Empty;
                return input.Trim();
            });
        }
    }
}
