using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Queen : Piece
    {
        public Queen(Queen otherpiece) : base(otherpiece) { }
        public Queen(Queen otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public Queen(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'q';

    }
}
