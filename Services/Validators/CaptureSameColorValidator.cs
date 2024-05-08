using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.Validators
{
    public class CaptureSameColorValidator : IMovementValidator
    {
        public bool ShouldValidateMove(Movement movement)
        {
            return true;  
        }

        public bool IsMovementValid(Movement movement, IBoard board)
        {
            var fromPiece = board.GetPieceByTilePosition(movement.From);
            var targetPiece = board.GetPieceByTilePosition(movement.To);

            if (targetPiece != null && fromPiece != null && targetPiece.Color == fromPiece.Color)
            {
                return false;
            }
            return true;
        }


    }
}   