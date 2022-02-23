using Microsoft.AspNetCore.Mvc;
using WebSudoku.Shared;

namespace WebSudoku.Server.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class WebSudokuController : ControllerBase
    {
        private readonly ILogger<WebSudokuController> _logger;
        private readonly Validator _validator;

        public WebSudokuController(ILogger<WebSudokuController> logger, Validator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult WebSudoku()
        {
            return RedirectToPage("Index");
        }

        public IActionResult sudoku()
        {
            return RedirectToPage("Sudoku");
        }
    }
}