using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveComposite
{
    public class PawnPromotionMoveLogic : BaseMoveLogic
    {
        public PawnPromotionMoveLogic(IPieceFactory pieceFactory) : base(pieceFactory) { }
        public override bool ShouldApplyMove(Movement movement) => movement is PawnPromotionMovement;
        protected override IBoard CreateNewBoard(IBoard board, Movement movement, params Tile[] excludeTiles)
        {
            return base.CreateNewBoard(board, movement, movement.To);
        }
        protected override Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                var promotionPieceSymbol = ((PawnPromotionMovement)movement).PromotionPieceSymbol;
                return pieceFactory.CreatePieceColor(promotionPieceSymbol, movement.To, board.CurrentTurnColor);
            }
            return pieceFactory.CreatePiece(piece);
        }
    }
}
