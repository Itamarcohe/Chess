using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class QueenTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors { get; } = [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1)];
        public QueenTilesGenerator(IBoardHolder boardHolder) : base(boardHolder) { }
        public override bool AppliesTo(Piece piece) => piece is Queen;
    }
}
