using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models;

namespace Chess_Backend.Services.MoveGenerator
{
    public class CompositeMovesGenerator : IMoveToTilesGenerator
    {
        private List<IMoveToTilesGenerator> _generators;
        public CompositeMovesGenerator(List<IMoveToTilesGenerator> generators)
        {
            _generators = generators;
        }

        public bool AppliesTo(Piece piece)
        {
            foreach (var generator in _generators)
            {
                if (generator.AppliesTo(piece))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Tile> GetPossibleMoves(Piece piece)
        {
            foreach (var generator in _generators)
            {
                if (generator.AppliesTo(piece))
                {
                    return generator.GetPossibleMoves(piece);
                }
            }
            throw new InvalidOperationException("No applicable validator found for this piece type.");
        }
    }
}
