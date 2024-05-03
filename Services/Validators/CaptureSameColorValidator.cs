using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.Validators
{
    public class CaptureSameColorValidator : IMovementValidator
    {
        // Determines if this validator should check the move
        public bool ShouldValidateMove(Movement movement)
        {
            // You can add conditions here to decide whether to apply this validator
            return true;  // For now, always validate
        }

        // Validates the movement according to this validator's rules
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            var fromPiece = board.GetPieceByTilePosition(movement.From);
            var targetPiece = board.GetPieceByTilePosition(movement.To);

            if (targetPiece != null && fromPiece != null && targetPiece.Color == fromPiece.Color)
            {
                return false; // Cannot capture a piece of the same color
            }
            return true;
        }


    }
}   