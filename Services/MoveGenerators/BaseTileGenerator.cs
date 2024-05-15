using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators
{
    public abstract class BaseTileGenerator : IMoveToTilesGenerator
    {
        protected BaseTileGenerator(IBoardHolder boardHolder)
        {
            this.boardHolder = boardHolder;
        }
        public abstract (int, int)[] MoveVectors { get; }
        public IBoardHolder boardHolder { get; }

        public IBoard? board;
        public abstract bool AppliesTo(Piece piece);

        public virtual List<Tile> GetPossibleMoves(Piece piece)
        {
            board = boardHolder.GetBoard();
            var moves = new List<Tile>();

            bool isSlidingPiece = piece is Queen || piece is Rook || piece is Bishop;  // Determine if piece slides

            foreach (var (dx, dy) in MoveVectors)
            {
                int newX = piece.TilePosition.Column;
                int newY = piece.TilePosition.Row;
                do
                {
                    newX += dx;
                    newY += dy;

                    if (!BoardUtils.IsWithinBoardBounds(newX, newY))
                    {
                        break;
                    }

                    Tile newTile = new Tile(newX, newY);
                    Piece? occupyingPiece = board.GetPieceByTilePosition(newX, newY);

                    if (occupyingPiece == null)
                    {
                        moves.Add(newTile);
                    }
                    else
                    {
                        if (occupyingPiece.Color != piece.Color) // Capture possible
                        {
                            moves.Add(newTile);
                        }
                        break; // Stop extending in this direction upon hitting any piece
                    }
                } while (isSlidingPiece);
            }

            return moves;
        }


    }
}
