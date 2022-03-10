using System.Diagnostics;

namespace WebSudoku.Shared.MeasureTime
{
    internal class CommandInvoker
    {
        private Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>()
        {
            { "Solver.Solve", MeasureSolverSolve }
        };

        private static async Task MeasureSolverSolve()
        {

            await Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var neighbors = new SudokuNeighbors();
                var solver = new Solver(neighbors);
                var solvedDefault = solver.Solve(new int[9, 9], new DefaultOptionOrder<int>());
                stopwatch.Stop();
                Console.WriteLine("Default order");
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

        internal async Task<string> WaitForInput()
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
