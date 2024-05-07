using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models;

namespace Chess_Backend.Services.Validators
{
    public class CompositePieceMovementValidator
    {
        private List<IPieceMovementValidator> _validators;

        public CompositePieceMovementValidator(List<IPieceMovementValidator> validators)
        {
            _validators = validators;
        }

        public bool IsMoveValid(Piece piece, Tile to, IBoard board)
        {
            foreach (var validator in _validators)
            {
                if (validator.AppliesTo(piece) && validator.IsMoveValid(piece, to, board))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Tile> GetPossibleMoves(Piece piece, IBoard board)
        {
            foreach (var validator in _validators)
            {
                if (validator.AppliesTo(piece))
                {
                    return validator.GetPossibleMoves(piece, board);
                }
            }
            throw new InvalidOperationException("No applicable validator found for this piece type.");
        }
    }
}
