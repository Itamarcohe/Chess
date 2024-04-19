using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using System.Numerics;

namespace Chess_Backend.Models
{
    public class Board : Iboard
    {
        public List<Piece>? whitePieces { get ; }
        public List<Piece>? blackPieces { get; }


        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Tile tile]
        {
            get { return this[tile.x, tile.y]; }
            set { this[tile.x, tile.y] = value; }
        }


        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece GetPieceByTilePosition(Tile tile)
        {
            if (tile.x < 0 || tile.x >= 8 || tile.y < 0 || tile.y >= 8)
            {
                throw new ArgumentOutOfRangeException("Coordinates are outside of the board boundaries.");
            }

            return pieces[tile.x, tile.y];

        }

        public bool IsTileOccupied(int x, int y)
        {
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                throw new ArgumentOutOfRangeException("Coordinates are outside of the board boundaries.");
            }

            return pieces[x, y] != null;
        }


    }
}
