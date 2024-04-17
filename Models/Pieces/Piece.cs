using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public abstract class Piece
    {

        public abstract Color Color { get; }
        public abstract Tile TilePosition { get; set; }

        protected Piece()
        {
            
        }

    }
}
