using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class AttackMovement : Movement
    {
        public AttackMovement(Tile from, Tile to) : base(from, to) { }
    }
}
