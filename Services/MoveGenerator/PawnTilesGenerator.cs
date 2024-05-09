using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerator
{
    public class PawnTilesGenerator : BaseTileGenerator
    {

        private (int, int)[] WhitePawnMoves = new[] { (0, 1), (-1, 1), (1, 1) };
        private (int, int)[] BlackPawnMoves = new[] { (0, -1), (-1, -1), (1, -1) };
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
                moveVectors = WhitePawnMoves;
                //if (!piece.HasMoved)
                //{
                //    moveVectors[3] = (0, 2);
                //}

            }
            else
            {
                moveVectors = BlackPawnMoves;
                //if (!piece.HasMoved)
                //{
                //    moveVectors[3] = (0, -2);
                //}

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

