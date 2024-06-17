using Chess_Backend.Models.Movements;
using Chess_Backend.Models;

namespace Chess_Backend.Services.Validators
{
    public interface ICompositeValidator
    {
        bool IsMovementValid(Movement movement, IBoard currentBoard);
        bool IsMovementValidFilterList(Movement movement, IBoard currentBoard, IEnumerable<Type> filterList);
    }
}
