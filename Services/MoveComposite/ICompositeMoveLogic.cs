using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.MoveComposite
{
    public interface ICompositeMoveLogic
    {
        IBoard? ApplyMove(Movement movement, IBoard currentBoard);
    }
}
