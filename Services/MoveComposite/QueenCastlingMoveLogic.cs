using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;

namespace Chess_Backend.Services.MoveComposite
{
    public class QueenCastlingMoveLogic : IMoveLogic
    {
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            throw new NotImplementedException();
        }

        public bool ShouldApplyMove(Movement movement)
        {
            return movement is QueenCastlingMovement;
        }
    }
}
