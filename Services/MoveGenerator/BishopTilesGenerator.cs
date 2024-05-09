using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services.MoveGenerator
{
    public class BishopTilesGenerator : BaseTileGenerator
    {
        private (int, int)[] AllVectors;
        public override (int, int)[] MoveVectors => AllVectors;
        public BishopTilesGenerator()
        {
            AllVectors = GetVectors();
        }
        private (int, int)[] GetVectors()
        {
            var initial = new[]
            {
                (1, 1),  // Up-right diagonal
                (-1, 1), // Up-left diagonal
                (1, -1), // Down-right diagonal
                (-1, -1) // Down-left diagonal
            };
            (int, int)[] vectors = new (int, int)[28];
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
            return piece is Bishop;
        }
    }
}
