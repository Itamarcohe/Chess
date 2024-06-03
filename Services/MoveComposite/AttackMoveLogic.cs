using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveComposite
{
    public class AttackMoveLogic : BaseMoveLogic
    {
        public AttackMoveLogic(IPieceFactory pieceFactory) : base(pieceFactory) { }

        public override bool ShouldApplyMove(Movement movement) => movement is AttackMovement;
        protected override IBoard CreateNewBoard(IBoard board, Movement movement, params Tile[] excludeTiles)
        {
            return base.CreateNewBoard(board, movement, movement.From);
        }
        protected override Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.To))
            {
                var fromPiece = board.GetPieceByTilePosition(movement.From);
                return pieceFactory.CreateMovedPiece(fromPiece!, movement.To);
            }
            return pieceFactory.CreatePiece(piece);
        }
    }
}
