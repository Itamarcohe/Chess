using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
    public class AttackMovement : Movement
    {
        public AttackMovement(Tile from, Tile to) : base(from, to) { }
    }
}
