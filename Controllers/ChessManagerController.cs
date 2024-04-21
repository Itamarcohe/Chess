using Microsoft.AspNetCore.Mvc;

namespace Chess_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessManagerController : ControllerBase
    {

        private static readonly string InitialChessFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

        private readonly ILogger<ChessManagerController> _logger;

        public ChessManagerController(ILogger<ChessManagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetInitialFen")]
        public ActionResult<string> GetInitialFen()
        {
            _logger.LogInformation("Returning initial FEN for new chess game.");
            return Ok(InitialChessFen);
        }
    }
}
