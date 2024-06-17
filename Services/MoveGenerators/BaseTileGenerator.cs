using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators
{
    public abstract class BaseTileGenerator : IMoveToTilesGenerator
    {
        protected abstract (int, int)[] GetMoveVectors(Color color);
        public abstract bool AppliesTo(Piece piece);
        public List<Tile> GetPossibleMoves(Piece piece, IBoard board)
        {
            var moves = new List<Tile>();
            foreach (var (dx, dy) in GetMoveVectors(piece.Color))
            {
                int newX = piece.TilePosition.Column + dx;
                int newY = piece.TilePosition.Row + dy;
                if (BoardUtils.IsWithinBoardBounds(newX, newY))
                {
                    Tile newTile = new Tile(newX, newY);
                    Piece? occupyingPiece = board.GetPieceByTilePosition(newTile);
                    if (occupyingPiece == null)
                    {
                        moves.Add(newTile);
                    }
                    else if (occupyingPiece.Color != piece.Color)
                    {
                        moves.Add(newTile);
                    }
                }
            }
            return moves;
        }
    }
}
