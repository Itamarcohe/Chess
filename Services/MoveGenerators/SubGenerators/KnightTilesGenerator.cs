using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KnightTilesGenerator : BaseTileGenerator
    {
        public override bool AppliesTo(Piece piece) => piece is Knight;
        protected override (int, int)[] GetMoveVectors(Color color)
        {
            return [(2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)];
        }
    }
}
