using Chess_Backend.Models;
using Chess_Backend.Models.Movement;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services;
using Chess_Backend.Services.Validators;
using Chess_Backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessManagerController : ControllerBase
    {


        private readonly ILogger<ChessManagerController> _logger;
        private readonly Board _board;
        private readonly MovementFactory _movementFactory;
        private readonly CompositeValidator _validator;


        public ChessManagerController(ILogger<ChessManagerController> logger,
            Board board, MovementFactory movementFactory)
        {
            _logger = logger;
            _board = board;
            _movementFactory = movementFactory;
            _validator = new CompositeValidator();
            // add validators
            _validator.AddValidator(new CaptureSameColorValidator());
            _validator.AddValidator(new KingCheckValidator());

        }

        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] MoveRequest request)
        {
            try
            {
                var fromTile = ChessNotationConverter.ConvertToTile(request.From);
                var toTile = ChessNotationConverter.ConvertToTile(request.To);

                var movement = _movementFactory.CreateMovement(fromTile, toTile);

                if (_validator.Validate(movement, _board))
                {
                    // Logic to update the board
                    // need to create move method or something --->

                    // _board.MakeMove(movement);

                    // Optionally return the new board state or confirmation
                    return Ok(new { Message = "Move successful" });
                }
                else
                {
                    return BadRequest(new { Message = "Invalid move" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, possibly logging them and returning an error response
                return BadRequest(new { Message = ex.Message });
            }

        }
            //[HttpPost("StartNewGame")]
            //public ActionResult<string> StartNewGame()
            //{
            //    _gameManager.StartNewGame();
            //    _logger.LogInformation("Started a new chess game.");
            //    return Ok(_gameManager.CurrentFen);
            //}


            //[HttpGet("GetCurrentFen")]
            //public ActionResult<string> GetCurrentFen()
            //{
            //    _logger.LogInformation("Retrieving current FEN.");
            //    return Ok(_gameManager.CurrentFen);
            //}


            //[HttpPost("ValidateMove")]
            //public ActionResult<string> ValidateMove([FromBody] MoveRequest move)
            //{
            //    try
            //    {
            //        if (_gameManager.TryMakeMove(move.From, move.To, out string newFen))
            //        {
            //            return Ok(newFen);
            //        }
            //        else
            //        {
            //            return BadRequest("Move is invalid.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError(ex, "Failed to validate move");
            //        return StatusCode(500, "Internal Server Error");
            //    }
            //}

        }
    }
