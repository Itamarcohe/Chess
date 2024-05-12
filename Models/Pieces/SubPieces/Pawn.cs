using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Tile tilePosition, bool hasMoved = false) : base(color, tilePosition, hasMoved) { }
        public Pawn(Pawn otherpiece) : base(otherpiece)
        {
        }

        protected override char GetInternalSymbol() => 'p';

    }
}
