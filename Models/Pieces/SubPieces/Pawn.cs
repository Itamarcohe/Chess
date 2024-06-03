using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class Pawn : Piece
    {
        public Pawn(Pawn otherpiece) : base(otherpiece) { }
        public Pawn(Pawn otherPiece, Tile newTilePosition) : base(otherPiece, newTilePosition) { }
        public Pawn(Color color, Tile tilePosition) : base(color, tilePosition) { }
        protected override char GetSymbolInternal() => 'p';

    }
}
