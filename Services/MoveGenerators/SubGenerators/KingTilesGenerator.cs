using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KingTilesGenerator : BaseTileGenerator
    {
        public KingTilesGenerator(IBoardHolder boardHolder) : base(boardHolder) { }
        public override (int, int)[] MoveVectors { get; } = [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1)];
        public override bool AppliesTo(Piece piece) =>  piece is King;
    }
}



