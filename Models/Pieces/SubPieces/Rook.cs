using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Rook : Piece
    {
        public Rook(Rook otherpiece) : base(otherpiece) { }
        public Rook(Rook otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public Rook(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'r';
    }
}
