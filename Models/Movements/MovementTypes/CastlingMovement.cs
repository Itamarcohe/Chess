using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class CastlingMovement : Movement
    {
        public CastlingMovement(Tile from, Tile to) : base(from, to)
        {
        }
    }
}
