using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;

namespace Chess_Backend.Services.Validators
{
    public class PawnTwoSquareMoveValidator : IMovementValidator
    {
        public bool ShouldValidateMove(Movement movement)
        {
            return movement is PawnTwoSquareMovement;
        }
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            var fromPiece = board.GetPieceByTilePosition(movement.From);
            var targetPiece = board.GetPieceByTilePosition(movement.To);
            if (targetPiece == null && fromPiece!.HasMoved == false)
            {
                return true;
            }
            return false;
        }
    }
}
