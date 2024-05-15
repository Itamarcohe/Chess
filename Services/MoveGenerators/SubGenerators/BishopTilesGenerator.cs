using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class BishopTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors { get; } = [(1, 1), (1, -1), (-1, 1), (-1, -1)];
        public BishopTilesGenerator(IBoardHolder boardHolder) : base(boardHolder) { }
        public override bool AppliesTo(Piece piece) => piece is Bishop;
    }
}
