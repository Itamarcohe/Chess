using Chess_Backend.Models.Movements;
using System.Collections.Immutable;

namespace Chess_Backend.Services.Validators
{
    public interface IValidatorProvider
    {
        public IEnumerable<IMovementValidator> GetAllValidators();
        public IEnumerable<IMovementValidator> FilterValidatorsByList(IEnumerable<Type> filterValidatorTypes);

    }
}
