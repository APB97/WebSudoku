using WebSudoku.Shared.MeasureTime;

Console.WriteLine("Time Mesurement App for WebSudoku.Shared project");

var invoker = new CommandInvoker();
await invoker.InputLoop();