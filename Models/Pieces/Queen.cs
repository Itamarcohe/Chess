using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Queen(Queen otherpiece) : base(otherpiece)
        {
        }

        protected override char GetInternalSymbol() => 'q';

    }
}
