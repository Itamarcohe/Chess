using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.Validators
{
    public interface IMovementValidator
    {
        public bool ShouldValidateMove(Movement movement);
        public bool IsMovementValid(Movement movement, IBoard board);
    }
}
