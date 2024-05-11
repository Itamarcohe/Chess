using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.Validators
{
    public class PlayerTurnValidator : IMovementValidator
    {
        public bool ShouldValidateMove(Movement movement)
        {
            return true;
        }
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            if (board.GetPieceByTilePosition(movement.From)!.Color == board.CurrentTurnColor)
            {
                return true;
            }
            return false;
        }
    }
}
