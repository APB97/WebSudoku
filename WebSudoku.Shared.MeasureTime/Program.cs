// See https://aka.ms/new-console-template for more information
using WebSudoku.Shared;
using WebSudoku.Shared.MeasureTime;

Console.WriteLine("Time Mesurement App for Websudoku.Shared project");

var invoker = new CommandInvoker();
await invoker.InputLoop();