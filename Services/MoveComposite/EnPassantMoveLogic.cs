using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.MovementHistory;

namespace Chess_Backend.Services.MoveComposite
{
    public class EnPassantMoveLogic : BaseMoveLogic
    {
        private readonly IMovementHistoryService movementHistoryService;
        public EnPassantMoveLogic(IPieceFactory pieceFactory, IMovementHistoryService movementHistoryService) : base(pieceFactory)
        {
            this.movementHistoryService = movementHistoryService;
        }
        protected override IBoard CreateNewBoard(IBoard board, Movement movement, params Tile[] excludeTiles)
        {
            // remove skipped pawn
            return base.CreateNewBoard(board, movement, movementHistoryService.getLast().To);
        }
        public override bool ShouldApplyMove(Movement movement) => movement is EnPassantMovement;
        protected override Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                return pieceFactory.CreateMovedPiece(piece, movement.To);
            }
            return pieceFactory.CreatePiece(piece);
        }
    }
}
