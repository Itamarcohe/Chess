using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.BoardServices;
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
        private readonly MovementFactory _movementFactory;
        private readonly ICompositeValidator _validator;
        private readonly IBoardParserService _boardParserService;
        private readonly IBoardFactory boardFactory;
        private readonly IBoardHolder boardHolder;

        public ChessManagerController(ILogger<ChessManagerController> logger,
            MovementFactory movementFactory,
            IBoardParserService boardParserService,
            ICompositeValidator compositeValidator,
            IBoardFactory boardFactory,
            IBoardHolder boardHolder
            )
        {
            _logger = logger;
            _movementFactory = movementFactory;
            _boardParserService = boardParserService;
            _validator = compositeValidator;
            this.boardFactory = boardFactory;
            this.boardHolder = boardHolder;
        }

        [HttpGet("GetInitialFen")]
        public IActionResult GetInitialFen()
        {
            try
            {
                boardHolder.SetBoard(boardFactory.InitializeNewBoard());
                var fen = _boardParserService.BoardToFen(boardHolder.GetBoard());
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
            var fromTile = ChessNotationConverter.ConvertToTile(request.From);
            var toTile = ChessNotationConverter.ConvertToTile(request.To);
            IBoard currentBoard = boardHolder.GetBoard();
            var movement = _movementFactory.CreateMovement(fromTile, toTile, currentBoard);
            var validMove = _validator.IsMovementValid(movement, currentBoard);
            if (validMove)
            {
                IBoard newBoard = boardFactory.CreateNewBoard(currentBoard, movement);
                boardHolder.SetBoard(newBoard);
                string NewBoardFen = _boardParserService.BoardToFen(newBoard);
                return Ok(new { Fen = NewBoardFen });
            }
            Piece? piece = currentBoard.GetPieceByTilePosition(movement.From);
            return BadRequest(new { Message = $"Cant move ur {piece} from: {request.From} to: {request.To}" });
        }
    }
}
