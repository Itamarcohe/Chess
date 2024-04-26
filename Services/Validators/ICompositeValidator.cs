using Chess_Backend.Models.Movement;
using Chess_Backend.Models;

namespace Chess_Backend.Services.Validators
{
    public interface ICompositeValidator
    {
        bool Validate(Movement movement, Board board);

    }
}
