using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models;

namespace Chess_Backend.Services.MoveGenerator
{
    public class CompositeMovesGenerator
    {
        private List<IMoveToTilesGenerator> _validators;
        public CompositeMovesGenerator(List<IMoveToTilesGenerator> validators)
        {
            _validators = validators;
        }
        public List<Tile> GetPossibleMoves(Piece piece)
        {
            foreach (var validator in _validators)
            {
                if (validator.AppliesTo(piece))
                {
                    return validator.GetPossibleMoves(piece);
                }
            }
            throw new InvalidOperationException("No applicable validator found for this piece type.");
        }
    }
}
