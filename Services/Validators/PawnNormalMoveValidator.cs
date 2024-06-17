using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.Validators
{
    public class PawnNormalMoveValidator : IMovementValidator
    {
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            if (board.GetPieceByTilePosition(movement.From) is Pawn)
            {

            }
            return true;
        }
        public bool ShouldValidateMove(Movement movement)
        {
            return movement is NormalMovement;
        }
    }
}
