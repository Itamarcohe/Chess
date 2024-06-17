using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Bishop : Piece
    {
        public Bishop(Bishop otherpiece) : base(otherpiece) { }
        public Bishop(Bishop otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public Bishop(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'b'; 
    }
}
