using apb97.github.io.WebSudoku;
using apb97.github.io.WebSudoku.Services.Localization;
using apb97.github.io.WebSudoku.Shared.Sudoku;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Neighbors>();
builder.Services.AddScoped<Validator>();
builder.Services.AddScoped<Solver>();
builder.Services.AddScoped<CountingSolver>();
builder.Services.AddScoped<Blanker>();

builder.Services.AddOptions<LocalizationOptions>()
    .Configure(options =>
    {
        options.ResourcesPath = "Resources";
        options.ProjectNamespace = "apb97.github.io.WebSudoku";
    });
builder.Services.AddScoped<StringLocalizerFactory>();
builder.Services.AddScoped(typeof(StringLocalizer<>));

await builder.Build().RunAsync();
