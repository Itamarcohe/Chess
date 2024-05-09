using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services;
using Chess_Backend.Services.MoveGenerator;
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
        private readonly IMoveToTilesGenerator compositeMovesGenerator;

        public ChessManagerController(ILogger<ChessManagerController> logger,
            MovementFactory movementFactory,
            IBoardParserService boardParserService,
            ICompositeValidator compositeValidator,
            IBoardFactory boardFactory,
            IBoardHolder boardHolder,
            IMoveToTilesGenerator compositeMovesGenerator
            )
        {
            _logger = logger;
            _movementFactory = movementFactory;
            _boardParserService = boardParserService;
            _validator = compositeValidator;
            _boardParserService = boardParserService;
            this.boardFactory = boardFactory;
            this.boardHolder = boardHolder;
            this.compositeMovesGenerator = compositeMovesGenerator;
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
            try
            {
                var fromTile = ChessNotationConverter.ConvertToTile(request.From);
                var toTile = ChessNotationConverter.ConvertToTile(request.To);
                IBoard currentBoard = boardHolder.GetBoard();
                var movement = _movementFactory.CreateMovement(fromTile, toTile, currentBoard);
                if (_validator.IsMovementValid(movement, currentBoard))
                {
                    Piece piece = currentBoard.GetPieceByTilePosition(fromTile)!;
                    var possibleMoves = compositeMovesGenerator.GetPossibleMoves(piece);
                    var validMove = possibleMoves.Any(tile => tile.Equals(toTile));
                    if (validMove)
                    {
                        var oldTurnColor = currentBoard.GetPieceByTilePosition(fromTile)!.Color;
                        IBoard newBoard = boardFactory.CreateNewBoard(currentBoard, movement, oldTurnColor);
                        boardHolder.SetBoard(newBoard);
                        string NewBoardFen = _boardParserService.BoardToFen(newBoard);
                        return Ok(new { Fen = NewBoardFen });
                    } else
                    {
                        return BadRequest(new { Message = $"Cant move ur {piece} from: {request.From} to: {request.To}" });
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Invalid move" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
