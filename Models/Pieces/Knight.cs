using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class Knight : Piece
    {
        public override Color Color { get; }

        public override Tile? TilePosition { get; set; }

    }
}
