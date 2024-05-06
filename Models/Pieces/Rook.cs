using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Rook(Rook otherpiece) : base(otherpiece)
        {
        }

        protected override char GetInternalSymbol() => 'r';
    }
}
