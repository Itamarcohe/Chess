using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Pawn(Pawn otherpiece) : base(otherpiece)
        {
        }

        protected override char GetInternalSymbol() => 'p';

    }
}
