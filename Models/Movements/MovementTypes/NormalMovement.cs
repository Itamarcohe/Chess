using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class NormalMovement : Movement
    {
        public NormalMovement(Tile from, Tile to) : base(from, to) { }
    }
}
