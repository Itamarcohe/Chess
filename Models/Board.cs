using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using System.Numerics;

namespace Chess_Backend.Models
{
    public class Board : Iboard
    {
        public List<Piece>? whitePieces { get ; }
        public List<Piece>? blackPieces { get; }


        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece GetPieceByTilePosition(Tile tile)
        {
            if (tile.Row < 0 || tile.Row >= 8 || tile.Column < 0 || tile.Column >= 8)
            {
                throw new ArgumentOutOfRangeException("Coordinates are outside of the board boundaries.");
            }

            return pieces[tile.Row, tile.Column];

        }

        public bool IsTileOccupied(int row, int column)
        {
            if (row < 0 || row >= 8 || column < 0 || column >= 8)
            {
                throw new ArgumentOutOfRangeException("Coordinates are outside of the board boundaries.");
            }

            return pieces[row, column] != null;
        }


    }
}
