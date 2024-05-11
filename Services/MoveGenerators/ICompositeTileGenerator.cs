using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveGenerators
{
    public interface ICompositeTileGenerator
    {
        List<Tile> GetPossibleMoves(Piece piece);
    }
}
