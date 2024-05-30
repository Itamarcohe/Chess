using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.MoveComposite
{
    public interface IMoveLogic
    {
        bool ShouldApplyMove(Movement movement);
        IBoard ApplyMove(Movement movement, IBoard board);
    }
}
