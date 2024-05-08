using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerator
{
    public class KnightTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors { get; } ={ (2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, 2) };
        public override bool AppliesTo(Piece piece)
        {
            return piece is Knight;
        }
    }
}
