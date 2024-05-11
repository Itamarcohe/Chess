using Chess_Backend.Models.Movements;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Chess_Backend.Services.Validators
{
    public class CompositeValidator : ICompositeValidator
    {
        private IEnumerable<IMovementValidator> _movementValidators;
        public CompositeValidator(IEnumerable<IMovementValidator> movementValidators)
        {
            _movementValidators = movementValidators;
        }
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            foreach (IMovementValidator validator in _movementValidators)
            {
                if (validator.ShouldValidateMove(movement))
                {
                    if (!validator.IsMovementValid(movement, currentBoard))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
