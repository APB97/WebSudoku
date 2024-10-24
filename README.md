# Web Sudoku

## Description

Sudoku application made with Blazor WebAssembly that includes features like:
- Navigation with arrow keys allowing to move between first and last cell in a row or a column by wrapping around. Pressing `Enter` allows to navigate to the next cell, or to the top-left one if pressed in the bottom-right cell.
- Save and Load with use of `localStorage`.
- Automatic validation with sudoku rules for highlighting invalid editable cells while entering values
- Printing of current sudoku board with adjustable settings for printing already filled values and highlighted errors.
- Printing mulitple sudoku boards which allows generating adjustable amount of additional sudoku boards at once. Every single board can be regenerated or removed. Generation process can be cancelled or made to use more resources for faster results in cost of responsiveness.
- Timer showing time spent on sudoku board that is saved and loaded along with board state.
- Application UI language can be changed between English and Polish (Polski) without requiring full page reload.

<picture>
 <source media="(prefers-color-scheme: dark)" srcset="images/Screenshot%20-%20sudoku%20-%20dark%20mode.png">
 <source media="(prefers-color-scheme: light)" srcset="images/Screenshot%20-%20sudoku.png">
 <img alt="Screenshot - sudoku board in dark mode" src="images/Screenshot%20-%20sudoku%20-%20dark%20mode.png">
</picture>

## Technologies used

The following technologies are used in this project
- .NET 8
- C#
- Blazor WebAssembly
- HTML
- CSS
- JavaScript
- JSON

## CI/CD

The master branch is deployed to Github Pages after every succesful push at the following address [https://apb97.github.io/WebSudoku](https://apb97.github.io/WebSudoku).

To achieve that, the project uses Github Actions through [dotnet.yml](.github/workflows/dotnet.yml) workflow file.

## Notes

Things that should be noted:
- Deploying to Github Pages works because Blazor WebAssembly application is downloaded to and run on the client.
- However it requires some specific changes to make routing work:
  - This includes adding some JavaScript code found in
  [404.html](WebSudoku/wwwroot/404.html).
  - And C# Code with JavaScript Interop found in [NavigationManagerExtensions.cs](WebSudoku/Extensions/NavigationManagerExtensions.cs) referenced in [Index.razor](WebSudoku/Pages/Index.razor) routeable component.
