using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public abstract class Piece
    {

        public Color Color { get; private set; }
        public Tile TilePosition { get; private set; }

        protected Piece(Color color, Tile tilePosition)
        {
            Color = color;
            TilePosition = tilePosition;
        }

    }
}
