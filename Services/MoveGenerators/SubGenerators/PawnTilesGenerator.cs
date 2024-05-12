using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class PawnTilesGenerator : BaseTileGenerator
    {

        private readonly (int, int)[] WhitePawnInitialMoves = new[] { (0, 2), (0, 1), (-1, 1), (1, 1) };
        private readonly (int, int)[] BlackPawnInitialMoves = new[] { (0, -2), (0, -1), (-1, -1), (1, -1) };

        private readonly (int, int)[] WhitePawnStandardMoves = new[] { (0, 1), (-1, 1), (1, 1) };
        private readonly (int, int)[] BlackPawnStandardMoves = new[] { (0, -1), (-1, -1), (1, -1) };
        public override (int, int)[] MoveVectors => Array.Empty<(int, int)>();

        public override bool AppliesTo(Piece piece)
        {
            return piece is Pawn;
        }

        public override List<Tile> GetPossibleMoves(Piece piece)
        {
            var moves = new List<Tile>();
            (int, int)[] moveVectors;
            if (piece.Color == Color.White)
            {
                moveVectors = piece.HasMoved ? WhitePawnStandardMoves : WhitePawnInitialMoves;
            }
            else
            {
                moveVectors = piece.HasMoved ? BlackPawnStandardMoves : BlackPawnInitialMoves;
            }

            foreach (var moveVector in moveVectors)
            {
                int newX = piece.TilePosition.Column + moveVector.Item1;
                int newY = piece.TilePosition.Row + moveVector.Item2;
                if (BoardUtils.IsWithinBoardBounds(newX, newY))
                {
                    Tile newTile = new Tile(newX, newY);
                    moves.Add(newTile);
                }
            }

            return moves;
        }
    }
}

