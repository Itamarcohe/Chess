using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators
{
    public abstract class BaseSlidingTilesGenerator : IMoveToTilesGenerator
    {
        public abstract (int, int)[] MoveVectors { get; }
        public abstract bool AppliesTo(Piece piece);
        public virtual List<Tile> GetPossibleMoves(Piece piece, IBoard board)
        {
            var moves = new List<Tile>();
            foreach (var (dx, dy) in MoveVectors)
            {
                int newX = piece.TilePosition.Column;
                int newY = piece.TilePosition.Row;
                while (true)
                {
                    newX += dx;
                    newY += dy;
                    if (!BoardUtils.IsWithinBoardBounds(newX, newY))
                    {
                        break;
                    }
                    Tile newTile = new Tile(newX, newY);
                    Piece? occupyingPiece = board.GetPieceByTilePosition(newTile);
                    if (occupyingPiece == null)
                    {
                        moves.Add(newTile);
                    }
                    else
                    {
                        if (occupyingPiece.Color != piece.Color)
                        {
                            moves.Add(newTile);
                        }
                        break;
                    }
                }
            }
            return moves;
        }

    }
}
