using Chess_Backend.Models.Movements;
using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Enums;
using Chess_Backend.Services.MovementHistory;

namespace Chess_Backend.Services.Validators
{
    public class EnPassantValidator : IMovementValidator
    {
        private readonly IMovementHistoryService _history;
        public EnPassantValidator(IMovementHistoryService history)
        {
            _history = history;
        }
        public bool ShouldValidateMove(Movement movement) => movement is EnPassantMovement;
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            if (_history == null || _history.getLast() is not PawnTwoSquareMovement lastMove || !lastMove.HasSkippedCapture)
            {
                return false;
            }
            if (Math.Abs(lastMove.To.Row - movement.To.Row) != 1 || lastMove.To.Column != movement.To.Column)
            {
                return false;
            }
            return true;
        }
    }
}
