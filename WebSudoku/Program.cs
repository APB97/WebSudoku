using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebSudoku;
using WebSudoku.Shared.Sudoku;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Neighbors>();
builder.Services.AddScoped<Validator>();
builder.Services.AddScoped<Solver>();
builder.Services.AddScoped<CountingSolver>();
builder.Services.AddScoped<Blanker>();

await builder.Build().RunAsync();
