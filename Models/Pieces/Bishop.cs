using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetInternalSymbol() => 'b'; // lowercase 'b' for bishop
    }
}
