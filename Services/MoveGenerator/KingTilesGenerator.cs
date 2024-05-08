using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerator
{
    public class KingTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors => throw new NotImplementedException();
        public override bool AppliesTo(Piece piece)
        {
            return piece is King;
        }
    }
}



