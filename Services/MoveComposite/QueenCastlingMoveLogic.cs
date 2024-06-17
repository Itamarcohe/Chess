using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveComposite
{
    public class QueenCastlingMoveLogic : BaseMoveLogic
    {
        public QueenCastlingMoveLogic(IPieceFactory pieceFactory) : base(pieceFactory) { }
        public override bool ShouldApplyMove(Movement movement) => movement is QueenCastlingMovement;
        protected override Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                return pieceFactory.CreateMovedPiece(piece, movement.To);
            }
            if (IsRookOnLeftOfKing(piece, movement))
            {
                var newTile = new Tile(piece.TilePosition.Column + 3, piece.TilePosition.Row);
                return pieceFactory.CreateMovedPiece(piece, newTile);
            }
            return pieceFactory.CreatePiece(piece);
        }
        private bool IsRookOnLeftOfKing(Piece piece, Movement movement)
        {
            return piece is Rook &&
                   piece.TilePosition.Row == movement.From.Row &&
                   piece.TilePosition.Column < movement.From.Column;
        }
    }
}
