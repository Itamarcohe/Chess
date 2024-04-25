using Chess_Backend.Models.Movement;
using Chess_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessManagerController : ControllerBase
    {


        private readonly ILogger<ChessManagerController> _logger;

        private readonly GameManager _gameManager;


        public ChessManagerController(ILogger<ChessManagerController> logger, GameManager gameManager)
        {
            _logger = logger;
            _gameManager = gameManager;
        }

        [HttpPost("StartNewGame")]
        public ActionResult<string> StartNewGame()
        {
            _gameManager.StartNewGame();
            _logger.LogInformation("Started a new chess game.");
            return Ok(_gameManager.CurrentFen);
        }


        [HttpGet("GetCurrentFen")]
        public ActionResult<string> GetCurrentFen()
        {
            _logger.LogInformation("Retrieving current FEN.");
            return Ok(_gameManager.CurrentFen);
        }


        [HttpPost("ValidateMove")]
        public ActionResult<string> ValidateMove([FromBody] MoveRequest move)
        {
            try
            {
                if (_gameManager.TryMakeMove(move.From, move.To, out string newFen))
                {
                    return Ok(newFen);
                }
                else
                {
                    return BadRequest("Move is invalid.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to validate move");
                return StatusCode(500, "Internal Server Error");
            }
        }



    }
}
