using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.Validators
{
    public class KnightMovementValidator : IPieceMovementValidator
    {
        public bool AppliesTo(Piece piece)
        {
            return piece is Knight;
        }

        public bool IsMoveValid(Piece piece, Tile to, IBoard board)
        {
            int dx = Math.Abs(to.Column - piece.TilePosition.Column);
            int dy = Math.Abs(to.Row - piece.TilePosition.Row);
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
        public List<Tile> GetPossibleMoves(Piece piece, IBoard board)
        {
            var moves = new List<Tile>();
            int[] xMoves = { 2, 2, -2, -2, 1, 1, -1, -1 };
            int[] yMoves = { 1, -1, 1, -1, 2, -2, 2, -2 };

            for (int i = 0; i < 8; i++)
            {
                int newX = piece.TilePosition.Column + xMoves[i];
                int newY = piece.TilePosition.Row + yMoves[i];
                Tile newTile = new Tile(newX, newY);
                if (board.GetPieceByTilePosition(newTile) == null || board.GetPieceByTilePosition(newTile)!.Color != piece.Color)
                {
                    if (IsMoveValid(piece, newTile, board))
                    {
                        moves.Add(newTile);
                    }
                }
            }

            return moves;

        }

    }

}

