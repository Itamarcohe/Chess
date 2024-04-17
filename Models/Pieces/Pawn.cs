using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Pawn : Piece
    {
        public override Color Color { get; }

        public override Tile TilePosition { get; set; }
    }
}
