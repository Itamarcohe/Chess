

namespace Chess_Backend.Services.Validators
{
    public class ValidatorProvider : IValidatorProvider
    {
        private IEnumerable<IMovementValidator> _movementValidators;
        public ValidatorProvider(IEnumerable<IMovementValidator> movementValidators)
        {
            _movementValidators = movementValidators;
        }
        public IEnumerable<IMovementValidator> GetAllValidators()
        {
            return _movementValidators;
        }
        public IEnumerable<IMovementValidator> FilterValidatorsByList(IEnumerable<Type> filterValidatorTypes)
        {
            return _movementValidators.Where(mv => !filterValidatorTypes.Contains(mv.GetType()));
        }
    }
}
