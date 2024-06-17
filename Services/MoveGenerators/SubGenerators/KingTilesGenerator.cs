using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KingTilesGenerator : BaseTileGenerator
    {
        public override bool AppliesTo(Piece piece) => piece is King;
        protected override (int, int)[] GetMoveVectors(Color color)
        {
            return [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1), (2, 0), (-2, 0)];
        }

    }
}


