using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Models.Movements
{
    public class CastlingMovement : Movement
    {
        public Color PlayerColor { get; private set; }
        public CastlingMovement(Tile from, Tile to, Color playerColor) : base(from, to)
        {
            PlayerColor = playerColor;
        }
    }
}
