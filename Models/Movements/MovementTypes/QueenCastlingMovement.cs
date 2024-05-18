using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class QueenCastlingMovement : CastlingBaseMovement
    {
        public QueenCastlingMovement(Tile from, Tile to, King kingTomove) : base(from, to, kingTomove) { }
    }
}

