using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces.SubPieces;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public abstract class CastlingBaseMovement : Movement
    {
        public King KingToMove { get; }
        public CastlingBaseMovement(Tile from, Tile to, King kingTomove) : base(from, to)
        {
            KingToMove = kingTomove;
        }
    }
}
