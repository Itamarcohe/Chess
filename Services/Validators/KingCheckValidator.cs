using Chess_Backend.Models.Movement;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : ICompositeValidator
    {
        public bool Validate(Movement movement, Board board)
        {
            // This would simulate the move and check if the king is in check
            // Simplified example; actual implementation would require game simulation
            return true;
        }
    }
}
