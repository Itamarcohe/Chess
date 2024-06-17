using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces.SubPieces;

namespace Chess_Backend.Services.Validators
{
    public class PawnAttackValidator : IMovementValidator
    {
        public bool ShouldValidateMove(Movement movement)
        {
            return movement is AttackMovement;
        }
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            if (board.GetPieceByTilePosition(movement.From) is Pawn)
            {
                if (movement.To.Column == movement.From.Column)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
