using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class RookTilesGenerator : BaseSlidingTilesGenerator
    {
        public override (int, int)[] MoveVectors { get; } =  [(1, 0), (-1, 0), (0, 1), (0, -1)];
        public override bool AppliesTo(Piece piece) => piece is Rook;
    }
}
