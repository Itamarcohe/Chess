using Chess_Backend.Models.Movements;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : IMovementValidator
    {
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            return true;
        }

        public bool ShouldValidateMove(Movement movement)
        {
            return true;
        }

    }
}
