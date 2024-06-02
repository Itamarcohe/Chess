using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services.MoveComposite
{
    public class AttackMoveLogic : IMoveLogic
    {
        private readonly IPieceFactory pieceFactory;
        public AttackMoveLogic(IPieceFactory pieceFactory)
        {
            this.pieceFactory = pieceFactory;
        }
        public bool ShouldApplyMove(Movement movement)
        {
            return movement is AttackMovement;
        }
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            return CreateNewBoard(board, movement);
        }
        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {
            var newTurnColor = board.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            var newPieces = board.Pieces
                                 .Where(piece => !piece.TilePosition.Equals(movement.From))
                                 .Select(piece => TransformPieceForNewBoard(piece, movement, board))
                                 .ToList();
            return new Board(newPieces, newTurnColor);
        }
        private Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.To))
            {
                var fromPiece = board.GetPieceByTilePosition(movement.From);
                return pieceFactory.CreatePieceColor(fromPiece!.GetSymbol(), movement.To, fromPiece.Color);
            }
           
            return pieceFactory.CreatePiece(piece);
        }
    }
}
