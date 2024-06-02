using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Tile tilePosition) : base(color, tilePosition) { }
        public Queen(Queen otherpiece) : base(otherpiece) { }
        protected override char GetSymbolInternal() => 'q';

    }
}
