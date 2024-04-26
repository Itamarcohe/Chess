using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
    public class MovementFactory
    {
        private readonly Board _board;

        public MovementFactory(Board board)
        {
            _board = board;
        }


        public Movement CreateMovement(Tile from, Tile to)
        {
            var gamePiece = _board.GetPieceByTilePosition(from);

            if (gamePiece == null)
            {
                throw new InvalidOperationException("No piece at the starting position.");
            }

            var targetPiece = _board.GetPieceByTilePosition(to);

            // checking if the To (tile) contains a piece means its a attack (capture attempt)

            if (targetPiece != null && targetPiece!.Color != gamePiece!.Color)
            {
                // attack
                return new AttackMovement(from, to);
            }


            // checking for Pawn Promotion

            if (gamePiece is Pawn && (to.Row == 7 || to.Row == 0))
            {
                // default promoting to queen for now
               return new PawnPromotionMovement(from, to, Queen);
            }


            // Castling (simplified logic)
            if (gamePiece is King && (Math.Abs(to.Column - from.Column) == 2))
            {
                 return new CastlingMovement(from, to, gamePiece.Color);
            }

            // Default to Normal Movement if none of the special conditions are met
            return new NormalMovement(from, to);


        }
    }
}
        