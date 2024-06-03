using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services.MoveComposite
{
    public class NormalMoveLogic : BaseMoveLogic
    {
        public NormalMoveLogic(IPieceFactory pieceFactory) : base(pieceFactory) { }
        public override bool ShouldApplyMove(Movement movement) => movement is NormalMovement;
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
