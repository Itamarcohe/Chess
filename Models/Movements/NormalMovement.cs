using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
    public class NormalMovement : Movement
    {
        public NormalMovement(Tile from, Tile to) : base(from, to) { }
    }
}
