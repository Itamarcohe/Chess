using Chess_Backend.Models.Movements;
using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.MoveGenerators;

namespace Chess_Backend.Services.MoveComposite
{
    public class CompositeMoveLogic : ICompositeMoveLogic
    {
        private IEnumerable<IMoveLogic> _moveLogics;
        public CompositeMoveLogic(IEnumerable<IMoveLogic> moveLogics)
        {
            _moveLogics = moveLogics;
        }
        public IBoard? ApplyMove(Movement movement, IBoard currentBoard)
        {
            foreach (var logic in _moveLogics)
            {
                if (logic.ShouldApplyMove(movement))
                {
                    return logic.ApplyMove(movement, currentBoard);
                }
            }
            return null;
        }

    }
}
