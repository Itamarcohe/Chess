using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Queen : Piece
    {
        public override Color Color { get; }

        public override Tile? TilePosition { get; set; }

    }
}
