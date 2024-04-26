using Chess_Backend.Models;
using Chess_Backend.Models.Movement;

namespace Chess_Backend.Services.Validators
{
    public class CaptureSameColorValidator : ICompositeValidator
    {
        public bool Validate(Movement movement, Board board)
        {
            var fromPiece = board.GetPieceByTilePosition(movement.From);
            var targetPiece = board.GetPieceByTilePosition(movement.To);

            if (targetPiece != null && targetPiece.Color == fromPiece!.Color)
            {
                return false; // cant capture piece of the same color
            }
            return true;
        }
    }
}
