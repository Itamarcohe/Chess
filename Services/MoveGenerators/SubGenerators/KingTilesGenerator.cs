using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KingTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors { get; } =
            [
                (1, 0),  // Right
                (-1, 0), // Left
                (0, 1),  // Up
                (0, -1), // Down
                (1, 1),  // Up-right diagonal
                (-1, 1), // Up-left diagonal
                (1, -1), // Down-right diagonal
                (-1, -1) // Down-left diagonal
            ];
        public override bool AppliesTo(Piece piece)
        {
            return piece is King;
        }
    }
}



