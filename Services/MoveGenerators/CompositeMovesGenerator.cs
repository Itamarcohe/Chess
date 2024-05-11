using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveGenerators
{
    public class CompositeMovesGenerator : ICompositeTileGenerator
    {
        private IEnumerable<IMoveToTilesGenerator> _generators;
        public CompositeMovesGenerator(IEnumerable<IMoveToTilesGenerator> generators)
        {
            _generators = generators;
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
