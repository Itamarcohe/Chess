using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class King : Piece
    {
        public King(King otherpiece) : base(otherpiece) { }
        public King(King otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public King(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'k';
    }
}
