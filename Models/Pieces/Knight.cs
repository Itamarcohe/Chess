using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Knight(Knight otherpiece) : base(otherpiece)
        {
        }

        protected override char GetInternalSymbol() => 'n';
    }
}
