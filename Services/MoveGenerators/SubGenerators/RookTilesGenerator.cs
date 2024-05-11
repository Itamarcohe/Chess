using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;
using System.IO.Pipelines;
using System.Xml.Linq;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class RookTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors => GetVectors();
        private (int, int)[] AllVectors;
        public RookTilesGenerator()
        {
            AllVectors = GetVectors();
        }
        private (int, int)[] GetVectors()
        {
            var initial = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            (int, int)[] vectors = new (int, int)[28];
            int index = 0;
            foreach (var vector in initial)
            {
                vectors[index++] = vector;
            }
            foreach (var (xDir, yDir) in initial)
            {
                for (int j = 2; j <= 7; j++)
                {
                    if (xDir != 0)
                        vectors[index++] = (xDir * j, 0);
                    else
                        vectors[index++] = (0, yDir * j);
                }
            }
            return vectors;
        }
        public override bool AppliesTo(Piece piece)
        {
            return piece is Rook;
        }
    }
}
