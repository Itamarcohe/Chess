using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Tile tilePosition, bool hasMoved = false) : base(color, tilePosition, hasMoved) { }
        public Rook(Rook otherpiece) : base(otherpiece) { }
        protected override char GetSymbolInternal() => 'r';
    }
}
