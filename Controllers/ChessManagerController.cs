using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
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
        private IBoard _board;
        private readonly MovementFactory _movementFactory;
        private readonly CompositeValidator _validator;
        private readonly IBoardParserService _boardParserService;
        private readonly IBoardFactory _boardFactory;

        public ChessManagerController(ILogger<ChessManagerController> logger,
            IBoard board,
            MovementFactory movementFactory,
            IBoardParserService boardParserService,
            CompositeValidator compositeValidator,
            IBoardFactory boardFactory
            )
        {
            _logger = logger;
            _board = board; // Scoped IBoard instance
            _movementFactory = movementFactory;
            _boardParserService = boardParserService;
            _validator = compositeValidator;
            _boardParserService = boardParserService;
            _boardFactory = boardFactory;
            Console.WriteLine("CTOR Chess instance hash: {0}", _board.GetHashCode());

        }

        [HttpGet("GetInitialFen")]
        public IActionResult GetInitialFen()
        {
            try
            {
                Console.WriteLine("Getting initial FEN using IBoard instance hash: {0}", _board.GetHashCode());

                _board = _boardFactory.InitializeNewBoard();

                var fen = _boardParserService.BoardToFen(_board);

                return Ok(fen);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to generate FEN: {Exception}", ex);
                return StatusCode(500, new { Message = "Internal Server Error. Please check the logs for more details." });

            }
        }



        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] MoveRequest request)
        {
            Console.WriteLine("request:", request.From, request.To);

            try
            {
                var fromTile = ChessNotationConverter.ConvertToTile(request.From);
                var toTile = ChessNotationConverter.ConvertToTile(request.To);

                
                var movement = _movementFactory.CreateMovement(fromTile, toTile, _board);

                if (_validator.IsMovementValid(movement, _board))
                {
                    
                    // Logic to update the board after validated the move
                    _board = _boardFactory.CreateNewBoard(_board, movement);

                    // use parser to get the new FEN of the updated board
                    string NewBoardFen = _boardParserService.BoardToFen(_board);


                    // Optionally return the new board state or confirmation
                    // here we will need to create the new board fen and update our board dictionary and everything

                    return Ok(new { Fen = NewBoardFen });
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

    }
}
