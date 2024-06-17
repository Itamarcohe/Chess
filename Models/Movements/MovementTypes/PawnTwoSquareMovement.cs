using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.MoveComposite;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class PawnTwoSquareMovement : Movement
    {
        public bool HasSkippedCapture { get; private set; }
        public PawnTwoSquareMovement(Tile from, Tile to, bool hasSkippedCapture) : base(from, to)
        {
            HasSkippedCapture = hasSkippedCapture;
        }
    }
}
