using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Knight : Piece
    {
        public Knight(Knight otherpiece) : base(otherpiece) { }
        public Knight(Knight otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public Knight(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'n';
    }
}
