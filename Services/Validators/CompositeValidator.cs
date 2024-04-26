using Chess_Backend.Models.Movement;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;

namespace Chess_Backend.Services.Validators
{
    public class CompositeValidator : ICompositeValidator
    {
        private readonly List<ICompositeValidator> _validators;

        public CompositeValidator()
        {
            _validators = new List<ICompositeValidator>();
        }

        public void AddValidator(ICompositeValidator validator)
        {
            _validators.Add(validator);
        }

        public bool Validate(Movement movement, Board board)
        {
            foreach (var validator in _validators)
            {
                if (!validator.Validate(movement, board))
                {
                    return false; // If any validator fails, the move is invalid
                }
            }
            return true; // All validators passed
        }

    }
}
