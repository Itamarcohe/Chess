using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveGenerators
{
    public interface IMoveToTilesGenerator
    {
        bool AppliesTo(Piece piece);
        List<Tile> GetPossibleMoves(Piece piece);
    }
}
