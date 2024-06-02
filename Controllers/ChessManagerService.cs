using Chess_Backend.Controllers;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Services.Validators;
using Chess_Backend.Utils;
using Chess_Backend.Services.MoveComposite;

public class ChessManagerService : IChessManagerService
{
    private readonly ILogger<ChessManagerService> _logger;
    private readonly MovementFactory _movementFactory;
    private readonly ICompositeValidator _validator;
    private readonly IBoardParserService _boardParserService;
    private readonly IBoardFactory _boardFactory;
    private readonly IBoardHolder _boardHolder;
    private readonly ICompositeMoveLogic _compositeMoveLogic;
    public ChessManagerService(ILogger<ChessManagerService> logger,
        MovementFactory movementFactory,
        IBoardParserService boardParserService,
        ICompositeValidator compositeValidator,
        IBoardFactory boardFactory,
        IBoardHolder boardHolder,
        ICompositeMoveLogic compositeMoveLogic
        )
    {
        _logger = logger;
        _movementFactory = movementFactory;
        _boardParserService = boardParserService;
        _validator = compositeValidator;
        _boardFactory = boardFactory;
        _boardHolder = boardHolder;
        _compositeMoveLogic = compositeMoveLogic;
    }
    public string GetInitialFen()
    {
        _boardHolder.SetBoard(_boardFactory.InitializeNewBoard());
        return _boardParserService.BoardToFen(_boardHolder.GetBoard());
    }
    public (bool success, string? fen, string? errorMessage) ProcessMove(MoveRequest request)
    {
        try
        {
            var fromTile = ChessNotationConverter.ConvertToTile(request.From);
            var toTile = ChessNotationConverter.ConvertToTile(request.To);
            IBoard currentBoard = _boardHolder.GetBoard();

            var movement = _movementFactory.CreateMovement(fromTile, toTile, currentBoard, request.Promotion);
            var validMove = _validator.IsMovementValid(movement, currentBoard);
            if (validMove)
            {
                IBoard newBoard = _compositeMoveLogic.ApplyMove(movement, currentBoard)!;
                _boardHolder.SetBoard(newBoard);
                return (true, _boardParserService.BoardToFen(newBoard), null);
            }
            Piece? piece = currentBoard.GetPieceByTilePosition(movement.From);
            return (false, null, $"Cannot move your {piece} from {request.From} to {request.To}");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error processing move: {Exception}", ex);
            return (false, null, "Internal Server Error. Please check the logs for more details.");
        }
    }
}
