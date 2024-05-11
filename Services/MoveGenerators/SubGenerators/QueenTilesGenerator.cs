using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class QueenTilesGenerator : BaseTileGenerator
    {
        private (int, int)[] AllVectors;
        public override (int, int)[] MoveVectors => AllVectors;
        public QueenTilesGenerator()
        {
            AllVectors = GetVectors();
        }
        private (int, int)[] GetVectors()
        {
            var initial = new[]
            {
                (1, 0),  // Right
                (-1, 0), // Left
                (0, 1),  // Up
                (0, -1), // Down
                (1, 1),  // Up-right diagonal
                (-1, 1), // Up-left diagonal
                (1, -1), // Down-right diagonal
                (-1, -1) // Down-left diagonal
            };
            (int, int)[] vectors = new (int, int)[56];
            int index = 0;
            foreach (var vector in initial)
            {
                vectors[index++] = vector;
                for (int j = 2; j <= 7; j++)
                {
                    vectors[index++] = (vector.Item1 * j, vector.Item2 * j);
                }
            }

            return vectors;
        }

        public override bool AppliesTo(Piece piece)
        {
            return piece is Queen;
        }
    }
}
