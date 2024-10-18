# Web Sudoku
Sudoku made with Blazor WebAssembly

## Description

This Blazor WebAssembly application includes features like:
- Navigation with arrow keys allowing to move between first and last cell in a row or a column by wrapping around
- Save and Load
- Automatic validation with sudoku rules for highlighting invalid cell values while entering values
- Printing of current sudoku board with adjustable settings for printing already filled values and highlighted errors
- Printing mulitple sudoku boards, adjustable by 2, 4 or 8 additional sudoku boards at once
- Timer showing time spent on sudoku board that is saved and loaded along with board state

![Screenshot - sudoku board](https://github.com/user-attachments/assets/68eca74d-6ba5-4596-8d90-e6dea4554692)

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
