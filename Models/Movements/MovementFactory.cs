using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
    public class MovementFactory
    {
        public MovementFactory() { }
        public Movement CreateMovement(Tile from, Tile to, IBoard _board, char? promotion = null)
        {
            var gamePiece = _board.GetPieceByTilePosition(from);
            if (gamePiece == null)
            {
                throw new InvalidOperationException("No piece at the starting position.");
            }
            var targetPiece = _board.GetPieceByTilePosition(to);
            if (targetPiece != null && targetPiece!.Color != gamePiece!.Color)
            {
                return new AttackMovement(from, to);
            }
            if (promotion != null && gamePiece is Pawn && (to.Row == 7 || to.Row == 0))
            {
                return new PawnPromotionMovement(from, to, promotion.Value);
            }
            if (gamePiece is King) 
            {
                if ((to.Column - from.Column) == 2)
                {
                    return new KingCastlingMovement(from, to, (King)gamePiece);
                }
                if ((from.Column - to.Column) == 2) 
                {
                    return new QueenCastlingMovement(from, to, (King)gamePiece);
                }
            }
            return new NormalMovement(from, to);
        }
    }
}
        