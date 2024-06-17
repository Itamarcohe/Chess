using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class PawnTilesGenerator : BaseTileGenerator
    {
        private readonly (int, int)[] WhitePawnInitialMoves = new[] { (0, 1), (-1, 1), (1, 1), (0, 2) };
        private readonly (int, int)[] BlackPawnInitialMoves = new[] { (0, -1), (-1, -1), (1, -1), (0, -2) };
        public override bool AppliesTo(Piece piece) => piece is Pawn;
        protected override (int, int)[] GetMoveVectors(Color color)
        {
            return (color == Color.White ? WhitePawnInitialMoves : BlackPawnInitialMoves);
        }
    }
}

