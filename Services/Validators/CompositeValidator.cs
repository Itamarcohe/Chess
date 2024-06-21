using Chess_Backend.Models.Movements;
using Chess_Backend.Models;

namespace Chess_Backend.Services.Validators
{
    public class CompositeValidator : ICompositeValidator
    {
        private Lazy<IValidatorProvider> _validatorProvider;

        public CompositeValidator(Lazy<IValidatorProvider> validatorProvider)
        {
            _validatorProvider = validatorProvider;
        }
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            foreach (IMovementValidator validator in _validatorProvider.Value.GetAllValidators())
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
        public bool IsMovementValidFilterList(Movement movement, IBoard currentBoard, IEnumerable<Type> filterList)
        {
            foreach (IMovementValidator validator in _validatorProvider.Value.FilterValidatorsByList(filterList))
            {
                if (!filterList.Any(type => type == validator.GetType()) && validator.ShouldValidateMove(movement))
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
