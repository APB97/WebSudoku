using WebSudoku.Shared.MeasureTime;

Console.WriteLine("Time Measurement App for WebSudoku.Shared project");

var invoker = new CommandInvoker();
await invoker.InputLoop();