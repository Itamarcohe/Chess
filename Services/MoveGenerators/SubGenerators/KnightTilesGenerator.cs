using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KnightTilesGenerator : BaseTileGenerator
    {
        public KnightTilesGenerator(IBoardHolder boardHolder) : base(boardHolder) { }
        public override (int, int)[] MoveVectors { get; } = [(2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)];
        public override bool AppliesTo(Piece piece)
        {
            return piece is Knight;
        }
    }
}
