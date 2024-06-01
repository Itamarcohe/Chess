using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services.MoveComposite
{
    public class PawnPromotionMoveLogic : IMoveLogic
    {
        private readonly IPieceFactory pieceFactory;
        public PawnPromotionMoveLogic(IPieceFactory pieceFactory)
        {
            this.pieceFactory = pieceFactory;
        }
        public bool ShouldApplyMove(Movement movement)
        {
            return movement is PawnPromotionMovement;
        }
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            return CreateNewBoard(board, movement);
        }
        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {
            var newPieces = board.Pieces
                                 .Select(piece => TransformPieceForNewBoard(piece, movement, board))
                                 .ToList();
            var newTurnColor = board.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            return new Board(newPieces, newTurnColor);
        }
        private Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                var promotionPieceSymbol = ((PawnPromotionMovement)movement).PromotionPieceSymbol;
                return pieceFactory.CreatePieceColor(promotionPieceSymbol, movement.To, board.CurrentTurnColor);
            }
            return pieceFactory.CreatePiece(piece);
        }
    }
}
