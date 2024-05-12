using Chess_Backend.Models.Movements;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessManagerController : ControllerBase
    {
        private readonly ILogger<ChessManagerController> logger;
        private readonly IChessManagerService chessManagerService;

        public ChessManagerController(ILogger<ChessManagerController> logger, IChessManagerService chessManagerService)
        {
            this.logger = logger;
            this.chessManagerService = chessManagerService;
        }

        [HttpGet("GetInitialFen")]
        public IActionResult GetInitialFen()
        {
            try
            {
                var fen = chessManagerService.GetInitialFen();
                return Ok(fen);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to generate FEN: {Exception}", ex);
                return StatusCode(500, "Internal Server Error. Please check the logs for more details.");
            }
        }

        [HttpPost("move")]
        public IActionResult ProcessMove([FromBody] MoveRequest request)
        {
            var (success, fen, errorMessage) = chessManagerService.ProcessMove(request);
            if (success)
            {
                return Ok(new { Fen = fen });
            }
            return BadRequest(new { Message = errorMessage });
        }
    }

}

