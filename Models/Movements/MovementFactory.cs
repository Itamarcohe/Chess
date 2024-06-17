using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
    public class MovementFactory
    {
        public MovementFactory() { }
        public Movement CreateMovement(Tile from, Tile to, IBoard board, char? promotion = null)
        {
            var gamePiece = board.GetPieceByTilePosition(from) ?? throw new InvalidOperationException("No piece at the starting position.");
            var targetPiece = board.GetPieceByTilePosition(to);

            if (gamePiece is Pawn && targetPiece == null && from.Column != to.Column)
            {
                return new EnPassantMovement(from, to);
            }

            if (gamePiece is Pawn && Math.Abs(from.Row - to.Row) == 2)
            {
                int[] colsToCheck = [1, -1];
                bool hasSkippedCapture = false;
                foreach ( var col in colsToCheck )
                {
                   if (board.GetPieceByTilePosition(from.Column + col, to.Row) is Pawn pawn && pawn.Color != gamePiece.Color)
                    {
                        hasSkippedCapture = true;
                    }
                }
                return new PawnTwoSquareMovement(from, to, hasSkippedCapture);
            }

            if (targetPiece != null && targetPiece!.Color != gamePiece!.Color && promotion == null)
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
        