using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Bishop(Bishop otherpiece) : base(otherpiece) { }
        protected override char GetSymbolInternal() => 'b'; 
    }
}
