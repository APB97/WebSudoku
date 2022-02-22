using Microsoft.AspNetCore.Mvc;
using WebSudoku.Shared;

namespace WebSudoku.Server.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class SudokuController : ControllerBase
    {
        private readonly ILogger<SudokuController> _logger;
        private readonly Validator _validator;

        public SudokuController(ILogger<SudokuController> logger, Validator validator)
        {
            _logger = logger;
            _validator = validator;
        }
    }
}