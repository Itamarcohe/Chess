using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class PawnPromotionMovement : Movement
    {
        public char PromotionPieceSymbol { get; private set; }
        public PawnPromotionMovement(Tile from, Tile to, char promotionPiece) : base(from, to)
        {
            PromotionPieceSymbol = promotionPiece;
        }
    }
}
