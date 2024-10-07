# Web Sudoku
Sudoku made with Blazor WebAssembly

## Description

This Blazor WebAssembly application includes features like:
- Navigation with arrow keys
- Save and Load
- Validation for highlighting invalid cell values
- Printing of sudoku board with adjustable settings for printing already filled values and highlighted errors

![screenshot with sudoku board](images/Screenshot%20-%20sudoku.png)

## Technologies used

The following technologies are used in this project
- .NET 8
- C#
- Blazor WebAssembly
- HTML
- CSS
- JavaScript

## CI/CD

The master branch is deployed to Github Pages after every succesful push at the following address [https://apb97.github.io/WebSudoku](https://apb97.github.io/WebSudoku).

To achieve that, the project uses Github Actions through [dotnet.yml](.github/workflows/dotnet.yml) workflow file.

## Notes

Things that should be noted:
- Deploying to Github Pages works because Blazor WebAssembly application is downloaded to and run on the client.
- However it requires some specific changes to make routing somehow work:
  - This includes adding some JavaScript code found in
  [404.html](WebSudoku/wwwroot/404.html).
  - And C# Code with JavaScript Interop found in [Index.razor](WebSudoku/Pages/Index.razor) routeable component.
